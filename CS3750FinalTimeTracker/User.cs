using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS3750FinalTimeTracker;

public class User
{
    public string userName;
    public string salt;
    public string hash;
    public string group;
    public string startTime;
    public string endTime;
    public int totalTime;
    public string description;

    public User(string userName, string salt, string hash, string startTime, string endTime, int totalTime, string description)
    {
        this.userName = userName;
        this.salt = salt;
        this.hash = hash;
        this.startTime = startTime;
        this.endTime = endTime;
        this.totalTime = totalTime;
        this.description = description;
    }
}

