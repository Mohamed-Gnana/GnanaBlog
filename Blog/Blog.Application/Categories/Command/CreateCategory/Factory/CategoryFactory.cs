using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Artichles;
using Blog.Domain.Categories;

namespace Blog.Application.Categories.Command.CreateCategory.Factory
{
    public class CategoryFactory : ICategoryFactory
    {
        public Category Create(
            DateTime createdAt,
            string categoryName)
        {
            var category = new Category();
            category.CreatedAt = createdAt;
            category.CategoryName = categoryName;
            category.Artichles = new List<Artichle>();
            return category;
        }
    }
}
