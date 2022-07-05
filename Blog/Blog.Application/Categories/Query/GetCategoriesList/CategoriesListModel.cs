using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Artichles;

namespace Blog.Application.Categories.Query.GetCategoriesList
{
    public class CategoryListModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public ICollection<Artichle> Artichles { get; set; } = null!;
    }
}
