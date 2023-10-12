using Microsoft.AspNetCore.Http;

namespace CSS.Application.ViewModels.ProposalModels;
public class ProposalCreateModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double RequireAmount { get; set; } = default!;
    public ICollection<IFormFile> Files { get; set; } = default!;
}