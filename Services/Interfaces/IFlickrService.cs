namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IFlickrService
    {
        Task<string> GetPictureIdAsync(string apiKey, string location);
        Task<string> GetPictureUrlAsync(string apiKey, string location);
    }
}
