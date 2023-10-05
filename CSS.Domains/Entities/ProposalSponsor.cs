namespace CSS.Domains.Entities;
public class ProposalSponsor : BaseEntity
{
    public string Description { get; set; } = "";
    public decimal Amount { get; set; } = default!;
    public bool IsDone { get; set; } = default!;
    public double Percentage { get; set; } = 0;
    public Guid SponsorId { get; set; } = default!;
    public Sponsor Sponsor { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public Proposal Proposal { get; set; } = default!;
}