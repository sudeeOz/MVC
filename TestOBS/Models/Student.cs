using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOBS.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Manuel Id girişi için
        [Display(Name = "Okul Numarası")]
        [Range(1000, 9999, ErrorMessage = "Okul numarası 4 haneli olmalıdır")]
        public int Id { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad gereklidir")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad gereklidir")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi gereklidir")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthOfDate { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        [Display(Name = "Şifre")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bölüm seçimi gereklidir")]
        [Display(Name = "Bölüm")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sınıf bilgisi gereklidir")]
        [Range(1, 4, ErrorMessage = "Sınıf 1-4 arası olmalıdır")]
        [Display(Name = "Sınıf")]
        public int Grade { get; set; }

        // Navigation property
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        // Computed property
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}