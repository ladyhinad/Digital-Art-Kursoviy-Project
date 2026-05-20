using System.Collections.Generic;
using System.Text;

namespace Digital_Art_Kursoviy_Project.Composites
{
    public class MenuComposite : IGalleryComponent
    {
        public string Title { get; set; }
        private List<IGalleryComponent> _children = new List<IGalleryComponent>();

        public MenuComposite(string title)
        {
            Title = title;
        }

        public void Add(IGalleryComponent component)
        {
            _children.Add(component);
        }

        public string RenderHtml()
        {
            var sb = new StringBuilder();

            sb.Append($"<li class='mb-2 mt-4 text-uppercase text-light' style='letter-spacing: 2px; font-size: 0.8rem; border-bottom: 1px solid rgba(255,255,255,0.1); padding-bottom: 5px;'>{Title}</li>");
            sb.Append("<ul class='list-unstyled ms-3 mt-2'>"); 

            foreach (var child in _children)
            {
                sb.Append(child.RenderHtml());
            }

            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}