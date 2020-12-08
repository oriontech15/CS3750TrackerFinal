using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CS3750FinalTimeTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        //clicking log in button
        public bool logInClick()
        {
            //get username
            string myuser = "";
            //get salt of user name
            string mysalt = SQLlogic.getSalt(myuser);

            //do magic stuff in JS to hash it
            string magicJSHash = "";
            //get hash
            string myhash = SQLlogic.getHash(myuser);
            //check hash to js hash if matches return true
            if (magicJSHash == myhash)
                return true;
            else
                return false;
        }

        //return the salt
        public string validateLogInClick()
        {
            //get username
            string myuser = "";
            //get salt of user name
            string mysalt = SQLlogic.getSalt(myuser);
            return mysalt;
        }

        //gen a new salt on creating a user
        public string createUserClick()
        {
            return SQLlogic.genSalt();
        }
    }
}
