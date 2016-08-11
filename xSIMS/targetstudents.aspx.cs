using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class targetstudents : System.Web.UI.Page
{
    xSystem oSystem = new xSystem();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        { 
        //Load to drop down data.
            displayLevelCategory();
            displayLevelType();

            //display data on grid view
            displayTargetStudents(Session["S_SY"].ToString());
           
        }
    }


  

    private void displayTargetStudents(string _sy)
    {
        DataTable dt = new DataTable();
        dt = oSystem.DISPLAY_TARGETSTUDENTS(_sy);

        gvTargetStudents.DataSource = dt;
        gvTargetStudents.DataBind();
    }

    protected void ddLevelCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
 
        displayLevelType();

        if (ddLevelCategory.SelectedValue.ToString() == "SHS")
        {
            displayStrand();
        }
        else
        {
            ddStrand.Items.Clear();
        }
    }

    protected void ddLevelType_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }



    protected void imgNew_Click(object sender, ImageClickEventArgs e)
    {
          
          //Hold value interger
          int iTotal = 0;
          int iRegularCount = 0;
          int iSSICCount = 0;
          
         //Hold strand code
          string strandcode = "";
          
        
          //Assign regular count input  
          if (string.IsNullOrEmpty(txtRegularCount.Text))
          {
              iRegularCount = 0;
          }
          else
          {
              iRegularCount = int.Parse(txtRegularCount.Text);  
          }
          

            //Assign SSI Child count input
          if(string.IsNullOrEmpty(txtSSICCount.Text))
          {
          iSSICCount = 0;
          }
          else
          {
          iSSICCount = int.Parse(txtSSICCount.Text);
          }
          
          //Sum Regular and SSI Child Input
          iTotal = iRegularCount + iSSICCount;
           
 
          //CHECK STRAND CODE
          if (string.IsNullOrEmpty(ddStrand.SelectedValue.ToString()))
          {
              strandcode = "";
          }
          else
          {
              strandcode = ddStrand.SelectedValue.ToString();
          }



          if (ddLevelType.SelectedIndex == 0)
          {
              MessageDialog("Please select Level Type", 3);

          }
         
          else
          {

              
              try
              {

                  //Validade if input already have record
                  if(oSystem.CHECK_TARGETSTUDENTS(Session["S_SY"].ToString(),ddLevelType.SelectedValue.ToString(),strandcode))
                  {
                  MessageDialog("Grade Level already in record.", 3);
                  }

                  else
                  {
                  
                        //Saving Now
                      oSystem.INSERT_TARGETSTUDENTS(Session["S_SY"].ToString(), ddLevelCategory.SelectedValue.ToString(),
                                                ddLevelType.SelectedValue.ToString(), strandcode, iRegularCount,
                                                iSSICCount, iTotal,txtRemarks.Text, Session["U_USERID"].ToString());

                  MessageDialog("Target Students successfully set.", 1);

                  //Display Changes in gridview.
                  displayTargetStudents(Session["S_SY"].ToString());

                  //Clear
                  clearInputs();

                  }
              }

              catch
              {

                  MessageDialog("Something wrong with Insert", 3);
              }
          
          }
   
       

    }




    #region "User-defined Function Section"

    

    private void displayLevelCategory()
    {
        DataTable dt = new DataTable();
        dt = oSystem.getLevelCategory();

        ddLevelCategory.DataSource = dt;
        ddLevelCategory.DataTextField = dt.Columns["LevelCatDesc"].ToString();
        ddLevelCategory.DataValueField = dt.Columns["LevelCatCode"].ToString();
        ddLevelCategory.DataBind();

    }

    //CLEAR Inputs
    private void clearInputs()
    {
        txtRegularCount.Text = "";
        txtSSICCount.Text = "";
        txtStudentCount.Text = "";

        ddLevelCategory.SelectedIndex = 0;
        ddLevelType.SelectedIndex = 0;

        ddStrand.SelectedItem.Text = "";
    }

    private void displayLevelType()
    {
        DataTable dt = new DataTable();
        dt = oSystem.getApplicantLevel(ddLevelCategory.SelectedValue.ToString());

        ddLevelType.DataSource = dt;
        ddLevelType.DataTextField = dt.Columns["LevelTypeDesc"].ToString();
        ddLevelType.DataValueField = dt.Columns["LevelTypeCode"].ToString();
        ddLevelType.DataBind();

        //Set the test to Passed
        ddLevelType.Items.Insert(0, new ListItem("Select Level"));

    }

    private void displayStrand()
    {
        DataTable dt = new DataTable();
        dt = oSystem.DISPLAY_STRAND();

        ddStrand.DataSource = dt;
        ddStrand.DataTextField = dt.Columns["StrandName"].ToString();
        ddStrand.DataValueField = dt.Columns["StrandCode"].ToString();
        ddStrand.DataBind();

    }

    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }


    #endregion



    /*
     Gridview Data Manipulation
     * 02/01/2016
     */


    protected void gvTargetStudents_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Enable Edit
        gvTargetStudents.EditIndex = e.NewEditIndex;
    }

    protected void gvTargetStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Return - Cancel
        gvTargetStudents.EditIndex = -1;
        displayTargetStudents(Session["S_SY"].ToString());
    }


    protected void gvTargetStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(gvTargetStudents.DataKeys[e.RowIndex].Value.ToString()); //Get the value of data key
        GridViewRow row = (GridViewRow)gvTargetStudents.Rows[e.RowIndex];

        TextBox txtRegularCount = (TextBox)row.FindControl("txtRegularCount");
        TextBox txtSSICCount = (TextBox)row.FindControl("txtSSICCount");
        TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

        //Action
        //Hold value interger
        int iTotal = 0;
        int iRegularCount = 0;
        int iSSICCount = 0;



        //Assign regular count input  
        if (string.IsNullOrEmpty(txtRegularCount.Text))
        {
            iRegularCount = 0;
        }
        else
        {
            iRegularCount = int.Parse(txtRegularCount.Text);
        }


        //Assign SSI Child count input
        if (string.IsNullOrEmpty(txtSSICCount.Text))
        {
            iSSICCount = 0;
        }
        else
        {
            iSSICCount = int.Parse(txtSSICCount.Text);
        }

        //Sum Regular and SSI Child Input
        iTotal = iRegularCount + iSSICCount;
           

        //Update Action
        try
        {

            oSystem.UPDATE_TARGETSTUDENTS(id, iRegularCount, iSSICCount, iTotal, txtRemarks.Text, Session["U_USERID"].ToString());

            //Exit on edit mode before message appear.
            gvTargetStudents.EditIndex = -1;

            MessageDialog("Target Students Update success.", 2);
           
            //reload data again.
            displayTargetStudents(Session["S_SY"].ToString());
            
        }

        catch
        { 
        MessageDialog("Error Update",3);
        }

    }
}