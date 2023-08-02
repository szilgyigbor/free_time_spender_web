using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IGameService
    {
        List<PlayerModel> GetPlayers();

        List<PlayerModel> UpdatePlayer(string username, int newX, int newY);

        void UpdateBot();

        void KillBot();

        void KillPlayer(string username);

        string CheckPlayers();

        Task UpdateGame();

        void AddABullet(bool lookRight, int starterX, int starterY, string shooterName);

        void MoveBullets();

    }
}
