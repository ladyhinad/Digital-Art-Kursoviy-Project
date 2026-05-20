using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Sculpture : Artwork
    {
        public string MaterialType { get; set; } 
        public double WeightKg { get; set; } 

        public override string GetArtworkDetails()
        {
            return base.GetArtworkDetails() + $", Матеріал: {MaterialType}, Вага: {WeightKg} кг";
        }
    }
}