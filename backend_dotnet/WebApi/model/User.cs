using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.model
{
    public class User
    {
        public required string Email { get; set; }
        public string? FisrtName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}