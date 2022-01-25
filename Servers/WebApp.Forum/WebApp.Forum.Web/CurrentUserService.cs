using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Common.Application.Contracts;

namespace WebApp.Forum.Web
{
    class CurrentUserService : ICurrentUser
    {
        public string UserId => throw new NotImplementedException();

        public IEnumerable<string> Roles => throw new NotImplementedException();
    }
}
