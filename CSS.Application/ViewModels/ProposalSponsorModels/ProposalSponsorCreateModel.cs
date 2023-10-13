using System.Runtime.CompilerServices;

namespace CSS.Application.ViewModels.ProposalSponsorModels;
public class ProposalSponsorCreateModel
{
    public string? Description { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
}