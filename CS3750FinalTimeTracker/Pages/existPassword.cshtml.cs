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
    public class ExistPasswordModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ExistPasswordModel(IUnitOfWork unitOfwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfwork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public CreateAccountVM UserObj { get; set; }

        public IActionResult OnPost()
        {
            var resultingHash = UserObj.User.hash;
            var savedHash = HttpContext.Session.GetString("hash"); 

            if(resultingHash == savedHash)
            {
                //server sets a session variable for the user account and sends a success message back to the browser so it can move to the tracker page
                return RedirectToPage("./Tracker");
            }

            else
            {
                // server must send back a failed password message and the client will display the failed password
                return RedirectToPage("./existPassword");
            }
        }
    }
}
