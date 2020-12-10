using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace CS3750FinalTimeTracker.Pages
{
    public class TrackerModel : PageModel
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TrackerModel(IUnitOfWork unitOfwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfwork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<User> UserList { get; set; }

        [BindProperty]
        public User UserObj { get; set; }

        public void OnGet()
        {
            UserList = _unitOfWork.User.GetAll(null, null, "Group");
        }

        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            UserObj.userName = HttpContext.Session.GetString("username");
            UserObj.salt = HttpContext.Session.GetString("salt");
            UserObj.hash = HttpContext.Session.GetString("hash");
            UserObj.GroupId = (int)HttpContext.Session.GetInt32("groupId");
           

            _unitOfWork.User.Add(UserObj);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");

        }
    }
}
