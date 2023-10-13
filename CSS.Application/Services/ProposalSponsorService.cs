using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ProposalSponsorModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services;
public class ProposalSponsorService : IProposalSponsorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimsService _claimsService;
    public ProposalSponsorService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }
    public async Task<ProposalSponsorViewModel> CreateAsync(ProposalSponsorCreateModel model)
    {
        var proposalSponsor = _mapper.Map<ProposalSponsor>(model);
        var sponsorId = _claimsService.GetCurrentUser == Guid.Empty 
            ? throw new Exception($"--> error: CurrentUser is empty")
            : _claimsService.GetCurrentUser;
        proposalSponsor.SponsorId = sponsorId;
        await _unitOfWork.ProposalSponsorRepository.AddAsync(proposalSponsor);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProposalSponsorViewModel>(proposalSponsor); 

    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var prop = await _unitOfWork.ProposalSponsorRepository.GetByIdAsync(id);
        if(prop is not null)
        {
            _unitOfWork.ProposalSponsorRepository.SoftRemove(prop);
            return await _unitOfWork.SaveChangesAsync();
        } else throw new Exception($"--> error: Not found proposal-sponsor with Id: {id}");
    }

    public async Task<IEnumerable<ProposalSponsorViewModel>> GetByProposalAsync(Guid Id)
    {
        return _mapper.Map<IEnumerable<ProposalSponsorViewModel>>(await _unitOfWork.ProposalSponsorRepository.FindListByField(x => x.ProposalId == Id, x => x.Proposal));
    }

    public async Task<IEnumerable<ProposalSponsorViewModel>> GetBySponsorAsync()
    {
        var sponsorId = _claimsService.GetCurrentUser == Guid.Empty 
            ? throw new Exception($"--> error: CurrentUser is empty")
            : _claimsService.GetCurrentUser;
        return _mapper.Map<IEnumerable<ProposalSponsorViewModel>>(await _unitOfWork.ProposalSponsorRepository.FindListByField(x => x.SponsorId == sponsorId, x => x.Proposal));
    }
}