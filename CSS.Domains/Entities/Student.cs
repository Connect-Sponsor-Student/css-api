namespace CSS.Domains.Entities;
public class Student : BaseEntity
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string StudentNumber   { get; set; } = default!;
    public ICollection<Proposal> Proposals {get ;set;} = default!;

}