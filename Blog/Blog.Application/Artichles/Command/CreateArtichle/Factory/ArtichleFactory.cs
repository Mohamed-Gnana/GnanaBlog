using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Artichles;
using Blog.Domain.Users;
using Blog.Domain.Categories;
using Blog.Domain.Comments;

namespace Blog.Application.Artichles.Command.CreateArtichle.Factory
{
    public class ArtichleFactory : IArtichleFactory
    {
        public Artichle Create(
            DateTime createdAt,
            User author, 
            string title, 
            string? content, 
            ICollection<Category> categories)
        {
            Artichle artichle = new();
            artichle.CreatedAt = createdAt;
            artichle.UpdatedAt = createdAt;
            artichle.Title = title;
            artichle.Content = content;
            artichle.AuthorId = author.Id;
            artichle.Author = author;
            artichle.Comments = new List<Comment>();
            artichle.Categories = categories;

            return artichle;
        }
    }
}
