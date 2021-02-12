using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for nfDBSQLProvider
/// </summary>
public class wDBSQLProvider : wProviderBase
{
	    public List<wDetails> GetWList()
    {
        // Step 2 - Defining the connection object and open it
        using (SqlConnection conn = new SqlConnection(
        ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            conn.Open();

            // Step 3 - Defining the command
            //string cmdText = "SELECT * FROM tblTool";
            SqlCommand cmd = new SqlCommand("wGetW", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Step 4 - Initialize parameters - there is none


            // Step 5 - Execute the command/query and store in reader object
            IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // Step 6 - convert objects in reader to detail object list

            return GetWDetailsCollectionFromReader(reader);
        }

    }

        public wDetails wGetW(int id)
        {
            // Step 2 - Defining the connection object and open it
            using (SqlConnection conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].
              ConnectionString))
            {
                conn.Open();
                // Step 3 - Defining the command
                //string cmdText = "SELECT * FROM tblTool WHERE toolNr=@toolNr";
                SqlCommand cmd = new SqlCommand("wGetWById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Step 4 - Initialize parameters 
                cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                // Step 5 - Execute the command/query and store in reader object

                IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                // Step 6 - convert object in reader to detail object 

                if (reader.Read())
                    return GetWDetailsFromReader(reader);
                else
                    return null;
            }
        }
        public int wInsertW(int id, string image, Decimal price)
        {

            // Step 2 - Defining the connection object and open it

            using (SqlConnection conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();

                // Step 3 - Defining the command
                //string cmdText = "INSERT INTO tblTool(toolNr, toolDescription, quantity, price) VALUES(@toolNr, @toolDescription,@quantity,@price)";
                SqlCommand cmd = new SqlCommand("wInsertW", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Step 4 - Initialize parameters
                // Step 4.1 - Create Parameters
                SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@image",SqlDbType.VarChar, -1),
                new SqlParameter("@price", SqlDbType.Decimal)
            };
                // Step 4.2 - Store Values in Parameters
                sqlParams[0].Value = id;
                sqlParams[1].Value = image;
                sqlParams[2].Value = price;

                // Step 4.3 - Add Parameters to command
                cmd.Parameters.AddRange(sqlParams);

                // Step 5 - no data returned from database 
                // Step 6 - Execute the command/query 

                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateW(int id, string image, Decimal price)
        {

            // Step 2 - Defining the connection object and open it
            using (SqlConnection conn = new SqlConnection(
           ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();

                // Step 3 - Defining the command

                //string cmdText = "UPDATE tblTool SET toolDescription=@toolDescription, quantity=@quantity, price=@price  WHERE toolNr=@toolNr";
                SqlCommand cmd = new SqlCommand("wUpdateW", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Step 4 - Initialize parameters
                // Step 4.1 - Create Parameters

                SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@image",SqlDbType.VarChar, -1),
                new SqlParameter("@price", SqlDbType.Decimal),
                new SqlParameter("@id", SqlDbType.Int)
            };

                // Step 4.2 - Store Values in Parameters

                sqlParams[0].Value = image;
                sqlParams[1].Value = price;
                sqlParams[2].Value = id;

                // Step 4.3 - Add Parameters to command

                cmd.Parameters.AddRange(sqlParams);

                // Step 5 - no data returned from database (if any)
                // Step 6 - Execute the command/query 

                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteW(int id)
        {
            // Step 2 - Defining the connection object and open it

            using (SqlConnection conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();

                // Step 3 - Defining the command

                // string cmdText = "DELETE FROM tblTool WHERE toolNr=@toolNr";
                SqlCommand cmd = new SqlCommand("wDeleteW", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Step 4 - Initialize parameters
                // Step 4.1 - Create Parameters

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);

                // Step 4.2 - Store Values in Parameters

                param.Value = id;

                // Step 4.3 - Add Parameters to command

                cmd.Parameters.Add(param);

                // Step 5 - no data returned from database 
                // Step 6 - Execute the command/query 

                return cmd.ExecuteNonQuery();
            }

        }
}