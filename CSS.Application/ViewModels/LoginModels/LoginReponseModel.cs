using CSS.Application.ViewModels.UserModels;

namespace CSS.Application.ViewModels.LoginModels;
public class LoginReponseModel
{
    public UserViewModel? User {get; set;} = default!;
    public string Token {get; set;} = default!;
}