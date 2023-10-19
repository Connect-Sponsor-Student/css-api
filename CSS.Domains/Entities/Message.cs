using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Domains.Entities
{
    public class Message:BaseEntity
    {
        public string Text { get; set; } = default!;
        public bool IsRead { get; set; } = false;
        public Guid InboxId { get; set; }
        public Inbox Inbox { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

    }
}
