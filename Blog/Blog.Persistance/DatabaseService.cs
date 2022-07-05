using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Domain.Artichles;
using Blog.Domain.Comments;
using Blog.Domain.Categories;
using Blog.Domain.Users;
using Blog.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Blog.Common.Date;

namespace Blog.Persistance
{
    public partial class DatabaseService : IdentityDbContext, IDatabaseService
    {
        private readonly string _connectionString = null!;
        private readonly IDateService _dateService;
        private readonly IPasswordHasher<User> _passwordHasher;
#nullable disable
        public DbSet<User> Users { get; set; }
        public DbSet<Artichle> Artichles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
#nullable enable

        public DatabaseService(
            DbContextOptions options,
            IDateService dateService,
            IPasswordHasher<User> passwordHasher,
            string connectionString = "Data Source=.;Database = GnanaBlog;Integrated Security=True;") : base(options)
        {
            _connectionString = connectionString;
            _dateService = dateService;
            _passwordHasher = passwordHasher;
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
