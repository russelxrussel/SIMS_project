using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_FailedApplicant : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        displayInitialReport();
        Page.Title = "List of Applicant-Passed" + "[" + DateTime.Now.ToShortDateString() + "]";
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //Cleaning Report Documents
        oReportDocument.Close();
    }
    private void displayInitialReport()
    {
        // oReportDocument.Load(Server.MapPath("~/reports/AES_G1112.rpt"))

        oReportDocument.Load(Server.MapPath("~/reports/admListFailedApp.rpt"));

        oReportDocument.SetParameterValue("User", Session["U_USERNAME"].ToString());
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        crv_Failed.ReportSource = oReportDocument;
        //crv.ID = "List of Passed: " + Session["S_SY"].ToString();
        
    }



    protected void lnkClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/home.aspx");
    }
}