using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS3750FinalTimeTracker;

public class MakeStuffWork
{
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
