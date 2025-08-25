using System.ComponentModel.DataAnnotations;

namespace TestOBS.Models
{
    public class Lesson
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Credit { get; set; }
        [Required]
        public string Department { get; set; } = string.Empty;

    }
}
