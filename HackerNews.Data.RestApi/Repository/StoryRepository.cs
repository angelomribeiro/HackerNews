using HackerNews.Domain.Config;
using HackerNews.Domain.Model;
using HackerNews.Domain.Repository;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.Data.RestApi.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private string _urlBase;
        private readonly HttpClient _httpClient;

        public StoryRepository(IOptions<HackerNewsConfig> configuration, HttpClient httpClient)
        {
            _urlBase = configuration.Value.UrlBase;
            _httpClient = httpClient;
        }

        public async Task<int[]> GetBestStoriesIdsAsync()
        {
            var httpResponse = await _httpClient.GetAsync(_urlBase + "/beststories.json");
            var content = await httpResponse.Content.ReadAsStringAsync();
            var bestStories = JsonConvert.DeserializeObject<int[]>(content);

            return bestStories;
        }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            var httpResponse = await _httpClient.GetAsync(_urlBase + $"/item/{id}.json");
            var content = await httpResponse.Content.ReadAsStringAsync();
            var story = JsonConvert.DeserializeObject<Story>(content);

            return story;
        }
    }
}
