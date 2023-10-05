namespace CSS.Domains.Entities;
public class FeedBack : BaseEntity
{
    public string Description {get ;set;} = default!;
    public Guid ProposalId {get; set;} = default!;
    public Proposal Proposal {get ;set;} = default!;
    public Guid AdminId {get ;set;} = default!;
    public Admin Admin {get; set; } = default!;
}