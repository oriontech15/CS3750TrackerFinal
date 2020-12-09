using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS3750FinalTimeTracker.Pages
{
    public class TrackerModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public TrackerModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> UserList { get; set; }



        public void OnGet()
        {
            UserList = _unitOfWork.User.GetAll(null, null, "Group");
        }
    }
}
