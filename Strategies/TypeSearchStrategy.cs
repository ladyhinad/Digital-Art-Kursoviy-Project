using System;
using System.Linq;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Strategies
{
    public class TypeSearchStrategy : ISearchStrategy
    {
        private string GetUkrainianTypeName(string className)
        {
            return className switch
            {
                "Painting" => "Класичний живопис",
                "DigitalArt" => "Цифрова графіка",
                "Photography" => "Фотографія",
                "Sculpture" => "Скульптура",
                "AIArt" => "AI-Генерація",
                _ => className
            };
        }

        public IQueryable<Artwork> Search(IQueryable<Artwork> artworks, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return artworks;

            var safeQuery = query.Trim();

            return artworks.AsEnumerable()
                .Where(a =>
                {
                    string engName = a.GetType().Name;
                    string ukrName = GetUkrainianTypeName(engName);

                    return ukrName.Contains(safeQuery, StringComparison.OrdinalIgnoreCase) ||
                           engName.Contains(safeQuery, StringComparison.OrdinalIgnoreCase);
                })
                .AsQueryable();
        }
    }
}