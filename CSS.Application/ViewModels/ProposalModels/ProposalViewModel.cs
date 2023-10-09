using CSS.Application.ViewModels.ProposalFileModels;

namespace CSS.Application.ViewModels.ProposalModels;
public class ProposalViewModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Status { get; set; } = default!;
    public ICollection<ProposalFileViewModel> ProposalFiles {get; set;} = default!;


}