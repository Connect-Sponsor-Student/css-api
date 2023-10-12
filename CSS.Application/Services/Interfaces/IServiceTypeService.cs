using CSS.Application.ViewModels.ServiceModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services.Interfaces;
public interface IServiceTypeService
{
    Task<IEnumerable<ServiceViewModel>> GetAllAsync();
    Task<ServiceViewModel> CreateAsync(ServiceCreateModel model); 
}
