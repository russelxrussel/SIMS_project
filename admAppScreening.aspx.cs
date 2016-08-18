using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMSBDAL;

public partial class admAppScreening : System.Web.UI.Page
{
    Utilities oUtilities = new Utilities();
    Applicant oApplicant = new Applicant();
    ApplicantSchedule oAppSchedule = new ApplicantSchedule();
    ApplicantTesting oAppTesting = new ApplicantTesting();
  
    private DataTable dtSchedule;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            loadDropDown();

            displayApplicantList();
            
        }

    }


    private void loadDropDown()
    {
        //oUtilities.getApplicantType(ddApplicantType);
        oUtilities.getApplicantLevel(ddLevelType);
        ddLevelType.Items.Insert(0, new ListItem("-- Select Level --"));
    }


   

    private void displayApplicantList()
    {
        gvApplicantScheduleList.DataSource = oAppSchedule.getApplicantForScheduling();
        gvApplicantScheduleList.DataBind();
    }


   

    protected void imgNew_Click(object sender, ImageClickEventArgs e)
    {
        var selEdit = (Control)sender;
        GridViewRow r = (GridViewRow)selEdit.NamingContainer;
       
        string selAppNum = r.Cells[2].Text; //2 because oh hidden column
        string selAppName = r.Cells[3].Text;

        TextBox selOR = (TextBox)r.Cells[4].FindControl("txtOR");
        CheckBox selChkFree = (CheckBox)r.Cells[4].FindControl("chkFree");
        DropDownList ddExamScheduleList = (DropDownList)r.Cells[5].FindControl("ddExamScheduleList");
        DropDownList ddIntScheduleList = (DropDownList)r.Cells[6].FindControl("ddIntScheduleList");
        DropDownList ddExamStatus = (DropDownList)r.Cells[7].FindControl("ddExamStatus");

        //Hold selected value
        
        int iExamStatus = 0, iIntID = 0, iExamID= 0;

        if (ddExamScheduleList.SelectedIndex != 0)
        {
            iExamID = Convert.ToInt32(ddExamScheduleList.SelectedValue.ToString());
        }
        
        if (ddIntScheduleList.SelectedIndex != 0)
        {
            iIntID = Convert.ToInt32(ddIntScheduleList.SelectedValue.ToString());
        }

        if (ddExamStatus.SelectedIndex != 0)
        {
            iExamStatus = Convert.ToInt32(ddExamStatus.SelectedValue.ToString());
        }
         


        if (ddExamScheduleList.SelectedIndex == 0 || ddExamStatus.SelectedIndex == 0)
        {
            MessageDialog("Please Select Examination Schedule and Status", 3);
        }

        else

        {

            //THIS IS USE FOR APPLICANT TRAIL STATUS IN SCHEDULING
            int ScheduleStatCode = 9;
            
            if (ddExamStatus.SelectedValue.ToString() == "1")
            {
                //Scheduled
                ScheduleStatCode = 6;
            }

            else if (ddExamStatus.SelectedValue.ToString() == "2")
            { 
                //Re-Scheduled
                ScheduleStatCode = 7;
            }

            else if (ddExamStatus.SelectedValue.ToString() == "3")

            {
                //BACK-OUT
                ScheduleStatCode = 8;
            }

              //Check if free 
                if (selChkFree.Checked)
                {
                    //Allowed save
                    if (oAppSchedule.checkExistAppInSchedule(selAppNum))
                    {
                            //Exist the prorcess will be UPDATE.
                            oAppSchedule.UpdateApplicantSchedule(selAppNum, selOR.Text, iExamID, iIntID, iExamStatus, selChkFree.Checked, Convert.ToDateTime(Session["S_SERVERDATE"].ToString()), Session["U_USERID"].ToString());
                            MessageDialog(selAppName + " scheduled successfully updated.", 2);

                        //Will decrease schedule by 1
                        oAppSchedule.updateScreeingSetupSlot(iExamID);
                        oAppSchedule.updateScreeingSetupSlot(iIntID);

                        //UPDATE SCHEDULE STAT IN STATUS TRAIL
                        oAppSchedule.UPDATE_ApplicantStatusTrail(selAppNum, ScheduleStatCode);
                        btnDisplayListOfApplicant_Click(sender, e);
                    }

                    else
                    {
                        //No record, the prorcess will be INSERT.
                        oAppSchedule.InsertApplicantSchedule(selAppNum, selOR.Text, iExamID, iIntID, iExamStatus, selChkFree.Checked, DateTime.Now, Session["U_USERID"].ToString());
                        MessageDialog(selAppName + " has been successfully scheduled.", 1);

                        //Will decrease schedule by 1
                        oAppSchedule.updateScreeingSetupSlot(iExamID);
                        oAppSchedule.updateScreeingSetupSlot(iIntID);

                        //UPDATE SCHEDULE STAT IN STATUS TRAIL
                        oAppSchedule.UPDATE_ApplicantStatusTrail(selAppNum, ScheduleStatCode);

                        btnDisplayListOfApplicant_Click(sender, e);
                    }

                }
                else
                {

                    if (!oApplicant.CHECKING_OR_INPUT(selOR.Text))
                    {
                        MessageDialog("Invalid Receipt No. input.", 3);
                    }

                    else
                    {
                        //another checking
                        //
                        if (oAppSchedule.CHECK_EXIST_OR(selOR.Text) == true && oAppSchedule.checkExistAppInSchedule(selAppNum) == false)
                        {
                            MessageDialog("Receipt No. already in used.", 3);
                        }
                        else
                        {

                            //SELECTION WHAT CONTROLS WILL FIRE UP
                            if (oAppSchedule.checkExistAppInSchedule(selAppNum))
                            {
                               
                                    //Exist the prorcess will be UPDATE.
                                oAppSchedule.UpdateApplicantSchedule(selAppNum, selOR.Text, iExamID, iIntID, iExamStatus, selChkFree.Checked, Convert.ToDateTime(Session["S_SERVERDATE"].ToString()), Session["U_USERID"].ToString());
                                MessageDialog(selAppName + " scheduled successfully updated.", 2);


                                //Will decrease schedule by 1
                                oAppSchedule.updateScreeingSetupSlot(iExamID);
                                oAppSchedule.updateScreeingSetupSlot(iIntID);


                                
                                //UPDATE SCHEDULE STAT IN STATUS TRAIL
                                oAppSchedule.UPDATE_ApplicantStatusTrail(selAppNum, ScheduleStatCode);
                                
                                btnDisplayListOfApplicant_Click(sender, e);
                            }

                            else
                            {
                                //No record, the prorcess will be INSERT.
                                oAppSchedule.InsertApplicantSchedule(selAppNum, selOR.Text, iExamID, iIntID, iExamStatus, selChkFree.Checked, DateTime.Now, Session["U_USERID"].ToString());
                                MessageDialog(selAppName + " has been successfully scheduled.", 1);

                                //Will decrease schedule by 1
                                oAppSchedule.updateScreeingSetupSlot(iExamID);
                                oAppSchedule.updateScreeingSetupSlot(iIntID);

                                //UPDATE SCHEDULE STAT IN STATUS TRAIL
                                oAppSchedule.UPDATE_ApplicantStatusTrail(selAppNum, ScheduleStatCode);

                                btnDisplayListOfApplicant_Click(sender, e);
                            }
                        }

                    
                } 
            }
        }

       
       
    }

    protected void btnDisplayListOfApplicant_Click(object sender, EventArgs e)
    {

        gvApplicantScheduleList.DataSource = oAppSchedule.getApplicantForScheduling(); 
        gvApplicantScheduleList.DataBind();
        
    }

    protected void gvApplicantScheduleList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dtExamScheduleList = new DataTable();
        dtExamScheduleList = oAppSchedule.getScheduleList("E");

        DataTable dtIntScheduleList = new DataTable();
        dtIntScheduleList = oAppSchedule.getScheduleList("I");

        DataTable dtExamStat = new DataTable();
        dtExamStat = oUtilities.GET_SCREENING_STATUS();

        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                Image imgIcon = (Image)e.Row.Cells[1].FindControl("imgIcon");
                Image imgControl = (Image)e.Row.Cells[8].FindControl("imgControl");
                TextBox txtOR = (TextBox)e.Row.Cells[4].FindControl("txtOR");
                CheckBox chkFree = (CheckBox)e.Row.Cells[4].FindControl("chkFree");
                

                     //Examination
                    DropDownList ddExamScheduleList = (DropDownList)e.Row.Cells[5].FindControl("ddExamScheduleList");
                    ddExamScheduleList.DataSource = dtExamScheduleList;
                    ddExamScheduleList.DataTextField = dtExamScheduleList.Columns["STitle"].ToString();
                    ddExamScheduleList.DataValueField = dtExamScheduleList.Columns["ID"].ToString();
                    ddExamScheduleList.DataBind();
                    ddExamScheduleList.Items.Insert(0, new ListItem("Select Exam Schedule"));
                    

                    //This code will remove the schedule that already expired.
                    //DataView dv = dtExamScheduleList.DefaultView;
                    //dv.RowFilter = "Status='" + false + "' OR ScheduleAvailableSlot <='" + 0 + "'";
                    //foreach (DataRowView dr in dv)
                    //{
                    //    foreach (ListItem item in ddExamScheduleList.Items)
                    //    {
                    //        if (dr["ID"].ToString() == item.Value.ToString())
                    //        {
                    //            item.Attributes.Add("style", "display:none");
                    //        }
                    //    }
                    //}
                                

                    //Interview
                    DropDownList ddIntScheduleList = (DropDownList)e.Row.Cells[6].FindControl("ddIntScheduleList");
                    ddIntScheduleList.DataSource = dtIntScheduleList;
                    ddIntScheduleList.DataTextField = dtIntScheduleList.Columns["STitle"].ToString();
                    ddIntScheduleList.DataValueField = dtIntScheduleList.Columns["ID"].ToString();
                    ddIntScheduleList.DataBind();
                    ddIntScheduleList.Items.Insert(0, new ListItem("Select Interview Schedule"));

                    //This code will remove the schedule that already expired.
                    //DataView dvInt = dtIntScheduleList.DefaultView;
                    //dv.RowFilter = "Status='" + false + "' OR ScheduleAvailableSlot='" + 0 + "'";
                    //foreach (DataRowView dr in dvInt)
                    //{
                    //    foreach (ListItem item in ddIntScheduleList.Items)
                    //    {
                    //        if (dr["ID"].ToString() == item.Value.ToString())
                    //        {
                    //            item.Attributes.Add("style", "display:none");
                    //        }
                    //    }
                    //}


                    //Status
                    DropDownList ddExamStatus = (DropDownList)e.Row.Cells[7].FindControl("ddExamStatus");
                    ddExamStatus.DataSource = dtExamStat;
                    ddExamStatus.DataTextField = dtExamStat.Columns["Description"].ToString();
                    ddExamStatus.DataValueField = dtExamStat.Columns["SchedStat"].ToString();
                    ddExamStatus.DataBind();

                    ddExamStatus.Items.Insert(0, new ListItem("-- Status --"));


                    if (oAppSchedule.checkExistAppInSchedule(e.Row.Cells[2].Text))
                    {

                        txtOR.Text = oAppSchedule._OR;
                        chkFree.Checked = oAppSchedule._ISFREE;
                        ddExamScheduleList.SelectedValue = oAppSchedule._EXAMID.ToString();
                        ddIntScheduleList.SelectedValue = oAppSchedule._INTID.ToString();
                        //ddExamStatus.SelectedValue = oAppSchedule._SCHEDSTAT.ToString();



                       // Check if Applicant Already Took the Exam and passed
                        if (oAppTesting.ExistAppTest(e.Row.Cells[2].Text) && oAppSchedule._ISPASSED == false && oAppSchedule._SCHEDSTAT == 4)
                        {
                            e.Row.BackColor = System.Drawing.Color.OrangeRed;
                            e.Row.Enabled = false;
                            ddExamStatus.SelectedValue = oAppSchedule._SCHEDSTAT.ToString();
                        }


                        else if (oAppTesting.ExistAppTest(e.Row.Cells[2].Text) && oAppSchedule._ISPASSED == false)
                        {
                            e.Row.BackColor = System.Drawing.Color.SandyBrown;
                            ddExamStatus.Items.Insert(0, new ListItem("FAILED"));
                        }


                        else if (oAppTesting.ExistAppTest(e.Row.Cells[2].Text) && oAppSchedule._ISPASSED == true)
                        {

                            e.Row.BackColor = System.Drawing.Color.LightGreen;
                            e.Row.Enabled = false;

                            //Set the test to Passed
                            ddExamStatus.Items.Insert(0, new ListItem("PASSED"));
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                            ddExamStatus.SelectedValue = oAppSchedule._SCHEDSTAT.ToString();
                        }

                        //Applicant Already Passed don't show the row
                        //if (oAppSchedule._ISPASSED)
                        //{
                        //    //If Applicant Already Passed
                        //    //e.Row.Attributes.Add("style", "display:none");
                        //    e.Row.BackColor = System.Drawing.Color.LightGreen;
                        //    e.Row.Enabled = false;  
                        //}
                        //else
                        //{
                            //e.Row.BackColor = System.Drawing.Color.
                            imgControl.ImageUrl = "~/images/controlsIcon/update_sched.png";
                        //}

                       


                        //Applicant Status is Backout
                        if (oAppSchedule._SCHEDSTAT == 3)
                        {
                            e.Row.Enabled = false;
                            e.Row.BackColor = System.Drawing.Color.DarkGray;
                            ddExamStatus.SelectedValue = oAppSchedule._SCHEDSTAT.ToString();
                        }

                        ////RETEST
                        //if (oAppSchedule._SCHEDSTAT == 4)
                        //{
                        //    e.Row.Enabled = false;
                        //   // e.Row.BackColor = System.Drawing.Color.LightCoral;
                        //}
                        
                       

                    }

                    else
                    {
                        imgControl.ImageUrl = "~/images/controlsIcon/new.png";
                       
                    }



                        if ((e.Row.Cells[0].Text) == "B")
                        {
                            imgIcon.ImageUrl = "~/images/iconLabel/boy.png";
                        }

                        else
                        {
                            imgIcon.ImageUrl = "~/images/iconLabel/girl.png";
                        }

              


          
            //Hover mouse
            e.Row.Attributes.Add("onmouseover", "self.MouseOverOldColor=this.style.backgroundColor;this.style.backgroundColor='#F3F781'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=self.MouseOverOldColor");
            
        }
    }

    protected void gvApplicantScheduleList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvApplicantScheduleList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvApplicantScheduleList.PageIndex = e.NewPageIndex;

        //Reload List again
        displayApplicantList();
    }

    //Search Applicant in the list
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        if(string.IsNullOrEmpty(txtSearch.Text))
        {
            MessageDialog("Please Type on Search box", 3);
        }
        else
        {
        displaySearchViaName(txtSearch.Text);
        }
    }

  
    private void displaySearchViaName(string INPUT)
    {
        DataTable dt = new DataTable();
        dt = oAppSchedule.getApplicantForScheduling();

        DataView dv = new DataView(dt);
        dv.RowFilter = "Name like '%" + INPUT + "%'";
        dv.Sort = "Name ASC";

        gvApplicantScheduleList.DataSource = dv;
        gvApplicantScheduleList.DataBind();
    }

    //Search Applicant in the list
    protected void imgSearchViaLevel_Click(object sender, ImageClickEventArgs e)
    {
        if (ddLevelType.SelectedIndex == 0)
        {
            MessageDialog("Please Select Level", 3);
        }
        else
        {
            displaySearchViaLevel(ddLevelType.SelectedValue.ToString());
        }
    }
   
    private void displaySearchViaLevel(string INPUT)
    {
        DataTable dt = new DataTable();
        dt = oAppSchedule.getApplicantForScheduling();

        DataView dv = new DataView(dt);
        dv.RowFilter = "LevelTypeCode = '" + INPUT + "'";
        dv.Sort = "Name ASC";

        gvApplicantScheduleList.DataSource = dv;
        gvApplicantScheduleList.DataBind();
    }

   


    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }


   

}