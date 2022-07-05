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
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string SenderId { get; set; } = null!;
        public User Sender { get; set; } = null!;
        public string RecieverId { get; set; } = null!;
        public User Reciever { get; set; } = null!;

    }
}
