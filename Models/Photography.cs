using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Photography : Artwork
    {
        public string CameraModel { get; set; } 
        public string LensType { get; set; } 

        public override string GetArtworkDetails()
        {
            return base.GetArtworkDetails() + $", Камера: {CameraModel}";
        }
    }
}