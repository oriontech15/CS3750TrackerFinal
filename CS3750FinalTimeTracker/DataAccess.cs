﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CS3750FinalTimeTracker;

/// <summary>
/// Class used to access the database.
/// </summary>
public static class DataAccess
{
    /// <summary>
    /// Connection string to the database.
    /// </summary>
    private static string sConnectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

    /// <summary>
    /// This method takes an SQL statment that is passed in and executes it.  The resulting values
    /// are returned in a DataSet.  The number of rows returned from the query will be put into
    /// the reference parameter iRetVal.
    /// </summary>
    /// <param name="sSQL">The SQL statement to be executed.</param>
    /// <param name="iRetVal">Reference parameter that returns the number of selected rows.</param>
    /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
    public static DataSet ExecuteSQLStatement(string sSQL, out int iRetVal)
    {
        try
        {
            //Create a new DataSet
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(sConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {

                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    adapter.SelectCommand = new SqlCommand(sSQL, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    //Fill up the DataSet with data
                    adapter.Fill(ds);
                }
            }

            //Set the number of values returned
            iRetVal = ds.Tables[0].Rows.Count;

            //return the DataSet
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    /// <summary>
    /// This method takes an SQL statment that is passed in and executes it.  The resulting single 
    /// value is returned.
    /// </summary>
    /// <param name="sSQL">The SQL statement to be executed.</param>
    /// <returns>Returns a string from the scalar SQL statement.</returns>
    public static string ExecuteScalarSQL(string sSQL)
    {
        try
        {
            //Holds the return value
            object obj;

            using (SqlConnection conn = new SqlConnection(sConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {

                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    adapter.SelectCommand = new SqlCommand(sSQL, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    //Execute the scalar SQL statement
                    obj = adapter.SelectCommand.ExecuteScalar();
                }
            }

            //See if the object is null
            if (obj == null)
            {
                //Return a blank
                return "";
            }
            else
            {
                //Return the value
                return obj.ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    /// <summary>
    /// This method takes an SQL statment that is a non query and executes it.
    /// </summary>
    /// <param name="sSQL">The SQL statement to be executed.</param>
    /// <returns>Returns the number of rows affected by the SQL statement.</returns>
    public static int ExecuteNonQuery(string sSQL)
    {
        try
        {
            //Number of rows affected
            int iNumRows;

            using (SqlConnection conn = new SqlConnection(sConnectionString))
            {
                //Open the connection to the database
                conn.Open();

                //Add the information for the SelectCommand using the SQL statement and the connection object
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.CommandTimeout = 0;

                //Execute the non query SQL statement
                iNumRows = cmd.ExecuteNonQuery();
            }

            //return the number of rows affected
            return iNumRows;
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }
}
