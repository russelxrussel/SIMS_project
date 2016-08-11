using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SIMSBDAL
{
    public class xSystem : cBase
    {
        public bool UserStat { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool flgUser { get; set; }

        public string SYSTART { get; set; }


        public string getPassword(string USERID)
        {
            string Password = "";

            //try
            //{
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select UserId, Uname, Status, Password from xSystem.UserCredentials_RF where UserId = '" + USERID + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        flgUser = true;
                        while (dr.Read())
                        {
                            Password = dr["Password"].ToString();
                            UserStat = (bool)dr["Status"];
                            UserName = dr["Uname"].ToString();
                            UserId = dr["UserId"].ToString();
                        }

                    }

                    else

                    {
                        flgUser = false;
                        Password = "";
                    }
                }
            }


            return Password;

        }


        //Get the Date of SQL Server..
        public DateTime GetServerDate()
        {
            DateTime serverDate;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select getdate()";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    serverDate = (DateTime)cmd.ExecuteScalar();
                }
            }

            return serverDate;
            
        }

        public string GetActiveSY()
        {
            string SY = "";

          using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select SYStart, SYDesc from xSystem.SchoolYear_RF where Status = '" + true + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //SY = cmd.ExecuteScalar().ToString();
                            SY = dr["SYDesc"].ToString();
                            SYSTART = dr["SYStart"].ToString();
                        
                        }
                    }
                }
            }

            return SY;
            
        }
     


        public bool existTargetApplicant(string SY, string LEVELTYPECODE)
        {
            bool x = false;

              using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select SY, LevelTypeCode from xSystem.TargetStudents_MF where SY = '" + SY + "' and LevelTypeCode = '" + LEVELTYPECODE + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        x = true;

                    }
                    else
                    { x = false; }
                }
              }


              return x;
        
        }

        //Getting Applicant Type list from database
        public DataTable getLevelCategory()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select LevelCatCode, LevelCatDesc from xSystem.LevelCategory_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        }


        //Getting Applicant Level Applying
        public DataTable getApplicantLevel()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select LevelTypeCode, LevelTypeDesc from xSystem.LevelType_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        }

        //OverLoaded
        public DataTable getApplicantLevel(string LEVELCATEGORY)
        {
            DataTable dt = new DataTable();
            string strSQL = "Select LevelTypeCode, LevelTypeDesc from xSystem.LevelType_RF where levelCatCode='" + LEVELCATEGORY + "' order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        }


        //Get Target Applicant Total
        public DataTable getTargetApplicant()
        {
             DataTable dt = new DataTable();
            string strSQL = "Select * from xSystem.TargetStudents_MF";
            dt = queryCommandDT(strSQL);
            return dt;
        }

        //Get Slot Details Total
        //Special Stored Procedure because of Parameter

        public DataTable getSlotDetails(string SY)
        {

            string strSQL = "spSlotDetails";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SY", SY);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable getCountApplicant()
        {
            DataTable dt = new DataTable();
            string strSQL = "spCountCurrentApplicant";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;            
        }
       

    } //End of Class

}//End of NameSpace


