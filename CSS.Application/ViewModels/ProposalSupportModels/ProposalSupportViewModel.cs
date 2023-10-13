using CSS.Application.ViewModels.ProposalModels;

namespace CSS.Application.ViewModels.ProposalServiceModels;
public class ProposalSupportViewModel
{
    public Guid Id { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ProposalViewModel ProposalViewModel {get; set;} = default!;
    
}