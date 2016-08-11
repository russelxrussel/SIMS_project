using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for WService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WService : System.Web.Services.WebService {

    public WService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetApplicantList(string _applicantname) {
        
         List<string> listApplicantNames = new List<string>();
   
         string CS = ConfigurationManager.ConnectionStrings["CSSIMS"].ToString();
         using (SqlConnection cn = new SqlConnection(CS))
         {
             SqlCommand cmd = new SqlCommand("spAutoComplete_Applicant", cn);
             //SqlCommand cmd = new SqlCommand(storedproc, cn);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.AddWithValue("@AppName", _applicantname);

             cn.Open();
             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             { 
             //listApplicantNames.Add(rdr["Fullname"].ToString());
             listApplicantNames.Add(string.Format("{0}*{1}", rdr["AppNum"].ToString(), rdr["Fullname"].ToString()));
             }

         }

         return listApplicantNames.ToArray();
    }

    [WebMethod]
    public string[] GetStudentList(string _studentname)
    {

        List<string> listStudentNames = new List<string>();

        string CS = ConfigurationManager.ConnectionStrings["CSSIMS"].ToString();
        using (SqlConnection cn = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spAutoComplete_Students", cn);
            //SqlCommand cmd = new SqlCommand(storedproc, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@STUDENTNAME", _studentname);

            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               // listStudentNames.Add(rdr["Fullname"].ToString());
                listStudentNames.Add(string.Format("{0}*{1}", rdr["StudNum"].ToString(), rdr["Fullname"].ToString()));
            }

        }

        return listStudentNames.ToArray();
    }

    [WebMethod]
    public string[] GetActiveStudents(string _studentname)
    {

        List<string> listStudentNames = new List<string>();

        string CS = ConfigurationManager.ConnectionStrings["CSSIMS"].ToString();
        using (SqlConnection cn = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spAutoComplete_Students_Active", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STUDENTNAME", _studentname);
            cn.Open();
            
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                listStudentNames.Add(string.Format("{0}*{1}", rdr["StudNum"].ToString(), rdr["Fullname"].ToString()));
            }

             return listStudentNames.ToArray();
        }

       
    }

}
