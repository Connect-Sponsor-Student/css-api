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

}