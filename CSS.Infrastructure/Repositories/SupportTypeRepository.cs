using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure.Repositories;
public class SupportTypeRepository : GenericRepository<SupportType>, ISupportTypeRepository
{
    public SupportTypeRepository(AppDbContext dbContext, ICurrentTime currentTime, IClaimsService claimsService) 
    : base(dbContext, currentTime, claimsService)
    {
        
    }
}