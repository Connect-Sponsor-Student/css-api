using System.Diagnostics.Contracts;

namespace CSS.Application.ViewModels.ProposalModels;
public class ProposalUpdateModel
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double RequireAmount { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string State { get; set; } = default!;
    public int ServiceType { get; set; } = default!;
    public string OrganizationName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string ProposalType { get; set; } = default!;
    public string? Others { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public string? MemberDescription { get; set; } = default!;
    public string EventPlace { get; set; } = default!;
    public DateTime StartedDate { get; set; } = default!;
    public string Approach { get; set; } = default!;
    public int NumberParticipate { get; set; } = default!;


}