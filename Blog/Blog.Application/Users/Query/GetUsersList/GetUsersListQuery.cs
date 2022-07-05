using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Users.Query.GetUsersList
{
    public class GetUsersListQuery : IGetUsersListQuery
    {
        private readonly IDatabaseService _dataService;

        public GetUsersListQuery(IDatabaseService databaseService)
        {
            _dataService = databaseService;
        }

        public List<UsersListModel> Execute()
        {
            var users = _dataService.Users
                .OrderByDescending(user => user.Artichles.Count)
                .Include(user => user.Artichles)
                .Select(user => new UsersListModel
                {
                    Id = user.Id,
                    UserName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin,
                    IsOnline = user.IsOnline,
                    Artichles = user.Artichles
                });

            return users.ToList();
        }
    }
}
