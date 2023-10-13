using System.Diagnostics;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.SponsorModels;

namespace CSS.Application.ViewModels.InvestmentModels;
public class InvestmentViewModel
{
    public Guid Id { get; set; } = default!;
    public double Amount { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public ProposalViewModel Proposal { get; set; } = default!;
    public Guid SponsorId { get; set; } = default!;
    public SponsorViewModel Sponsor { get; set; } = default!;
}