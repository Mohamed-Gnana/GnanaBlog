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
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserConfiguration(
            IDateService dateService,
            IPasswordHasher<User> passwordHasher)
        {
            _dateService = dateService;
            _passwordHasher = passwordHasher;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
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


            User admin = new User()
            {
                Id = "1",
                FirstName = "Moahmed",
                LastName = "Gnana",
                Email = "mohamedgnana@gnana.com",
                NormalizedEmail = "mohamedgnana@gnana.com",
                NormalizedUserName = "mohamedgnana@gnana.com",
                AvatarImagePath = "~/wwwroot/images/noavatar.jpeg",
                EmailConfirmed = true,
                IsAdmin = true
            };
            admin.UserName = admin.FirstName + admin.LastName;
            admin.PasswordHash = _passwordHasher.HashPassword(admin, "Pa$$w0rd");

            User luckyUser = new User()
            {
                Id = "2",
                FirstName = "Ahmed",
                LastName = "Gnana",
                Email = "ahmedgnana@gnana.com",
                NormalizedEmail = "ahmedgnana@gnana.com",
                NormalizedUserName = "ahmedgnana@gnana.com",
                AvatarImagePath = "~/wwwroot/images/noavatar.jpeg",
                EmailConfirmed = true,
                IsAdmin = true
            };
            luckyUser.UserName = luckyUser.FirstName + luckyUser.LastName;
            luckyUser.PasswordHash = _passwordHasher.HashPassword(luckyUser, "Pa$$w0rd");

            builder
                .HasData(
                    admin,
                    luckyUser
                );

        }
    }
}
