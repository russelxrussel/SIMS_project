using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SIMSBDAL;

public partial class rep_StudentInfo : System.Web.UI.Page
{
    ReportDocument oReportDocument = new ReportDocument();
    Utilities oUtilities = new Utilities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayLevelType();
        }

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


        
        oReportDocument.Load(Server.MapPath("~/reports/regStudInfo_Final.rpt"));
        oReportDocument.SetParameterValue("prmStudTypeCode", paramSel);
        oReportDocument.SetParameterValue("prmLevelDesc", ddGradeLevel.SelectedItem.Text);
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

    private void displayLevelType()
    {
        DataTable dt = new DataTable();
        dt = oUtilities.getApplicantLevel();
        ddGradeLevel.DataSource = dt;
        ddGradeLevel.DataTextField = dt.Columns["LevelTypeDesc"].ToString();
        ddGradeLevel.DataValueField = dt.Columns["LevelTypeCode"].ToString();
        ddGradeLevel.DataBind();

        ddGradeLevel.Items.Insert(0, "--Select--");
    }
}