using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IShooterGameService
    {
        List<PlayerData> GetPlayers();

        void AddPlayer(string username, int positionX, int positionY);

        List<PlayerData> UpdatePlayer(string username, int newX, int newY);

        void UpdateBot();

        void KillPlayer(string username);

        string CheckPlayers();

        Task UpdateGame();

        void AddABullet(bool lookRight, int starterX, int starterY, string shooterName);

        void MoveBullets();

    }
}
