using System.Collections.Generic;
using System.Linq;
using Digital_Art_Kursoviy_Project.Models;
using Digital_Art_Kursoviy_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Digital_Art_Kursoviy_Project.Proxies
{
    public class DatabaseArtworkProvider : IArtworkProvider
    {
        private readonly ApplicationDbContext _context;

        public DatabaseArtworkProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Artwork> GetPublicArtworks()
        {
            return _context.Artworks
                .Include(a => a.Artist)
                .Where(a => a.CurrentStateName == "OnDisplay" || a.CurrentStateName == null)
                .OrderByDescending(a => a.Id)
                .ToList();
        }
    }
}