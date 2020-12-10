using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace CS3750FinalTimeTracker.Pages
{
    public class PasswordModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PasswordModel(IUnitOfWork unitOfwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfwork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public CreateAccountVM UserObj { get; set; }

        public IActionResult OnPost()
        {
           
            HttpContext.Session.SetString("hash", UserObj.User.hash);

            UserObj.User.userName = HttpContext.Session.GetString("username");
            //UserObj.User.GroupId = (int)HttpContext.Session.GetInt32("groupID");
         
            _unitOfWork.User.Add(UserObj.User);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");
        }
    }
}
