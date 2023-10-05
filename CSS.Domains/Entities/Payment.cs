using System.Dynamic;

namespace CSS.Domains.Entities;
public class Payment : BaseEntity 
{
    public decimal Amount {get ;set;} = default!;
    public string Description {get ;set;} = default!;
    public bool State {get; set;}  =default!;
    public Guid ProposalServiceId {get; set;} 
    public ProposalService ProposalService {get; set;} = default!;
}