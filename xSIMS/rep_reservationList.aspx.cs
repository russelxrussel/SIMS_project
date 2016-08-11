using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SIMSBDAL;

public partial class rep_reservationList : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();
    xSystem oSystem = new xSystem();

    protected void Page_Load(object sender, EventArgs e)
    {
        displayReport();
    }

    private void displayReport()
    {
        //string paramSel = "N";
        //if (rbNew.Checked)
        //{
        //  paramSel = "N";
        //}
        //else if (rbReturnee.Checked)
        //{
        //    paramSel = "R";
        //}
        //else
        //{
        //    paramSel = "O";
        //}


        //string paramType = "";
        //string paramReportName = "";

        //if (rbRes.Checked)
        //{
        //    paramType = "RE";
        //    paramReportName = "RESERVED";
        //}
        //else if (rbEn.Checked)
        //{
        //    paramType = "EN";
        //    paramReportName = "ENROLLED";
        //}

        oSystem.Execute_ReservationUpdate();

        oReportDocument.Load(Server.MapPath("~/reports/xReservationReport.rpt"));
        //oReportDocument.SetParameterValue("studtype", paramSel);
        //oReportDocument.SetParameterValue("report_type", paramType);
        //oReportDocument.SetParameterValue("repName", paramReportName);
       
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