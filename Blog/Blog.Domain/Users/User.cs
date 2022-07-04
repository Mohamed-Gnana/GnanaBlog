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
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public bool IsOnline { get; set; }
        public DateTime? LastLogin { get; set; }
        public ICollection<Artichle>? Artichles { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
