using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Categories.Query.GetCategoryProducts
{
    public class GetCategoryProductsQuery : IGetCategoryProductsQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetCategoryProductsQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public CategoryProductsModel Execute(int id)
        {
            var category = _databaseService.Categories
                .Where(c => c.Id == id)
                .Include(c => c.Artichles)
                .Select(c => new CategoryProductsModel
                {
                    Id = c.Id,
                    Name = c.CategoryName,
                    Artichles = c.Artichles
                })
                .Single();

            return category;
        }
    }
}
