using Microsoft.AspNetCore.Mvc;
using WebApi.helper;
using WebApi.model;
using WebApi.repository;

namespace WebApi.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController(ITopicRepository repository, LoggerHelper<TopicController> logger) : ControllerBase
    {
        private readonly ITopicRepository _repository = repository;
        private readonly LoggerHelper<TopicController> _logger = logger;

        [HttpGet("all")] // Custom route: api/topic/all
        public async Task<ActionResult<IEnumerable<Topic>>> GetAllTopics()
        {
            _logger.LogInformation("Fetching all topics");

            try
            {
                var topics = await _repository.GetAllTopics();
                if (topics == null || !topics.Any())
                {
                    _logger.LogWarning("No topics found");
                    return NotFound("No topics found");
                }
                _logger.LogInformation("Fetched all topics successfully");
                return Ok(topics);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching topics: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("details/{id}")] // Custom route: api/topic/details/{id}
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            _logger.LogInformation($"Fetching topic with ID: {id}");

            try
            {
                var topic = await _repository.GetTopic(id);
                if (topic == null)
                {
                    _logger.LogWarning($"Topic with ID: {id} not found");
                    return NotFound($"Topic with ID: {id} not found");
                }
                _logger.LogInformation($"Fetched topic with ID: {id} successfully");
                return Ok(topic);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching topic with ID: {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
