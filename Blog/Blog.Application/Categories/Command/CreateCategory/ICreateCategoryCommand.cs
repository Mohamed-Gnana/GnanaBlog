using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Categories.Command.CreateCategory
{
    public interface ICreateCategoryCommand
    {
        void Execute(CreateCategoryModel model);
    }
}
