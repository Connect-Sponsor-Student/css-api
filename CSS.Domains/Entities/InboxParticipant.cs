using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Domains.Entities
{
    public class InboxParticipant:BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid InboxId { get; set; }
        public Inbox Inbox { get; set; }=default!;
    }
}
