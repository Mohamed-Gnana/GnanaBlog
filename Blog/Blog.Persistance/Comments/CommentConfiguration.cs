using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Common.Date;
using Blog.Domain.Comments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistance.Comments
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        private readonly IDateService _dateService;

        public CommentConfiguration(IDateService dateService)
        {
            _dateService = dateService;
        }

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(comment => comment.Id);

            builder
                .Property(comment => comment.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(comment => comment.CreatedAt)
                .IsRequired();

            builder
                .Property(comment => comment.UpdatedAt)
                .IsRequired();

            builder
                .Property(comment => comment.UserId)
                .IsRequired();

            builder
                .Property(comment => comment.ArtichleId)
                .IsRequired();

            builder
                .HasData(
                    new Comment()
                    {
                        Id = 1,
                        Content = "My first comment on my first post",
                        CreatedAt = _dateService.GetDateTime(),
                        UpdatedAt = _dateService.GetDateTime(),
                        UserId = "1",
                        ArtichleId = 1
                    }
                );
        }
    }
}
