namespace CSS.Domains.Entities;
public class Investment : BaseEntity
{
    public Guid ProposalId { get; set; } = default!;
    public Proposal Proposal { get; set; } = default!;
    public double Amount { get; set; } = default!;
    public Guid SponsorId { get; set; } = default!;
    public Sponsor Sponsor { get; set; } = default!;
    
}