using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CS3750FinalTimeTracker;
using System.Text;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using System.Windows.Forms.HtmlElement;

namespace CS3750FinalTimeTracker.Pages
{
    public class TrackerModel : PageModel
    {
        public void OnGet()
        {
            // SQLlogic logicController = new SQLlogic();
            // List<DisplayUser> infoList = logicController.GetAllInfo("group1");

            // createTable(infoList);
        }

    //     public void createTable(List<DisplayUser> infoList) {

    //             StringBuilder sb = new StringBuilder();
    //             sb.Append("<table cellpadding='3' cellspacing='3' style='border: 1px solid #800000;font-size: 12pt;font-family:Arial'>");
    //             //Add Table Header
    //             sb.Append("<thead class='text-light bg-dark'>");
    //             sb.Append("<tr>");
    //             sb.Append("<th class=''>Start Time</th>");
    //             sb.Append("<th class=''>End Time</th>");
    //             sb.Append("<th class=''>Total Time</th>");
    //             sb.Append("<th class=''>Username</th>");
    //             sb.Append("<th class=''>Description</th>");
    //             sb.Append("</tr>");
    //             sb.Append("</thead>");
                
    //             //Add Table Rows
    //             sb.Append("<tbody>");
    //             foreach (DisplayUser displayUser in infoList) {
    //                 sb.Append("<tr>");
    //                 //Add Table Columns
    //                 sb.Append("<td>" + displayUser.startTime + "</td>");
    //                 sb.Append("<td>" + displayUser.endTime + "</td>");
    //                 sb.Append("<td>" + displayUser.totalTime + "</td>");
    //                 sb.Append("<td>" + displayUser.userName + "</td>");
    //                 sb.Append("<td>" + displayUser.description + "</td>");
    //                 sb.Append("</tr>");
    //             }
    //             sb.Append("</tbody>");
    //             sb.Append("</table>");
    //     }
    // }
    }
}
