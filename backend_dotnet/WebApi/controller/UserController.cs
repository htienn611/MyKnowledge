namespace WebApi.controller
{

    using Microsoft.AspNetCore.Mvc;
    using WebApi.DTO.request;
    using WebApi.helper;
    using WebApi.model;
    using WebApi.repository;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository, LoggerHelper<UserController> logger) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;
        private readonly LoggerHelper<UserController> _logger = logger;

        [HttpGet("all")] // Custom route: api/user/all
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            _logger.LogInformation("Fetching all users");

            try
            {
                var users = await _repository.GetAllUsers();
                if (users == null || !users.Any())
                {
                    _logger.LogWarning("No users found");
                    return NotFound("No users found");
                }
                _logger.LogInformation("Fetched all users successfully");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")] // Custom route: api/user/login
        public async Task<ActionResult<User>> Login([FromBody] UserRequest user)
        {
            _logger.LogInformation($"Logging in user with email: {user.Email}");

            try
            {
                var existingUser = await _repository.GetUserByEmail(user.Email);
                if (existingUser == null)
                {
                    _logger.LogWarning($"User with email: {user.Email} not found");
                    return NotFound($"User with email: {user.Email} not found");
                }
                if (existingUser.Password != user.Password)
                {
                    _logger.LogWarning("Invalid password");
                    return Unauthorized("Invalid password");
                }
                _logger.LogInformation($"User with email: {user.Email} logged in successfully");
                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while logging in user with email: {user.Email}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("register")] // Custom route: api/user/register
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            _logger.LogInformation($"Registering user with email: {user.Email}");

            try
            {
                var existingUser = await _repository.GetUserByEmail(user.Email);
                if (existingUser != null)
                {
                    _logger.LogWarning($"User with email: {user.Email} already exists");
                    return Conflict($"User with email: {user.Email} already exists");
                }
                var createdUser = await _repository.CreateUser(user);
                _logger.LogInformation($"User with email: {user.Email} registered successfully");
                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while registering user with email: {user.Email}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}