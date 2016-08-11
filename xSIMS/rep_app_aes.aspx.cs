using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class rep_app_aes : System.Web.UI.Page
{
     
    ReportDocument oReportDocument = new ReportDocument();

    
    protected void Page_Init(object sender, EventArgs e)
    {
        //Default Report Selected
        ViewState["ReportSelected"] = "ADM";

    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //Session["A_APPLICANTNO"] = "";
        
        //Cleaning Report Documents
        oReportDocument.Close();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Session["A_APPLICANTNO"].ToString()))
        { 
        
        }
        else 
        {
            /*Working code for Crystal Report
           09/26/2015
            */
          // ReportDocument oReportDocument = new ReportDocument(); //Instantiate report document


            if (ViewState["ReportSelected"].ToString() == "ADM")
            {

                //SELECT REPORT BASE ON Grade level Category
                if ((bool)Session["A_STRAND?"])
                {
                    oReportDocument.Load(Server.MapPath("~/reports/AES_G1112.rpt")); // Locate Reoirt file   
                }
                else
                {
                    oReportDocument.Load(Server.MapPath("~/reports/AES_G110.rpt"));
                }

            }
            else
            {
                oReportDocument.Load(Server.MapPath("~/reports/GAES.rpt"));
            }

            oReportDocument.SetParameterValue("AppNum", Session["A_APPLICANTNO"]); // Set Parameter
            oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials
            
            crv_aes.ReportSource = oReportDocument; // To avoid logon error

            //crv_gaes.ReportSource = oReportDocument; // Display result on Crystal Viewer
             
        }
    }

    protected void lnkGuidanceReport_Click(object sender, EventArgs e)
    {
        ViewState["ReportSelected"] = "GUI";
      
        //ReportDocument oReportDocument = new ReportDocument(); //Instantiate report document

        //crv_aes.Visible = false;
        //crv_gaes.Visible = true;

        

        //if ((bool)Session["A_STRAND?"])
        //{
        //    oReportDocument.Load(Server.MapPath("~/reports/AES_G1112.rpt")); // Locate Reoirt file   
        //}
        //else
        //{
        //    oReportDocument.Load(Server.MapPath("~/reports/AES_G110.rpt"));
        //}
        oReportDocument.Load(Server.MapPath("~/reports/GAES.rpt")); // Locate Reoirt file

        oReportDocument.SetParameterValue("AppNum", Session["A_APPLICANTNO"]); // Set Parameter
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        crv_aes.ReportSource = oReportDocument;

    }

    protected void lnkAdmissionReport_Click(object sender, EventArgs e)
    {

        ViewState["ReportSelected"] = "ADM";

       // oReportDocument.Load(Server.MapPath("~/reports/AES.rpt")); // Locate Reoirt file

        //SELECT REPORT BASE ON Grade level Category
        if ((bool)Session["A_STRAND?"])
        {
            oReportDocument.Load(Server.MapPath("~/reports/AES_G1112.rpt")); // Locate Reoirt file   
        }
        else
        {
            oReportDocument.Load(Server.MapPath("~/reports/AES_G110.rpt"));
        }

        oReportDocument.SetParameterValue("AppNum", Session["A_APPLICANTNO"]); // Set Parameter
        oReportDocument.SetDatabaseLogon("sa", "p@ssw0rd"); // Supply user credentials

        crv_aes.ReportSource = oReportDocument;

    }
   
}