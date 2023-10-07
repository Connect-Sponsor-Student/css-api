using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure.Repositories;
public class ServiceRepository : GenericRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext dbContext, ICurrentTime currentTime, IClaimsService claimsService) 
    : base(dbContext, currentTime, claimsService)
    {
        
    }
}