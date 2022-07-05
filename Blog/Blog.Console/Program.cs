using Microsoft.EntityFrameworkCore;
using Blog.Persistance;
using Blog.Common.Date;
using Blog.Application.Interfaces;
using Blog.Application.Users;
using Blog.Domain.Categories;
using Blog.Application.Artichles.Command.CreateArtichle;
using Blog.Application.Artichles.Query.GetArtichlesList;
using Blog.Application.Artichles.Query.GetArtichleDetail;
using Blog.Application.Artichles.Command.CreateArtichle.Factory;
using Blog.Application.Categories.Command.CreateCategory;
using Blog.Application.Categories.Command.CreateCategory.Factory;
using Blog.Application.Categories.Query.GetCategoriesList;
using Blog.Domain.Users;
using Blog.Domain.Artichles;
using Microsoft.AspNetCore.Identity;
using static System.Console;


using (DatabaseService db = 
    new(
        new DbContextOptions<DatabaseService>(),
        new DateService(),
        new PasswordHasher<User>()))
{
    bool deleted = await db.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await db.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    ICreateArtichleCommand createArtichle = new CreateArtichleCommand(
            new DateService(),
            db,
            new ArtichleFactory(),
            new CreateCategoryCommand(
                    new DateService(),
                    db,
                    new CategoryFactory()
                )
        );

    createArtichle.Execute(
        new CreateArtichleModel
        {
            Title = "Hello C# Developers",
            Content = "Writing from Blog.Console",
            AuthorId = "1",
            Categories = "C# admin Asp.net"
        }
        );

    foreach(User user in db.Users.Include(user => user.Artichles))
    {
        WriteLine("{0} {1} created the following {2} artichles:",
        user.FirstName, user.LastName, user.Artichles.Count);

        foreach(Artichle artichle in user.Artichles)
        {
            WriteLine($"Artichle Title: {artichle.Title}");
            WriteLine($"Artichle Content: {artichle.Content}");
            foreach(Category category in artichle.Categories)
            {
                WriteLine($"Category Name: {category.CategoryName}");
            }
        }
    }

    IGetCategoriesListQuery categoriesQuery = new GetCategoriesListQuery(
        db
        );

    List<CategoriesListModel> categories = categoriesQuery.Execute();

    foreach(var category in categories)
    {
        WriteLine($"Category Name: {category.Name}");
        WriteLine($"Created at: {category.CreatedAt}");
    }
}