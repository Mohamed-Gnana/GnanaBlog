using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Common.Date;
using Blog.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Blog.Persistance.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IDateService _dateService;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public UserConfiguration(
            IDateService dateService,
            IPasswordHasher<IdentityUser> passwordHasher)
        {
            _dateService = dateService;
            _passwordHasher = passwordHasher;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(user => user.LastName)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(user => user.Email)
                .IsRequired();

            builder
                .HasMany(user => user.Artichles)
                .WithOne(artichle => artichle.Author);


            builder
                .HasMany(user => user.Comments)
                .WithOne(comment => comment.User);

            User admin = new User()
            {
                Id = "1",
                FirstName = "Moahmed",
                LastName = "Gnana",
                Email = "mohamedgnana@gnana.com",
                AvatarImagePath = "~/wwwroot/images/noavatar.jpeg",
                EmailConfirmed = true,
                IsAdmin = true
            };
            admin.PasswordHash = _passwordHasher.HashPassword(admin, "Pa$$w0rd");

            User luckyUser = new User()
            {
                Id = "2",
                FirstName = "Ahmed",
                LastName = "Gnana",
                Email = "ahmedgnana@gnana.com",
                AvatarImagePath = "~/wwwroot/images/noavatar.jpeg",
                EmailConfirmed = true,
                IsAdmin = true
            };
            luckyUser.PasswordHash = _passwordHasher.HashPassword(luckyUser, "Pa$$w0rd");

            builder
                .HasData(
                    admin,
                    luckyUser
                );

        }
    }
}
