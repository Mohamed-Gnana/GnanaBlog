using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Artichles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Common.Date;

namespace Blog.Persistance.Artichles
{
    public class ArtichleConfiguration : IEntityTypeConfiguration<Artichle>
    {
        private readonly IDateService _dateService;

        public ArtichleConfiguration(IDateService dateService)
        {
            _dateService = dateService;
        }
        public void Configure(EntityTypeBuilder<Artichle> builder)
        {

            builder
                .HasKey(artichle => artichle.Id);

            builder
               .HasMany(artichle => artichle.Comments)
               .WithOne(comment => comment.Artichle)
               .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(artichle => artichle.Author)
                .WithMany(author => author.Artichles)
                .HasForeignKey(artichle => artichle.AuthorId);

            builder
                .HasMany(artichle => artichle.Categories)
                .WithMany(category => category.Artichles);

            builder
                .Property(artichle => artichle.Title)
                .IsRequired()
                .HasMaxLength(120);

            builder
                .Property(artichle => artichle.Content)
                .HasMaxLength(3000)
                .HasColumnType("ntext");

            builder
                .Property(artichle => artichle.AuthorId)
                .IsRequired();

            builder
                .Property(artichle => artichle.CreatedAt)
                .IsRequired();

            builder
                .Property(artichle => artichle.UpdatedAt)
                .IsRequired();

            builder
                .HasData(
                new Artichle()
                {
                    Id = 1,
                    Title = "Hello World",
                    Content = "Hi everyone, this is my first post in my blog",
                    CreatedAt = _dateService.GetDateTime(),
                    UpdatedAt = _dateService.GetDateTime(),
                    AuthorId = "1"
                }
                );

            builder
              .HasMany(artichle => artichle.Categories)
              .WithMany(category => category.Artichles)
              .UsingEntity(e => e.HasData(
                  new { ArtichlesId = 1, CategoriesId = 1 }
                  ));
        }
    }
}
