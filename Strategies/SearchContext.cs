using System.Linq;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Strategies
{
    public class SearchContext
    {
        private ISearchStrategy _strategy;

        public void SetStrategy(ISearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public IQueryable<Artwork> ExecuteSearch(IQueryable<Artwork> artworks, string query)
        {
            if (_strategy == null)
            {
                return artworks;
            }

            return _strategy.Search(artworks, query);
        }
    }
}