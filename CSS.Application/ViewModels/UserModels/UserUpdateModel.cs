namespace CSS.Application.ViewModels.UserModels;
public class UserUpdateModel
{
    public Guid Id {get; set;} = default!;
    public string? Password {get; set;} = default!;
    public string FullName {get; set;} = default!;
    public string Address {get ;set;} = default!;
}