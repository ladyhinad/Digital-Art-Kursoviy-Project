using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Builders
{
    public interface IArtworkBuilder
    {
        IArtworkBuilder SetBasicInfo(string title, int year, string description);
        IArtworkBuilder SetConnections(int artistId, int categoryId);
        IArtworkBuilder SetImage(string imageUrl);
        IArtworkBuilder SetTechnique(string technique);

        Artwork Build();
    }
}