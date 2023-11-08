using System.Runtime.InteropServices;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalServiceModels;
using CSS.Domains.Entities;
using CSS.Domains.Enums;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace CSS.Application.Services;
public class ProposalSupportService : IProposalSupportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProposalSupportService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ProposalSupportViewModel> CreateAsync(ProposalSupportCreateModel model, Guid proposalId)
    {
        var propSupport = _mapper.Map<ProposalSupport>(model);
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId) ?? throw new Exception($"Not found proposal with Id: {proposalId}");
        propSupport.ProposalId = proposalId;
        await _unitOfWork.ProposalSupportRespository.AddAsync(propSupport);
        if (await _unitOfWork.SaveChangesAsync())
        {
            var service = await _unitOfWork.SupportTypeRepository.GetByIdAsync(propSupport.SupportTypeId) ?? throw new Exception($"Not found Service Type with Id: {propSupport.SupportTypeId}");
            if(service.Name == "AdminFeedback")
            {
                proposal.ServiceType = (int)ServiceTypeEnum.Vip;
                proposal.Status = nameof(ProposalStatusEnum.WaitingFeedback); 
            } else if(service.Name == "FullService")
            {
                proposal.ServiceType = (int)ServiceTypeEnum.VVip;
                proposal.Status = nameof(ProposalStatusEnum.WaitingFeedback);
            }
            _unitOfWork.ProposalRepository.Update(proposal);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProposalSupportViewModel>(propSupport);
        }
        else
        {
            throw new Exception($"--> error: Create ProposalSupport Failed! Id: {propSupport.Id}");
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var prop = await _unitOfWork.ProposalSupportRespository.GetByIdAsync(id) ?? 
        throw new Exception($"--> error: Could not delete! Not found ProposalSupports with Id: {id}");
        _unitOfWork.ProposalSupportRespository.SoftRemove(prop);
        return await _unitOfWork.SaveChangesAsync();
    }

    public Task<ProposalSupportViewModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProposalSupportViewModel>> GetByProposalAsync(Guid proposalId)
    {
        return _mapper.Map<IEnumerable<ProposalSupportViewModel>>(await _unitOfWork.ProposalSupportRespository.FindListByField(x => x.ProposalId == proposalId, x => x.SupportType, x => x.Proposal));
    }
}