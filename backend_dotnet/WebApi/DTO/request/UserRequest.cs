namespace WebApi.DTO.request
{
    public class UserRequest
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}