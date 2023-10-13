namespace CSS.Application.ViewModels.InvestmentModels;
public class InvestmentCreateModel
{
    public double Amount { get; set; } = default!;
    public Guid? ProposalId { get; set; } = default!;
}