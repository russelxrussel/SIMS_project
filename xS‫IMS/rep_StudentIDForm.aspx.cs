using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_StudentIDForm : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        displayReport();
    }

    private void displayReport()
    {
        string paramSel = "N";
        if (rbNew.Checked)
        {
          paramSel = "N";
        }
        else if (rbReturnee.Checked)
        {
            paramSel = "R";
        }
        else
        {
            paramSel = "O";
        }


        oReportDocument.Load(Server.MapPath("~/reports/regIDForm_Final.rpt"));
        oReportDocument.SetParameterValue("prmStudTypeCode", paramSel);
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