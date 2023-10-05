using CSS.Infrastructure.Data;
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

        return services;
    }
}