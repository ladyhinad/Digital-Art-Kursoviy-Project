using Digital_Art_Kursoviy_Project.Core;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Services
{
    public class DigitalArtFactory : ArtworkFactory
    {
        public override Artwork CreateArtwork() => new DigitalArt();
    }

    public class PaintingFactory : ArtworkFactory
    {
        public override Artwork CreateArtwork() => new Painting();
    }

    public class PhotographyFactory : ArtworkFactory
    {
        public override Artwork CreateArtwork() => new Photography();
    }

    public class SculptureFactory : ArtworkFactory
    {
        public override Artwork CreateArtwork() => new Sculpture();
    }

    public class AIArtFactory : ArtworkFactory
    {
        public override Artwork CreateArtwork() => new AIArt();
    }
}