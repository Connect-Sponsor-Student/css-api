namespace CSS.Application.ViewModels.UserModels;
public class UserCreateModel
{
    public string Email {get; set;} = default!;
    public string? Password {get; set;} = default!;
    public string FullName {get; set;} = default!;
    public string Address {get; set;} = default!;
    public bool isFireBaseAuthen { get;set;} = default!;
    public Guid? RoleId {get; set;} = Guid.Empty;
}