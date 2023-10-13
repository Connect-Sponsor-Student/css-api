using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.InvestmentModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services;
public class InvestmentService : IInvestmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimsService _claimsService;
    public InvestmentService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
    {
        _mapper = mapper;
        _claimsService = claimsService;
        _unitOfWork = unitOfWork;
    }
    public async Task<InvestmentViewModel> CreateAsync(InvestmentCreateModel model)
    {
        var investment = _mapper.Map<Investment>(model);
        var sponsorId = _claimsService.GetCurrentUser == Guid.Empty ? throw new Exception($"--> error: currentUser is null") : _claimsService.GetCurrentUser;
        investment.SponsorId = sponsorId;
        await _unitOfWork.InvestmentRepository.AddAsync(investment);
        if(await _unitOfWork.SaveChangesAsync())
        {
            var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(investment.ProposalId) ?? throw new Exception($"--> err: can not find proposal to update! ProposalId: {investment.ProposalId}");
            proposal.ActualAmount += investment.Amount;
            _unitOfWork.ProposalRepository.Update(proposal);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvestmentViewModel>(await _unitOfWork.InvestmentRepository.GetByIdAsync(investment.Id, x => x.Proposal));
        } else throw new Exception($"--> error: Save changes failed! Create Investment Failed!");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var investment = await _unitOfWork.InvestmentRepository.GetByIdAsync(id) ?? throw new Exception
        ($"--> error: not found Investment with Id:{id}! Delete Failed!");
        _unitOfWork.InvestmentRepository.SoftRemove(investment);
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(investment.ProposalId);
        if(proposal is not null)
        {
            proposal.ActualAmount -= investment.Amount;
            _unitOfWork.ProposalRepository.Update(proposal);
        }

        return await _unitOfWork.SaveChangesAsync();
        
    }

    public async Task<IEnumerable<InvestmentViewModel>> GetAllByProposalAsync(Guid id)
    {
        var result = await _unitOfWork.InvestmentRepository.FindListByField(x => x.ProposalId == id, x => x.Sponsor);
        return result.Any() ? _mapper.Map<IEnumerable<InvestmentViewModel>>(result)
            : throw new Exception($"--> error: Proposal not have any investment yet! ProposalId: {id}");
    }

    public async Task<IEnumerable<InvestmentViewModel>> GetBySponsorAsync()
    {
        var sponsorId = _claimsService.GetCurrentUser == Guid.Empty ? throw new Exception($"--> error: current user is null!") 
            : _claimsService.GetCurrentUser;
        var investmentList = await _unitOfWork.InvestmentRepository.FindListByField(x => x.SponsorId == sponsorId, x => x.Sponsor);
        return investmentList.Any() ? _mapper.Map<IEnumerable<InvestmentViewModel>>(investmentList) 
            : throw new Exception($"--> error: Sponsor not invest to any project! SponsorId : {sponsorId}");
    }
}