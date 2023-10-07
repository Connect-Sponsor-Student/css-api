using CSS.Application.ViewModels.RoleModels;

namespace CSS.Application.Services.Interfaces;
public interface IRoleService
{
    Task<IEnumerable<RoleViewModel>> GetAllAsync();
}
