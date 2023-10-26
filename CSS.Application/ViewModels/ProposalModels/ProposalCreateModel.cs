using Microsoft.AspNetCore.Http;

namespace CSS.Application.ViewModels.ProposalModels;
public class ProposalCreateModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string OrganizationName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public double RequireAmount { get; set; } = default!;
    public string ProposalType { get; set; } = default!;
    public string? Others { get; set; } = default!;
    public string Reason { get; set; } = default!;
public string? MemberDescription { get; set; } = default!;
    public string EventPlace { get; set; } = default!;
    public DateTime StartedDate { get; set; } = default!;
    public string Approach { get; set; } = default!;
    public int NumberParticipate { get; set; } = default!;
    public ICollection<IFormFile> Files { get; set; } = default!;
}