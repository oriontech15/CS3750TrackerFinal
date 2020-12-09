using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using CS3750FinalTimeTracker;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Collections;




public class SQLlogic
{
    public ViewResult Tracker() {
        DisplayUser user1 = new DisplayUser{userName="orion", startTime="00:00:01", endTime="00:00:02", totalTime=1, description="TESTING"};
        DisplayUser user2 = new DisplayUser{userName="orion", startTime="00:00:01", endTime="00:00:02", totalTime=1, description="TESTING"};
        DisplayUser user3 = new DisplayUser{userName="orion", startTime="00:00:01", endTime="00:00:02", totalTime=1, description="TESTING"};

        IEnumerable<DisplayUser> list = new List<DisplayUser>{user1, user2, user3};
        // list.Add(user1);
        // list.Add(user2);
        // list.Add(user3);

        return View(list);
    }

    public List<string> GetGroupNames()
    {
        try
        {
            int returnedLines;
            DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetGroupName(), out returnedLines);

    // public List<string> GetGroupNames(String group)
    // {
    //     try
    //     {
    //         int returnedLines;
    //         DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetGroupName(group), out returnedLines);

    //         List<string> groups = new List<string>();

    //         foreach (DataRow id in ds.Tables[0].Rows)
    //         {
    //             String i = new String(id[0].ToString());
    //             groups.Add(i);
    //         }

    //         return groups;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
    //     }
    // }

    // public int getTotalTime(string username)
    // {
    //     try
    //     {
    //         string totaltime = DataAccess.ExecuteScalarSQL(SQLStatements.GetTotalTime(username));
    //         int totalTime;
    //         if (Int32.TryParse(totaltime, out totalTime))
    //         {
    //             return totalTime;
    //         }
    //         else
    //         {
    //             return 0;
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
    //     }
    // }

    // public List<string> GetUsersOfGroup(String group)
    // {
    //     try
    //     {
    //         int returnedLines;
    //         DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetUsersOfGroup(group), out returnedLines);

    //         List<string> users = new List<string>();

    //         foreach (DataRow id in ds.Tables[0].Rows)
    //         {
    //             String i = new String(id[0].ToString());
    //             users.Add(i);
    //         }

    //         return users;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
    //     }
    // }

    // /// <summary>
    // /// returns display info of a given group
    // /// </summary>
    // public List<DisplayUser> GetAllInfo(String group)
    // {
    //     try
    //     {
    //         int returnedLines;
    //         DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetDisplayInfoOfGroup(group), out returnedLines);

    //         List<DisplayUser> userInfo = new List<DisplayUser>();

    //         foreach (DataRow id in ds.Tables[0].Rows)
    //         {
    //             DisplayUser i = new DisplayUser(id[0].ToString(), id[1].ToString(), id[2].ToString(), Convert.ToInt32(id[3]), id[4].ToString());
    //             userInfo.Add(i);
    //         }

    //         return userInfo;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
    //     }
    // }

    public string getSalt(string username)
    {
        try
        {
            string salt = DataAccess.ExecuteScalarSQL(SQLStatements.GetSalt(username));
            return salt;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public string getGroup(string username)
    {
        try
        {
            string group = DataAccess.ExecuteScalarSQL(SQLStatements.GetGroup(username));
            return group;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }
}

