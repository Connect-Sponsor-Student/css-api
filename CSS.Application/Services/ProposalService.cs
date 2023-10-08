using System.Runtime.CompilerServices;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Domains.Entities;
using CSS.Domains.Enums;

namespace CSS.Application.Services;
public class ProposalService : IProposalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimsService _claimsService;
    public ProposalService(IUnitOfWork unitOfWork, IClaimsService claimsServivce, IMapper mapper)
    {
        _mapper = mapper;
        _claimsService = claimsServivce;
        _unitOfWork = unitOfWork;
    }
    public Task<ProposalViewModel> CreateAsync(ProposalCreateModel model)
    {
        var proposal = _mapper.Map<Proposal>(model);
        proposal.StudentId = _claimsService.GetCurrentUser;
       


    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProposalViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProposalViewModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ProposalViewModel> UpdateAsync(ProposalUpdateModel model)
    {
        throw new NotImplementedException();
    }
}