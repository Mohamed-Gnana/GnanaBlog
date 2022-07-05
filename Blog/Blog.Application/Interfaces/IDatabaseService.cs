using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Artichles;
using Blog.Domain.Users;
using Blog.Domain.Comments;
using Blog.Domain.Messages;
using Blog.Domain.Categories;

namespace Blog.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Artichle> Artichles { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Message> Messages { get; set; }

        void Save();
    }
}
