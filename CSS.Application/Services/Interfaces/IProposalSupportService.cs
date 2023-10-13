using CSS.Application.ViewModels.ProposalServiceModels;

namespace CSS.Application.Services.Interfaces;
public interface IProposalSupportService
{
    Task<ProposalSupportViewModel> CreateAsync(ProposalSupportCreateModel model, Guid proposalId);
    Task<IEnumerable<ProposalSupportViewModel>> GetByProposalAsync(Guid proposalId);
    Task<bool> DeleteAsync(Guid id);
    Task<ProposalSupportViewModel> GetByIdAsync(Guid id);
}