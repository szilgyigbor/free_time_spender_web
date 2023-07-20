using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using FreeTimeSpenderWeb.Models;
using System.Collections.Generic;

namespace FreeTimeSpenderWeb.Hubs
{
    public class GameHub : Hub
    {

        private static List<PlayerModel> Players = new List<PlayerModel>();


        public async Task MoveCharacter(string username, int newX, int newY)
        {
            PlayerModel player = Players.Find(p => p.Name == username)!;

            if (player != null)
            {
                player.PositionX = newX;
                player.PositionY = newY;
            }

            else { 
                player = new PlayerModel
                {
                    Name = username,
                    PositionX = newX,
                    PositionY = newY,
                    Health = 100
                };

                Players.Add(player);
            }

            await Clients.All.SendAsync("PlayersMoved", Players);
        }
    }
}
