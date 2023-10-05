using CSS.Domains.Enums;

namespace CSS.Domains.Entities;
public class Proposal : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Requirement { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string State { get; set; } = default!;

    public int ServiceType { get; set; } = (int)ServiceTypeEnum.Free;
    public Guid StudentId { get; set; } = default!;
    public Student Student { get; set; } = default!;
    public ICollection<FeedBack> FeedBacks { get; set; } = default!;
    public ICollection<ProposalService> ProposalServices { get; set; } = default!;
    public ICollection<ProposalSponsor> ProposalSponsors { get; set; } = default!;


}