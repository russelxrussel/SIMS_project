using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SIMSBDAL
{
    public class userMenu: cBase 
    {

        public DataSet displayUserMenu(string _UserCode)
        {
            //DataSet ds = new DataSet();
            //string strSQL = "spUserMenuList";            
            //ds = queryCommandDS(strSQL);
            //return ds;

            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spUserMenuList", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserCode", _UserCode);
                

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }

            return ds;
        }


        public DataSet displayMenu()
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from xSystem.Menus", cn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@UserCode", _UserCode);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }

            return ds;
        }

    }
}
