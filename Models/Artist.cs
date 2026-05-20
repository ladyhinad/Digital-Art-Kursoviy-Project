using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'ПІБ' є обов'язковим")]
        [StringLength(100, ErrorMessage = "Ім'я не може бути довшим за 100 символів")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Рік народження є обов'язковим")]
        [Range(1000, 2026, ErrorMessage = "Будь ласка, введіть реальний рік народження (до 2026)")]
        public int BirthYear { get; set; }

        public int? DeathYear { get; set; }

        [Required(ErrorMessage = "Контактна інформація є обов'язковою")]
        [Phone(ErrorMessage = "Введіть коректний номер телефону")]
        public string ContactInfo { get; set; }

        [StringLength(2000, ErrorMessage = "Біографія занадто довга (максимум 2000 символів)")]
        public string Biography { get; set; }

        [Url(ErrorMessage = "Будь ласка, введіть коректне URL-посилання (починається з http:// або https://)")]
        public string? PhotoUrl { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
    }
}