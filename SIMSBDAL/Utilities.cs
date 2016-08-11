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
        public DataTable getApplicantStrand()
        { 
            DataTable dt = new DataTable();
            string strSQL = "Select StrandCode, StrandName from xSystem.Strand_RF order by ID";
            dt = queryCommandDT(strSQL);

            return dt;
        }

       //Getting Gender 
        public DataTable getGender()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select GenderCode,GenderDesc from Utilities.Gender_RF order by ID";
            dt = queryCommandDT(strSQL);

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

        public DataTable getBarangay()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select BarangayCode,BarangayDesc from Utilities.Barangay_RF";
            dt = queryCommandDT(strSQL);

            return dt;
        }


        //Get City/Province
        public DataTable getCity()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select CityCode,CityDesc from Utilities.CityProvince_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt;
        }


        public DataTable getScreeningType ()
        {
            DataTable dt = new DataTable();
            string strSQL = "Select ScreeningCode,ScreeningDesc from Utilities.ScreeningType_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt; 
        }


        public DataTable getApplicantHealthStatus()
        {

            DataTable dt = new DataTable();
            string strSQL = "Select HealthStatusCode,HealthStatusRemarks from Utilities.Health_Applicant_Status_RF order by Arr";
            dt = queryCommandDT(strSQL);

            return dt; 
        }

     


    }

}
