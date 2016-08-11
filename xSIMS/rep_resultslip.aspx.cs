using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIMSBDAL;
using System.Data;

public partial class rep_resulslip : System.Web.UI.Page
{
    
    Utilities oUtilities = new Utilities();
    ApplicantTesting oApplicantTesting = new ApplicantTesting();

    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (!Page.IsPostBack)
        {

            /*
            Will hold the data how the program react on Page Index Event
            * 0 =  Search will react base on Slip Type General
            * 1 = Search will react base on Slip Type and Level Type
            */
            ViewState["SEL_KEY"] = 0;


        ddSlipType.Items.Insert(0, new ListItem("-- Select Slip Type --"));
        ddSlipType.Items.Insert(1, new ListItem("For Reservation"));
        ddSlipType.Items.Insert(2, new ListItem("During Enrollment"));
        ddSlipType.Items.Insert(3, new ListItem("Failure/Reject"));

        //Display data on drop down grade level
        oUtilities.getApplicantLevel(ddLevelType);
        ddLevelType.Items.Insert(0, new ListItem("-- Select Level --"));

        //Display List of Passed Applicant
      //  displayPassed();
  
        }


    

    }

   
       
       

  

    //protected void btnGenerate_Click(object sender, EventArgs e)
    //{
    //    displayReport();
    
    //}



    //USER-DEFINED METHOD

    /*DISPLAY LIST OF APPLICANT IN GRIDVIEW
     * PASSED AND FAILED HAVE ON DISPLAY 
     * BASE ON THE USER SELECTION
     * 02/09/2016 - RUSSEL VASQUEZ
     * */
    private void displayPassed()
    {
        DataTable dt = new DataTable();
        dt = oApplicantTesting.DISPLAY_APPLICANTPASSED();

        gvApplicantResult.DataSource = dt;
        gvApplicantResult.DataBind();
    }

   //Override function with parameter
    private void displayPassed(string _leveltype)
    {
        DataTable dt = new DataTable();
        dt = oApplicantTesting.DISPLAY_APPLICANTPASSED(_leveltype);

        gvApplicantResult.DataSource = dt;
        gvApplicantResult.DataBind();
    }

    private void displayFailed()
    {
        DataTable dt = new DataTable();
        dt = oApplicantTesting.DISPLAY_APPLICANTFAILED();

        gvApplicantResult.DataSource = dt;
        gvApplicantResult.DataBind();
    }
    //Override function with parameter
    private void displayFailed(string _leveltype)
    {
        DataTable dt = new DataTable();
        dt = oApplicantTesting.DISPLAY_APPLICANTFAILED(_leveltype);

        gvApplicantResult.DataSource = dt;
        gvApplicantResult.DataBind();
    }

    private void displaySelectionBaseOnSlip()
    {
        if (ddSlipType.SelectedIndex == 0)
        {
            gvApplicantResult.DataSource = null;
            gvApplicantResult.DataBind();
        }
        else if (ddSlipType.SelectedIndex == 1 || ddSlipType.SelectedIndex == 2)
        {
            //Display Passed
            displayPassed();

            //reset level type index to 0
            ddLevelType.SelectedIndex = 0;
        }
        else
        {
            //Display Failed
            displayFailed();
            //reset level type index to 0
            ddLevelType.SelectedIndex = 0;

        }
    }

    private void displaySelectionBaseOnLevel(string _leveltype)
    {
        if (ddSlipType.SelectedIndex == 0)
        {
            //Message Here
        }
        else if (ddSlipType.SelectedIndex == 1 || ddSlipType.SelectedIndex == 2)
        {
            //Display Passed with parameter
            displayPassed(_leveltype);
        }
        else
        {
            //Display Failed with parameter
            displayFailed(_leveltype);

        }
    }


    protected void ddSlipType_SelectedIndexChanged(object sender, EventArgs e)
    {
        displaySelectionBaseOnSlip();
        ViewState["SEL_KEY"] = 0;
    }

    protected void imgSearchViaLevel_Click(object sender, ImageClickEventArgs e)
    {
        displaySelectionBaseOnLevel(ddLevelType.SelectedValue.ToString());
        ViewState["SEL_KEY"] = 1;
    }

    protected void gvApplicantResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvApplicantResult.PageIndex = e.NewPageIndex;

        //Condition base on selection of search type
        if (Convert.ToInt32(ViewState["SEL_KEY"].ToString()) == 0)
        { 
            displaySelectionBaseOnSlip();
        }
        else if(Convert.ToInt32(ViewState["SEL_KEY"].ToString()) == 1)
        {
            displaySelectionBaseOnLevel(ddLevelType.SelectedValue.ToString());
        }

     
    }

    protected void imgPrint_Click(object sender, ImageClickEventArgs e)
    {
        var selEdit = (Control)sender;
        GridViewRow r = (GridViewRow)selEdit.NamingContainer;
        
        //Data Bound Selection
        string selAppNum = r.Cells[0].Text;
        string selFullName = r.Cells[1].Text;
        string selGradeLevel = r.Cells[5].Text;


        //Templatefield Selection
        TextBox txtDated = (TextBox)r.Cells[2].FindControl("txtDated");
        TextBox txtAddressTo = (TextBox) r.Cells[3].FindControl("txtAddressTo");
        TextBox txtDateExpired = (TextBox)r.Cells[4].FindControl("txtDateExpired");
        
    

        //Need to use query on address bar

        //Session["A_APPLICANTNO"] = selAppNum;

        //Get the level description of level code
        string levelDesc = oUtilities.RET_LEVELTYPEDESC(selGradeLevel);


        //SAVING THE RESULT SLIP SELECTION
        try
        {

            //Condition level 1
            if (string.IsNullOrEmpty(txtDated.Text) || string.IsNullOrEmpty(txtAddressTo.Text) || string.IsNullOrEmpty(txtDateExpired.Text))
            {
                //message error
            }
            //Condition level 2 type of record saving
            else
            {
                if (oApplicantTesting.CHECK_APPRESULTSLIP(selAppNum))
                {
                    //Found?=Yes : Use update method
                    oApplicantTesting.UPDATE_RESULTSLIP(selAppNum, Convert.ToDateTime(txtDated.Text), txtAddressTo.Text.ToUpper(), Convert.ToDateTime(txtDateExpired.Text), ddSlipType.SelectedIndex, Session["U_USERID"].ToString());
                }
                else
                {
                    //Insert method
                    oApplicantTesting.INSERT_RESULTSLIP(selAppNum, Convert.ToDateTime(txtDated.Text), txtAddressTo.Text.ToUpper(), Convert.ToDateTime(txtDateExpired.Text), ddSlipType.SelectedIndex, Session["U_USERID"].ToString());
                }


                //Print Report
                PRINT_NOW("rep_resultslip_item.aspx?date1=" + txtDated.Text + "&addressTo=" + txtAddressTo.Text.ToUpper() + "&dateExpired=" + txtDateExpired.Text +
                          "&gradeLevel=" + levelDesc + "&applicantName=" + selFullName + "&counselor=" + Session["U_USERNAME"].ToString() +
                          "&slipType=" + ddSlipType.SelectedIndex + "&appnum=" + selAppNum);

            }


            


        }

        catch (Exception ex)
        {
            
        }




    }


    private void PRINT_NOW(string url)
    {
        string s = "window.open('" + url + "', '_blank', 'width=850, height=600, left=0, top=0, resizable=yes');";
        ScriptManager.RegisterClientScriptBlock(this, this.Page.GetType(), "ReportScript", s, true);
    }


    protected void gvApplicantResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Image imgIcon = (Image)e.Row.Cells[1].FindControl("imgIcon");
            //Image imgControl = (Image)e.Row.Cells[8].FindControl("imgControl");
            //TextBox txtOR = (TextBox)e.Row.Cells[4].FindControl("txtOR");
            //CheckBox chkFree = (CheckBox)e.Row.Cells[4].FindControl("chkFree");

            TextBox txtDated = (TextBox)e.Row.Cells[2].FindControl("txtDated");
            TextBox txtAddressTo = (TextBox)e.Row.Cells[3].FindControl("txtAddressTo");
            TextBox txtDateExpired = (TextBox)e.Row.Cells[4].FindControl("txtDateExpired");

            string selAppNum = e.Row.Cells[0].Text;

            if (oApplicantTesting.CHECK_APPRESULTSLIP(selAppNum))
            {
                txtDated.Text = oApplicantTesting._DATECREATED.ToShortDateString();
                txtAddressTo.Text = oApplicantTesting._ADDRESSTO;
                txtDateExpired.Text = oApplicantTesting._DATEEXPIRED.ToShortDateString();
                e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
            }
            
        }
    }
}