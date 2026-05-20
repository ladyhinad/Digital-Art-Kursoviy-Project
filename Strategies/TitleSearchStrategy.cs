using System;
using System.Linq;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Strategies
{
    public class TitleSearchStrategy : ISearchStrategy
    {
        public IQueryable<Artwork> Search(IQueryable<Artwork> artworks, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return artworks;

            var safeQuery = query.Trim();

            return artworks.AsEnumerable()
                .Where(a => !string.IsNullOrEmpty(a.Title) &&
                            a.Title.Contains(safeQuery, StringComparison.OrdinalIgnoreCase))
                .AsQueryable();
        }
    }
}