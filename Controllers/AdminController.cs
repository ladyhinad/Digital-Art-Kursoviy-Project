using Microsoft.AspNetCore.Mvc;
using Digital_Art_Kursoviy_Project.Data;
using Digital_Art_Kursoviy_Project.Services;
using Digital_Art_Kursoviy_Project.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Digital_Art_Kursoviy_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GalleryFacade _facade;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            _facade = new GalleryFacade(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var artworks = _context.Artworks.Include(a => a.Artist).ToList();
            var artists = _context.Artists.ToList();

            ViewBag.Artworks = artworks;
            ViewBag.Artists = artists;

            return View();
        }

        [HttpGet]
        public IActionResult CreateArtwork()
        {
            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CreateArtwork(string artworkType, string title, int year, string description, string imageUrl, int artistId, int categoryId, string technique)
        {
            if (year > DateTime.Now.Year || year < 1000)
            {
                return RedirectToAction("Index"); 
            }

            _facade.AddNewArtwork(artworkType, title, year, description, imageUrl, artistId, categoryId, technique);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateArtist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArtist(string fullName, int birthYear, int? deathYear, string contactInfo, string biography, string? photoUrl)
        {
            if (birthYear > DateTime.Now.Year || birthYear < 1000)
            {
                 return RedirectToAction("Index"); 
            }

            var artist = new Artist
            {
                FullName = fullName,
                BirthYear = birthYear,
                DeathYear = deathYear,
                ContactInfo = contactInfo,
                Biography = biography,
                PhotoUrl = photoUrl
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return RedirectToAction("CreateArtwork");
        }

        [HttpGet]
        public IActionResult EditArtwork(int id)
        {
            var artwork = _context.Artworks.FirstOrDefault(a => a.Id == id);
            if (artwork == null) return NotFound();

            ViewBag.Artists = _context.Artists.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            ViewBag.CurrentArtworkType = artwork.GetType().Name;

            return View(artwork);
        }

        
        [HttpPost]
        public IActionResult EditArtwork(int id, string title, int year, string description, string imageUrl, int artistId, int categoryId, string artworkType, string technique, string currentStateName)
        {
            if (year > DateTime.Now.Year || year < 1000)
            {
                 return RedirectToAction("Index"); 
            }

            var artwork = _context.Artworks.FirstOrDefault(a => a.Id == id);
            if (artwork == null) return NotFound();

            string currentType = artwork.GetType().Name;

            if (currentType == artworkType)
            {
                artwork.Title = title;
                artwork.CreationYear = year;
                artwork.Description = description;
                artwork.ArtistId = artistId;
                artwork.CategoryId = categoryId;
                artwork.Technique = technique;

                artwork.CurrentStateName = currentStateName;

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    artwork.ImageUrl = imageUrl;
                }

                _context.SaveChanges();
            }
            else
            {
                _context.Artworks.Remove(artwork);
                _context.SaveChanges();

                string finalUrl = string.IsNullOrEmpty(imageUrl) ? artwork.ImageUrl : imageUrl;
                _facade.AddNewArtwork(artworkType, title, year, description, finalUrl, artistId, categoryId, technique);

                var newArtwork = _context.Artworks.OrderByDescending(a => a.Id).FirstOrDefault();
                if (newArtwork != null)
                {
                    newArtwork.CurrentStateName = currentStateName;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteArtwork(int id)
        {
            var artwork = _context.Artworks.FirstOrDefault(a => a.Id == id);
            if (artwork != null)
            {
                _context.Artworks.Remove(artwork);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null) return NotFound();

            return View(artist);
        }

        [HttpPost]
        public IActionResult EditArtist(int id, string fullName, int birthYear, int? deathYear, string contactInfo, string biography, string? photoUrl)
        {
            if (birthYear > DateTime.Now.Year || birthYear < 1000)
            {
                 return RedirectToAction("Index"); 
            }

            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null) return NotFound();

            artist.FullName = fullName;
            artist.BirthYear = birthYear;
            artist.DeathYear = deathYear;
            artist.ContactInfo = contactInfo;
            artist.Biography = biography;
            artist.PhotoUrl = photoUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var adminUser = _context.Admininstrators.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (adminUser != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, adminUser.Username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Невірний логін або пароль адміністратора!";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}