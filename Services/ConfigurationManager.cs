namespace Digital_Art_Kursoviy_Project.Core
{
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager _instance = null;
        private static readonly object _lock = new object();

        public string GalleryName { get; private set; }
        public string UploadDirectoryPath { get; private set; }
        public int ArtworksPerPage { get; private set; }
        public long MaxImageSizeBytes { get; private set; }

        private ConfigurationManager()
        {
            GalleryName = "Digital Art Gallery";
            UploadDirectoryPath = "wwwroot/images/artworks/";
            ArtworksPerPage = 12;
            MaxImageSizeBytes = 5242880;
        }

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigurationManager();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}