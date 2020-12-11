using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using CS3750FinalTimeTracker;




public static class SQLlogic
{

    public static void InsertIntoFinal(String userName, String salt, String hash, String group, String startTime, String endTime, int totalTime, String description)
    {
        try
        {
            DataAccess.ExecuteNonQuery(SQLStatements.InsertLine(userName, salt, hash, group, startTime, endTime, totalTime, description));
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public static List<string> GetGroupNames()
    {
        try
        {
            int returnedLines;
            DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetGroupName(), out returnedLines);

            List<string> groups = new List<string>();

            foreach (DataRow id in ds.Tables[0].Rows)
            {
                String i = new String(id[0].ToString());
                groups.Add(i);
            }

            return groups;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public static int getTotalTime(string username)
    {
        try
        {
            string totaltime = DataAccess.ExecuteScalarSQL(SQLStatements.GetTotalTime(username));
            int totalTime;
            if (Int32.TryParse(totaltime, out totalTime))
            {
                return totalTime;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public static List<string> GetUsersOfGroup(int group)
    {
        try
        {
            int returnedLines;
            DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetUsersOfGroup(group), out returnedLines);

            List<string> users = new List<string>();

            foreach (DataRow id in ds.Tables[0].Rows)
            {
                String i = new String(id[0].ToString());
                users.Add(i);
            }

            return users;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    /// <summary>
    /// returns display info of a given group
    /// </summary>
    public static List<DisplayUser> GetAllInfo(String group)
    {
        try
        {
            int returnedLines;
            DataSet ds = DataAccess.ExecuteSQLStatement(SQLStatements.GetDisplayInfoOfGroup(group), out returnedLines);

            List<DisplayUser> userInfo = new List<DisplayUser>();

            foreach (DataRow id in ds.Tables[0].Rows)
            {
                DisplayUser i = new DisplayUser(id[0].ToString(), id[1].ToString(), id[2].ToString(), Convert.ToInt32(id[3]), id[4].ToString());
                userInfo.Add(i);
            }

            return userInfo;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public static string getHash(string username)
    {
        try
        {
            string hash = DataAccess.ExecuteScalarSQL(SQLStatements.GetHash(username));
            return hash;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    public static string getSalt(string username)
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

    public static int getGroup(string username)
    {
        try
        {
            string group = DataAccess.ExecuteScalarSQL(SQLStatements.GetGroup(username));
            int m = Int32.Parse(group);
            return m;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }
}

