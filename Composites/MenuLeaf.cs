namespace Digital_Art_Kursoviy_Project.Composites
{
    public class MenuLeaf : IGalleryComponent
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public MenuLeaf(string title, string url)
        {
            Title = title;
            Url = url;
        }

        public string RenderHtml()
        {
            return $"<li class='mb-2'><a href='{Url}' class='text-decoration-none text-white-50 hover-white' style='transition: color 0.3s;'>{Title}</a></li>";
        }
    }
}