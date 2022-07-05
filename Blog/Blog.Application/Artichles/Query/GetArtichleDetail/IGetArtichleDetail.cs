using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;

namespace Blog.Application.Artichles.Query.GetArtichleDetail
{
    public  interface IGetArtichleDetail
    {
        ArtichleDetailModel Execute(int id);
    }
}
