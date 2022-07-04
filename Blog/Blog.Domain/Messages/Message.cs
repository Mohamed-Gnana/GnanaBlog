using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entity;
using Blog.Domain.Users;

namespace Blog.Domain.Messages
{
    public class Message : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string? Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public User? User { get; set; }
    }
}
