using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.ViewModels.MessageModels
{
    public class MessageReadModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = default!;
        public bool IsRead { get; set; } = false;
        public Guid InboxId { get; set; }
        public DateTime CreationDate {  get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = default!;
    }
}
