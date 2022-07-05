using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Users;
using Blog.Domain.Categories;

namespace Blog.Application.Artichles.Command.CreateArtichle
{
    public class CreateArtichleModel
    {
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public string AuthorId { get; set; } = null!;
        public string Categories { get; set; } = null!;

    }
}
