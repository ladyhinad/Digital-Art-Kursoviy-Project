using Microsoft.AspNetCore.Mvc;
using Digital_Art_Kursoviy_Project.Data;
using Digital_Art_Kursoviy_Project.Composites;
using System.Linq;

namespace Digital_Art_Kursoviy_Project.ViewComponents
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SidebarMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var rootMenu = new MenuComposite("Головне меню");

            var typesComposite = new MenuComposite("Каталог напрямків");
            typesComposite.Add(new MenuLeaf("Класичний живопис", "/?searchType=type&searchQuery=Класичний живопис"));
            typesComposite.Add(new MenuLeaf("Цифрова графіка", "/?searchType=type&searchQuery=Цифрова графіка"));
            typesComposite.Add(new MenuLeaf("Фотографія", "/?searchType=type&searchQuery=Фотографія"));
            typesComposite.Add(new MenuLeaf("Скульптура", "/?searchType=type&searchQuery=Скульптура"));
            typesComposite.Add(new MenuLeaf("AI-Генерація", "/?searchType=type&searchQuery=AI-Генерація"));

            var artistsComposite = new MenuComposite("Митці (Нові надходження)");
            var topArtists = _context.Artists.OrderByDescending(a => a.Id).Take(10).ToList();

            foreach (var artist in topArtists)
            {
                artistsComposite.Add(new MenuLeaf(artist.FullName, $"/Home/ArtistProfile/{artist.Id}"));
            }

            var infoComposite = new MenuComposite("Інформація");
            infoComposite.Add(new MenuLeaf("Вхід для кураторів", "/Admin/Login"));

            rootMenu.Add(typesComposite);
            rootMenu.Add(artistsComposite);
            rootMenu.Add(infoComposite);

            string finalHtml = rootMenu.RenderHtml();

            return View("Default", finalHtml);
        }
    }
}