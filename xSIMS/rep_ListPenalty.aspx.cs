using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_ListPenalty : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        displayReport();
    }

    private void displayReport()
    {

        oReportDocument.Load(Server.MapPath("~/reports/ListPenalty.rpt"));

        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        //Will rename the pdf file name.

        crv.ReportSource = oReportDocument;

    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //Cleaning Report Documents
        oReportDocument.Close();
    }
}