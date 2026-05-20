using Microsoft.AspNetCore.Mvc;
using Digital_Art_Kursoviy_Project.Data;
using Digital_Art_Kursoviy_Project.Strategies;
using Digital_Art_Kursoviy_Project.Proxies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory; 
using System.Linq;

namespace Digital_Art_Kursoviy_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public HomeController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache; 
        }

        [HttpGet]
        public IActionResult Index(string searchType, string searchQuery)
        {
            ViewBag.GalleryName = "Aura Gallery";

            IArtworkProvider realProvider = new DatabaseArtworkProvider(_context);

            IArtworkProvider proxyProvider = new CachedArtworkProvider(realProvider, _cache);

            var artworksQuery = proxyProvider.GetPublicArtworks().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery) && !string.IsNullOrWhiteSpace(searchType))
            {
                var searchContext = new SearchContext();

                switch (searchType.ToLower())
                {
                    case "author":
                        searchContext.SetStrategy(new AuthorSearchStrategy());
                        break;
                    case "technique":
                        searchContext.SetStrategy(new TechniqueSearchStrategy());
                        break;
                    case "title":
                        searchContext.SetStrategy(new TitleSearchStrategy());
                        break;
                    case "type":
                        searchContext.SetStrategy(new TypeSearchStrategy());
                        break;
                }

                artworksQuery = searchContext.ExecuteSearch(artworksQuery, searchQuery);
            }

            ViewBag.CurrentSearchType = searchType;
            ViewBag.CurrentSearchQuery = searchQuery;

            return View(artworksQuery.ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var artwork = _context.Artworks
                .Include(a => a.Artist)
                .Include(a => a.Category)
                .FirstOrDefault(a => a.Id == id);

            if (artwork == null)
                return NotFound();

            return View(artwork);
        }

        [HttpGet]
        public IActionResult ArtistProfile(int id)
        {
            var artist = _context.Artists
                .Include(a => a.Artworks)
                .FirstOrDefault(a => a.Id == id);

            if (artist == null)
                return NotFound();

            return View(artist);
        }
    }
}