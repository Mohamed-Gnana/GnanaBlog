using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Application.Categories.Command.CreateCategory.Factory;
using Blog.Common.Date;
using Blog.Domain.Categories;
using Blog.Domain.Artichles;

namespace Blog.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
#nullable disable
        private readonly IDateService _dateService;
        private readonly IDatabaseService _databaseService;
        private readonly ICategoryFactory _categoryFactory;
#nullable enable

        public CreateCategoryCommand(
            IDateService dateService,
            IDatabaseService databaseService,
            ICategoryFactory categoryFactory)
        {
            _dateService = dateService;
            _databaseService = databaseService;
            _categoryFactory = categoryFactory;
        }

        public void Execute(CreateCategoryModel model)
        {
            DateTime categoryCreatedAt = _dateService.GetDateTime();
            string categoryName = model.CategoryName;

            Category category = _categoryFactory
                .Create(
                categoryCreatedAt,
                categoryName
                );

            _databaseService.Categories.Add(category);
            _databaseService.Save();
        }
    }
}
