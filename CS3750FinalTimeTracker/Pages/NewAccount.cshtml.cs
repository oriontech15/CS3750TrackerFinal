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
using System.Security.Cryptography;

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

        public string createSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];

            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            return salt;
        }

        public IActionResult OnPost()
        {
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //var files = HttpContext.Request.Form.Files;
         
            UserObj.User.salt = createSalt();

            //UserObj.User.hash = Request.Cookies["hashedPassword"];
            //UserObj.User.hash = Request.Form["hdnHash"].ToString();
            //UserObj.User.hash = hdnHash.Value; 

            _unitOfWork.User.Add(UserObj.User);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");

        }
    }
}
