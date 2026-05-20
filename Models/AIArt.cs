using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class AIArt : Artwork
    {
        public string AIModelVersion { get; set; } 
        public string GenerationPrompt { get; set; } 

        public override string GetArtworkDetails()
        {
            return base.GetArtworkDetails() + $", Згенеровано в: {AIModelVersion}";
        }
    }
}