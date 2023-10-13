using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.SponsorModels;

namespace CSS.Application.ViewModels.ProposalSponsorModels;
public class ProposalSponsorViewModel
{
    public Guid Id { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid SponsorId { get; set; } = default!;
    public SponsorViewModel Sponsor { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public ProposalViewModel Proposal { get; set; } = default!;
}