namespace CSS.Domains.Entities;
public class ProposalFile : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Extension { get; set; } = default!;
    public string URL { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public Proposal Proposal { get; set; } = default!;
}