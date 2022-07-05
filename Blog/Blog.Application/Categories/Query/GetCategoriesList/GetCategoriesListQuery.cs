using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Categories.Query.GetCategoriesList
{
    public class GetCategoriesListQuery : IGetCategoriesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetCategoriesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<CategoriesListModel> Execute()
        {
            var categories = _databaseService.Categories
                .OrderByDescending(category => category.CreatedAt)
                .Include(category => category.Artichles)
                .Select(category => new CategoriesListModel
                {
                    Id = category.Id,
                    Name = category.CategoryName,
                    CreatedAt = category.CreatedAt,
                    Artichles = category.Artichles,
                });

            return categories.ToList();
        }
    }
}
