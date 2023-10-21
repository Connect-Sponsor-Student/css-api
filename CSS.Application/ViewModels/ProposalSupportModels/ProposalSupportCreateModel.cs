using System.Diagnostics;

namespace CSS.Application.ViewModels.ProposalServiceModels;
public class ProposalSupportCreateModel
{
    public string Title { get; set; } = default!;
    public Guid SupportTypeId { get; set; } = default!;
}