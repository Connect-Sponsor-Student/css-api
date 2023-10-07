using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.RoleModels;

namespace CSS.Application.Services;
public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<RoleViewModel>> GetAllAsync()
        => _mapper.Map<IEnumerable<RoleViewModel>>(await _unitOfWork.RoleRepository.GetAllAsync());


}