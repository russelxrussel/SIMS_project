using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMSBDAL;
using System.Data;

public partial class heaScreening : System.Web.UI.Page
{
    Health oHealth = new Health();
    Applicant oApplicant = new Applicant();
    Utilities oUtilities = new Utilities();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            displayListOfAppStud();
            displayHealthStatus();
            
            
        }

    }


    //Illness List
    private void displayIllnessList()
    {
        DataTable dt = oHealth.GET_STUDENT_ILLNESS();

         //Display for Category 2
        DataView dvCat1 = new DataView(dt, "CatID = '" + 1 + "'", "Arr", DataViewRowState.CurrentRows);
        chkIllnessListCat1.DataSource = dvCat1;
        chkIllnessListCat1.DataTextField = "IllnessDesc";
        chkIllnessListCat1.DataValueField = "IllnessCode";
        chkIllnessListCat1.DataBind();

        //Display for Category 2
        DataView dvCat2 = new DataView(dt, "CatID = '" + 2 + "'", "Arr", DataViewRowState.CurrentRows);
        chkIllnessListCat2.DataSource = dvCat2;
        chkIllnessListCat2.DataTextField = "IllnessDesc";
        chkIllnessListCat2.DataValueField = "IllnessCode";
        chkIllnessListCat2.DataBind();

    }

    //Medicine May Given List
    private void dispalyMedicineMayGiven()
    {
        DataTable dt = oHealth.GET_STUDENT_MEDICINE_GIVEN();

        chkMedicineMayGiven.DataSource = dt;
        chkMedicineMayGiven.DataTextField = dt.Columns["MedDesc"].ToString();
        chkMedicineMayGiven.DataValueField = dt.Columns["MedCode"].ToString();
        chkMedicineMayGiven.DataBind();
    }


    //Display List of Customer
    private void displayListOfAppStud()
    {
        //DataTable dt = oApplicant.getApplicant();
        DataTable dt = oHealth.GET_APPLICANT_CLINIC_LIST();
        //DataView dv = new DataView(dt, "statCode='" + 1 + "'", "FullName Asc", DataViewRowState.CurrentRows);
        DataView dv = new DataView();
        dv = dt.DefaultView;
        dv.Sort= "FullName Asc";

        gvAppStudentList.DataSource = dv;
        gvAppStudentList.DataBind();
    
    }

    //Private void list of Health Status

    private void displayHealthStatus()
    {
        DataTable dt = oUtilities.GET_APPLICANT_HEALTH_STATUS();

        ddClinicRecommendation.DataSource = dt;
        ddClinicRecommendation.DataTextField = dt.Columns["HealthStatusRemarks"].ToString();
        ddClinicRecommendation.DataValueField = dt.Columns["HealthStatusCode"].ToString();
        ddClinicRecommendation.DataBind();

        ddClinicRecommendation.Items.Insert(0, new ListItem("--Select Status"));
    }



    //Display Retrive Health Data
    private void retrieveAppStudHealth(string INPUT)
    {
        //DataTable dt = oHealth.retrieveHealthIllness();
        DataSet ds = oHealth.RET_STUDENT_HEALTH_DETAILS(INPUT);
        DataTable dtIllnessCat = ds.Tables[0];
        DataTable dtMedicine = ds.Tables[1];
        DataTable dtHealthRecord = ds.Tables[2];

        //Category 1
        DataRow[] drCat1 = dtIllnessCat.Select("SNUM ='" + INPUT + "' AND CatID='" + 1 + "'");
        chkIllnessListCat1.Items.Clear();

        if (drCat1.Length > 0)
        {
            foreach (DataRow row in drCat1)
            {
                ListItem oLi = new ListItem();
                oLi.Text = row["IllnessDesc"].ToString();
                oLi.Value = row["IllnessCode"].ToString();
                oLi.Selected = Convert.ToBoolean(row["IsChecked"]);

                chkIllnessListCat1.Items.Add(oLi);
            }

        }

        //Category 2 Retrieval
        DataRow[] drCat2 = dtIllnessCat.Select("SNUM ='" + INPUT + "' AND CatID='" + 2 + "'");
        chkIllnessListCat2.Items.Clear();

        if (drCat2.Length > 0)
        {
            foreach (DataRow row in drCat2)
            {
                ListItem oLi = new ListItem();
                oLi.Text = row["IllnessDesc"].ToString();
                oLi.Value = row["IllnessCode"].ToString();
                oLi.Selected = Convert.ToBoolean(row["IsChecked"]);

                chkIllnessListCat2.Items.Add(oLi);
            }

        }

        //Medicine Retrieval
        DataRow[] drMed = dtMedicine.Select("SNUM='" + INPUT + "'");
        chkMedicineMayGiven.Items.Clear();
        if (drMed.Length > 0)
        {
            foreach (DataRow row in drMed)
            { 
                ListItem oLi = new ListItem();
                oLi.Text = row["MedDesc"].ToString();
                oLi.Value = row["MedCode"].ToString();
                oLi.Selected = Convert.ToBoolean(row["IsChecked"]);

                chkMedicineMayGiven.Items.Add(oLi);
            }
            
        }

        //Health Record Details
        DataRow[] drHRecord = dtHealthRecord.Select("SNUM='" + INPUT + "'");
        if (drHRecord.Length > 0)
        {
            foreach (DataRow row in drHRecord)
            {
                chkCongenital.Checked = (bool)row["IsCongenital"];
                txtCongenitalDesc.Text = row["CongenitalDesc"].ToString();
                chkHospitalized.Checked = (bool)row["IsHospitalized"];

                //if (string.IsNullOrEmpty(row["DateHospitalized"].ToString()))
                //{
                //    //Do nothing
                //}
                //else
                //{
                    txtDateHospitalized.Text = row["DateHospitalized"].ToString();  //Convert.ToDateTime(row["DateHospitalized"]).ToString("d");
                //}
                
                txtHospitalized.Text = row["ReasonHospitalized"].ToString();
                chkSurgery.Checked = (bool)row["IsMinorMajor"];
                txtSurgery.Text = row["MinorMajorDesc"].ToString();
                //if (string.IsNullOrEmpty(row["MinorMajorDate"].ToString()))
                //{
                //    //Do nothing
                //}
                //else
                //{
                //    
                //}
                txtDateSurgery.Text = row["MinorMajorDate"].ToString();
                
                chkAccidents.Checked = (bool)row["IsSeriousAccident"];
                txtAccidents.Text = row["SeriousAccidentDesc"].ToString();
                //if(string.IsNullOrEmpty(row["SeriousAccidentDate"].ToString()))
                //{
                ////Do nothing
                //}
                //else
                //{
                txtDateAccident.Text = row["SeriousAccidentDate"].ToString();

                txtRemarksParent.Text = row["ParentRemarks"].ToString();
                txtNurseRemarks.Text = row["NurseRemarks"].ToString();
                if (string.IsNullOrEmpty(row["HealthStatusCode"].ToString()))
                {
                    //Do nothing
                    ddClinicRecommendation.SelectedIndex = 0;
                }
                else {
                    ddClinicRecommendation.SelectedValue = row["HealthStatusCode"].ToString();
                }

                txtOthers.Text = row["illOthers"].ToString();
            }
        }




    }


    //Clearing Inputs

    private void clearInputs()
    {
        //Checkbox List Clear and Load
        chkIllnessListCat1.Items.Clear();
        chkIllnessListCat2.Items.Clear();
        chkMedicineMayGiven.Items.Clear();

        //Load
        //displayIllnessList();
        //dispalyMedicineMayGiven();

        //Checkbox
        chkCongenital.Checked = false;
        chkHospitalized.Checked = false;
        chkSurgery.Checked = false;
        chkAccidents.Checked = false;

        //Date Input
        txtDateAccident.Text = "";
        txtDateSurgery.Text = "";
        txtDateHospitalized.Text= "";

        //Textboxes

        txtCongenitalDesc.Text = "";
        txtAccidents.Text = "";
        txtHospitalized.Text ="";
        txtRemarksParent.Text ="";
        txtNurseRemarks.Text = "";
        txtSurgery.Text = "";

        //Label

        lblContacts.Text ="";
        lblEmergency.Text ="";
        lblStudentName.Text ="";

        txtOthers.Text = "";
        //Selected index of remarks
        ddClinicRecommendation.SelectedIndex = 0;

    }
   

    //CRU TRANSACTION

    private void InsertRecord(string _snum, int _statcode)
    {

       
            //Loop and save data entry to Health Illness_MF Category 1
            foreach (ListItem li in chkIllnessListCat1.Items)
            {
                oHealth.INSERT_STUDENT_ILLNESS(_snum, li.Value.ToString(), li.Selected);
            }

            //Loop and save data entry to Health Illness_MF Category 1
            foreach (ListItem li in chkIllnessListCat2.Items)
            {
                oHealth.INSERT_STUDENT_ILLNESS(_snum, li.Value.ToString(), li.Selected);
            }

            //Loop and save data entry to Health MedicineGiven MF
            foreach (ListItem li in chkMedicineMayGiven.Items)
            {
                oHealth.INSERT_STUDENT_MEDICINE_GIVEN(_snum, li.Value.ToString(), li.Selected);
            }

            //Save input on Health Record
        
            oHealth.INSERT_STUDENT_HEALTH_DETAILS(_snum, chkCongenital.Checked, txtCongenitalDesc.Text, chkHospitalized.Checked, txtDateHospitalized.Text, txtHospitalized.Text,
                                        chkSurgery.Checked, txtSurgery.Text, txtDateSurgery.Text, chkAccidents.Checked, txtAccidents.Text, txtDateAccident.Text, txtRemarksParent.Text, txtNurseRemarks.Text, txtOthers.Text, ddClinicRecommendation.SelectedValue.ToString(),
                                        _statcode, DateTime.Now, Session["U_USERID"].ToString());


    }

    private void updateRecord(string _snum)
    {
        //Update Record of Illness
        foreach (ListItem li in chkIllnessListCat1.Items)
        {
            oHealth.UPDATE_STUDENT_ILLNESS(_snum, li.Value.ToString(), li.Selected);
        }

        foreach (ListItem li in chkIllnessListCat2.Items)
        {
            oHealth.UPDATE_STUDENT_ILLNESS(_snum, li.Value.ToString(), li.Selected);
        }

        //Update Record of GivenMedicine
        foreach (ListItem li in chkMedicineMayGiven.Items)
        {
            oHealth.UPDATE_STUDENT_MEDICINE_GIVEN(_snum, li.Value.ToString(), li.Selected);
        }


        //Update Health Details
        oHealth.UPDATE_STUDENT_HEALTH_DETAILS(_snum, chkCongenital.Checked, txtCongenitalDesc.Text, chkHospitalized.Checked, txtDateHospitalized.Text, txtHospitalized.Text,
                             chkSurgery.Checked, txtSurgery.Text, txtDateSurgery.Text, chkAccidents.Checked, txtAccidents.Text, txtDateAccident.Text, txtRemarksParent.Text, txtNurseRemarks.Text, txtOthers.Text, ddClinicRecommendation.SelectedValue.ToString(),
                             DateTime.Now, Session["U_USERID"].ToString());


    }

 



 

    protected void gvAppStudentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgIcon = (Image)e.Row.Cells[0].FindControl("imgStatus");
            Image imgControl = (Image)e.Row.Cells[5].FindControl("imgAction");

            //Check if applicant have record
            if (oHealth.GET_EXIST_HEALTH_RECORD(e.Row.Cells[1].Text))
            {
                //Indicate that Update action will be use
             
                imgControl.ImageUrl = "~/images/controlsIcon/edit.png";
            }

            else { 
               
                imgControl.ImageUrl = "~/images/controlsIcon/new.png";

            }



            if (e.Row.Cells[2].Text == "B")
            {
                imgIcon.ImageUrl = "~/images/iconLabel/boy.png";
            }

            else {
                imgIcon.ImageUrl = "~/images/iconLabel/girl.png";
            }

            //Hover mouse
            e.Row.Attributes.Add("onmouseover", "self.MouseOverOldColor=this.style.backgroundColor;this.style.backgroundColor='#F3F781'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=self.MouseOverOldColor");

        }
    }
    protected void imgAction_Click(object sender, ImageClickEventArgs e)
    {

        panApplicantSelection.Visible = false;
        panHealthDE.Visible = true;

        //Set default open is Illness
        Accordion1.SelectedIndex = 0;


        var sel = (Control)sender;
        GridViewRow r = (GridViewRow)sel.NamingContainer;
        
        
        //This was get from gridview rows
        ViewState["SEL_APPNO"] = r.Cells[1].Text;
        ViewState["SEL_NAME"] = r.Cells[2].Text;

        if (oHealth.GET_EXIST_HEALTH_RECORD(ViewState["SEL_APPNO"].ToString()))
        {

            //clear all dynmic checkbox first
            chkIllnessListCat1.Items.Clear();
            chkIllnessListCat2.Items.Clear();
            chkMedicineMayGiven.Items.Clear();

            retrieveAppStudHealth(ViewState["SEL_APPNO"].ToString());

            ViewState["ACTION"] = 2; //Indicate that action will be update
        }

        else

        {
            ViewState["ACTION"] = 1; //Action will be insert
         
           
           
            clearInputs();

            //Display Default checkboxes
            displayIllnessList();
            dispalyMedicineMayGiven();
        }


        //Display Brief info of Applicant
        DataTable dt = oHealth.GET_APPLICANT_CLINIC_LIST();

        //Category 1
        DataRow[] dr = dt.Select("AppNum ='" + ViewState["SEL_APPNO"].ToString() + "'");
        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                lblEmergency.Text = row["ContactPerson"].ToString();
                lblStudentName.Text = row["FullName"].ToString();
                lblContacts.Text = row["TelNo"].ToString() + "-" + row["MobileNo"].ToString();
            }
        }




    }

    protected void imgReturn_Click(object sender, ImageClickEventArgs e)
    {
        panApplicantSelection.Visible = true;
        panHealthDE.Visible = false;
    }

    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {

        //Clinic Recommendation should not be default into 0 index
        if (ddClinicRecommendation.SelectedIndex == 0)
        {
            //string message = "Please select your recommendation!";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.onload=function(){");
            //sb.Append("alert('");
            //sb.Append(message);
            //sb.Append("')};");
            //sb.Append("</script>");

            ////ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", sb.ToString());

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sb.ToString(), true);
            //lblMessage.Text = "Error";
            //lblMessage.ForeColor = System.Drawing.Color.Red;

         MessageDialog("Please select clinic recommendation.", 3);

        }

        else
        {
            int healthStatCode = 9;

           
            if(ddClinicRecommendation.SelectedValue.ToString() == "P")
            
            {
                //Success
                healthStatCode = 2;
            }

            else if (ddClinicRecommendation.SelectedValue.ToString() == "S")
            {
                //Special Arrangement
                 healthStatCode = 3;
            }
            else    if (ddClinicRecommendation.SelectedValue.ToString() == "O")
            {
                //on hold
                healthStatCode = 4;
            }
            else if(ddClinicRecommendation.SelectedValue.ToString() == "F")
            {
                //Failed
                healthStatCode = 5;
            }
            


            if ((int)ViewState["ACTION"] == 1)
            {

                //Validation
                if (oHealth.GET_EXIST_HEALTH_RECORD(ViewState["SEL_APPNO"].ToString()))
                {
                  
                }

                else
                {

                    //Insert New Record
                    InsertRecord(ViewState["SEL_APPNO"].ToString(), healthStatCode);

                    oHealth.UPDATE_APPLICANT_STATUS_TRAIL(ViewState["SEL_APPNO"].ToString(), healthStatCode);

          //          oHealth.updateApplicantStatusTrail(ViewState["SEL_APPNO"].ToString(), statcode);

                    //Reload the data
                    displayListOfAppStud();

                    //return to selection
                    imgReturn_Click(sender, e);
                    
                    MessageDialog(lblStudentName.Text + " Health record successfully saved.", 1);

                }

            }

            else if ((int)ViewState["ACTION"] == 2)
            {
                //Update Record
                updateRecord(ViewState["SEL_APPNO"].ToString());
                //oHealth.updateApplicantStatusTrail(ViewState["SEL_APPNO"].ToString(), healthStatCode);

                oHealth.UPDATE_APPLICANT_STATUS_TRAIL(ViewState["SEL_APPNO"].ToString(), healthStatCode);
                //Return to Selection
                imgReturn_Click(sender, e);
                
                MessageDialog(lblStudentName.Text + " Health record successfully updated.", 2);

            }

        }
    }
    protected void gvAppStudentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAppStudentList.PageIndex = e.NewPageIndex;

        //Reload List again
        displayListOfAppStud();
    }


    //Search Student in the list
    private void displaySearchViaName(string INPUT)
    {
        DataTable dt = new DataTable();
        dt = oHealth.GET_APPLICANT_CLINIC_LIST();

        DataView dv = new DataView(dt);
        dv.RowFilter = "Fullname like '%" + INPUT + "%'";

        gvAppStudentList.DataSource = dv;
        gvAppStudentList.DataBind();
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        displaySearchViaName(txtSearch.Text);
    }

    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }

}