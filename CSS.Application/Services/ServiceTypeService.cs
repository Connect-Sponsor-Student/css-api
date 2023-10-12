using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ServiceModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services;
public class ServiceTypeService : IServiceTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ServiceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ServiceViewModel> CreateAsync(ServiceCreateModel model)
    {
        var service = _mapper.Map<Service>(model);
        await _unitOfWork.ServiceRepository.AddAsync(service);
        return await _unitOfWork.SaveChangesAsync() ? 
            _mapper.Map<ServiceViewModel>(await _unitOfWork.ServiceRepository.GetByIdAsync(service.Id))
            : throw new Exception($"--> Error: Save Change Failed");
        
    }

    public async Task<IEnumerable<ServiceViewModel>> GetAllAsync()
        => _mapper.Map<IEnumerable<ServiceViewModel>>(await _unitOfWork.ServiceRepository.GetAllAsync());
}