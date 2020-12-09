using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

            UserObj.userName = Request.Cookies["name"];
            UserObj.salt = SQLlogic.getSalt(UserObj.userName);
            UserObj.hash = "testHash";
            UserObj.GroupId = 5;
            //UserObj.hash = SQLlogic.getHash(UserObj.userName);
            //UserObj.GroupId = SQLlogic.getGroup(UserObj.userName);


            _unitOfWork.User.Add(UserObj);
            _unitOfWork.Save();

            return RedirectToPage("./Tracker");

        }

    }
}
