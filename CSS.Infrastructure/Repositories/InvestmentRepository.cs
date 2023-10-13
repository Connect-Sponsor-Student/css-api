using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure.Repositories;
public class InvestmentRepository : GenericRepository<Investment>, IInvestmentRepository
{
    public InvestmentRepository(AppDbContext dbContext, IClaimsService claimsService, ICurrentTime currentTime) : 
    base(dbContext, currentTime, claimsService)
    {

    }
}