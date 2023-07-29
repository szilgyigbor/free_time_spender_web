﻿using Microsoft.AspNetCore.SignalR;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameService _gameService;

        public GameHub(IGameService gameService)
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
            await Clients.All.SendAsync("PlayersMoved", _gameService.GetPlayers());

            await Clients.All.SendAsync("KilledPlayer", _gameService.CheckPlayers());
        }


        public async Task KillTheBot()
        {
            _gameService.KillBot();
        }
        
    }
}
