using CSS.Application.ViewModels.RoleModels;
using CSS.Domains.Entities;

namespace CSS.Application.ViewModels.UserModels;
public class UserViewModel
{
    public Guid Id { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string ReddemCode { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int NumberRefer { get; set; } = 0;
    public bool IsReddem { get; set; } 
    public RoleViewModel Role { get; set; } = default!;
}