using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using CS3750FinalTimeTracker;

public class SQLStatements
{
    //insert a line to the dbo.Final table
    public static string InsertLine(String userName, String salt, String hash, String group, String startTime, String endTime, int totalTime, String description)
    {
        try
        {
            string sSQL = "Insert into dbo.User(userName, salt, hash, group, startTime, endTime, totalTime, description) " +
                "Values('" + userName + "', '" + salt + "', '" + hash + "', '" + group + "', '" + startTime + "', '" + endTime + "', " + totalTime + ", '" + description + "')";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns list of group names logic check
    public static string GetGroupName()
    {
        try
        {
            string sSQL = "select distinct(group) from dbo.User";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns total time by username logic check
    public static string GetTotalTime(String userName)
    {
        try
        {
            string sSQL = "select SUM(totalTime) from dbo.User group by '" + userName + "' where userName = '" + userName + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns list of users from a group logic check
    public static string GetUsersOfGroup(String group)
    {
        try
        {
            string sSQL = "select distinct(userName) from dbo.User where group = '" + group + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns list all info from a group logic check
    public static string GetDisplayInfoOfGroup(String group)
    {
        try
        {
            string sSQL = "select userName, startTime, endTime, totalTime, description from dbo.User where group = '" + group + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns hash for a username logic check
    public static string GetHash(String userName)
    {
        try
        {
            string sSQL = "select distinct(hash) from dbo.User where userName = '" + userName + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns salt for a username logic check
    public static string GetSalt(String userName)
    {
        try
        {
            string sSQL = "select distinct(salt) from dbo.User where userName = '" + userName + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }

    //returns group for a username 
    public static string GetGroup(String userName)
    {
        try
        {
            string sSQL = "select distinct(groupId) from dbo.User where userName = '" + userName + "'";
            return sSQL;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }
}

