using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public class CreateAccountVM
    {

        public User User { get; set; }
        public IEnumerable<SelectListItem> GroupList { get; set; }

    }
}
