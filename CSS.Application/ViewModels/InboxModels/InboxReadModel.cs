using CSS.Application.ViewModels.MessageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.ViewModels.InboxModels
{
    public class InboxReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Status {  get; set; } = default!;
        public DateTime CreationDate {  get; set; }
        public MessageReadModel? Message { get; set; }= default!;
    }
}
