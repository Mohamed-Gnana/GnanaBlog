using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Query.GetUsersList
{
    public interface IGetUsersListQuery
    {
        List<UsersListModel> Execute();
    }
}
