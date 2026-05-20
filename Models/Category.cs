using System.Collections.Generic;

namespace Digital_Art_Kursoviy_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();

        public virtual string GetCategoryTree(int depth = 0)
        {
            string indent = new string('-', depth * 2);
            string result = $"{indent}> {Name}\n";

            foreach (var subCategory in SubCategories)
            {
                result += subCategory.GetCategoryTree(depth + 1);
            }

            return result;
        }
    }
}