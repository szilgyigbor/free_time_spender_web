using Microsoft.AspNetCore.SignalR;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb.Hubs
{
    public class GameHub : Hub
    {
        private readonly IShooterGameService _gameService;

        public GameHub(IShooterGameService gameService)
        {
            _gameService = gameService;

        }


        public async Task MoveCharacter(string username, int newX, int newY)
        {
            _gameService.UpdatePlayer(username, newX, newY);

            //await Clients.All.SendAsync("PlayersMoved", _gameService.GetPlayers());

        }


        public async Task UpdateStatus()
        {
            await Clients.Caller.SendAsync("PlayersMoved", _gameService.GetPlayers());

            await Clients.Caller.SendAsync("KilledPlayer", _gameService.CheckPlayers());
        }


        public async Task MakeAShot(bool lookRight, int starterX, int starterY, string shooterName)
        {
            _gameService.AddABullet(lookRight, starterX, starterY, shooterName);
        }

        public async Task AddPlayer(string username, int positionX, int positionY)
        {
            _gameService.AddPlayer(username, positionX, positionY);
        }


        public async Task KillPlayer(string username)
        {
            _gameService.KillPlayer(username);
        }
        
    }
}
