using System.Collections.Generic;
using System.IO;
using Digital_Art_Kursoviy_Project.Data;
using Digital_Art_Kursoviy_Project.Models;
using Digital_Art_Kursoviy_Project.Core;
using Digital_Art_Kursoviy_Project.Builders;

namespace Digital_Art_Kursoviy_Project.Services
{
    public class GalleryFacade
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly Dictionary<string, ArtworkFactory> _factories;

        public GalleryFacade(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            _factories = new Dictionary<string, ArtworkFactory>
            {
                { "Painting", new PaintingFactory() },
                { "DigitalArt", new DigitalArtFactory() },
                { "Photography", new PhotographyFactory() },
                { "Sculpture", new SculptureFactory() },
                { "AIArt", new AIArtFactory() }
            };
        }

        public void AddNewArtwork(
            string artworkType,
            string title,
            int year,
            string description,
            string fileName,
            int artistId,
            int categoryId,
            string technique)
        {
            description = description ?? "";

            if (!_factories.TryGetValue(artworkType, out ArtworkFactory factory))
            {
                factory = new DigitalArtFactory();
            }

            Artwork emptyArtwork = factory.CreateArtwork();

            string finalImagePath;

            if (!string.IsNullOrEmpty(fileName) && fileName.StartsWith("http"))
            {
                finalImagePath = fileName;
            }
            else
            {
                string uploadPath = Digital_Art_Kursoviy_Project.Core.ConfigurationManager.Instance.UploadDirectoryPath;
                string webPath = uploadPath.Replace("wwwroot", "").Replace("wwwroot/", "");
                finalImagePath = Path.Combine(webPath, fileName).Replace("\\", "/");
            }

            ArtworkBuilder builder = new ArtworkBuilder(emptyArtwork);

            Artwork readyArtwork = builder
                .SetBasicInfo(title, year, description)
                .SetConnections(artistId, categoryId)
                .SetTechnique(technique)
                .SetImage(finalImagePath)
                .Build();

            _dbContext.Artworks.Add(readyArtwork);
            _dbContext.SaveChanges();
        }
    }
}