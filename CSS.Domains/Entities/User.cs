namespace CSS.Domains.Entities;
public class User : BaseEntity
{
    public string Email { get; set; } = default!;
    public string? Password { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Address { get; set; } = default!;
    public Guid RoleId { get; set; } = default!;
    public Role Role { get; set; } = default!;  
    //public Guid EntityId { get; set; } = default!;
    public string Status {  get; set; } = "Active";

    public ICollection<Message>? Messages { get; set; }
    public ICollection<InboxParticipant>? InboxParticipants { get; set; }
}