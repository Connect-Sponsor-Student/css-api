using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Domains.Entities
{
    public class Inbox:BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<InboxParticipant>? Participants { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
