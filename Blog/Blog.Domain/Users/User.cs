using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entity;
using Blog.Domain.Artichles;
using Blog.Domain.Comments;
using Blog.Domain.Messages;
using Microsoft.AspNetCore.Identity;

namespace Blog.Domain.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsOnline { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AvatarImagePath { get; set; }
        public ICollection<Artichle> Artichles { get; set; } = new List<Artichle>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
