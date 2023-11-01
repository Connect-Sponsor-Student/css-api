using AutoMapper;
using CSS.Application.ViewModels.AdminModels;
using CSS.Application.ViewModels.FeedbackModels;
using CSS.Application.ViewModels.InvestmentModels;
using CSS.Application.ViewModels.MessageModels;
using CSS.Application.ViewModels.ProposalFileModels;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ProposalServiceModels;
using CSS.Application.ViewModels.ProposalSponsorModels;
using CSS.Application.ViewModels.ProposalSupportModels;
using CSS.Application.ViewModels.RoleModels;
using CSS.Application.ViewModels.ServiceModels;
using CSS.Application.ViewModels.SponsorModels;
using CSS.Application.ViewModels.UserModels;
using CSS.Domains.Entities;

namespace CSS.Application.Mappers;
public class MapperConfigurationProfile : Profile
{
    public MapperConfigurationProfile()
    {
        CreateMap<RoleViewModel, Role>()
            .ForMember(r => r.RoleName, r => r.MapFrom(src => src.RoleName))
            .ForMember(r => r.Id, r => r.MapFrom(src => src.Id))
            .ReverseMap();
        CreateMap<ProposalFile, ProposalFileViewModel>().ReverseMap();

        #region UserMapping
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        #endregion
        CreateMap<AdminViewModel, Admin>().ReverseMap();
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
        CreateMap<ProposalSupportCreateModel,ProposalSupport>().ReverseMap();
        CreateMap<ProposalViewModel,ProposalSupport>().ReverseMap();
        CreateMap<ProposalSupportUpdateModel, ProposalSupport>().ReverseMap();
        #endregion
        #region Sponsor
        CreateMap<Sponsor, SponsorViewModel>().ReverseMap();
        #endregion
        #region  Invesment
        CreateMap<Investment, InvestmentCreateModel>().ReverseMap();
        CreateMap<Investment, InvestmentViewModel>().ReverseMap();

        #endregion

        #region  Feedback 
        CreateMap<FeedBack, FeedbackCreateModel>().ReverseMap();
        CreateMap<FeedBack, FeeedbackUpdateModel>().ReverseMap();
        CreateMap<FeedBack, FeedbackViewModel>().ReverseMap();
        #endregion
        #region  ProposalSponsor
         CreateMap<ProposalSponsor, ProposalSponsorCreateModel>().ReverseMap();
         CreateMap<ProposalSponsor, ProposalSponsorViewModel>().ReverseMap(); 
        #endregion
    
        #region Message
        CreateMap<MessageReadModel, Message>()
            .ForPath(x => x.User.FullName, opt => opt.MapFrom(x => x.UserName))
            .ReverseMap();
        CreateMap<MessageCreateModel, Message>().ReverseMap();
        #endregion

        #region Services
        CreateMap<SupportTypeCreateModel, SupportType>().ReverseMap();
        CreateMap<SupportTypeUpdateModel, SupportType>().ReverseMap();
        CreateMap<SupportTypeViewModel, SupportType>().ReverseMap();
        #endregion

    }
}