using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class regStudentClassList : System.Web.UI.Page
{
    Student oStudent = new Student();
    Utilities oUtilities = new Utilities();

    
   
    


    #region "CONTROL EVENT"
    /*=======================================================================================
    ***************************************************************************************
    CONTROL EVENT - SECTION
    ***************************************************************************************
    =======================================================================================*/
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadOldStudentActive();
            displayLevelType();
            displaySectionList();
            displayRoomList();
            displayTeacherList();

            displayAvailableSections();

            pnlTransaction.Visible = false;

            ////displayStrand();
           
        }

        panelEdit.Enabled = false;
       

        //ViewState["ACTION"] = "";
        //_actionCommand = false;
        //ViewState["ACTIONCOMMAND"] = "INSERT";

    }



  


    protected void gvSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvSource.PageIndex = e.NewPageIndex;

        //DisplayStudentList(ddLevelType.SelectedValue.ToString());
    }


    protected void gvSource_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgIcon = (Image)e.Row.Cells[2].FindControl("imgIcon");

            if ((e.Row.Cells[1].Text) == "B")
            {
                imgIcon.ImageUrl = "~/images/iconLabel/boy.png";
            }

            else
            {
                imgIcon.ImageUrl = "~/images/iconLabel/girl.png";
            }

        }

    }

    protected void gvDestination_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgIcon = (Image)e.Row.Cells[2].FindControl("imgIcon");

            if ((e.Row.Cells[1].Text) == "B")
            {
                imgIcon.ImageUrl = "~/images/iconLabel/boy.png";
            }

            else
            {
                imgIcon.ImageUrl = "~/images/iconLabel/girl.png";
            }

        }
    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
 
      //CONDITION
        if (ddLevelType.SelectedIndex == 0 || ddSection.SelectedIndex == 0 || ddRoomList.SelectedIndex == 0) //|| ddTeacherList.SelectedIndex == 0 || string.IsNullOrEmpty(txtDaysDesc.Text))
        {
            lblFormMessage.Text = "Fields required to fill up!";
            return;
        }


        if ((int)ViewState["ACTIONCOMMAND"] == 1)
            {


            //if (check_teachersection(ddLevelType.SelectedValue.ToString(), ddSection.SelectedValue.ToString(), Convert.ToInt32(ddRoomList.SelectedValue.ToString())))//,ddSection.SelectedValue.ToString(),Convert.ToInt32(ddRoomList.SelectedValue.ToString())))
            //{
            //    pnlTransaction.Visible = false;
            //    lblFormMessage.Text = "This section was already exist.";
            //}
            //    else
            //        {
                        
                        oStudent.INSERT_TEACHERSECTION(Session["S_SY"].ToString(), ddLevelType.SelectedValue.ToString(), ddSection.SelectedValue.ToString(),
                                                  Convert.ToInt32(ddRoomList.SelectedValue.ToString()), ddTeacherList.SelectedValue.ToString(), txtDaysDesc.Text,
                                                  txtBuildingDesc.Text, Session["U_USERID"].ToString());

                DisplayStudentNoSectionYet(ddLevelType.SelectedValue.ToString());
               
                PanelSetter.Enabled = false;
                pnlTransaction.Visible = true;
                lblFormMessage.Text = "";

                panelEdit.Enabled = false;

                reloadSectionList();

                
                     }
            //}

        else if ((int)ViewState["ACTIONCOMMAND"] == 2)
                    {
                        oStudent.UPDATE_TEACHERSECTION(Session["S_SY"].ToString(), ddLevelType.SelectedValue.ToString(), ddSection.SelectedValue.ToString(),
                                  Convert.ToInt32(ddRoomList.SelectedValue.ToString()), ddTeacherList.SelectedValue.ToString(), txtDaysDesc.Text,
                                  txtBuildingDesc.Text, Session["U_USERID"].ToString(), (int)ViewState["_selectedID"]);


                        if (gvDestination.Rows.Count > 0)
                        {
                            //UPDATE section room of students in destination
                            int count = 0;


                            //Loop throug gridview
                            foreach (GridViewRow row in gvDestination.Rows)
                            {

                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDestination");
                                    string getStudNum = row.Cells[3].Text;

                                    //if (chk.Checked)
                                    //{
                                    //    count = count + 1;


                                        //UPDATE SECTION OF SELECTED STUDENT TO STUDENT_MF/STUDENT_INFO_MF/SAP_OCRD
                                        oStudent.UPDATE_STUDENTSECTION(getStudNum, ddSection.SelectedValue.ToString(), Convert.ToInt32(ddRoomList.SelectedValue.ToString()), Session["U_USERID"].ToString());
                                    //}
                                }
                            }
                        }
                    
                        PanelSetter.Enabled = false;
                        pnlTransaction.Visible = true;
                        lblFormMessage.Text = "";

                        panelEdit.Enabled = false;

                        reloadSectionList();
        
                    }


            
        

 }



    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        int count = 0;
  
  
        //Loop throug gridview
       foreach (GridViewRow row in gvSource.Rows)
       {

           if (row.RowType == DataControlRowType.DataRow)
           {
               CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkSource");
               string getStudNum = row.Cells[3].Text;
               
               if (chk.Checked)
               { 
                count = count + 1;
               
                
                //UPDATE SECTION OF SELECTED STUDENT TO STUDENT_MF/STUDENT_INFO_MF/SAP_OCRD
                oStudent.UPDATE_STUDENTSECTION(getStudNum, ddSection.SelectedValue.ToString(), Convert.ToInt32(ddRoomList.SelectedValue.ToString()), Session["U_USERID"].ToString());
               }
           }
       }

        //Reload Source Gridview
       DisplayStudentNoSectionYet(ddLevelType.SelectedValue.ToString());

       //Destination Gridview
       DisplayStudentWithSection(ddLevelType.SelectedValue.ToString(), ddSection.SelectedValue.ToString(), Convert.ToInt32(ddRoomList.SelectedValue.ToString()));
       
    }

    protected void imgNew_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect(Request.RawUrl);

        //Clear things and set as new
        newAction();
    }

 

    #endregion


    #region "METHOD - FUNCTION"

    /*=======================================================================================
    ***************************************************************************************
    METHOD - FUNCTION - SECTION
    ***************************************************************************************
    =======================================================================================*/

    private void newAction()
    {
        //Clear Fields:
        lblDestinationCount.Text = "";
        lblSourceCount.Text = "";
        txtDaysDesc.Text = "";
        txtBuildingDesc.Text = "";

        ddLevelType.SelectedIndex = 0;
        ddRoomList.SelectedIndex = 0;
        ddSection.SelectedIndex = 0;
        ddTeacherList.SelectedIndex = 0;
        //ddStrand.SelectedIndex = 0;

        PanelSetter.Enabled = true;
        pnlTransaction.Visible = false;

        lblFormMessage.Text = "";

        //ViewState["ACTION"] = "INSERT";
        ViewState["ACTIONCOMMAND"] = 1;
        btnEdit.Enabled = false;
    }

    private void displayLevelType()
    {
        oUtilities.getApplicantLevel(ddLevelType);
        ddLevelType.Items.Insert(0, new ListItem("---"));
    }

    private void displaySectionList()
    {
        DataTable dt = oUtilities.GET_SECTION_LIST();


        ddSection.DataSource = dt;
        ddSection.DataTextField = dt.Columns["sectionCode"].ToString();
        ddSection.DataValueField = dt.Columns["sectionCode"].ToString();
        ddSection.DataBind();

        ddSection.Items.Insert(0, new ListItem("---"));


    }

    //private void displayStrand()
    //{
    //    DataTable dt = oUtilities.GET_LEVEL_STRAND();

    //    ddStrand.DataSource = dt;
    //    ddStrand.DataTextField = dt.Columns["strandName"].ToString();
    //    ddStrand.DataValueField = dt.Columns["strandCode"].ToString();
    //    ddStrand.DataBind();

    //    ddStrand.Items.Insert(0, new ListItem("---"));
    //}

    private void displayRoomList()
    {
        DataTable dt = oUtilities.GET_ROOM_LIST();
        DataView dv = dt.DefaultView;

        dv.Sort = "roomDescription ASC";


        ddRoomList.DataSource = dv;
        ddRoomList.DataTextField = dv.Table.Columns["roomDescription"].ToString();
        ddRoomList.DataValueField = dv.Table.Columns["roomID"].ToString();
        ddRoomList.DataBind();

        ddRoomList.Items.Insert(0, new ListItem("---"));
    }

    private void displayTeacherList()
    {
        DataTable dt = oUtilities.GET_TEACHER_LIST();
        DataView dv = dt.DefaultView;

        dv.Sort = "Uname ASC";


        ddTeacherList.DataSource = dv;
        ddTeacherList.DataTextField = dv.Table.Columns["uname"].ToString();
        ddTeacherList.DataValueField = dv.Table.Columns["userid"].ToString();
        ddTeacherList.DataBind();

        ddTeacherList.Items.Insert(0, new ListItem("---"));
    }

    private string GetIconGender(string gender)
    {
        return string.Format("/images/iconLabel/{0}.png", gender);
    }

    private void DisplayStudentNoSectionYet(string _leveltypecode)
    {
        DataTable dt = oStudent.GET_STUDENTS_NO_SECTION();
        DataView dv = dt.DefaultView;

        //CONDITION 
        //if (_leveltypecode == "G11" || _leveltypecode == "G12")
        //{
        //    dv.RowFilter = "levelcode='" + _leveltypecode + "' and strandCode= '" + ddStrand.SelectedValue.ToString() + "'";
        //}
        //else
        //{ 
        dv.RowFilter = "levelcode='" + _leveltypecode + "'";
        //}

        dv.Sort = "StudName";
        gvSource.DataSource = dv;
        gvSource.DataBind();

        lblSourceCount.Text = gvSource.Rows.Count.ToString();

    }

    private void DisplayStudentWithSection(string _leveltypecode, string _sectionCode, int _roomID)
    {
        DataTable dt = oStudent.GET_STUDENTS_WITH_SECTION();
        DataView dv = dt.DefaultView;

        ////CONDITION 
        //if (_leveltypecode == "G11" || _leveltypecode == "G12")
        //{
        //    dv.RowFilter = "levelcode = '" + _leveltypecode + "' and strandcode ='" + ddStrand.SelectedValue.ToString() + "' and section = '" + _sectionCode + "' and roomID = '" + _roomID + "'";
        //}
        //else
        //{
            dv.RowFilter = "levelcode = '" + _leveltypecode + "' and section = '" + _sectionCode + "' and roomID = '" + _roomID + "'";
        //}
       
        dv.Sort = "StudName";

        gvDestination.DataSource = dv;
        gvDestination.DataBind();

        lblDestinationCount.Text = gvDestination.Rows.Count.ToString();
    }

    private void reloadSectionList()
    {
        DataTable dt = oStudent.GET_TEACHER_SECTION_LIST();
        DataView dv = dt.DefaultView;

        dv.Sort = "roomId ASC";

        gvListSection.DataSource = dv;
        gvListSection.DataBind();
    
    }

    private void displayAvailableSections()
    {
        DataTable dt = oStudent.GET_TEACHER_SECTION_LIST();
        DataView dv = dt.DefaultView;

        dv.Sort = "roomId ASC";

        gvListSection.DataSource = dv;
        gvListSection.DataBind();
        
    }

    private void displaySelectedSection(int _sectionID)
    {
        DataTable dt = oStudent.GET_TEACHER_SECTION_LIST();
        DataView dv = dt.DefaultView;

        dv.RowFilter = "id = '" + _sectionID + "'";

        //Will get the dataview record
        DataRowView drv = dv[0];
        
        if (dv.Count > 0)
        {

            ddLevelType.SelectedValue = drv["levelcode"].ToString();
            ddRoomList.SelectedValue = drv["roomid"].ToString();
            ddSection.SelectedValue = drv["sectioncode"].ToString();

            //if (string.IsNullOrEmpty(drv["strandcode"].ToString()) || drv["strandcode"].ToString() == "")
            //{
            //    ddStrand.SelectedIndex = 0;
            //    ddStrand.Enabled = false;
            //}
            //else
            //{
            //    ddStrand.SelectedValue = drv["strandcode"].ToString();
            //}

            if (string.IsNullOrEmpty(drv["teacherID"].ToString()))
            {
            ddTeacherList.SelectedIndex = 0;
            }
            else{
            ddTeacherList.SelectedValue = drv["teacherID"].ToString();
            }
            
            
            txtDaysDesc.Text = drv["Schedule"].ToString();
            txtBuildingDesc.Text = drv["bldgDesc"].ToString();
            
            //Make Transaction Panel Visible
            pnlTransaction.Visible = true;
            PanelSetter.Enabled = false;
        
            //display the data on source and destination gridview
            //Source Gridview
            DisplayStudentNoSectionYet(ddLevelType.SelectedValue.ToString());

            //Destination Gridview
            DisplayStudentWithSection(ddLevelType.SelectedValue.ToString(),ddSection.SelectedValue.ToString(),Convert.ToInt32(ddRoomList.SelectedValue.ToString()));

           

        }
    }

    //CHECKING

    private bool check_teachersection(string _levelcode, string _sectioncode, int _roomid) //, , int _roomid
    {
        bool x = false;

        DataTable dt = oStudent.GET_TEACHER_SECTION_LIST();
        DataView dv = dt.DefaultView;


        dv.RowFilter = "levelcode= '" + _levelcode + "' and sectioncode= '" + _sectioncode + "' and roomid = '" + _roomid + "'";// and roomid= '" + _roomid +"'";


        if (dv.Count > 0)
        {
            x = true;
        }
        else { x = false; }



        return x;

    }


    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }

    #endregion


    protected void imgModify_Click(object sender, ImageClickEventArgs e)
    {
        displayAvailableSections();
    }



    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        var selEdit = (Control)sender;
        GridViewRow r = (GridViewRow)selEdit.NamingContainer;

        ViewState["_selectedID"] = Convert.ToInt32(r.Cells[1].Text);

        displaySelectedSection((int)ViewState["_selectedID"]);

        panelEdit.Enabled = true;

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        /*
         *  ============================================================
         THIS WILL CLEAR STUDENT SECTION AND ROOM ID ON DESTINATION
         05/17/2016
        ============================================================
        */

       // int count = 0;

        //Loop throug gridview
        foreach (GridViewRow row in gvDestination.Rows) 
        {

            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkDestination");
                string getStudNum = row.Cells[3].Text;

                if (chk.Checked)
                {
                   // count = count + 1;


                    //UPDATE SECTION OF SELECTED STUDENT TO STUDENT_MF/STUDENT_INFO_MF/SAP_OCRD
                    oStudent.UPDATE_STUDENTSECTION(getStudNum, "", 0, Session["U_USERID"].ToString());
                }
            }
        }

        //Reload Source Gridview
        DisplayStudentNoSectionYet(ddLevelType.SelectedValue.ToString());

        //Destination Gridview
        DisplayStudentWithSection(ddLevelType.SelectedValue.ToString(), ddSection.SelectedValue.ToString(), Convert.ToInt32(ddRoomList.SelectedValue.ToString()));
       
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //ViewState["ACTION"] = "UPDATE";
        ViewState["ACTIONCOMMAND"] = 2;

        PanelSetter.Enabled = true;

        
    }

    protected void ddLevelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddLevelType.SelectedValue.ToString() == "G11" || ddLevelType.SelectedValue.ToString() == "G12")
        //{
        //    ddStrand.Enabled = true;
        //    //displayStrand();
        //}
        //else
        //{
        //    ddStrand.SelectedIndex = 0;
        //    ddStrand.Enabled = false;
        //}

    }
}