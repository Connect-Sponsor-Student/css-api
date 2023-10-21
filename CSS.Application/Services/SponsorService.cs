using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.SponsorModels;


namespace CSS.Application.Services;
public class SponsorService : ISponsorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public SponsorService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async  Task<IEnumerable<SponsorViewModel>> GetAllSponsor()
    {
        return _mapper.Map<IEnumerable<SponsorViewModel>>(await _unitOfWork.SponsorRepository.GetAllAsync());
    }
}
