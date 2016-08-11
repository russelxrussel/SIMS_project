using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_resultslip_item : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
      displayReport();

    }

     private void displayReport()
    {
        if (Convert.ToInt32(Request.QueryString["slipType"].ToString()) == 1)
        {
            oReportDocument.Load(Server.MapPath("~/reports/admRS_R.rpt"));
        }
        else if (Convert.ToInt32(Request.QueryString["slipType"].ToString()) == 2)
        {
            oReportDocument.Load(Server.MapPath("~/reports/admRS_E.rpt"));
        }
        else
        {
            oReportDocument.Load(Server.MapPath("~/reports/admRS_F.rpt"));
        }
       

        oReportDocument.SetParameterValue("Date1", Request.QueryString["date1"]);
        oReportDocument.SetParameterValue("ParentName", Request.QueryString["addressTo"]);
        oReportDocument.SetParameterValue("AppName", Request.QueryString["applicantName"]);
        oReportDocument.SetParameterValue("LevelApplied", Request.QueryString["gradeLevel"]);
        oReportDocument.SetParameterValue("SY", Session["S_SY"].ToString());
        oReportDocument.SetParameterValue("DateExpired", Request.QueryString["dateExpired"]);
        oReportDocument.SetParameterValue("Counselor", Request.QueryString["counselor"].ToUpper());
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        //Will rename the pdf file name.
        
        crv.ReportSource = oReportDocument;

        crv.ID = "Result Slip " + Request.QueryString["appnum"].ToString();
     }


     protected void Page_UnLoad(object sender, EventArgs e)
     {
         //Cleaning Report Documents
         oReportDocument.Close();
     }

}