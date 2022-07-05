using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Application.Artichles.Command.CreateArtichle.Factory;
using Blog.Common.Date;
using Blog.Domain.Artichles;
using Blog.Domain.Users;
using Blog.Domain.Categories;
using Blog.Application.Categories.Command.CreateCategory;

namespace Blog.Application.Artichles.Command.CreateArtichle
{
    public class CreateArtichleCommand : ICreateArtichleCommand
    {
#nullable disable
        private readonly IDateService _dateService;
        private readonly IDatabaseService _databaseService;
        private readonly IArtichleFactory _artichleFactory;
        private readonly ICreateCategoryCommand _createCategoryCommand;
#nullable enable

        public CreateArtichleCommand(
            IDateService dateService,
            IDatabaseService databaseService,
            IArtichleFactory artichleFactory,
            ICreateCategoryCommand createCategoryCommand)
        {
            _dateService = dateService;
            _databaseService = databaseService;
            _artichleFactory = artichleFactory;
            _createCategoryCommand = createCategoryCommand;
        }

        public void Execute(CreateArtichleModel model)
        {
            DateTime artichleCreatedAt = _dateService.GetDateTime();
            var author = _databaseService.Users
                .Single(user => user.Id == model.AuthorId);
            var title = model.Title;
            var content = model.Content;
            var categories = GetCategoriesFromString(model.Categories);

            Artichle artichle = _artichleFactory
                .Create(
                artichleCreatedAt,
                author,
                title,
                content,
                categories);

            _databaseService.Artichles.Add(artichle);
            _databaseService.Save();
        }

        private ICollection<Category> GetCategoriesFromString(string categoriesAsString)
        {
            ICollection<Category> categories = new List<Category>();
            string[] categoriesTitlesAsArray = GetCategoriesTitlesFromString(categoriesAsString);
            foreach(string title in categoriesTitlesAsArray)
            {
                string titleAsUpper = title.ToUpper();
#nullable disable
                Category category = _databaseService.Categories
                    .Where(c => c.CategoryName == titleAsUpper).FirstOrDefault();
#nullable enable

                if (category is null)
                {
                    _createCategoryCommand.Execute(
                        new CreateCategoryModel() { CategoryName = titleAsUpper });
#nullable disable
                    Category categoryAfterAdding = _databaseService.Categories
                        .Where(c => c.CategoryName == titleAsUpper).First();
#nullable enable
                    categories.Add(categoryAfterAdding);
                }
                else
                {
                    categories.Add(category);
                }
            }
            return categories;
        }
        private string[] GetCategoriesTitlesFromString(string categories)
        {
            return categories.Split();
        }
    }
}
