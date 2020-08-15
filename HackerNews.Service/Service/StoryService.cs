using AutoMapper;
using HackerNews.Domain.Config;
using HackerNews.Domain.Model;
using HackerNews.Domain.Repository;
using HackerNews.Service.Dtos;
using HackerNews.Service.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Service.Service
{
    public class StoryService : IStoryService
    {
        private readonly int _maxSize;
        private readonly IStoryRepository _repository;
        private readonly IMapper _mapper;

        public StoryService(IOptions<HackerNewsConfig> configuration, IStoryRepository repository)
        {
            _maxSize = configuration.Value.MaxSize;
            _repository = repository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Story, BestStoryDTO>()
                    .ForMember(d => d.postedBy, o => o.MapFrom(x => x.by))
                    .ForMember(d => d.uri, o => o.MapFrom(x => x.url))
                    .ForMember(d => d.commentCount, o => o.MapFrom(x => x.descendants))
                    .ForMember(d => d.time, o => o.MapFrom(x => DateTimeOffset.FromUnixTimeSeconds(x.time).DateTime));
            });

            _mapper = config.CreateMapper();
        }

        public async Task<List<BestStoryDTO>> GetBestStoriesAsync()
        {
            // get best stories
            var bestStories = await _repository.GetBestStoriesIdsAsync();
            List<BestStoryDTO> lstStories = new List<BestStoryDTO>();

            int maxSize = bestStories.Length > _maxSize ? _maxSize : bestStories.Length;

            for (int x = 0; x < maxSize; x++)
            {
                lstStories.Add(_mapper.Map<BestStoryDTO>(await _repository.GetStoryByIdAsync(bestStories[x])));
            }

            return lstStories
                .OrderByDescending(o => o.score)
                .ToList();
        }
    }
}
