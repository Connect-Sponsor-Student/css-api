namespace CSS.Domains.Entities;
public class Sponsor : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public ICollection<ProposalSponsor> ProposalSponsors { get; set; } = default!;
}