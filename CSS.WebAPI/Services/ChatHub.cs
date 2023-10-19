using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.MessageModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CSS.WebAPI.Services
{
    [Authorize]
    public class ChatHub:Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessageToGroup(string group, string user, MessageCreateModel newMessage)
        {
            var result = await _messageService.CreateMessage(newMessage);
            await Clients.Group(group).SendAsync("ReceiveMessage", user, result);
        }
    }
}
