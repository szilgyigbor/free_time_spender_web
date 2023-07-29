using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IGameService
    {
        List<PlayerModel> GetPlayers();

        List<PlayerModel> UpdatePlayer(string username, int newX, int newY);

        Task UpdateBot();

        void KillBot();

        string CheckPlayers();

    }
}
