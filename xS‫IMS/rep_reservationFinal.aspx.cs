using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SIMSBDAL;

public partial class rep_reservationFinal : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();
    xSystem oSystem = new xSystem();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            txtDateStart.Text = Convert.ToDateTime(Session["S_SERVERDATE"]).ToShortDateString(); //DateTime.Now.ToShortDateString();
            txtDateEnd.Text = Convert.ToDateTime(Session["S_SERVERDATE"]).ToShortDateString();         }

            displayReport();

            
            
        //}
        //else
        //{
        //    ReportDocument doc = (ReportDocument)Session["S_ReportDocument"];
        //    crv.ReportSource = doc;
        //}
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    displayReport();
        //}
        //else
        //{
        //    ReportDocument doc = (ReportDocument)Session["S_ReportDocument"];
        //    crv.ReportSource = doc;
        //}
    }

    private void displayReport()
    {
       
       
//        oSystem.Execute_EnrollmentUpdate();
        oSystem.Execute_ReservationUpdate();


       ParameterRangeValue myRangeValue = new ParameterRangeValue();
        myRangeValue.StartValue = txtDateStart.Text; //txtDateStart.Text;
        myRangeValue.EndValue = txtDateEnd.Text;


        if (rbList.Checked)
        {
            oReportDocument.Load(Server.MapPath("~/reports/xReservationReport.rpt"));
            crv.HasToggleGroupTreeButton = true;
        }
        else if (rbSummary.Checked)
        {
           
            oReportDocument.Load(Server.MapPath("~/reports/xReserveReport_Summary_Portrait.rpt"));
            crv.HasToggleGroupTreeButton = false;
            crv.HasToggleParameterPanelButton = false;
            
        }
        
        oReportDocument.SetParameterValue("DateRange", myRangeValue);
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