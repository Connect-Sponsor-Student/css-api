namespace CSS.Domains.Entities;
public class Admin : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; } = default!;
    public bool IsBussinessAdmin { get; set; } = false; // Check if BussAd, can create feedback
    public ICollection<FeedBack> FeedBacks { get; set; } = default!;
}