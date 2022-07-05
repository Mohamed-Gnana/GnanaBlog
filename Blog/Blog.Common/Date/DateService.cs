using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Common.Date
{
    public class DateService : IDateService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
