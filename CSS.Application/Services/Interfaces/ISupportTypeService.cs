using CSS.Application.ViewModels.ServiceModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services.Interfaces;
public interface ISupportTypeService
{
    Task<IEnumerable<SupportTypeViewModel>> GetAllAsync();
    Task<SupportTypeViewModel> CreateAsync(SupportTypeCreateModel model); 
}
