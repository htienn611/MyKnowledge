using Microsoft.AspNetCore.Mvc;
using WebApi.helper;
using WebApi.model;
using WebApi.repository;

namespace WebApi.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController(IMajorRepository repository, LoggerHelper<MajorController> logger) : ControllerBase
    {
        private readonly IMajorRepository _repository = repository;
        private readonly LoggerHelper<MajorController> _logger = logger;

        [HttpGet("all")] // Custom route: api/major/all
        public async Task<ActionResult<IEnumerable<Major>>> GetALLMajors()
        {
            _logger.LogInformation("Fetching all majors");

            try
            {
                var majors = await _repository.GetAllMajors();
                if (majors == null || !majors.Any())
                {
                    _logger.LogWarning("No majors found");
                    return NotFound("No majors found");
                }
                _logger.LogInformation("Fetched all majors successfully");
                return Ok(majors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching majors: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("details/{id}")] // Custom route: api/major/details/{id}
        public async Task<ActionResult<Major>> GetMajor(int id)
        {
            _logger.LogInformation($"Fetching major with ID: {id}");
            try
            {
                var major = await _repository.GetMajor(id);
                if (major == null)
                {
                    _logger.LogWarning($"Major with ID: {id} not found");
                    return NotFound($"Major with ID: {id} not found");
                }
                _logger.LogInformation($"Fetched major with ID: {id} successfully");
                return Ok(major);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching major with ID: {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}