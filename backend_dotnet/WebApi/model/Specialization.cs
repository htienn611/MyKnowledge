using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.model
{
    public class Specialization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public bool IsActive { get; set; }
        public int MajorId { get; set; }
        public Major? Major { get; set; }
    }
}