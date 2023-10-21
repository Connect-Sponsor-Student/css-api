using CSS.Application.ViewModels.LoginModels;
using CSS.Application.ViewModels.UserModels;

namespace CSS.Application.Services.Interfaces;
public interface IUserService
{
    Task<IEnumerable<UserViewModel>> GetAllAsync();
    Task<UserViewModel> CreateAsync(UserCreateModel model);
    Task<UserViewModel> GetByIdAsync(Guid id);
    Task<UserViewModel> UpdateAsync(UserUpdateModel model);
    Task<bool> DeleteAsync(Guid id);
    Task<LoginReponseModel> LoginAsync(string email);
    Task<LoginReponseModel> LoginAsync(LoginRequestModel model);
    Task<bool> ReddemCode(Guid userId ,string code);
}