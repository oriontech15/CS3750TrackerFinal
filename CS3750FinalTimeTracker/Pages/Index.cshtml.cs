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
            var salt = SQLlogic.getSalt(UserObj.userName);
            var hash = SQLlogic.getHash(UserObj.userName);
            var group = SQLlogic.getGroup(UserObj.userName);


            if(salt == null || hash == null)
            {
                //username does not exist then the browser needs to indicate the use account was not found
                return RedirectToPage("./Index");
            }

            UserObj.salt = salt;
            UserObj.hash = hash;
            UserObj.GroupId = group;
           

            HttpContext.Session.SetString("username", UserObj.userName);
            HttpContext.Session.SetString("salt", UserObj.salt);
            HttpContext.Session.SetString("hash", UserObj.hash);
            HttpContext.Session.SetInt32("groupId", UserObj.GroupId);

         
            return RedirectToPage("./existPassword");
        }
    }
}
