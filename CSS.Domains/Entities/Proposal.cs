using CSS.Domains.Enums;

namespace CSS.Domains.Entities;
public class Proposal : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Requirement { get; set; } = default!; // Amount Money Requireed
    public decimal Actual {get; set;} = default!; // Amount Money has been invested
    public string Status { get; set; } = nameof(ProposalStatusEnum.Created);
    public string State { get; set; } = nameof(ProposalStateEnum.KickOff);

    public int ServiceType { get; set; } = (int)ServiceTypeEnum.Free;
    public Guid StudentId { get; set; } = default!;
    public Student Student { get; set; } = default!;
    public ICollection<FeedBack> FeedBacks { get; set; } = default!;
    public ICollection<ProposalService> ProposalServices { get; set; } = default!;
    public ICollection<ProposalSponsor> ProposalSponsors { get; set; } = default!;


}