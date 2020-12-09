using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS3750FinalTimeTracker.Pages
{
    public class CreateGroupModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGroupModel(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        [BindProperty]
        public Group GroupObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            GroupObj = new Group();

            if (id != null)
            {
                GroupObj = _unitOfWork.Group.GetFirstOrDefault(u => u.Id == id);
                if (GroupObj == null)
                {
                    return NotFound();
                }
            }

            return Page(); // refresh page call on Get again without id
        }

        public IActionResult OnPost()
        {
            _unitOfWork.Group.Add(GroupObj);
            _unitOfWork.Save();
            return RedirectToPage("./NewAccount");
        }
    }
}
