namespace CSS.Application.ViewModels.ProposalFileModels;
public class ProposalFileViewModel
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Extension { get; set; } = default!;
    public string URL { get; set; } = default!;
}