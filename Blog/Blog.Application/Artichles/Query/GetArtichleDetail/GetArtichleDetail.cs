using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Artichles.Query.GetArtichleDetail
{
    public class GetArtichleDetail : IGetArtichleDetail
    {
        private readonly IDatabaseService _databaseService;

        public GetArtichleDetail(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ArtichleDetailModel Execute(int id)
        {
            var artichle = _databaseService.Artichles
                .Where(a => a.Id == id)
                .Include(a => a.Comments)
                .Include(a => a.Categories)
                .Include(a => a.Author)
                .Select(a => new ArtichleDetailModel
                {
                    Id = a.Id,
                    Comments = a.Comments,
                    Categories = a.Categories,
                    Title = a.Title,
                    Content = a.Content,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    AuthorId = a.AuthorId,
                    AuthorName = a.Author.FirstName + a.Author.LastName,
                    AuthorAvatarImagePath = a.Author.AvatarImagePath
                })
                .Single();

            return artichle;
        }
    }
}
