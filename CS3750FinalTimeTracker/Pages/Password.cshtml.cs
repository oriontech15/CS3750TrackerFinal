using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace CS3750FinalTimeTracker.Pages
{
    public class PasswordModel : PageModel
    {



        public IActionResult OnPost()
        {
           

            UserObj.User.salt = createSalt();

            HttpContext.Session.SetString("username", UserObj.User.userName);

            HttpContext.Session.SetString("username", UserObj.User.userName);
            HttpContext.Session.SetString("salt", UserObj.User.salt);

            _unitOfWork.User.Add(UserObj.User);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");

        }
    }
}
