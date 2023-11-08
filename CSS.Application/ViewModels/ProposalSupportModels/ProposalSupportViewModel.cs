using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ServiceModels;

namespace CSS.Application.ViewModels.ProposalServiceModels;
public class ProposalSupportViewModel
{
    public Guid Id { get; set; } = default!;
    public ProposalViewModel ProposalViewModel { get; set; } = default!;
    public SupportTypeViewModel SupportType { get; set; } = default!;

}