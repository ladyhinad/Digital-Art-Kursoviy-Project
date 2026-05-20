using Microsoft.EntityFrameworkCore;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Administrator> Admininstrators { get; set; }

        public DbSet<Painting> Paintings { get; set; }
        public DbSet<DigitalArt> DigitalArts { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Sculpture> Sculptures { get; set; }
        public DbSet<AIArt> AIArts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator
                {
                    Id = 1,
                    Username = "admin",
                    Password = "gallery2024",
                    FullName = "Головний Куратор",
                    Email = "admin@gallery.com",
                    IsSuperAdmin = true
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Головна експозиція", Description = "Центральний зал для змішаних виставок" },
                new Category { Id = 2, Name = "Картини та полотна", Description = "Простір традиційного образотворчого мистецтва" },
                new Category { Id = 3, Name = "Мультимедійна зона", Description = "Зал цифрових технологій, медіа-арту та ШІ" },
                new Category { Id = 4, Name = "Зал об'ємних інсталяцій", Description = "Простір для скульптур та тривимірних об'єктів" }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, FullName = "Леонардо да Вінчі", BirthYear = 1452, DeathYear = 1519, ContactInfo = "Немає", Biography = "Італійський вчений, винахідник, художник.", PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/b/ba/Leonardo_self.jpg" },

                new Artist { Id = 10, FullName = "Rae Klein", BirthYear = 1995, ContactInfo = "rae.klein@art.com", Biography = "Американська художниця, відома своїми глибокими та сюрреалістичними полотнами.", PhotoUrl = "https://picsum.photos/seed/artist1/300/300" },
                new Artist { Id = 11, FullName = "Maria Prisyazhnuk", BirthYear = 1998, ContactInfo = "maria.art@ukr.net", Biography = "Українська художниця, що створює містичні світи.", PhotoUrl = "https://picsum.photos/seed/artist2/300/300" },
                new Artist { Id = 12, FullName = "Nisha Boehm", BirthYear = 1990, ContactInfo = "nisha@boehm.art", Biography = "Майстриня емоційних портретів. Її роботи відрізняються деталізацією.", PhotoUrl = "https://picsum.photos/seed/artist3/300/300" },
                new Artist { Id = 13, FullName = "Енні Лейбовіц", BirthYear = 1949, ContactInfo = "contact@leibovitz.studio", Biography = "Легендарна фотографиня. Працює зі світлом та тінню.", PhotoUrl = "https://picsum.photos/seed/artist4/300/300" },
                new Artist { Id = 14, FullName = "Огюст Роден", BirthYear = 1840, DeathYear = 1917, ContactInfo = "Музей Родена", Biography = "Один із засновників сучасної скульптури.", PhotoUrl = "https://picsum.photos/seed/artist5/300/300" },
                new Artist { Id = 15, FullName = "Midjourney v6", BirthYear = 2022, ContactInfo = "midjourney.com", Biography = "Штучний інтелект, навчений на мільйонах зображень.", PhotoUrl = "https://picsum.photos/seed/artist6/300/300" }
            );
            modelBuilder.Entity<Artwork>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Painting>("Painting")
                .HasValue<DigitalArt>("DigitalArt")
                .HasValue<Photography>("Photography")
                .HasValue<Sculpture>("Sculpture")
                .HasValue<AIArt>("AIArt")
                .HasValue<Artwork>("Artwork");

            modelBuilder.Entity<Painting>().HasData(
                new Painting { Id = 20, Title = "Silent Observer", CreationYear = 2023, Technique = "Олія", Material = "Полотно", Description = "Сюрреалістичний погляд на самотність і тишу.", ImageUrl = "https://picsum.photos/seed/art1/800/600", ArtistId = 10, CategoryId = 2, CurrentStateName = "OnDisplay", CanvasType = "Льон" },
                new Painting { Id = 21, Title = "The Red Ribbon", CreationYear = 2024, Technique = "Акрил", Material = "Дерево", Description = "Напруга і спокій в одному моменті.", ImageUrl = "https://picsum.photos/seed/art2/800/600", ArtistId = 10, CategoryId = 2, CurrentStateName = "OnDisplay", CanvasType = "Бавовна" },
                new Painting { Id = 22, Title = "Echoes of Time", CreationYear = 2022, Technique = "Олія", Material = "Полотно", Description = "Роздуми про плинність часу.", ImageUrl = "https://picsum.photos/seed/art3/800/600", ArtistId = 12, CategoryId = 2, CurrentStateName = "OnDisplay", CanvasType = "Льон" }
            );

            modelBuilder.Entity<DigitalArt>().HasData(
                new DigitalArt { Id = 23, Title = "Fragmented Reality", CreationYear = 2025, Technique = "Procreate", Material = "Digital", Description = "Цифровий сюрреалізм на межі сну і реальності.", ImageUrl = "https://picsum.photos/seed/art4/800/600", ArtistId = 11, CategoryId = 3, CurrentStateName = "OnDisplay", Resolution = "3840x2160 (4K)", SoftwareUsed = "Procreate" },
                new DigitalArt { Id = 24, Title = "Cybernetic Dreams", CreationYear = 2024, Technique = "Photoshop", Material = "Digital", Description = "Візуалізація того, як машини бачать власні сни.", ImageUrl = "https://picsum.photos/seed/art5/800/600", ArtistId = 11, CategoryId = 3, CurrentStateName = "Archived", Resolution = "1920x1080 (Full HD)", SoftwareUsed = "Adobe Photoshop" }
            );

            modelBuilder.Entity<Photography>().HasData(
                new Photography { Id = 25, Title = "Monochrome Portrait", CreationYear = 1999, Technique = "Чорно-біла плівка", Material = "Фотопапір", Description = "Класичний портрет.", ImageUrl = "https://picsum.photos/seed/art6/800/600", ArtistId = 13, CategoryId = 1, CurrentStateName = "OnDisplay", CameraModel = "Leica M6", LensType = "35mm f/1.4" },
                new Photography { Id = 26, Title = "Urban Shadows", CreationYear = 2010, Technique = "Цифрова фотографія", Material = "Digital", Description = "Гра світла і тіні у великому мегаполісі.", ImageUrl = "https://picsum.photos/seed/art7/800/600", ArtistId = 13, CategoryId = 1, CurrentStateName = "OnDisplay", CameraModel = "Sony A7R IV", LensType = "24-70mm f/2.8" }
            );

            modelBuilder.Entity<Sculpture>().HasData(
                new Sculpture { Id = 27, Title = "The Thinker", CreationYear = 1904, Technique = "Лиття", Material = "Бронза", Description = "Символ людського інтелекту.", ImageUrl = "https://picsum.photos/seed/art8/800/600", ArtistId = 14, CategoryId = 4, CurrentStateName = "OnDisplay", MaterialType = "Метал" },
                new Sculpture { Id = 28, Title = "The Kiss", CreationYear = 1882, Technique = "Різьблення", Material = "Мармур", Description = "Вічне кохання, застигле у камені.", ImageUrl = "https://picsum.photos/seed/art9/800/600", ArtistId = 14, CategoryId = 4, CurrentStateName = "Restoration", MaterialType = "Камінь" }
            );

            modelBuilder.Entity<AIArt>().HasData(
                new AIArt { Id = 29, Title = "Neon Genesis", CreationYear = 2026, Technique = "Text-to-Image", Material = "Пікселі", Description = "Генерація за мотивами кіберпанк-майбутнього.", ImageUrl = "https://picsum.photos/seed/art10/800/600", ArtistId = 15, CategoryId = 3, CurrentStateName = "OnDisplay", AIModelVersion = "Midjourney v6", GenerationPrompt = "Cyberpunk city, neon lights" },
                new AIArt { Id = 30, Title = "Surreal Mindscape", CreationYear = 2026, Technique = "Prompt Engineering", Material = "Пікселі", Description = "Подорож у підсвідомість штучного інтелекту.", ImageUrl = "https://picsum.photos/seed/art11/800/600", ArtistId = 15, CategoryId = 3, CurrentStateName = "OnDisplay", AIModelVersion = "DALL-E 3", GenerationPrompt = "Surreal landscape, melting clocks" },
                new AIArt { Id = 31, Title = "Echoes of Yesteryear", CreationYear = 2026, Technique = "Stable Diffusion", Material = "Пікселі", Description = "Спроба ШІ відтворити стиль ренесансу.", ImageUrl = "https://picsum.photos/seed/art12/800/600", ArtistId = 15, CategoryId = 3, CurrentStateName = "OnDisplay", AIModelVersion = "Stable Diffusion XL", GenerationPrompt = "Renaissance portrait of a lady" }
            );
        }
    }
}