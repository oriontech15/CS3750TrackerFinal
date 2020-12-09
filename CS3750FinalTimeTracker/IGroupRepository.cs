using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<SelectListItem> GetGroupListForDropDown();

        void Update(Group group);

    }
}
