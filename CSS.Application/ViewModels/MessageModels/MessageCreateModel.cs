using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.ViewModels.MessageModels
{
    public class MessageCreateModel
    {
        public string Text { get; set; } = default!;
        public Guid InboxId { get; set; }
    }
}
