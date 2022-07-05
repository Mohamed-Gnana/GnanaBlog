using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Blog.Domain.Users;
using Blog.Domain.Artichles;
using Blog.Domain.Comments;
using Blog.Domain.Categories;
using Blog.Domain.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Blog.Persistance.Artichles;
using Blog.Persistance.Categories;
using Blog.Persistance.Comments;
using Blog.Persistance.Messages;
using Blog.Persistance.Users;


namespace Blog.Persistance
{
    public partial class DatabaseService : IdentityDbContext, IDatabaseService
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArtichleConfiguration(_dateService));
            builder.ApplyConfiguration(new CategoryConfiguration(_dateService));
            builder.ApplyConfiguration(new UserConfiguration(_dateService, _passwordHasher));
            builder.ApplyConfiguration(new CommentConfiguration(_dateService));
            builder.ApplyConfiguration(new MessageConfiguration(_dateService));
            
        }

       
    }
}
