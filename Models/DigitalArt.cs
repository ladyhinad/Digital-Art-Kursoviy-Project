using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class DigitalArt : Artwork
    {
        public string Resolution { get; set; } 
        public string SoftwareUsed { get; set; } 

        public override string GetArtworkDetails()
        {
            return base.GetArtworkDetails() + $", Програма: {SoftwareUsed}";
        }
    }
}