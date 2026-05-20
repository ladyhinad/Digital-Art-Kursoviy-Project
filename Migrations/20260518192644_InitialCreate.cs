using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital_Art_Kursoviy_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admininstrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admininstrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DeathYear = table.Column<int>(type: "INTEGER", nullable: true),
                    ContactInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Biography = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Technique = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentStateName = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    AIModelVersion = table.Column<string>(type: "TEXT", nullable: true),
                    GenerationPrompt = table.Column<string>(type: "TEXT", nullable: true),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    SoftwareUsed = table.Column<string>(type: "TEXT", nullable: true),
                    CanvasType = table.Column<string>(type: "TEXT", nullable: true),
                    CameraModel = table.Column<string>(type: "TEXT", nullable: true),
                    LensType = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialType = table.Column<string>(type: "TEXT", nullable: true),
                    WeightKg = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artworks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artworks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admininstrators",
                columns: new[] { "Id", "Email", "FullName", "IsSuperAdmin", "Password", "Username" },
                values: new object[] { 1, "admin@gallery.com", "Головний Куратор", true, "gallery2024", "admin" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Biography", "BirthYear", "ContactInfo", "DeathYear", "FullName", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, "Італійський вчений, винахідник, художник.", 1452, "Немає", 1519, "Леонардо да Вінчі", "https://upload.wikimedia.org/wikipedia/commons/b/ba/Leonardo_self.jpg" },
                    { 10, "Американська художниця, відома своїми глибокими та сюрреалістичними полотнами.", 1995, "rae.klein@art.com", null, "Rae Klein", "https://picsum.photos/seed/artist1/300/300" },
                    { 11, "Українська художниця, що створює містичні світи.", 1998, "maria.art@ukr.net", null, "Maria Prisyazhnuk", "https://picsum.photos/seed/artist2/300/300" },
                    { 12, "Майстриня емоційних портретів. Її роботи відрізняються деталізацією.", 1990, "nisha@boehm.art", null, "Nisha Boehm", "https://picsum.photos/seed/artist3/300/300" },
                    { 13, "Легендарна фотографиня. Працює зі світлом та тінню.", 1949, "contact@leibovitz.studio", null, "Енні Лейбовіц", "https://picsum.photos/seed/artist4/300/300" },
                    { 14, "Один із засновників сучасної скульптури.", 1840, "Музей Родена", 1917, "Огюст Роден", "https://picsum.photos/seed/artist5/300/300" },
                    { 15, "Штучний інтелект, навчений на мільйонах зображень.", 2022, "midjourney.com", null, "Midjourney v6", "https://picsum.photos/seed/artist6/300/300" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Центральний зал для змішаних виставок", "Головна експозиція", null },
                    { 2, "Простір традиційного образотворчого мистецтва", "Картини та полотна", null },
                    { 3, "Зал цифрових технологій, медіа-арту та ШІ", "Мультимедійна зона", null },
                    { 4, "Простір для скульптур та тривимірних об'єктів", "Зал об'ємних інсталяцій", null }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CanvasType", "CategoryId", "CreationYear", "CurrentStateName", "Description", "Discriminator", "ImageUrl", "Material", "Technique", "Title" },
                values: new object[,]
                {
                    { 20, 10, "Льон", 2, 2023, "OnDisplay", "Сюрреалістичний погляд на самотність і тишу.", "Painting", "https://picsum.photos/seed/art1/800/600", "Полотно", "Олія", "Silent Observer" },
                    { 21, 10, "Бавовна", 2, 2024, "OnDisplay", "Напруга і спокій в одному моменті.", "Painting", "https://picsum.photos/seed/art2/800/600", "Дерево", "Акрил", "The Red Ribbon" },
                    { 22, 12, "Льон", 2, 2022, "OnDisplay", "Роздуми про плинність часу.", "Painting", "https://picsum.photos/seed/art3/800/600", "Полотно", "Олія", "Echoes of Time" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CategoryId", "CreationYear", "CurrentStateName", "Description", "Discriminator", "ImageUrl", "Material", "Resolution", "SoftwareUsed", "Technique", "Title" },
                values: new object[,]
                {
                    { 23, 11, 3, 2025, "OnDisplay", "Цифровий сюрреалізм на межі сну і реальності.", "DigitalArt", "https://picsum.photos/seed/art4/800/600", "Digital", "3840x2160 (4K)", "Procreate", "Procreate", "Fragmented Reality" },
                    { 24, 11, 3, 2024, "Archived", "Візуалізація того, як машини бачать власні сни.", "DigitalArt", "https://picsum.photos/seed/art5/800/600", "Digital", "1920x1080 (Full HD)", "Adobe Photoshop", "Photoshop", "Cybernetic Dreams" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CameraModel", "CategoryId", "CreationYear", "CurrentStateName", "Description", "Discriminator", "ImageUrl", "LensType", "Material", "Technique", "Title" },
                values: new object[,]
                {
                    { 25, 13, "Leica M6", 1, 1999, "OnDisplay", "Класичний портрет.", "Photography", "https://picsum.photos/seed/art6/800/600", "35mm f/1.4", "Фотопапір", "Чорно-біла плівка", "Monochrome Portrait" },
                    { 26, 13, "Sony A7R IV", 1, 2010, "OnDisplay", "Гра світла і тіні у великому мегаполісі.", "Photography", "https://picsum.photos/seed/art7/800/600", "24-70mm f/2.8", "Digital", "Цифрова фотографія", "Urban Shadows" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CategoryId", "CreationYear", "CurrentStateName", "Description", "Discriminator", "ImageUrl", "Material", "MaterialType", "Technique", "Title", "WeightKg" },
                values: new object[,]
                {
                    { 27, 14, 4, 1904, "OnDisplay", "Символ людського інтелекту.", "Sculpture", "https://picsum.photos/seed/art8/800/600", "Бронза", "Метал", "Лиття", "The Thinker", 0.0 },
                    { 28, 14, 4, 1882, "Restoration", "Вічне кохання, застигле у камені.", "Sculpture", "https://picsum.photos/seed/art9/800/600", "Мармур", "Камінь", "Різьблення", "The Kiss", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "AIModelVersion", "ArtistId", "CategoryId", "CreationYear", "CurrentStateName", "Description", "Discriminator", "GenerationPrompt", "ImageUrl", "Material", "Technique", "Title" },
                values: new object[,]
                {
                    { 29, "Midjourney v6", 15, 3, 2026, "OnDisplay", "Генерація за мотивами кіберпанк-майбутнього.", "AIArt", "Cyberpunk city, neon lights", "https://picsum.photos/seed/art10/800/600", "Пікселі", "Text-to-Image", "Neon Genesis" },
                    { 30, "DALL-E 3", 15, 3, 2026, "OnDisplay", "Подорож у підсвідомість штучного інтелекту.", "AIArt", "Surreal landscape, melting clocks", "https://picsum.photos/seed/art11/800/600", "Пікселі", "Prompt Engineering", "Surreal Mindscape" },
                    { 31, "Stable Diffusion XL", 15, 3, 2026, "OnDisplay", "Спроба ШІ відтворити стиль ренесансу.", "AIArt", "Renaissance portrait of a lady", "https://picsum.photos/seed/art12/800/600", "Пікселі", "Stable Diffusion", "Echoes of Yesteryear" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_CategoryId",
                table: "Artworks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admininstrators");

            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
