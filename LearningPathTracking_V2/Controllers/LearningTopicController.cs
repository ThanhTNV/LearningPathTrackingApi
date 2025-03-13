using LearningPathTracking_V2.Application.DTOs.LearningTopic;
using LearningPathTracking_V2.Application.Interfaces;
using LearningPathTracking_V2.Domain.Entities;
using LearningPathTracking_V2.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningPathTracking_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningTopicController : ControllerBase
    {
        private ILearningTopicService _service;
        public LearningTopicController(ILearningTopicService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetAllTopics();
            return ApiResponses.Ok200("Get all topics successfully", result);
        }

        // GET api/<LearningTopicController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _service.GetOneLearningTopic(id);
            if(result is null)
            {
                return ApiResponses.NotFound404($"Not found topic with id {id}");
            }
            return ApiResponses.Ok200($"Get topic with id {id} successfully", result);
        }

        // POST api/<LearningTopicController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateLearningTopicDto topicDto)
        {
            var result = await _service.CreateLearningTopic(topicDto);
            if (result is null)
                return ApiResponses.BadRequest400("Invalid topic data");
            return ApiResponses.Created201("Create new topic successfully", result);
        }

        // PUT api/<LearningTopicController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]UpdateLearningTopicDto topicDto)
        {
            var result = await _service.UpdateLearningTopic(id, topicDto);
            if (result is null) 
            {
                return ApiResponses.NotFound404($"Not found topic with id {id}");
            }
            return ApiResponses.Ok200("User updated successfully", result);
        }

        // DELETE api/<LearningTopicController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteLearningTopic(id);
            if(result is null)
            {
                return ApiResponses.NotFound404($"Not found topic with id {id}");
            }
            return ApiResponses.NoContent204();
        }
    }
}
