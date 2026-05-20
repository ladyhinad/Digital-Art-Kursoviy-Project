using System.Linq;

using Digital_Art_Kursoviy_Project.Models;



namespace Digital_Art_Kursoviy_Project.Strategies

{

    public interface ISearchStrategy

    {

        IQueryable<Artwork> Search(IQueryable<Artwork> artworks, string query);

    }

}