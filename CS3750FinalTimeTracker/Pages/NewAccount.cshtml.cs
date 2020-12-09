using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace CS3750FinalTimeTracker.Pages
{
    public class NewAccountModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public NewAccountModel(IUnitOfWork unitOfwork, IWebHostEnvironment hostingEnvironment)
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
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;



            _unitOfWork.User.Add(UserObj.User);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");

           

        }
    }
}
