using CSS.Application.ViewModels.SponsorModels;

namespace CSS.Application.Services.Interfaces;
public interface ISponsorService
{
    Task<IEnumerable<SponsorViewModel>> GetAllSponsor();
}