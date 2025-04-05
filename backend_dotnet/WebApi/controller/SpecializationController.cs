using Microsoft.AspNetCore.Mvc;
using WebApi.helper;
using WebApi.model;
using WebApi.repository;

namespace WebApi.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController(ISpecializationRepository repository, LoggerHelper<SpecializationController> logger) : ControllerBase
    {
        private readonly ISpecializationRepository _repository = repository;
        private readonly LoggerHelper<SpecializationController> _logger = logger;

        [HttpGet("all")] // Custom route: api/specialization/all
        public async Task<ActionResult<IEnumerable<Specialization>>> GetAllSpecializations()
        {
            _logger.LogInformation("Fetching all specializations");

            try
            {
                var specializations = await _repository.GetAllSpecializations();
                if (specializations == null || !specializations.Any())
                {
                    _logger.LogWarning("No specializations found");
                    return NotFound("No specializations found");
                }
                _logger.LogInformation("Fetched all specializations successfully");
                return Ok(specializations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching specializations: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("details/{id}")] // Custom route: api/specialization/details/{id}
        public async Task<ActionResult<Specialization>> GetSpecialization(int id)
        {
            _logger.LogInformation($"Fetching specialization with ID: {id}");

            try
            {
                var specialization = await _repository.GetSpecialization(id);
                if (specialization == null)
                {
                    _logger.LogWarning($"Specialization with ID: {id} not found");
                    return NotFound($"Specialization with ID: {id} not found");
                }
                _logger.LogInformation($"Fetched specialization with ID: {id} successfully");
                return Ok(specialization);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching specialization with ID: {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
