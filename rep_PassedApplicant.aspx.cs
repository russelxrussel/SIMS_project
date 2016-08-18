using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using SIMSBDAL;
using System.Data;


public partial class rep_PassedApplicant : System.Web.UI.Page
{
    Utilities oUtilities = new Utilities();
    ReportDocument oReportDocument = new ReportDocument();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            oUtilities.getApplicantLevel(ddGradeLevel);
            ddGradeLevel.Items.Insert(0, new ListItem("-- Select Level --"));
        }
            
            displaySelectedReport();
            Page.Title = "List of Applicant-Passed" + "[" + DateTime.Now.ToShortDateString() + "]";
    }


    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //Cleaning Report Documents
        oReportDocument.Close();
    }


    private void displaySelectedReport()
    {
        if (ddGradeLevel.SelectedIndex == 0)
        {
            //If no selection in grade level
            //Show all
            oReportDocument.Load(Server.MapPath("~/reports/admListPassedApp.rpt"));
        }
        else
        {
            oReportDocument.Load(Server.MapPath("~/reports/admListPassedApp_PerLevel.rpt"));
            oReportDocument.SetParameterValue("GradeLevel", ddGradeLevel.SelectedValue.ToString());
            oReportDocument.SetParameterValue(2, ddGradeLevel.SelectedItem.Text);
        }
        

        oReportDocument.SetParameterValue("User", Session["U_USERNAME"].ToString());
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        crv_Passed.ReportSource = oReportDocument;
        //crv.ID = "List of Passed: " + Session["S_SY"].ToString();
    }

    //private void displayLevelTypeList()
    //{ 
    //DataTable dt = new DataTable();
    //dt = 
    //}


    protected void lnkClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/home.aspx");
    }

    protected void ddGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        displaySelectedReport();
    }
}