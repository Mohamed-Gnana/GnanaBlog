using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Domain.Comments;
using Blog.Domain.Categories;

namespace Blog.Application.Artichles.Query.GetArtichleDetail
{
    public class ArtichleDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string AuthorAvatarImagePath { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = null!;
        public ICollection<Category> Categories { get; set; } = null!;
    }
}
