using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class appList : System.Web.UI.Page
{
    Applicant oApplicant = new Applicant();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayListApplicantStat();


        }
        

    }


    //Create function that will get List of Applicant
    private void displayListApplicantStat()
    { 
        DataTable dt = new DataTable();
        dt = oApplicant.getApplicant();

        DataView dv = dt.DefaultView;
        
         //ALL APPLICANT
        if (Session["A_STATTYPE"].ToString()=="ALL")
        {
            gvAppList.DataSource = dv;
            gvAppList.DataBind();

            Page.Title = "List of All Applicant";
        }

        else if (Session["A_STATTYPE"].ToString() == "LEVELTYPECODESELECTION")
        {
            dv.RowFilter = "LevelTypeCode ='" + Session["A_APPLICANTTYPECODE"].ToString() + "'";

            Page.Title = "List of Applicant with Level Applied " + Session["A_APPLICANTTYPECODE"].ToString();
        }

        else if (Session["A_STATTYPE"].ToString() == "WAITLISTEDSELECTION")
        {
            dv.RowFilter = "WLSTATUS ='" + true + "'";
        }

        else if (Session["A_STATTYPE"].ToString() == "SSICHILDSELECTION")
        {
            dv.RowFilter = "SSIChild ='" + true + "'";
        }

         //ALL BOYS
        else if (Session["A_STATTYPE"].ToString() == "BOYS")
        {
            dv.RowFilter = "GenderCode='" + "B" + "'";
            Page.Title = "List of Boys - Applicant";
        }

         //ALL BOYS
        else if (Session["A_STATTYPE"].ToString() == "GIRLS")
        {
            dv.RowFilter = "GenderCode='" + "G" + "'";
            Page.Title = "List of Girls - Applicant";
        }

       
       
        
  
        gvAppList.DataSource = dv;
        gvAppList.DataBind();

    }
    protected void gvAppList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAppList.PageIndex = e.NewPageIndex;
        displayListApplicantStat();
    }
}