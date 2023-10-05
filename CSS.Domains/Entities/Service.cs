namespace CSS.Domains.Entities;
public class Service : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description {get ;set;} = default!;
    public ICollection<ProposalService> ProposalServices {get; set;} = default!;

}