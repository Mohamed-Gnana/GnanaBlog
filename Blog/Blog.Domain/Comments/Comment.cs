using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Artichles;
using Blog.Domain.Entity;
using Blog.Domain.Users;

namespace Blog.Domain.Comments
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string UserId { get; set; } = null!;
        public User? User { get; set; }
        public int ArtichleId { get; set; }
        public Artichle? Artichle { get; set; } = null!;
    }
}
