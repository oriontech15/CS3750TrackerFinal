using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CS3750FinalTimeTracker.Pages
{
    public class TrackerModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public string jsonUsers;
        public string jsonTotalTime;

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

            List<string> UsersList = SQLlogic.GetUsersOfGroup((int)HttpContext.Session.GetInt32("groupId"));
            List<int> TotalTimeList = new List<int>();

            foreach (var un in UsersList)
            {
                TotalTimeList.Add(SQLlogic.getTotalTime(un));
            }

            jsonUsers = JsonSerializer.Serialize(UsersList);
            jsonTotalTime = JsonSerializer.Serialize(TotalTimeList);
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
