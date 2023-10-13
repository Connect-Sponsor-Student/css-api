using System.Diagnostics;

namespace CSS.Application.ViewModels.ProposalServiceModels;
public class ProposalSupportCreateModel
{
    public decimal Amount { get; set; } = default!;
    public string Title { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
}