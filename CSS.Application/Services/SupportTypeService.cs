using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ServiceModels;
using CSS.Domains.Entities;

namespace CSS.Application.Services;
public class SupportTypeService : ISupportTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SupportTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<SupportTypeViewModel> CreateAsync(SupportTypeCreateModel model)
    {
        var service = _mapper.Map<SupportType>(model);
        await _unitOfWork.SupportTypeRepository.AddAsync(service);
        return await _unitOfWork.SaveChangesAsync() ? 
            _mapper.Map<SupportTypeViewModel>(await _unitOfWork.SupportTypeRepository.GetByIdAsync(service.Id))
            : throw new Exception($"--> Error: Save Change Failed");
        
    }

    public async Task<IEnumerable<SupportTypeViewModel>> GetAllAsync()
        => _mapper.Map<IEnumerable<SupportTypeViewModel>>(await _unitOfWork.SupportTypeRepository.GetAllAsync());
}