namespace CSS.Domains.Entities;
public class ProposalSupport : BaseEntity
{
    public decimal Amount { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid ProposalId { get; set; } = default!;
    public Proposal Proposal { get; set; } = default!;
    public Guid SupportTypeId { get; set; } = default!;
    public SupportType SupportType { get; set; } = default!;
    public ICollection<Payment> Payments { get; set; } = default!;

}