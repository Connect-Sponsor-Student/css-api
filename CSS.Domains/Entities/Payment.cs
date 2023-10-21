using System.Dynamic;

namespace CSS.Domains.Entities;
public class Payment : BaseEntity 
{
    public decimal Amount {get ;set;} = default!;
    public bool State {get; set;}  =default!;
    public Guid ProposalSupportId {get; set;} 
    public ProposalSupport ProposalSupport {get; set;} = default!;
}