using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SIMSBDAL
{
    public class xSystem : cBase
    {
        public bool UserStat { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool flgUser { get; set; }

        public string SYSTART { get; set; }


        public string AppPrefix { get; set; }
        public string StudPrefix { get; set; }


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


        public void getMasterSetupDetails()
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                
                using (SqlCommand cmd = new SqlCommand("spDisplayMasterSetup", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //SY = cmd.ExecuteScalar().ToString();
                            AppPrefix = dr["applicant_prefix"].ToString();
                            StudPrefix = dr["Student_Prefix"].ToString();

                        }
                    }
                }
            }
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

        public DataTable DISPLAY_STRAND()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select StrandCode, StrandName from xSystem.Strand_RF order by ID";
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


        //Old-Student outstanding Balance Checker

        public Boolean checkOutstanding(string lastName, string firstName, string MI)
        {
            Boolean x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select lastName, firstname from xSystem.Uncleared_Dump where lastName=@lastName and firstname=@firstName and MI=@MI";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@MI", MI);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        x = true;
                    }

                    else

                    {
                        x = false;
                    }
                }
            }

            return x;
        }


        //DISPLAY TARGET STUDENT
        public DataTable DISPLAY_TARGETSTUDENTS(string _sy)
        {
            DataTable dt = new DataTable();
            //string strSQL = "spDisplayTargetStudents";
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayTargetStudents", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SY", _sy);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public bool CHECK_TARGETSTUDENTS(string _sy, string _leveltype, string _strandcode)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spCheckTargetStudents";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@LEVELTYPECODE", _leveltype);
                    cmd.Parameters.AddWithValue("@STRANDCODE", _strandcode);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        x = true;
                    }

                    else
                    {
                        x = false;
                    }
                }
            }

            return x;
        }

        #region "TRANSACTION/ DATA MANIPULATION SECTIONS"

        /*
         INSERT TARGET STUDENTS INPUT
         * 02/01/2016 - RUSSEL VASQUEZ
         */

        public void INSERT_TARGETSTUDENTS(string _sy, string _levelcatcode, string _leveltypecode, string _strandcode,
            int _regularcount, int _ssiccount, int _studentcount, string _remarks, string _userid)
        { 
        using (SqlConnection cn = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("spInsertTargetStudents", cn))
            {
                cn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SY", _sy);
                cmd.Parameters.AddWithValue("@LEVELCATCODE", _levelcatcode);
                cmd.Parameters.AddWithValue("@LEVELTYPECODE", _leveltypecode);
                cmd.Parameters.AddWithValue("@STRANDCODE", _strandcode);
                cmd.Parameters.AddWithValue("@REGULARCOUNT", _regularcount);
                cmd.Parameters.AddWithValue("@SSICCOUNT", _ssiccount);
                cmd.Parameters.AddWithValue("@STUDENTCOUNT", _studentcount);
                cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                cmd.Parameters.AddWithValue("@USERID", _userid);

             
                cmd.ExecuteNonQuery();


            }
            
            }
        }

        
        /*
         UPDATE TARGET STUDENTS
         * 02/01/2016 - RUSSEL VASQUEZ
         * */
      public void UPDATE_TARGETSTUDENTS(int _id, int _regularcount, int _ssiccount, int _studentcount, string _remarks, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateTargetStudents", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@REGULARCOUNT", _regularcount);
                    cmd.Parameters.AddWithValue("@SSICCOUNT", _ssiccount);
                    cmd.Parameters.AddWithValue("@STUDENTCOUNT", _studentcount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cmd.Parameters.AddWithValue("@USERID", _userid);


                    cmd.ExecuteNonQuery();


                }

            }
        }
        
      
    

        
        //SAP DATA ENTRY TESTING - 02/22/2016
      public void INSERT_SAP_BP(string _code, string _name, string _Ustudnum, string _Uname, string _Ulevel, string _Utype, string _Udescription, string _Usection,
                                 string _Uaction, string _Uprocessed, string _Uforprocess, string _UAccountCode)
      {
          using (SqlConnection cn = new SqlConnection(SAPCS))
          {
              // string sqlstr= string.Format("INSERT INTO {0}(Code,Name,U_StudentNo,U_Name,U_Type,U_Description,U_Section,U_Dunning,U_Action,U_Processed,U_ForProcess,U_Level) " +  
              //                "VALUES (@code,@name,@stud_num,@type,@desc,@sec,@dunning,@action,@process,@forprocess,@level)", "@FT_OCRD");
              //using (SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO [{0}](Code,Name,U_StudentNo,U_Name,U_Type,U_Description,U_Section,U_Dunning,U_Action,U_Processed,U_ForProcess,U_Level) " +
              //                "VALUES (@code,@name,@stud_num,@u_name,@type,@desc,@sec,@dunning,@action,@process,@forprocess,@level)", "@FT_OCRD"), cn))
              //{
              using (SqlCommand cmd = new SqlCommand("spSIMSInsertBP", cn))
              {
                  cn.Open();

                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CODE", _code);
                  cmd.Parameters.AddWithValue("@NAME", _name);
                  cmd.Parameters.AddWithValue("@U_STUDENTNO", _Ustudnum);
                  cmd.Parameters.AddWithValue("@U_NAME", _Uname);
                  cmd.Parameters.AddWithValue("@U_LEVEL", _Ulevel);
                  cmd.Parameters.AddWithValue("@U_TYPE", _Utype);
                  cmd.Parameters.AddWithValue("@U_DESCRIPTION", _Udescription);
                  cmd.Parameters.AddWithValue("@U_SECTION", _Usection);
                  cmd.Parameters.AddWithValue("@U_ACTION", _Uaction);
                  cmd.Parameters.AddWithValue("@U_PROCESSED", _Uprocessed);
                  cmd.Parameters.AddWithValue("@U_FORPROCESS", _Uforprocess);
                  cmd.Parameters.AddWithValue("@U_ACCTCODE", _UAccountCode);


                  cmd.ExecuteNonQuery();


              }

          }
      }


      public void UPDATE_SAP_BP(string _code, string _Ulevel, string _Usection, string _Uaction, string _Uprocessed, string _Uforprocess)
      {
          using (SqlConnection cn = new SqlConnection(SAPCS))
          {
              //string sqlstr= string.Format("INSERT INTO {0}(Code,Name,U_StudentNo,U_Name,U_Type,U_Description,U_Section,U_Dunning,U_Action,U_Processed,U_ForProcess,U_Level) " +  
              //               "VALUES (@code,@name,@stud_num,@type,@desc,@sec,@dunning,@action,@process,@forprocess,@level)", "@FT_OCRD");

              //using (SqlCommand cmd = new SqlCommand(string.Format("UPDATE [{0}] SET U_Level=@level,U_Section@section,U_Action=@action " +
              //                                                      "U_Processed=@processed, U_ForProcess=@forprocess WHERE Code=@Code", "@FT_OCRD"), cn))

              using (SqlCommand cmd = new SqlCommand("spSIMSUpdateBP", cn))
                {
                  cn.Open();

                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@CODE", _code);
                  cmd.Parameters.AddWithValue("@U_LEVEL", _Ulevel);
                  cmd.Parameters.AddWithValue("@U_SECTION", _Usection);
                  cmd.Parameters.AddWithValue("@U_ACTION", _Uaction);
                  cmd.Parameters.AddWithValue("@U_PROCESSED", _Uprocessed);
                  cmd.Parameters.AddWithValue("@U_FORPROCESS", _Uforprocess);

                  cmd.ExecuteNonQuery();
              }
          }
      }

      public void UPDATE_SAP_BP_SECTION(string _code, string _section)
      {
          using (SqlConnection cn = new SqlConnection(SAPCS))
          {
             using (SqlCommand cmd = new SqlCommand("spSIMSUpdateBP_SECTION", cn))
                    {
                      cn.Open();

                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@CODE", _code);
                      cmd.Parameters.AddWithValue("@U_SECTION", _section);

                      cmd.ExecuteNonQuery();
                  }
          }
      }


    //Refresh Enrollment list from SAP
      public void Execute_EnrollmentUpdate()
      {
          using (SqlConnection cn = new SqlConnection(CS))
          {
              using (SqlCommand cmd = new SqlCommand("spGenerateEnrolledStudentFromSAP", cn))
              {
                  cn.Open();
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.ExecuteNonQuery();
              }
          }
      }

      //Refresh Reservation list from SAP
      public void Execute_ReservationUpdate()
      {
          using (SqlConnection cn = new SqlConnection(CS))
          {
              using (SqlCommand cmd = new SqlCommand("spGenerateReserveStudentFromSAP", cn))
              {
                  cn.Open();
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.ExecuteNonQuery();
              }
          }
      }
        #endregion


    } //End of Class

    //LIST OF SETUP 
    public class xSetup : cBase
    { 
    
    }

}//End of NameSpace


