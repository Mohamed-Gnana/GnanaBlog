using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Common.Date;

namespace Blog.Persistance.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IDateService _dateService;

        public CategoryConfiguration(IDateService dateService)
        {
            _dateService = dateService;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(category => category.Id);

            builder
                .HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "SayingHello",
                    CreatedAt = _dateService.GetDateTime()
                }
                );

            builder
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(category => category.CreatedAt)
                .IsRequired();




        }
    }
}
