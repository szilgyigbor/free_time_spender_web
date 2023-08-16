using System;
using FreeTimeSpenderWeb.Hubs;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using System.Linq;

namespace FreeTimeSpenderWeb.Services

{
    public class GameService: IGameService
    {
        private static List<PlayerData> _players = new List<PlayerData>();
        private Random _random = new Random();
        private bool _gameIsRunning = true;

        public GameService()
        {
            Task.Run(UpdateGame);
        }


        public async Task UpdateGame()
        {
            CreateBots(3);

            while (_gameIsRunning)
            {
                UpdateBot();
                MoveBullets();

                await Task.Delay(100);

            }
        }


        public List<PlayerData> GetPlayers()
        {
            return _players;
        }

        public void AddPlayer(string username, int positionX, int positionY)
        {
            PlayerData player = new PlayerData
            {
                Name = username,
                PositionX = positionX,
                PositionY = positionY,
                Health = 100,
                IsReversed = false,
                Shooter = username
            };

            _players.Add(player);
        }

        public List<PlayerData> UpdatePlayer(string username, int newX, int newY)
        {
            PlayerData player = _players.Find(p => p.Name == username)!;
            
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
            
            return _players;
        }


        public void UpdateBot()
        {
            
            List<PlayerData> bots = _players.Where(p => p.Name!.StartsWith("Bot-")).ToList();

            foreach (PlayerData bot in bots)
            {

                PlayerData closestPlayer = null;
                double closestDistance = double.MaxValue;

                foreach (PlayerData player in _players)
                {
                    if (player.Name!.StartsWith("Bot-") || player.Name!.StartsWith("bullet-"))
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


                if (_random.Next(50) == 0)
                {
                    AddABullet(!bot.IsReversed, bot.PositionX, bot.PositionY, bot.Name!);
                }

            }
            
        }


        public void KillPlayer(string username)
        {
            _players.RemoveAll(p => p.Name == username);
        }

        public string CheckPlayers()
        {
            PlayerData botPlayer = _players.FirstOrDefault(player => player.Name == "Bot")!;

            if (botPlayer == null)
            {
                return "Players checked";
            }

            foreach (PlayerData player in _players)
            {
                if (player.Name == "Bot" || player.Name!.StartsWith("bullet-"))
                {
                    continue;
                }

                bool overlapX = (player.PositionX - 10 <= botPlayer.PositionX + 25 && botPlayer.PositionX - 10 <= player.PositionX + 25);
                bool overlapY = (player.PositionY + 30 <= botPlayer.PositionY + 80 && botPlayer.PositionY + 30 <= player.PositionY + 80);

                if (overlapX && overlapY)
                {
                    KillPlayer(player.Name!);
                    return player.Name!;
                }
            }

            return "Players checked";
        }

        public void CreateBots(int botNumber)
        {
            for (int i = 0; i < botNumber; i++)
            {
                AddPlayer("Bot-" + i, _random.Next(100, 700), _random.Next(100, 500));
            }
        }

        public void AddABullet(bool lookRight, int starterX, int starterY, string shooterName) 
        {
            string baseName = "bullet-";
            int index = 1;

            while (_players.Any(p => p.Name == baseName + index))
            {
                index++;
            }

            string newBulletName = baseName + index;

            starterY += 60;    //hitbox Y +30 +80,  X -15 +30

            if (lookRight)
            {
                starterX += 30;
            }
            else
            {
                starterX -= 15;
            }

            PlayerData newBullet = new PlayerData
            {
                Name = newBulletName,
                PositionX = starterX,
                PositionY = starterY,
                Health = 10,
                IsReversed = lookRight,
                Shooter = shooterName
            };

            _players.Add(newBullet);

        }

        public void MoveBullets()
        {
            List<PlayerData> bullets = _players.Where(p => p.Name!.StartsWith("bullet-")).ToList();

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                PlayerData bullet = bullets[i];

                if (bullet.IsReversed)
                {
                    bullet.PositionX += 10;
                }
                else
                {
                    bullet.PositionX -= 10;
                }

                if (bullet.PositionX < 0 || bullet.PositionX > 2000)
                {
                    _players.Remove(bullet);
                }

                CheckHit(bullet);
            }
        }

        public void CheckHit(PlayerData bullet)
        {
            for (int i = _players.Count - 1; i >= 0; i--)
            {
                PlayerData player = _players[i];

                if (player.Name!.StartsWith("bullet-") || player.Name == bullet.Shooter)
                    continue;

                if (bullet.PositionY < player.PositionY + 30 || bullet.PositionY > player.PositionY + 80 ||
                    bullet.PositionX < player.PositionX - 10 || bullet.PositionX > player.PositionX + 25)
                    continue;

                player.Health -= bullet.Health;
                bullet.Health -= player.Health;

                if (player.Health <= 0)
                {
                    _players.Remove(player);
                    
                }

                if (bullet.Health <= 0)
                {
                    _players.Remove(bullet);
                }
            }
        }

    }
}
