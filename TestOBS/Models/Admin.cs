using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestOBS.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // otomatik artan ID
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur.")]
        [RegularExpression(@"^(\+90|0)?\d{10}$",
            ErrorMessage = "Telefon numarası 10 haneli ve boşluksuz olmalı (örn: 05551234567).")]
        public string Phone { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Bölüm zorunludur.")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı.")]
        public string Password { get; set; } = string.Empty;
    }
}
