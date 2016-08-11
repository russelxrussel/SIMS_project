using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class regStudentStatus : System.Web.UI.Page
{
    
    Student oStudentStatus = new Student();

    Utilities oUtilities = new Utilities();

    public string data;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            displayLevelType();
            displayStudents();

            ViewState["SEARCH_TYPE"] = 0;
        }

        //searchData();

       
    }


    #region "USER-DEFINED FUNCTION"

    private void displayStudents()
    {
   
    DataTable dt = new DataTable();
    dt = oStudentStatus.GET_STUDENTS_NO_SECTION();

    gvActiveStudents.DataSource = dt;
    gvActiveStudents.DataBind();

    ViewState["SEARCH_TYPE"] = 0;
    
    }

    private void displayLevelType()
    {
      oUtilities.getApplicantLevel(ddLevelType);
      ddLevelType.Items.Insert(0, new ListItem("-- Select Level --"));
    }

    private void displayStudentViaStudNum(string _studnum)
    {
        DataTable dt = new DataTable();
        dt = oStudentStatus.GET_STUDENTS_NO_SECTION();

        DataView dv = dt.DefaultView;
        dv.RowFilter = "StudNum='" + _studnum + "'";

        gvActiveStudents.DataSource = dv;
        gvActiveStudents.DataBind();

        ViewState["SEARCH_TYPE"] = 1;

    }

    private void displayStudentViaLevel(string _leveltypecode)
    {
        DataTable dt = new DataTable();
        dt = oStudentStatus.GET_STUDENTS_NO_SECTION();

        DataView dv = dt.DefaultView;
        dv.RowFilter = "current_levelcode='" + _leveltypecode + "'";

        gvActiveStudents.DataSource = dv;
        gvActiveStudents.DataBind();

        ViewState["SEARCH_TYPE"] = 2;
    }

    private void ShowBySearchType(int _stype)
    {
        if (_stype == 0)
        {
            displayStudents();
        }

        else if (_stype == 1)
        {
        string _studnum = Request.Form[hfStudNum.UniqueID]; 
        displayStudentViaStudNum(_studnum);
        }

        else if (_stype == 2)
        {
          displayStudentViaLevel(ddLevelType.SelectedValue.ToString());
        }

    }

    

    //private void searchData()
    //{
    //    DataTable dt = new DataTable();
    //    dt = oStudentStatus.GET_ACTIVESTUDENTS();

       
    //    if (dt.Rows.Count > 0)
    //    {
    //          for (int i = 0; i < 15; i++)
    //        {
    //            data += dt.Rows[i]["Fullname"].ToString() + ",";
    //        }
    //    }
    //}

    #endregion

    //Confirmation method
    //protected void DeleteRecord(object sender, EventArgs e)
    //{
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Record Deleted.')", true);
    //    //lblRemove.Text = "Record Remove2";
    //    lblRemove.Text = Request.Form[hfStudNum.UniqueID];
            
    //}

    //public static string ShowText(string name)
    //{
    //    return "Hello " + name + Environment.NewLine +
    //           "The current time is: " + DateTime.Now.ToString();
    //}


   
    protected void gvActiveStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Get List of Status in General Table of Status
        DataTable dtAdmStatus = oUtilities.getGeneralStatus("ADM");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgControl = (Image)e.Row.Cells[1].FindControl("imgControl");

            //Examination
            DropDownList ddAdmStatus = (DropDownList)e.Row.Cells[0].FindControl("ddAdmStatus");
            ddAdmStatus.DataSource = dtAdmStatus;
            ddAdmStatus.DataTextField = dtAdmStatus.Columns["StatDesc"].ToString();
            ddAdmStatus.DataValueField = dtAdmStatus.Columns["StatCode"].ToString();
            ddAdmStatus.DataBind();
            ddAdmStatus.Items.Insert(0, new ListItem("Select Status"));

            imgControl.ImageUrl = "~/images/controlsIcon/update_sched.png";


            //If student row record exit then run this function]
            if(oStudentStatus.CHECK_STUDENTSTATUSEXIST(e.Row.Cells[0].Text))
            {
             
             ddAdmStatus.SelectedValue = oStudentStatus.STATCODE;
             if (oStudentStatus.STATCODE == "EN")
             {
                 e.Row.BackColor = System.Drawing.Color.SandyBrown;
                 ddAdmStatus.Enabled = false; 
             }
             else if(oStudentStatus.STATCODE == "RE")
             {
                 //e.Row.BackColor = System.Drawing.Color.Khaki;
               // ddAdmStatus.Items.Insert(0, new ListItem("RESERVED"));
                 ddAdmStatus.BackColor = System.Drawing.Color.Khaki;
                 ddAdmStatus.Enabled = false; 
             }
            }
        
        }

        //Hover mouse
        e.Row.Attributes.Add("onmouseover", "self.MouseOverOldColor=this.style.backgroundColor;this.style.backgroundColor='#F3F781'");
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=self.MouseOverOldColor");



    }

    protected void gvActiveStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActiveStudents.PageIndex = e.NewPageIndex;
        ShowBySearchType((int)ViewState["SEARCH_TYPE"]);
    }


    protected void imgControl_Click(object sender, ImageClickEventArgs e)
    {
        //Getting the selected Row List
        var selectRow = (Control)sender;
        GridViewRow row = (GridViewRow)selectRow.NamingContainer;


        string selStudNum = row.Cells[0].Text;
        string selLevelTypeCode = row.Cells[2].Text;

        DropDownList ddStatusCode = (DropDownList)row.Cells[3].FindControl("ddAdmStatus");
        //Label lblConfirmMessage = (Label)row.Cells[1].FindControl("lblConfirmMessage");
        Label lblConfirm = (Label)row.Cells[4].FindControl("lblConfirmMessage");
       
        //INSERT THE STUDENT STATUS DETAILS

        //User should select one of status
        if (ddStatusCode.SelectedIndex == 0)
        {
            //Show dialog message problem

        }
        else
        {
            //Save or Update Record

            //UPDATE Record
            if (oStudentStatus.CHECK_STUDENTSTATUSEXIST(selStudNum))
            {
                oStudentStatus.UPDATE_STUDENTSTATUS(selStudNum, Session["S_SY"].ToString(), ddStatusCode.SelectedValue.ToString(), Session["U_USERID"].ToString());
                //displayStudents();
                ShowBySearchType((int)ViewState["SEARCH_TYPE"]);
                
            }
            else
            {
                //SAVING Record
                oStudentStatus.INSERT_STUDENTSTATUS(selStudNum, Session["S_SY"].ToString(), selLevelTypeCode, ddStatusCode.SelectedValue.ToString(), Session["U_USERID"].ToString());
                //displayStudents();
                ShowBySearchType((int)ViewState["SEARCH_TYPE"]);
            }
        }
    }



    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtSearch.Text) || txtSearch.Text == "*")
        {
            displayStudents();
            ViewState["SEARCH_TYPE"] = 0;
        }
        else
        { 
        string _studnum = Request.Form[hfStudNum.UniqueID]; 
        displayStudentViaStudNum(_studnum);
        txtSearch.Text = "";
        }

        ddLevelType.SelectedIndex = 0;
    }

    protected void imgSearchLevel_Click(object sender, ImageClickEventArgs e)
    {
        displayStudentViaLevel(ddLevelType.SelectedValue.ToString());
        txtSearch.Text = "";
    }
}