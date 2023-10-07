using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure.Repositories;
public class FeedBackRepository : GenericRepository<FeedBack>,  IFeedBackRepository
{
    public FeedBackRepository(AppDbContext dbContext, ICurrentTime currentTime, IClaimsService claimsService) 
    : base(dbContext, currentTime, claimsService)
    {
        
    }
}