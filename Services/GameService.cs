using System;
using FreeTimeSpenderWeb.Hubs;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb.Services

{
    public class GameService: IGameService
    {
        private static List<PlayerModel> _players = new List<PlayerModel>();
        private bool _botIsLiving = true;

        public GameService() 
        {
            UpdateBot();
        }

        public List<PlayerModel> GetPlayers()
        {
            return _players;
        }

        public List<PlayerModel> UpdatePlayer(string username, int newX, int newY)
        {
            PlayerModel player = _players.Find(p => p.Name == username)!;

            if (player != null)
            {
                player.PositionX = newX;
                player.PositionY = newY;
            }
            else
            {
                player = new PlayerModel
                {
                    Name = username,
                    PositionX = newX,
                    PositionY = newY,
                    Health = 100
                };

                _players.Add(player);
            }

            return _players;
        }


        public async Task UpdateBot() 
        {
            while (_botIsLiving)
            {
                PlayerModel bot = _players.Find(p => p.Name == "Bot")!;

                if (bot == null)
                {

                    bot = new PlayerModel
                    {
                        Name = "Bot",
                        PositionX = 300,
                        PositionY = 300,
                        Health = 100
                    };

                    _players.Add(bot);

                }

                else 
                {
                    Random rnd = new Random();

                    int newX = rnd.Next(-1, 2);
                    int newY = rnd.Next(-1, 2);

                    bot.PositionX += newX;
                    bot.PositionY += newY;
                }

                await Task.Delay(500);
            }
        
        
        }

    }
}
