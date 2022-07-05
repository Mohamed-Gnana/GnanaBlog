using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entity;
using Blog.Domain.Comments;
using Blog.Domain.Users;
using Blog.Domain.Categories;

namespace Blog.Domain.Artichles
{
    public class Artichle : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthorId { get; set; } = null!;
        public User Author { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        
    }
}
