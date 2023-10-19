using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.MessageModels;
using CSS.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.Services
{
    public class MessageService:IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        public async Task<MessageReadModel> CreateMessage(MessageCreateModel model)
        {
            var message = _mapper.Map<Message>(model);
            message.UserId = _claimsService.GetCurrentUser;

            var result= await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MessageReadModel>(result);
        }
    }
}
