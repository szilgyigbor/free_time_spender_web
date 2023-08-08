using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IGameService
    {
        List<PlayerModel> GetPlayers();

        void AddPlayer(string username, int positionX, int positionY);

        List<PlayerModel> UpdatePlayer(string username, int newX, int newY);

        void UpdateBot();

        void KillPlayer(string username);

        string CheckPlayers();

        Task UpdateGame();

        void AddABullet(bool lookRight, int starterX, int starterY, string shooterName);

        void MoveBullets();

    }
}
