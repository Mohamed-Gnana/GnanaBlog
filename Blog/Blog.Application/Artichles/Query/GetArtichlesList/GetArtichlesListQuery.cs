using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Artichles.Query.GetArtichlesList
{
    public class GetArtichleListQuery : IGetArtichlesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetArtichleListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<ArtichlesListModel> Execute()
        {
            var artichles = _databaseService.Artichles
                .Include(artichle => artichle.Comments)
                .Include(artichle => artichle.Categories)
                .Include(artichle => artichle.Author)
                .OrderByDescending(artichle => artichle.CreatedAt)
                .Select(artichle => new ArtichlesListModel
                {
                    Id = artichle.Id,
                    Title = artichle.Title,
                    Content = artichle.Content,
                    CreatedAt = artichle.CreatedAt,
                    UpdatedAt = artichle.UpdatedAt,
                    AuthorId = artichle.AuthorId,
                    AuthorName = artichle.Author.FirstName + artichle.Author.LastName,
                    AuthorAvatarImagePath = artichle.Author.AvatarImagePath,
                    Comments = artichle.Comments,
                    Categories = artichle.Categories
                });

            return artichles.ToList();

        }
    }
}
