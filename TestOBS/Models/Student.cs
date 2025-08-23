using System.ComponentModel.DataAnnotations;

namespace TestOBS.Models
{
    public class Student
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

        // Öğrenciye özel alanlar
        public string StudentNumber { get; set; } = string.Empty;   // Öğrenci numarası
        public string Department { get; set; } = string.Empty;      // Bölüm adı
        public int Grade { get; set; }                              // Sınıf (1-4 arası olabilir)
    }
}
