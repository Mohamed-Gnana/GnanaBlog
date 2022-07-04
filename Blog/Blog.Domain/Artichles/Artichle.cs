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
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Title { get; set; } = null!;
        [Column(TypeName = "ntext")]
        [StringLength(3000)]
        public string? Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public User? Author { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        [Required]
        public ICollection<Category>? Categories { get; set; }
        
    }
}
