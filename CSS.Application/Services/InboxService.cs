using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.InboxModels;
using CSS.Application.ViewModels.MessageModels;
using CSS.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.Services
{
    public class InboxService : IInboxService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public InboxService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        public async Task<InboxReadModel> CreateInbox(InboxCreateModel model)
        {
            var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(model.ProposalId,x=>x.Student);
            if (proposal == null) throw new Exception("Proposal is not exist!");
            var sponsor = await _unitOfWork.SponsorRepository.GetByIdAsync(_claimsService.GetCurrentUser);
            var inbox = new Inbox { Name = $"{proposal.Name} - {sponsor!.Name}"};
            var result= await _unitOfWork.InboxRepository.AddAsync(inbox);

            await _unitOfWork.InboxParticipantRepository.AddRangeAsync(new List<InboxParticipant>
            {
                new InboxParticipant{InboxId=result.Id,UserId= proposal.StudentId},
                new InboxParticipant{InboxId=result.Id,UserId= _claimsService.GetCurrentUser},
            });

            await _unitOfWork.SaveChangesAsync();
            return new InboxReadModel
            {
                Id = result.Id,
                Name = result.Name,
                Status = "InActive",
                CreationDate=result.CreationDate,
            };
        }

        public async Task<List<MessageReadModel>> GetAllMessageByInboxId(Guid inboxId)
        {
            var messages = await _unitOfWork.MessageRepository.FindListByField(x => x.InboxId == inboxId && x.IsDeleted == false, x => x.User);
            if (messages.Count==0) throw new Exception("There are not message available!");
            return _mapper.Map<List<MessageReadModel>>(messages);
        }

        public async Task<List<InboxReadModel>> GetInboxes()
        {
            var inbox_Participants = await _unitOfWork.InboxParticipantRepository.FindListByField(x => x.UserId == _claimsService.GetCurrentUser && x.IsDeleted == false,x=>x.Inbox);
            if (inbox_Participants.Count == 0) throw new Exception("There are no inboxs available!");
            var result= new List<InboxReadModel>();
            foreach (var item in inbox_Participants)
            {
                var messageList = await _unitOfWork.MessageRepository
                    .FindListByField(x => x.InboxId == item.InboxId && x.IsDeleted == false, x => x.User);
                var message = messageList.Count > 0 ? messageList.MaxBy(x => x.CreationDate) : null;
                result.Add(new InboxReadModel {
                    Id = item.Id,
                    Name = item.Inbox.Name,
                    Status = message == null ? "InActive": message.User.Status,
                    CreationDate = item.CreationDate,
                    Message = message==null? null : _mapper.Map<MessageReadModel>(message)
                });
            }
            return result;
        }

    }
}
