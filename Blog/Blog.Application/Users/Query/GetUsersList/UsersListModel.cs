using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Artichles;

namespace Blog.Application.Users.Query.GetUsersList
{
    public class UsersListModel
    {
        public string Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<Artichle> Artichles { get; set; } = null!;

    }
}
