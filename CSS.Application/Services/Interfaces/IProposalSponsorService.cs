using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ProposalSponsorModels;

namespace CSS.Application.Services.Interfaces;
public interface IProposalSponsorService
{
    Task<ProposalSponsorViewModel> CreateAsync(ProposalSponsorCreateModel model);
    Task<IEnumerable<ProposalSponsorViewModel>> GetByProposalAsync(Guid Id);
    Task<IEnumerable<ProposalSponsorViewModel>> GetBySponsorAsync();
    Task<bool> DeleteAsync(Guid id);
}