using AutoMapper;
using CSS.Application.ViewModels.RoleModels;
using CSS.Application.ViewModels.UserModels;
using CSS.Domains.Entities;

namespace CSS.Application.Mappers;
public class MapperConfigurationProfile : Profile
{
    public MapperConfigurationProfile()
    {
        CreateMap<RoleViewModel, Role>().ReverseMap();

        #region UserMapping
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        #endregion
    }
}