using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Artichles.Query.GetArtichlesList
{
    public interface IGetArtichlesListQuery
    {
        async Task<List<ArtichlesListModel>> Execute();
    }
}
