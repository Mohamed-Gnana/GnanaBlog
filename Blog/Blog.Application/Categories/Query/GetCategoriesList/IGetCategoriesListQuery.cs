using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Categories.Query.GetCategoriesList
{
    public interface IGetCategoriesListQuery
    {
        List<CategoriesListModel> Execute();
    }
}
