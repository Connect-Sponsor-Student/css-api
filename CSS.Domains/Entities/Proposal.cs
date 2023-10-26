using CSS.Domains.Enums;

namespace CSS.Domains.Entities;
public class Proposal : BaseEntity
{
    public string Name { get; set; } = default!;
    public string OrganizationName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ProposalType { get; set; } = default!;
    public string? Others { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public string? MemberDescription { get; set; } = default!;
    public string EventPlace { get; set; } = default!;
    public DateTime StartedDate { get; set; } = default!;
    public string Approach { get; set; } = default!;
    public int NumberParticipate { get; set; } = default!;
    public string Status { get; set; } = nameof(ProposalStatusEnum.Created);
    public string State { get; set; } = nameof(ProposalStateEnum.KickOff);

    public double RequireAmount { get; set; } = default!;
    public double ActualAmount { get; set; } = 0;
    public int ServiceType { get; set; } = (int)ServiceTypeEnum.Free;
    public Guid StudentId { get; set; } = default!;
    public Student Student { get; set; } = default!;
    public ICollection<FeedBack> FeedBacks { get; set; } = default!;
    public ICollection<ProposalSupport> ProposalSupports { get; set; } = default!;
    public ICollection<ProposalSponsor> ProposalSponsors { get; set; } = default!;
    public ICollection<ProposalFile> ProposalFiles { get; set; } = default!;
    public ICollection<Investment> Investments { get; set; } = default!;



}