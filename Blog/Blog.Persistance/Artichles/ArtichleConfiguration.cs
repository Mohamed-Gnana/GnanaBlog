using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Artichles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistance.Artichles
{
    public class ArtichleConfiguration : IEntityTypeConfiguration<Artichle>
    {
        public void Configure(EntityTypeBuilder<Artichle> builder)
        {

            builder
                .HasKey(artichle => artichle.Id);

            builder
               .HasMany(artichle => artichle.Categories)
               .WithMany(category => category.Artichles)
               .UsingEntity(e => e.HasData(
                   new { ArtichlesArtichleId = 1, CategoriesCategoryId = 1 }
                   ));

            builder
               .HasMany(artichle => artichle.Comments)
               .WithOne(comment => comment.Artichle);

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
        }
    }
}
