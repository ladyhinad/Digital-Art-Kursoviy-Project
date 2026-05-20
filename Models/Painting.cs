using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Painting : Artwork
    {
        public string CanvasType { get; set; } 

        public override string GetArtworkDetails()
        {
            return base.GetArtworkDetails() + $", Полотно: {CanvasType}";
        }
    }
}