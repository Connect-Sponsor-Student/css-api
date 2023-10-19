using CSS.Application.ViewModels.MessageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Application.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageReadModel> CreateMessage(MessageCreateModel model);
    }
}
