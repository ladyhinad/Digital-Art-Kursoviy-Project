using System.Collections.Generic;
using Digital_Art_Kursoviy_Project.Models;

namespace Digital_Art_Kursoviy_Project.Proxies
{
    public interface IArtworkProvider
    {
        List<Artwork> GetPublicArtworks();
    }
}