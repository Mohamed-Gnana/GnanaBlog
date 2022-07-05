using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Artichles;
using Blog.Domain.Users;
using Blog.Domain.Categories;

namespace Blog.Application.Artichles.Command.CreateArtichle.Factory
{
    public interface IArtichleFactory
    {
        Artichle Create(
            DateTime createdAt,
            User author,
            string title,
            string? content,
            ICollection<Category> categories);
    }
}
