using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Builders
{
    public class ArtworkBuilder : IArtworkBuilder
    {
        private Artwork _artwork;

        public ArtworkBuilder(Artwork emptyArtwork)
        {
            _artwork = emptyArtwork;
        }

        public IArtworkBuilder SetBasicInfo(string title, int year, string description)
        {
            _artwork.Title = title;
            _artwork.CreationYear = year;
            _artwork.Description = description;

            return this; 
        }

        public IArtworkBuilder SetConnections(int artistId, int categoryId)
        {
            _artwork.ArtistId = artistId;
            _artwork.CategoryId = categoryId;

            return this;
        }

        public IArtworkBuilder SetImage(string imageUrl)
        {
            _artwork.ImageUrl = imageUrl;

            return this;
        }

        public Artwork Build()
        {
            return _artwork; 
        }
        public IArtworkBuilder SetTechnique(string technique)
        {
            _artwork.Technique = technique;
            return this;
        }
    }
}