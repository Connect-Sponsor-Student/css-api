using CSS.Application;
using CSS.Application.Mappers;
using CSS.Application.Repositories;
using CSS.Application.Services;
using CSS.Application.Services.Interfaces;
using CSS.Infrastructure.Data;
using CSS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSS.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string dbConnection)
    {
        /*if (!string.IsNullOrEmpty(dbConnection))
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("CSS_InMemDb"));
        else*/
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(dbConnection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(MapperConfigurationProfile).Assembly);
        #region  DI REPO
        services.AddScoped<IAdminRepository, AdminRepository>()
                .AddScoped<IFeedBackRepository, FeedBackRepository>()
                .AddScoped<IPaymentRepository, PaymentRepository>()
                .AddScoped<IProposalRepository, ProposalRepository>()
                .AddScoped<IProposalSupportRespository, ProposalSupportRepository>()
                .AddScoped<IProposalSponsorRepository, ProposalSponsorRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<ISupportTypeRepository, SupportTypeRepository>()
                .AddScoped<ISponsorRepository, SponsorRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProposalFileRepository, ProposalFileRepository>()
                .AddScoped<IInvestmentRepository, InvestmentRepository>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IInboxRepository, InboxRepository>()
                .AddScoped<IInboxParticipantRepository, InboxParticipantRepository>();
        #endregion
        #region  DI Services 
        services.AddScoped<IUserService, UserService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IProposalService, ProposalService>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<ISupportTypeService, SupportTypeService>()
                .AddScoped<IProposalSupportService, ProposalSupportService>()
                .AddScoped<IProposalSponsorService, ProposalSponsorService>()
                .AddScoped<IInvestmentService, InvestmentService>()
                .AddScoped<IMessageService, MessageService>()
                .AddScoped<IInboxService, InboxService>();
        #endregion
        return services;
    }


}