using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class admScreeningSetup : System.Web.UI.Page
{
    Utilities oUtilities = new Utilities();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            displayScreeningType();
            displayAvailableSlotItems();
        }

    }




    //Routine

    private void displayScreeningType()
    {
        DataTable dt = oUtilities.GET_SCREENING_TYPE();

        ddScreeningType.DataSource = dt;
        ddScreeningType.DataTextField = dt.Columns["ScreeningDesc"].ToString();
        ddScreeningType.DataValueField = dt.Columns["ScreeningCode"].ToString();
        ddScreeningType.DataBind();

    }


    private void addNewScreening()
    {
        //Convert Server time to DATETime
        DateTime dtServerTime = Convert.ToDateTime(Session["S_SERVERDATE"].ToString());
        

        string strSdateFormat = ucScreeningDate.textBoxValue().ToShortDateString();
        string strDescFormat = strSdateFormat + "-(" + ScreningTime.Text + ")";                      
        
        //Validation

        if (string.IsNullOrEmpty(ScreningTime.Text) || string.IsNullOrEmpty(ucScreeningDate.textBoxValue().ToString()))
        {
            
            MessageDialog("Please insert schedule time", 3);
        }

        else
        {
            sqlScreeningSetup.InsertParameters["SY"].DefaultValue = Session["S_SY"].ToString();
            sqlScreeningSetup.InsertParameters["ScreeningCode"].DefaultValue = ddScreeningType.SelectedValue.ToString();
            sqlScreeningSetup.InsertParameters["Sdate"].DefaultValue = ucScreeningDate.textBoxValue().ToShortDateString();
            sqlScreeningSetup.InsertParameters["Stime"].DefaultValue = ScreningTime.Text;
            sqlScreeningSetup.InsertParameters["STitle"].DefaultValue = strDescFormat;
            sqlScreeningSetup.InsertParameters["SDesc"].DefaultValue = txtExamDescription.Text;
            sqlScreeningSetup.InsertParameters["ScheduleAvailableSlot"].DefaultValue = ddSchedAvailSlot.SelectedItem.Text;
            sqlScreeningSetup.InsertParameters["DI"].DefaultValue = dtServerTime.ToString();
            sqlScreeningSetup.InsertParameters["UserCode"].DefaultValue = Session["U_USERID"].ToString();

            sqlScreeningSetup.Insert();

            MessageDialog("Schedule Successfully Created!", 1);
            clearInputs();

            
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        addNewScreening();
    }

    private void clearInputs()
    {
        txtExamDescription.Text = "";
        ScreningTime.Text = "";
    }


    protected void gvScreening_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            if((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == DataControlRowState.Alternate))
            {
            Label lExamDate = (Label)e.Row.Cells[2].FindControl("lblExamDate");
            DateTime dtExamDate = Convert.ToDateTime(lExamDate.Text).AddDays(1); //Add One day to avoid expiration within the date.
            Image imgIconSel = (Image)e.Row.Cells[0].FindControl("imgIcon");

            //expired = txtExamDate.ToString({0:ddScreeningType}) - DateTime.Now).
            
           if (dtExamDate < (DateTime.Now))
            {
                e.Row.BackColor = System.Drawing.Color.Thistle;
                imgIconSel.ImageUrl = "~/images/micon/151.png";
            }
            else
            {
                imgIconSel.ImageUrl = "~/images/micon/152.png";
            }

            
        //Hover mouse
        e.Row.Attributes.Add("onmouseover", "self.MouseOverOldColor=this.style.backgroundColor;this.style.backgroundColor='#F3F781'");
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=self.MouseOverOldColor");


       
            }
        }

    }



    protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
    {
  
    }

    protected void gvScreening_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {   
        //var selRow = (Control)sender;
        GridViewRow r = gvScreening.Rows[e.RowIndex];
       // string selAppNum = r.Cells[2].Text;

       

        //lExamDate = (Label)e.Row.Cells[2].FindControl("lblExamDate");
        TextBox txtExamDate = r.Cells[3].FindControl("txtExamDate") as TextBox;
        DateTime dtExamDate = Convert.ToDateTime(txtExamDate.Text);
        TextBox txtExamTime = (TextBox)r.Cells[4].FindControl("txtExamTime");
        TextBox txtAvailable = (TextBox)r.Cells[5].FindControl("txtSlotAvailable");
        TextBox txtDesc = (TextBox)r.Cells[6].FindControl("txtExamDesc");

        if (string.IsNullOrEmpty(txtExamDate.Text) || string.IsNullOrEmpty(txtExamTime.Text))
        {
            MessageDialog("Date and Time inputs required!", 3);
        }

        else
        {
            string sTitle = dtExamDate.ToShortDateString() + "-(" + txtExamTime.Text + ")";


            sqlScreeningSetup.UpdateParameters["Sdate"].DefaultValue = dtExamDate.ToShortDateString();
            sqlScreeningSetup.UpdateParameters["Stime"].DefaultValue = txtExamTime.Text;
            sqlScreeningSetup.UpdateParameters["SDesc"].DefaultValue = txtDesc.Text;
            sqlScreeningSetup.UpdateParameters["STitle"].DefaultValue = sTitle;
            sqlScreeningSetup.UpdateParameters["ScheduleAvailableSlot"].DefaultValue = txtAvailable.Text;
            sqlScreeningSetup.UpdateParameters["DU"].DefaultValue = Session["S_SERVERDATE"].ToString();
            sqlScreeningSetup.UpdateParameters["UserCode"].DefaultValue = Session["U_USERID"].ToString();
            sqlScreeningSetup.Update();

            MessageDialog("Schedule Successfully updated!", 2);
        }
    }



    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }


    private void displayAvailableSlotItems()
    { 
     
         for(int x= 0; x < 31; x++)
        {
         ddSchedAvailSlot.Items.Insert(x, new ListItem(x.ToString()));
        }
    }

}