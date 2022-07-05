using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Categories;
using Blog.Domain.Artichles;

namespace Blog.Application.Categories.Command.CreateCategory.Factory
{
    public interface ICategoryFactory
    {
        Category Create(
            DateTime createdAt,
            string categoryName);
    }
}
