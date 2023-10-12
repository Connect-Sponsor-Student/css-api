namespace CSS.Application.ViewModels.FeedbackModels;
public class FeedbackCreateModel
{
    public string Description { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
}