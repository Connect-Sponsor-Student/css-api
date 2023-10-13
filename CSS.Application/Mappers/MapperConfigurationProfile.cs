using AutoMapper;
using CSS.Application.ViewModels.ProposalFileModels;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ProposalServiceModels;
using CSS.Application.ViewModels.ProposalSupportModels;
using CSS.Application.ViewModels.RoleModels;
using CSS.Application.ViewModels.ServiceModels;
using CSS.Application.ViewModels.UserModels;
using CSS.Domains.Entities;

namespace CSS.Application.Mappers;
public class MapperConfigurationProfile : Profile
{
    public MapperConfigurationProfile()
    {
        CreateMap<RoleViewModel, Role>().ReverseMap();
        CreateMap<ProposalFile, ProposalFileViewModel>().ReverseMap();

        #region UserMapping
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        #endregion

        #region ProposalMapping
        CreateMap<Proposal, ProposalCreateModel>().ReverseMap();
        CreateMap<Proposal, ProposalViewModel>().ReverseMap();
        CreateMap<Proposal, ProposalUpdateModel>().ReverseMap();
        #endregion
        #region SupportTypeMapping
        CreateMap<SupportType, SupportTypeCreateModel>().ReverseMap();
        CreateMap<SupportType, SupportTypeUpdateModel>().ReverseMap();
        CreateMap<SupportType, SupportTypeUpdateModel>().ReverseMap();
        #endregion

        #region  ProposalSupport Mapping
        CreateMap<ProposalSupport, ProposalSupportCreateModel>().ReverseMap();
        CreateMap<ProposalSupport, ProposalViewModel>().ReverseMap();
        CreateMap<ProposalSupport, ProposalSupportUpdateModel>().ReverseMap();
        #endregion
    }
}