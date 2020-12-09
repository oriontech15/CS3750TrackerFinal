using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS3750FinalTimeTracker.Pages
{
    public class ObserverModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ObserverModel(IUnitOfWork unitOfwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfwork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public CreateAccountVM UserObj { get; set; }

        public IActionResult OnGet(int? id)
        {

            UserObj = new CreateAccountVM
            {
                User = new User(),
                GroupList = _unitOfWork.Group.GetGroupListForDropDown()
            };

            if (id != null) // edit a menu item
            {
                UserObj.User = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
                if (UserObj == null)
                {
                    return NotFound();
                }
            }

            return Page(); // refresh page call on Get again without id

        }


        public IActionResult OnPost()
        {
           



         
            return RedirectToPage("./Tracker");



        }
    }
}
