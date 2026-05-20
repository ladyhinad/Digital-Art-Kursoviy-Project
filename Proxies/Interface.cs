using System;
using System.Collections.Generic;
using Digital_Art_Kursoviy_Project.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Digital_Art_Kursoviy_Project.Proxies
{
    public class CachedArtworkProvider : IArtworkProvider
    {
        private readonly IArtworkProvider _realProvider;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "PublicArtworksCache";

        public CachedArtworkProvider(IArtworkProvider realProvider, IMemoryCache cache)
        {
            _realProvider = realProvider;
            _cache = cache;
        }

        public List<Artwork> GetPublicArtworks()
        {
            if (!_cache.TryGetValue(CacheKey, out List<Artwork> artworks))
            {
                artworks = _realProvider.GetPublicArtworks();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                _cache.Set(CacheKey, artworks, cacheEntryOptions);
            }

            return artworks;
        }
    }
}