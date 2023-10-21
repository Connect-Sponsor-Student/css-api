using CSS.Application.ViewModels.ProposalFileModels;

namespace CSS.Application.ViewModels.ProposalModels;
public class ProposalViewModel
{
    public Guid Id {get;set;} = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double RequireAmount { get; set; } = default!;
    public double ActualAmount { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Status { get; set; } = default!;
    public ICollection<ProposalFileViewModel> ProposalFiles { get; set; } = default!;



}