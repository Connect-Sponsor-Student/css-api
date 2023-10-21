using CSS.Application.ViewModels.AdminModels;

namespace CSS.Application.ViewModels.FeedbackModels;
public class FeedbackViewModel
{
    public Guid Id { get; set; } = default!;
    public string Description { get; set; } = default!;
    public AdminViewModel Admin { get; set; } = default!;
}