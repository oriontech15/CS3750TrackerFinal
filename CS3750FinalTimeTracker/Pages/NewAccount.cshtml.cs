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


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //if (MenuItemObj.MenuItem.Id == 0) // means a brand new category
            //{

                //////Physically upload and save image

                ////string fileName = Guid.NewGuid().ToString();
                ////var uploads = Path.Combine(webRootPath, @"images\menuitems");
                ////var extension = Path.GetExtension(files[0].FileName);

                ////using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                ////{
                ////    files[0].CopyTo(fileStream);
                ////}

                //////save the string data path
                ////MenuItemObj.MenuItem.Image = @"\images\menuitems\" + fileName + extension;

                _unitOfWork.User.Add(UserObj.User);
            //}

            _unitOfWork.Save();
            return RedirectToPage("./Tracker");

        }

    }
}
