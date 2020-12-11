using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CS3750FinalTimeTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        [BindProperty]
        public User UserObj { get; set; }

        public void OnGet()
        {

        }

        

        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("username", UserObj.userName);
            var userName = HttpContext.Session.GetString("username");


            //var hashObject = _unitOfWork.User.GetFirstOrDefault(u => u.hash == UserObj.hash).hash;
            //var saltObject = _unitOfWork.User.GetFirstOrDefault(u => u.salt == UserObj.salt).salt;
            //var groupObject = _unitOfWork.User.GetFirstOrDefault(u => u.salt == UserObj.salt).GroupId;


            var salt = SQLlogic.getSalt(userName);
            var hash = SQLlogic.getHash(userName);
            var group = SQLlogic.getGroup(userName);

            if (salt == null || hash == null)
            {
                //username does not exist then the browser needs to indicate the use account was not found
                return RedirectToPage("./Index");
            }

            UserObj.salt = salt;
            UserObj.hash = hash;
            UserObj.GroupId = group;



            HttpContext.Session.SetString("salt", UserObj.salt);
            HttpContext.Session.SetString("hash", UserObj.hash);
            HttpContext.Session.SetInt32("groupId", UserObj.GroupId);

         
            return RedirectToPage("./existPassword");
        }
    }
}
