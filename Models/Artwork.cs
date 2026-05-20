using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using Digital_Art_Kursoviy_Project.States;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Artwork
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва твору не може бути порожньою")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Назва має містити від 2 до 150 символів")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Рік створення є обов'язковим")]
        [Range(1000, 2026, ErrorMessage = "Рік створення має бути реальним (не більше 2026)")]
        public int CreationYear { get; set; }

        [StringLength(100)]
        public string Technique { get; set; } = "Змішана техніка";

        [StringLength(100)]
        public string Material { get; set; } = "Не вказано";

        [StringLength(3000, ErrorMessage = "Опис занадто довгий")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необхідно додати посилання на зображення")]
        [Url(ErrorMessage = "Введіть коректне URL-посилання на картинку")]
        public string ImageUrl { get; set; }


        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string CurrentStateName { get; set; } = "OnDisplay";

        [NotMapped]
        public IArtworkState State
        {
            get
            {
                return CurrentStateName switch
                {
                    "Archived" => new ArchivedState(),
                    "Restoration" => new UnderRestorationState(),
                    _ => new OnDisplayState()
                };
            }
        }

        public void ChangeState(IArtworkState newState)
        {
            CurrentStateName = newState.StateName;
        }

        public virtual string GetArtworkDetails()
        {
            return $"Твір: {Title}, Рік: {CreationYear}";
        }
    }
}