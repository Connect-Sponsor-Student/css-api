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
                .AddScoped<IProposalServiceRespository, ProposalServiceRepository>()
                .AddScoped<IProposalSponsorRepository, ProposalSponsorRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IServiceRepository, ServiceRepository>()
                .AddScoped<ISponsorRepository, SponsorRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region  DI Services 
        services.AddScoped<IUserService, UserService>()
                .AddScoped<IRoleService, RoleService>();
        #endregion
        return services;
    }

    
}