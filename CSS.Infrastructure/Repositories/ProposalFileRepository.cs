using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure.Repositories;
public class ProposalFileRepository : GenericRepository<ProposalFile>, IProposalFileRepository
{
    public ProposalFileRepository(AppDbContext dbContext, IClaimsService claimsService, ICurrentTime timeService) 
    : base(dbContext, timeService, claimsService)
    {
        
    }
}