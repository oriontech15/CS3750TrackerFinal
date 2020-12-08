using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public interface IUserRepository : IRepository<User>
    {
        //IEnumerable<SelectListItem> GetUserListForDropDown();

        void Update(User user);
    }
}
