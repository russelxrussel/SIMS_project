using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_ShootPrintOut : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        displayReport();
    }

    private void displayReport()
    {
        if (rbYA.Checked)
        {
//            paramSel = "N";
            oReportDocument.Load(Server.MapPath("~/reports/regYG_shoot.rpt"));
        }
        else if (rbFrat.Checked)
        {
 //           paramSel = "R";
            oReportDocument.Load(Server.MapPath("~/reports/regFSWaiver_shoot.rpt"));
        }
        else if(rbMOT.Checked)
        {
//            paramSel = "O";
            oReportDocument.Load(Server.MapPath("~/reports/regMOT_shoot.rpt"));
        }


    //    oReportDocument.Load(Server.MapPath("~/reports/regIDForm_Final.rpt"));
   //     oReportDocument.SetParameterValue("prmStudTypeCode", paramSel);
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        //Will rename the pdf file name.

        crv.ReportSource = oReportDocument;

    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //Cleaning Report Documents
        oReportDocument.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        displayReport();
    }
}