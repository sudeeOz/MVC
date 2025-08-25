using System.ComponentModel.DataAnnotations;

namespace TestOBS.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public DateTime BirthOfDate { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;  
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
