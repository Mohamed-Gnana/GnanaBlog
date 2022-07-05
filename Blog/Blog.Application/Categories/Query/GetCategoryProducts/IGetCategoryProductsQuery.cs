using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Categories.Query.GetCategoryProducts
{
    public interface IGetCategoryProductsQuery
    {
        CategoryProductsModel Execute(int id);
    }
}
