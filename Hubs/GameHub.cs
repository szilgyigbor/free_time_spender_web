using Microsoft.AspNetCore.SignalR;

namespace FreeTimeSpenderWeb.Hubs
{
    public class GameHub : Hub
    {
        public async Task MoveCharacter(string username, int newX, int newY)
        {

            await Clients.Others.SendAsync("CharacterMoved", username, newX, newY);
        }
    }
}
