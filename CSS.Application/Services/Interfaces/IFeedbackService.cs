using CSS.Application.ViewModels.FeedbackModels;

namespace CSS.Application.Services.Interfaces;
public interface IFeedbackService 
{
    Task<FeedbackViewModel> CreateAsync(FeedbackCreateModel model);
    Task<IEnumerable<FeedbackViewModel>> GetAllAsync();
    Task<IEnumerable<FeedbackViewModel>> GetByProposalAsync(Guid proposalId);
    Task<FeedbackViewModel> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> UpdateAsync(FeeedbackUpdateModel model);
}