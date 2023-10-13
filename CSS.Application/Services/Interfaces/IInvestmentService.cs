using CSS.Application.ViewModels.InvestmentModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services.Interfaces;
public interface IInvestmentService
{
    Task<InvestmentViewModel> CreateAsync(InvestmentCreateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<InvestmentViewModel>> GetAllByProposalAsync(Guid id);
    Task<IEnumerable<InvestmentViewModel>> GetBySponsorAsync();

}