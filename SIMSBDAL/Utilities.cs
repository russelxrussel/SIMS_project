using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

//To Get Web Tools
using System.Web.UI;
//using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SIMSBDAL
{

    public class Utilities: cBase
    {
      //  string CS = ConfigurationManager.ConnectionStrings["CSSIMS"].ToString();

        private DataSet queryCommand(string sqlQuery)

        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
            }

            return ds;
        }


        public DataSet getTest() {

            DataSet ds = new DataSet();
            string strC = "Select * from Utilities.CityProvince_RF Order by Arr";
            ds = queryCommand(strC);

            return ds;
        }

        //Getting Applicant Type list from database
        public DataTable getApplicantType()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select AppTypeCode, AppTypeDesc from xSystem.ApplicantType_RF order by ID";
            dt = queryCommandDT(strSQL);

            return dt;
        }


        //OverWrite Parameter with drop down.
        public void getApplicantType(DropDownList dd)
        {
            DataTable dt = getApplicantType();

            dd.DataSource = dt;
            dd.DataTextField = dt.Columns["AppTypeDesc"].ToString();
            dd.DataValueField = dt.Columns["AppTypeCode"].ToString();
            dd.DataBind();
        }


        //Getting Applicant Level Applying
        public DataTable getApplicantLevel()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select LevelTypeCode, LevelTypeDesc from xSystem.LevelType_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        }

        //Overide with Drop Down Parameter Applicant Level
        public void getApplicantLevel(DropDownList dd)
        {
            DataTable dt = getApplicantLevel();

            dd.DataSource = dt;
            dd.DataTextField = dt.Columns["LevelTypeDesc"].ToString();
            dd.DataValueField = dt.Columns["LevelTypeCode"].ToString();
            dd.DataBind();

           
        }

        //Getting Applicant Strand for Grade 11 to 12
        public DataTable GET_LEVEL_STRAND()
        { 
            DataTable dt = new DataTable();
            string strSQL = "spGET_STRAND_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;
        }

       //Getting Gender 
        public DataTable GET_GENDER()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_GENDER_LIST";
            dt = queryCommandDT_StoredProc(strSQL);

            return dt;
        }


        //Get Area/Baranggay
        public DataTable getBarangay(string INPUT)
        { 
            DataTable dt = new DataTable();
            string strSQL = "Select BarangayCode,BarangayDesc from Utilities.Barangay_RF WHERE CityCode ='" + INPUT + "' order by BarangayDesc";
            dt = queryCommandDT(strSQL);

            return dt;
        }

        public DataTable GET_BARANGAY()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_BARANGAY_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;
        }


        //Get City/Province
        public DataTable GET_CITY()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_CITY_LIST";
            dt = queryCommandDT_StoredProc(strSQL);

            return dt;
        }


        //Get Citizenship
        public DataTable GET_CITIZENSHIP()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_CITIZENSHIP_LIST";
            dt = queryCommandDT_StoredProc(strSQL);

            return dt;
        }

        //Get Religion
        public DataTable GET_RELIGION()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_RELIGION_LIST";
            dt = queryCommandDT_StoredProc(strSQL);

            return dt;
       }
        
        //Get Education Background Type
        public DataTable GET_EDUBACKGROUND()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGetEduTypeList";
            dt = queryCommandDT_StoredProc(strSQL);
         
            return dt;
        }
    

        //Get MODE OF TRANSPORTATION
        public DataTable GET_MOT()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_MOT_LIST";
            dt = queryCommandDT_StoredProc(strSQL);

            return dt;
        }

        //Section List
        public DataTable GET_SECTION_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("spGetSectionList");

            return dt;
        }

        //Room List
        public DataTable GET_ROOM_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("spGetRoomList");

            return dt;
        }

        //List of Teacher
        public DataTable GET_TEACHER_LIST()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("spGetTeacherList");

            return dt;
        }

        public DataTable GET_SCREENING_STATUS()
        {
            DataTable dt = new DataTable();
            dt = queryCommandDT_StoredProc("spScreeningStat");
            return dt;
       }


        public DataTable GET_APPLICANT_HEALTH_STATUS()
        {

            DataTable dt = new DataTable();
            string strSQL = "Select HealthStatusCode,HealthStatusRemarks from Utilities.Health_Applicant_Status_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt; 
        }

        //Guidance Scheduling-Assignment and Setup
        public DataTable GET_SCREENING_TYPE()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select ScreeningCode,ScreeningDesc from Utilities.ScreeningType_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        } 

        //FOR TESTING STATUS
        public DataTable getGeneralStatus(string _acode)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayGeneralStatus", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACODE", _acode);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
           
        }


        public string RET_LEVELTYPEDESC(string _leveltypecode)
        {
         string ret_string = "";

         using (SqlConnection cn = new SqlConnection(CS))
         {
             using (SqlCommand cmd = new SqlCommand("Select LevelTypeDesc from xSystem.LevelType_RF where LevelTypeCode='" + _leveltypecode + "'", cn))
             {
                 cn.Open();
                 SqlDataReader dr = cmd.ExecuteReader();

                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         ret_string = dr["LevelTypeDesc"].ToString();
                     }
                 }

                 
             }
         }
         return ret_string;

        }

    }

}
