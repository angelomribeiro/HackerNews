using HackerNews.Service.Dtos;
using HackerNews.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HackerNews.Test
{
    public class StoryServiceTest
    {
        private IStoryService _storyService;

        [Fact]
        public async Task GetBestStoriesSucess()
        {
            var storyServiceMoq = new Mock<IStoryService>();
            storyServiceMoq.Setup(o => o.GetBestStoriesAsync())
            .Returns(Task.FromResult(List20BestStoriesSuccess()));

            _storyService = storyServiceMoq.Object;
            var result = await _storyService.GetBestStoriesAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task CheckType()
        {
            var storyServiceMoq = new Mock<IStoryService>();
            storyServiceMoq.Setup(o => o.GetBestStoriesAsync())
            .Returns(Task.FromResult(List20BestStoriesSuccess()));

            _storyService = storyServiceMoq.Object;
            var result = await _storyService.GetBestStoriesAsync();

            Assert.IsType<List<BestStoryDTO>>(result);
        }

        [Fact]
        public async Task CheckIfIsEmpty()
        {
            var storyServiceMoq = new Mock<IStoryService>();
            storyServiceMoq.Setup(o => o.GetBestStoriesAsync())
            .Returns(Task.FromResult(EmptyBestStories()));

            _storyService = storyServiceMoq.Object;
            var result = await _storyService.GetBestStoriesAsync();

            Assert.False(result.Any());
        }

        private List<BestStoryDTO> List20BestStoriesSuccess()
        {
            var lstStories = new List<BestStoryDTO>();

            for (int x = 1; x <= 20; x++)
            {
                lstStories.Add(new BestStoryDTO
                {
                    title = $"Factorio 1.0 - {x}",
                    uri = $"https://factorio.com/blog/post/fff-360{x}",
                    postedBy = $"Akronymus",
                    time = Convert.ToDateTime("2020-08-14T09:12:32"),
                    score = 1756 * x,
                    commentCount = 575 + (x * 5)
                });
            }

            return lstStories;
        }

        private List<BestStoryDTO> EmptyBestStories()
        {
            var lstStories = new List<BestStoryDTO>();
            return lstStories;
        }
    }
}
