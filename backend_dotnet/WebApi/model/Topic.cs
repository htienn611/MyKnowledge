
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.model
{
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public bool IsActive { get; set; }

        public int SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }
    }
}