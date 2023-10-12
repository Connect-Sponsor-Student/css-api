using CSS.Application.ViewModels.ProposalModels;

namespace CSS.Application.Services.Interfaces;
public interface IProposalService
{
    Task<IEnumerable<ProposalViewModel>> GetAllAsync();
    Task<ProposalViewModel> CreateAsync(ProposalCreateModel model);
    Task<bool> UpdateAsync(ProposalUpdateModel model);
    Task<ProposalViewModel> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
}