using HackerNews.Service.Dtos;
using HackerNews.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HackerNews.Api.Controllers
{
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _service;

        public StoryController(IStoryService service)
        {
            _service = service;
        }

        [Route("api/beststories"), HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<BestStoryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var models = await _service.GetBestStoriesAsync();

                if (models == null || models.Count == 0)
                    return NoContent();

                return Ok(models);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
