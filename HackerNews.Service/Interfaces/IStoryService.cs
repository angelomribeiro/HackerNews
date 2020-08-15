using HackerNews.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Service.Interfaces
{
    public interface IStoryService
    {
        Task<List<BestStoryDTO>> GetBestStoriesAsync();
    }
}
