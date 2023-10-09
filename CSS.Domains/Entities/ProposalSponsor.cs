namespace CSS.Domains.Entities;
public class ProposalSponsor : BaseEntity
{
    public string Description { get; set; } = "";
    public Guid SponsorId { get; set; } = default!;
    public Sponsor Sponsor { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public Proposal Proposal { get; set; } = default!;
}