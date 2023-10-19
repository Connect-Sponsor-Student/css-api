using CSS.Application.ViewModels.InboxModels;
using CSS.Application.ViewModels.MessageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.Services.Interfaces
{
    public interface IInboxService
    {
        Task<List<InboxReadModel>> GetInboxes();
        Task<InboxReadModel> CreateInbox(InboxCreateModel model);

        Task<List<MessageReadModel>> GetAllMessageByInboxId(Guid inboxId);
    }
}
