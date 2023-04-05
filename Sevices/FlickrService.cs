using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace FreeTimeSpenderWeb.Sevices
{
    public class FlickrService
    {
        private readonly HttpClient _httpClient;

        public FlickrService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPictureIdAsync(string apiKey, string location)
        {
            var response = await _httpClient.GetAsync($"https://www.flickr.com/services/rest/?method=flickr.photos.search&api_key={apiKey}&text={location}&tags={location}&format=json&nojsoncallback=1");
            
            string json = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(json);

            JArray photosArray = (JArray)jsonResponse["photos"]["photo"];
            
            int randomIndex = new Random().Next(0, photosArray.Count);
            string id = photosArray[randomIndex].Value<string>("id");
            return id;

        }


        public async Task<string> GetPictureUrlAsync(string apiKey, string location)
        {
            
            var pictureId = await GetPictureIdAsync(apiKey, location);

            var response = await _httpClient.GetAsync($"https://www.flickr.com/services/rest/?method=flickr.photos.getSizes&api_key={apiKey}&photo_id={pictureId}&format=json&nojsoncallback=1");
            var pictureInfo = await response.Content.ReadAsStringAsync();

            return pictureInfo;
        }

    }
}
