using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;


namespace InterviewBoard.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly UserManager<UserAcc> _userManager;
        public ChatHub(UserManager<UserAcc> userManager)
        {
            _userManager = userManager;
        }
        public async Task SendMessage(string user,string message,string myself)
        {
            UserAcc userA = await _userManager.FindByNameAsync(user);
            UserAcc userM = await _userManager.FindByNameAsync(myself);

            // await Clients.User().SendAsync("ReceiveMessage", user, message);
            await Clients.User(userA.Id).SendAsync("ReceiveMessage", user, message);
            await Clients.User(userM.Id).SendAsync("ReceiveMessage", user, message);
        }
    }
}
