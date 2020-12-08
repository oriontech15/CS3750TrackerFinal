using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CS3750FinalTimeTracker;

public class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "User Name")]
    public string userName { get; set; }

    public string salt { get; set; }

    public string hash { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string password { get; set; }

    [Required]
    [Display(Name = "Group Name")]

    public int GroupId { get; set; }

    //public string group;
    public string startTime { get; set; }

    public string endTime { get; set; }

    public int totalTime { get; set; }

    public string description { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group Group { get; set; }

    //public User(string userName, string salt, string hash, string startTime, string endTime, int totalTime, string description)
    //{
    //    this.userName = userName;
    //    this.salt = salt;
    //    this.hash = hash;
    //    this.startTime = startTime;
    //    this.endTime = endTime;
    //    this.totalTime = totalTime;
    //    this.description = description;
    //}
}

