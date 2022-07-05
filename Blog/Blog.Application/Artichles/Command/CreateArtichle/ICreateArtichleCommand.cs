using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Artichles.Command.CreateArtichle
{
    public interface ICreateArtichleCommand
    {
        void Execute(CreateArtichleModel model);
    }
}
