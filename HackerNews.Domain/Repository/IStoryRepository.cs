using HackerNews.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Domain.Repository
{
    public interface IStoryRepository
    {
        Task<int[]> GetBestStoriesIdsAsync();
        Task<Story> GetStoryByIdAsync(int id);
    }
}
