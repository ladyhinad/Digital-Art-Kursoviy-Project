using Digital_Art_Kursoviy_Project.Models;
using System;

namespace Digital_Art_Kursoviy_Project.Core
{
    public abstract class ArtworkFactory
    {
        public abstract Artwork CreateArtwork();

        public Artwork InitializeArtwork(string title, int year, string description)
        {
            Artwork artwork = CreateArtwork();

            artwork.Title = title;
            artwork.CreationYear = year;
            artwork.Description = description;

            return artwork;
        }
    }
}