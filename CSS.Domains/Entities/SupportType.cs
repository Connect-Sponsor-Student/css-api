namespace CSS.Domains.Entities;
public class SupportType : BaseEntity
{
    public string Name { get; set; } = default!;
    public double Price { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<ProposalSupport> ProposalSupports { get; set; } = default!;

}