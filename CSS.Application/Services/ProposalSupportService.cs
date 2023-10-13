using System.Runtime.InteropServices;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalServiceModels;
using CSS.Domains.Entities;

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
        propSupport.ProposalId = proposalId;
        await _unitOfWork.ProposalSupportRespository.AddAsync(propSupport);
        if (await _unitOfWork.SaveChangesAsync())
        {
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
        return _mapper.Map<IEnumerable<ProposalSupportViewModel>>(await _unitOfWork.ProposalSupportRespository.FindListByField(x => x.ProposalId == proposalId, x => x.SupportType));
    }
}