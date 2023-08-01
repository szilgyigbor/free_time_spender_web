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
                if (player.PositionX > newX)
                {
                    player.IsReversed = true;
                }
                else if (player.PositionX < newX)
                {
                    player.IsReversed = false;
                }

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
                    Health = 100,
                    IsReversed = false
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
                        Health = 100,
                        IsReversed = false
                    };

                    _players.Add(bot);
                }
                else
                {
                    PlayerModel closestPlayer = null;
                    double closestDistance = double.MaxValue;

                    foreach (PlayerModel player in _players)
                    {
                        if (player.Name == "Bot")
                        {
                            continue;
                        }

                        int dx = player.PositionX - bot.PositionX;
                        int dy = player.PositionY - bot.PositionY;
                        double distance = Math.Sqrt(dx * dx + dy * dy);

                        if (distance < closestDistance)
                        {
                            closestPlayer = player;
                            closestDistance = distance;
                        }
                    }

                    if (closestPlayer != null)
                    {
                        int dx = closestPlayer.PositionX - bot.PositionX;
                        int dy = closestPlayer.PositionY - bot.PositionY;

                        double length = Math.Sqrt(dx * dx + dy * dy);
                        double directionX = dx / length;
                        double directionY = dy / length;

                        if (bot.PositionX > (bot.PositionX + 2 * ((int)Math.Round(directionX))))
                        {
                            bot.IsReversed = true;
                        }

                        else if (bot.PositionX < (bot.PositionX + 2 * ((int)Math.Round(directionX))))
                        {
                            bot.IsReversed = false;
                        }

                        bot.PositionX += 2 * ((int)Math.Round(directionX));
                        bot.PositionY += 2 * ((int)Math.Round(directionY));
                    }
                }

                await Task.Delay(100);
            }
        }


        public void KillBot()
        {
            _botIsLiving = false;
            _players.RemoveAll(p => p.Name == "Bot");
        }


        public void KillPlayer(string username)
        {
            _players.RemoveAll(p => p.Name == username);
        }

        public string CheckPlayers()
        {
            PlayerModel botPlayer = _players.FirstOrDefault(player => player.Name == "Bot")!;

            if (botPlayer == null)
            {
                return "Players checked";
            }

            foreach (PlayerModel player in _players)
            {
                if (player.Name == "Bot")
                {
                    continue;
                }

                if (Math.Abs(botPlayer.PositionX - player.PositionX) <= 20 &&
                    Math.Abs(botPlayer.PositionY - player.PositionY) <= 42)
                {
                    KillPlayer(player.Name!);
                    return player.Name!;
                }
            }

            return "Players checked";
        }

    }
}
