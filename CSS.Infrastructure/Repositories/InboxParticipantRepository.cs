using CSS.Application.Repositories;
using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using CSS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Infrastructure.Repositories
{
    public class InboxParticipantRepository : GenericRepository<InboxParticipant>, IInboxParticipantRepository
    {
        public InboxParticipantRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
