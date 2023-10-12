using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.FeedbackModels;
using CSS.Domains.Entities;
using CSS.Domains.Enums;

namespace CSS.Application.Services;
public class FeedbackService : IFeedbackService
{
    private readonly IUnitOfWork _uniOfWork;
    private readonly IClaimsService _claimsService;
    private readonly IMapper _mapper;
    public FeedbackService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
    {
        _mapper = mapper;
        _claimsService = claimsService;
        _uniOfWork = unitOfWork;
    }
    public async Task<FeedbackViewModel> CreateAsync(FeedbackCreateModel model)
    {
        var feedback = _mapper.Map<FeedBack>(model);
        var adminId = _claimsService.GetCurrentUser == Guid.Empty ? throw new Exception($"--> Error: Login User not have Id: {_claimsService.GetCurrentUser}")
        : _claimsService.GetCurrentUser;
        var admin = await _uniOfWork.AdminRepository.GetByIdAsync(adminId) ?? throw new Exception($"--> Error: Not found Admin with Id: {adminId}"); 
        if(!admin.IsBussinessAdmin) throw new Exception($"--> Error: Admin doest not have permission to create feedback!");
        feedback.AdminId = admin.Id;

        var proposal = await _uniOfWork.ProposalRepository.GetByIdAsync(feedback.ProposalId) ?? throw new Exception($"--> Error: Not found Proposal with Id: {feedback.ProposalId}");
        if(proposal.ServiceType < (int) ServiceTypeEnum.Vip)
        {
            throw new Exception($"--> Error: ServiceType is FREE!");
        }

        await _uniOfWork.FeedBackRepository.AddAsync(feedback);
        return await _uniOfWork.SaveChangesAsync() ? _mapper.Map<FeedbackViewModel>(await _uniOfWork.FeedBackRepository.GetByIdAsync(feedback.Id)) 
            : throw new Exception($"--> Error: Save Change Failed!");


    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FeedbackViewModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<FeedbackViewModel>>(await _uniOfWork.FeedBackRepository.GetAllAsync(x => x.Admin));
    }

    public async Task<FeedbackViewModel> GetByIdAsync(Guid id)
    {
        return _mapper.Map<FeedbackViewModel>(await _uniOfWork.FeedBackRepository.GetByIdAsync(id, x => x.Admin));
    }

    public async Task<IEnumerable<FeedbackViewModel>> GetByProposalAsync(Guid proposalId)
    {
        var fbList = await _uniOfWork.FeedBackRepository.FindListByField(x => x.ProposalId == proposalId, x => x.Admin);
        if(fbList is not null)
        {
            if(fbList.Count() > 0) return _mapper.Map<IEnumerable<FeedbackViewModel>>(fbList);
        }
        
        throw new Exception($"--> Error: Not Found Any Feedback with ProposalId: {proposalId}");
    }

    public Task<bool> UpdateAsync(FeeedbackUpdateModel model)
    {
        throw new NotImplementedException();
    }
}