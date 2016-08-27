using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMSBDAL;

public partial class HealthInfo : System.Web.UI.Page
{
    Health oHealth = new Health();
    Student oStudent = new Student();

    Applicant oApplicant = new Applicant();
    Utilities oUtilities = new Utilities();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            displayHealthStatus();
            displayIllnessList();
            dispalyMedicineMayGiven();

            panHealthDE.Enabled = false;

            complaintDefault();

           

            display_IncidentSelection();

            //Initialize temporary Data Table
            createTempDTComplaint();
            createTempDTMedicine();


            panComplaintMain.Visible = false;
            panMedicineContent.Enabled = false;



            //Complaint Action Identifier
            //DEFAULT VALUE: 1 = NEW RECORD
            //VALUE: 2 = UPDATE RECORD

            ViewState["COMPLAINT_ACTION"] = 1;

            //This will use to check if the user
            //didn't add the medicine with stock value.
            //08/27/2016
            ViewState["FLG_MED_CONTROL"] = false;

            //Generation of TransactionCode
            generateReferenceNum();
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

       
        lblStudentName.Text ="";
        lblStudNum.Text = "";

        lblContactAddress.Text = "";
        lblContactName.Text = "";
        lblContactNumber.Text = "";
        lblRelation.Text = "";

        txtOthers.Text = "";
        lblGradeLevel.Text = "";
        //Selected index of remarks
        ddClinicRecommendation.SelectedIndex = 0;

        panHealthDE.Enabled = false;
        txtSearch.Text = "";
        tcHealthEntry.ActiveTabIndex = 0;

    }
   

    //Complaint Default
    private void complaintDefault()
    {
        
        //List of Complaints
        DataTable dt = oHealth.GET_COMPLAINT_LIST();
        ddComplaintSelection.DataSource = dt;
      
        ddComplaintSelection.DataValueField = dt.Columns["complaintCode"].ToString();
        ddComplaintSelection.DataTextField = dt.Columns["complaintDesc"].ToString();
        ddComplaintSelection.DataBind();


       //List of Medicine
        DataTable dtMed = oHealth.GET_MEDICINE_LIST();
        ddMedicineSelection.DataSource = dtMed;

        ddMedicineSelection.DataValueField = dtMed.Columns["medCode"].ToString();
        ddMedicineSelection.DataTextField = dtMed.Columns["medDesc"].ToString();
        ddMedicineSelection.DataBind();        
    }

    //Generation of complaint reference Report
    private void generateReferenceNum()
    {
        DateTime dc = new DateTime();
        dc = Convert.ToDateTime(Session["S_SERVERDATE"].ToString());

        txtDateComplaint.Text = dc.ToShortDateString();
        txtTimeComplaint.Text = DateTime.Now.ToShortTimeString();


        //Hold the value for the entire page cycle
        ViewState["TRANSACTIONCODE"] = dc.ToString("yyyyMMdd") + DateTime.Now.ToString("mmssf");
    }

    private void display_IncidentSelection()
    {
        DataTable dtTimeIncident = oHealth.GET_TIMEINCIDENT_LIST();
        ddTimeIncident.DataSource = dtTimeIncident;
        ddTimeIncident.DataValueField = dtTimeIncident.Columns[0].ToString();
        ddTimeIncident.DataTextField = dtTimeIncident.Columns[1].ToString();
        ddTimeIncident.DataBind();
        //ddTimeIncident.Items.Insert(0, new ListItem("--N/A--"));


        DataTable dtPlaceIncident = oHealth.GET_PLACEINCIDENT_LIST();
        ddPlaceIncident.DataSource = dtPlaceIncident;
        ddPlaceIncident.DataValueField = dtPlaceIncident.Columns[0].ToString();
        ddPlaceIncident.DataTextField = dtPlaceIncident.Columns[1].ToString();
        ddPlaceIncident.DataBind();
        //ddPlaceIncident.Items.Insert(0, new ListItem("--N/A--"));
   }

    private void createTempDTComplaint()
    { 
        DataTable dt = new DataTable();
        dt.Columns.Add("CODE", System.Type.GetType("System.String"));
        dt.Columns.Add("DESCRIPTION", System.Type.GetType("System.String"));

        Session["tempDTComplaint"] = dt;

    }

    private void createTempDTMedicine()
    { 
        DataTable dt = new DataTable();
        dt.Columns.Add("BATCHID", System.Type.GetType("System.Int32"));
        dt.Columns.Add("CODE", System.Type.GetType("System.String"));
        dt.Columns.Add("DESCRIPTION", System.Type.GetType("System.String"));
        dt.Columns.Add("QUANTITY", System.Type.GetType("System.Int32"));

        Session["tempDTMedicine"] = dt;
    }


    //Condition if the List of Batch Medicine will popup or not.
    //== 07/20/2016
    private bool checkMedLevel(string _medCode)
    {
        bool x;
       

        DataTable dt = oHealth.GET_MEDICINE_LIST();
        DataView dv = dt.DefaultView;

        dv.RowFilter = "medCode= '" + _medCode + "'";

        DataRowView drv = dv[0];

        
        if (dv.Count > 0)
        {
       
            if (drv["medLevelCode"].ToString() == "LV2")
            {
                x = true;
            }
            else
            {
                x = false;
            }

        }
        else
        {
            x = false;
        }

        return x;

    }

    //Display on list of Gridview Batch

    private void displayBatch(string _medCode)
    {
        DataTable dt = oHealth.GET_MEDICINE_BATCH_LIST();
        DataView dv = dt.DefaultView;

        dv.RowFilter = "medCode= '" + _medCode + "'";

        if (dv.Count > 0)
        {
            ddMedBatch.DataSource = dv;
            ddMedBatch.DataValueField = dv.Table.Columns["batchID"].ToString();// drv["batchID"].ToString();
            ddMedBatch.DataTextField = dv.Table.Columns["expirationDate"].ToString();
            ddMedBatch.DataBind();

            ddMedBatch.Items.Insert(0, new ListItem("- Select Batch -"));


        }
        else
        {

            ddMedBatch.Items.Clear();
            lblAvailableQuantity.Text = "";
        }

    
    }

    private void extractBatchMedicine(int _batchID)
    {

        DataTable dt = oHealth.GET_MEDICINE_BATCH_LIST();
        DataView dv = dt.DefaultView;

        dv.RowFilter = "batchId= '" + _batchID + "'";

        if (dv.Count > 0)
        {
            DataRowView drv = dv[0];

            lblAvailableQuantity.Text = drv["inStock"].ToString(); // dv.Table.Columns["stockOnHand"].ToString();
         
        
        }

    }



    private void displayPatientComplaint(string _transcode)
    {
        DataTable dt = oHealth.GET_COMPLAINT_PATIENT_LIST(_transcode);

        if (dt.Rows.Count > 0)
        {
            gvComplaintList.DataSource = dt;
            gvComplaintList.DataBind();
            panComplaintContent.Visible = true;
            panComplaintContent.Enabled = false;

            lnkAddComplaint.Visible = false;
        }
        else
        {
            gvComplaintList.DataSource = null;
            gvComplaintList.DataBind();
        }

    }

    private void displayPatientMedicine(string _transcode)
    {
        DataTable dt = oHealth.GET_MEDICINE_PATIENT_LIST(_transcode);
        if (dt.Rows.Count > 0)
        {

            gvMedicineList.DataSource = dt;
            gvMedicineList.DataBind();

            panMedicineContent.Visible = true;
            panMedicineContent.Enabled = false;

            lnkAddMedicine.Visible = false;
        }
        else
        {
            gvMedicineList.DataSource = null;
            gvMedicineList.DataBind();
        }
      
        
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

        if (oHealth.GET_EXIST_HEALTH_RECORD(ViewState["SEL_STUDNUM"].ToString()))
        {

            //clear all dynmic checkbox first
            chkIllnessListCat1.Items.Clear();
            chkIllnessListCat2.Items.Clear();
            chkMedicineMayGiven.Items.Clear();

            retrieveAppStudHealth(ViewState["SEL_STUDNUM"].ToString());

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
        DataRow[] dr = dt.Select("AppNum ='" + ViewState["SEL_STUDNUM"].ToString() + "'");
        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                //lblEmergency.Text = row["ContactPerson"].ToString();
                //lblStudentName.Text = row["FullName"].ToString();
                //lblContacts.Text = row["TelNo"].ToString() + "-" + row["MobileNo"].ToString();
                //lblStudNum.Text = row[""].ToString();
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
            


          

                //Validation
                if (oHealth.GET_EXIST_HEALTH_RECORD(ViewState["SEL_STUDNUM"].ToString()))
                {
                    //Update Record
                    updateRecord(ViewState["SEL_STUDNUM"].ToString());
                    //oHealth.updateApplicantStatusTrail(ViewState["SEL_APPNO"].ToString(), healthStatCode);

                    oHealth.UPDATE_APPLICANT_STATUS_TRAIL(ViewState["SEL_STUDNUM"].ToString(), healthStatCode);
                    
                    MessageDialog(lblStudentName.Text + " Health record successfully updated.", 2);
                    clearInputs();
                    
                    
                }

                else
                {

                    //Insert New Record
                    InsertRecord(ViewState["SEL_STUDNUM"].ToString(), healthStatCode);

                  //  oHealth.UPDATE_ApplicantStatusTrail(ViewState["SEL_STUDNUM"].ToString(), healthStatCode);

          //          oHealth.updateApplicantStatusTrail(ViewState["SEL_APPNO"].ToString(), statcode);


                    
                    MessageDialog(lblStudentName.Text + " Health record successfully saved.", 1);
                    clearInputs();

                }

          

             

         

        }
    }
  


    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        string _studnum = Request.Form[hfStudNum.UniqueID];

        if (oStudent.GETINFO_HEALTH(_studnum))
        {
            lblStudentName.Text = oStudent.FULLNAME;
            lblGradeLevel.Text = oStudent.CURRENT_LEVELDESC;
            lblSection.Text = oStudent.SECTION;
            lblStudNum.Text = _studnum;
            lblContactName.Text = oStudent.PRIMARY_CONTACT_PERSON;
            lblRelation.Text = oStudent.CONTACT_RELATION;
            lblContactNumber.Text = oStudent.CONTACT_NUMBERS;
            lblContactAddress.Text = oStudent.COMPLETE_ADDRESS;
            lblMOT.Text = oStudent.MOTDESC;
            imgStudentPicture.ImageUrl = oStudent.PHOTOLOC;
            

            ViewState["SEL_STUDNUM"] = _studnum;

            panHealthDE.Enabled = true;


          

            if (oHealth.GET_EXIST_HEALTH_RECORD(_studnum))
            {

                //clear all dynmic checkbox first
                chkIllnessListCat1.Items.Clear();
                chkIllnessListCat2.Items.Clear();
                chkMedicineMayGiven.Items.Clear();

                retrieveAppStudHealth(ViewState["SEL_STUDNUM"].ToString());

                txtSearch.Text = "";

                ViewState["ACTION"] = 2; //Indicate that action will be update
            }

            else
            {
                ViewState["ACTION"] = 1; //Action will be insert




                ////Display Default checkboxes
                displayIllnessList();
                dispalyMedicineMayGiven();
            }



            //Complaint Area
            panComplaintMain.Visible = true;

            //DISPLAY COMPLAINT HISTORY
            //08-02-2016
            displayComplaintHistory(_studnum);

            //COMPLAINT ACTION
            ViewState["COMPLAINT_ACTION"] = 1;

            resetComplaintsFields();
            
        }
        //MessageDialog(_studnum, 1);
    }

    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }
    

    protected void lnkAddComplaint_Click(object sender, EventArgs e)
    {

       
            //Instantiate table 
            DataTable dt = (DataTable)Session["tempDTComplaint"];

            if (gvComplaintList.Rows.Count == 0)
            {
                //Add New Row
                DataRow newRow = dt.NewRow();
                newRow["CODE"] = ddComplaintSelection.SelectedValue.ToString();
                newRow["DESCRIPTION"] = ddComplaintSelection.SelectedItem.ToString();
                dt.Rows.Add(newRow);

                Session["tempDTComplaint"] = dt;

                gvComplaintList.DataSource = dt;
                gvComplaintList.DataBind();

                panMedicineContent.Enabled = true;

            }
            else
            {
                //Validate if data if already exist on table

                if (checkComplaintExist())
                {
                    MessageDialog("Complaint already exist!", 3);
                    return;
                }
                else
                {

                    //ADD here
                    DataRow newRow = dt.NewRow();
                    newRow["CODE"] = ddComplaintSelection.SelectedValue.ToString();
                    newRow["DESCRIPTION"] = ddComplaintSelection.SelectedItem.ToString();
                    dt.Rows.Add(newRow);
                    Session["tempDTComplaint"] = dt;

                    gvComplaintList.DataSource = dt;
                    gvComplaintList.DataBind();

                }
            }
     

       
          
     }
     

    private bool checkComplaintExist()
    {
       bool bExist = false;

       foreach (GridViewRow gvr in gvComplaintList.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    string sCode = gvr.Cells[1].Text;
                    if (sCode == ddComplaintSelection.SelectedValue.ToString())
                    {
                        bExist = true;
                    }
                }
             }


    return bExist;

    }


    private bool checkMedicineExist()
    {
        bool bExist = false;

        foreach (GridViewRow gvr in gvMedicineList.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                string sCode = gvr.Cells[2].Text;
                if (sCode == ddMedicineSelection.SelectedValue.ToString())
                {
                    bExist = true;
                }
               
            }
        }


        return bExist;
    }

    private bool checkMedicineExist_Batch()
    {
        bool bExist = false;

        foreach (GridViewRow gvr in gvMedicineList.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                string sCode = gvr.Cells[1].Text;
                if (sCode == ddMedBatch.SelectedValue.ToString())
                {
                    bExist = true;
                }

            }
        }


        return bExist;
    }



    private void resetComplaintsFields()
    { 
        //dropdown 
        ddComplaintSelection.SelectedIndex = 0;
        ddMedicineSelection.SelectedIndex = 0;
        ddPlaceIncident.SelectedIndex = 0;
        ddTimeIncident.SelectedIndex = 0;

        //gridview
        gvComplaintList.DataSource = null;
        gvComplaintList.DataBind();
        gvMedicineList.DataSource = null;
        gvMedicineList.DataBind();

        
        //textbox
        txtMedQuantity.Text = "";
        txtNote.Text = "";
        lblAvailableQuantity.Text = "";
        txtPhysician.Text = "";
        txtAmount.Text = "";
        txtRemarks.Text = "";

        //checkbox
        chkSentHome.Checked = false;
        chkSentHospital.Checked = false;

        //Datatable 
        createTempDTComplaint();
        createTempDTMedicine();
        

        //Clear transactionCode
        ViewState["TRANSACTIONCODE"] = "";

        //Methods
        generateReferenceNum();

        //Visibility
        panIncident.Visible = false;
        

        //Access
        panMedicineContent.Enabled = false;
        panComplaintContent.Enabled = true;
        panMedicineContent.Enabled = true;

        ViewState["COMPLAINT_ACTION"] = 1;

        lnkAddComplaint.Visible = true;
        lnkAddMedicine.Visible = true;

        //Will Reset if medicine is inventoriable
        displayBatch(ddMedicineSelection.SelectedValue.ToString());
        
        //Hide Remove Complaint Button
        lnkRemoveComplaintRecord.Visible = false; 
    }


    private void displayComplaintHistory(string _patientnum)
    {
        DataTable dt = oHealth.GET_COMPLAINT_HISTORY(_patientnum);

        if (dt.Rows.Count > 0)
        {
            gvComplaintHistory.DataSource = dt;
            gvComplaintHistory.DataBind();

            panComplaintHistory.Visible = true;


            Session["COMPLAINT_HISTORY"] = dt;

        }
        else
        {
            Session["COMPLAINT_HISTORY"] = null;
            gvComplaintHistory.DataSource = null;
            gvComplaintHistory.DataBind();
        }

    }

    protected void lnkAddMedicine_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["tempDTMedicine"];

        if (checkMedLevel(ddMedicineSelection.SelectedValue.ToString()))
        {
          
            
            displayBatch(ddMedicineSelection.SelectedValue.ToString());
            panMedBatch.Visible = true;

            //Will avoid saving of complaint if the user forgot to ADD the 
            //medicine with inventory value.
            ViewState["FLG_MED_CONTROL"] = true;
        }

        else
        {

            panMedBatch.Visible = false;
            txtMedQuantity.Text = "";

            //Allow to Save the compaint incase no other 
            //medicine with inventory value open
            ViewState["FLG_MED_CONTROL"] = false;

            if (gvMedicineList.Rows.Count == 0)
            {
                DataRow row = dt.NewRow();

                row["CODE"] = ddMedicineSelection.SelectedValue.ToString();
                row["DESCRIPTION"] = ddMedicineSelection.SelectedItem.ToString();
                //Avoid to add quantity if non accountable
                if (!string.IsNullOrEmpty(txtMedQuantity.Text))
                {
                    row["QUANTITY"] = Convert.ToInt32(txtMedQuantity.Text);
                }
                else
                {
                    txtMedQuantity.Text = "";
                }

                dt.Rows.Add(row);

                Session["tempDTMedicine"] = dt;


                gvMedicineList.DataSource = dt;
                gvMedicineList.DataBind();

                panMedBatch.Visible = false;
            }

            else
            { 
               //validate if medicine / action exist
                if (checkMedicineExist())
                {
                    MessageDialog("Medicine already in the list", 3);
                    return;
                }
                else
                {
                DataRow row = dt.NewRow();

                row["CODE"] = ddMedicineSelection.SelectedValue.ToString();
                row["DESCRIPTION"] = ddMedicineSelection.SelectedItem.ToString();
                //Avoid to add quantity if non accountable
                if (!string.IsNullOrEmpty(txtMedQuantity.Text))
                {
                    row["QUANTITY"] = Convert.ToInt32(txtMedQuantity.Text);
                }
                else
                {
                    txtMedQuantity.Text = "";
                }

                dt.Rows.Add(row);

                Session["tempDTMedicine"] = dt;


                gvMedicineList.DataSource = dt;
                gvMedicineList.DataBind();

                panMedBatch.Visible = false;
                }
            
            }
           
        }

        
    }


    protected void lnkRemoveComplaint_Click(object sender, EventArgs e)
    {

        //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
        var selEdit = (Control)sender;
        GridViewRow r = (GridViewRow)selEdit.NamingContainer;
       // string selAppNum = r.Cells[2].Text;
        string selCode = r.Cells[1].Text;


        DataTable dt = (DataTable)Session["tempDTComplaint"];

        for(int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow drow = dt.Rows[i];
            if (drow["CODE"].ToString() == selCode)
                drow.Delete();
        }

        dt.AcceptChanges();

        Session["tempDTComplaint"] = dt;

        gvComplaintList.DataSource = dt;
        gvComplaintList.DataBind();


    }

    protected void lnkRemoveMedicine_Click(object sender, EventArgs e)
    {
        //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
        var selEdit = (Control)sender;
        GridViewRow r = (GridViewRow)selEdit.NamingContainer;
        // string selAppNum = r.Cells[2].Text;
        string selCode = r.Cells[2].Text;


        DataTable dt = (DataTable)Session["tempDTMedicine"];

        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow drow = dt.Rows[i];
            if (drow["CODE"].ToString() == selCode)
                drow.Delete();
        }

        dt.AcceptChanges();

        Session["tempDTMedicine"] = dt;


        gvMedicineList.DataSource = dt;
        gvMedicineList.DataBind();

    }

    protected void ddMedBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddMedBatch.SelectedIndex != 0)
        { 
        extractBatchMedicine(Convert.ToInt32(ddMedBatch.SelectedValue.ToString()));
        }
        else
        {
        lblAvailableQuantity.Text = "";
        ddMedBatch.SelectedIndex = 0;
        return;
        }
    }

    protected void lnkBatchAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["tempDTMedicine"];

        if (ddMedBatch.SelectedIndex == 0 || string.IsNullOrEmpty(txtMedQuantity.Text) || string.IsNullOrEmpty(lblAvailableQuantity.Text))
        {
            return;
        }
        else
        {
            if (gvMedicineList.Rows.Count == 0)
            {

               
                DataRow row = dt.NewRow();

                if (ddMedBatch.SelectedIndex == 0)
                {
                    row["BATCHID"] = 0;
                }
                else
                {
                    row["BATCHID"] = Convert.ToInt32(ddMedBatch.SelectedValue.ToString());
                }

                row["CODE"] = ddMedicineSelection.SelectedValue.ToString();
                row["DESCRIPTION"] = ddMedicineSelection.SelectedItem.ToString();
                row["QUANTITY"] = Convert.ToInt32(txtMedQuantity.Text);

                dt.Rows.Add(row);

                Session["tempDTMedicine"] = dt;

                //Allow saving the complaint
                ViewState["FLG_MED_CONTROL"] = false;

                gvMedicineList.DataSource = dt;
                gvMedicineList.DataBind();


            }
            else
            {
                if (checkMedicineExist_Batch())
                {
                    MessageDialog("Medicine batch already in the list", 3);
                    return;
                }

                else {
                    DataRow row = dt.NewRow();

                    if (ddMedBatch.SelectedIndex == 0)
                    {
                        row["BATCHID"] = 0;
                    }
                    else
                    {
                        row["BATCHID"] = Convert.ToInt32(ddMedBatch.SelectedValue.ToString());
                    }

                    row["CODE"] = ddMedicineSelection.SelectedValue.ToString();
                    row["DESCRIPTION"] = ddMedicineSelection.SelectedItem.ToString();
                    row["QUANTITY"] = Convert.ToInt32(txtMedQuantity.Text);

                    dt.Rows.Add(row);

                    Session["tempDTMedicine"] = dt;

                    //Allow saving the complaint
                    ViewState["FLG_MED_CONTROL"] = false;


                    gvMedicineList.DataSource = dt;
                    gvMedicineList.DataBind();

                }
            }


          

            panMedBatch.Visible = false;
            //gvMedBatch.DataSource = null;

            txtMedQuantity.Text = "";
            ddMedBatch.SelectedIndex = 0;
        }
    }

    protected void lnkSaveComplaint_Click(object sender, EventArgs e)
    {

        //Validate Inputs
        if (gvComplaintList.Rows.Count == 0 || gvMedicineList.Rows.Count == 0)
        {
            MessageDialog("Complaint and Medicine should not be empty", 3);
            return;
        }

        else if ((bool)ViewState["FLG_MED_CONTROL"] == true) {
            MessageDialog("Please add the medicine first", 3);
            return;
        }      

        else
        {

            //SAVING COMPLAINT RECORD
            //VALIDATE TYPE OF SAVING

            //ADDING NEW COMPLAINT RECORD
            if ((int)ViewState["COMPLAINT_ACTION"] == 1)
            {
                oHealth.INSERT_COMPLAINT_SUMMARY(ViewState["TRANSACTIONCODE"].ToString(), "2016-2017", lblStudNum.Text, Convert.ToDateTime(txtDateComplaint.Text), Convert.ToDateTime(txtTimeComplaint.Text),
                                                txtNote.Text, chkSentHome.Checked, chkSentHospital.Checked, ddTimeIncident.SelectedValue.ToString(), ddPlaceIncident.SelectedValue.ToString(),
                                                txtPhysician.Text, txtAmount.Text, txtRemarks.Text, false, "testing User");



                foreach (GridViewRow row in gvComplaintList.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        string getRowCompCode = row.Cells[1].Text;


                        oHealth.INSERT_PATIENT_COMPLAINT_DETAILS(ViewState["TRANSACTIONCODE"].ToString(), getRowCompCode.ToString());
                    }
                }


                //Saving Medicine Action Done
                foreach (GridViewRow row in gvMedicineList.Rows)
                {
                    string getDataKey = row.Cells[1].Text;
                    int grBatchID;
                    int grQuantity;
                    bool isCountable;

                    if (row.RowType == DataControlRowType.DataRow)
                    {


                        if (string.IsNullOrEmpty(getDataKey) || getDataKey == "&nbsp;")
                        {
                            grBatchID = 0;
                            grQuantity = 0;
                            isCountable = false;
                        }

                        else
                        {
                            grBatchID = Convert.ToInt32(row.Cells[1].Text);
                            grQuantity = Convert.ToInt32(row.Cells[4].Text);
                            isCountable = true;
                        }

                        string grMedCode = row.Cells[2].Text;

                        //execute substraction on medicine stock
                        oHealth.INSERT_PATIENT_MEDICINE_DETAILS(ViewState["TRANSACTIONCODE"].ToString(), grMedCode, grQuantity, grBatchID, isCountable);


                        if (isCountable)
                        {
                            oHealth.UPDATE_MEDICINE_STOCK_DOWN(grBatchID, grMedCode, grQuantity);
                        }
                    }

                }


                //DISPLAY Successful message
                MessageDialog("Complaint successfully recorded", 1);

                //Reset and clear all fields.
                resetComplaintsFields();

                //Reload Complaint History
                displayComplaintHistory(lblStudNum.Text);
            }



            else
            //update complaint summary
            {
                oHealth.UPDATE_COMPLAINT_SUMMARY(ViewState["TRANSACTIONCODE"].ToString(), Convert.ToDateTime(txtDateComplaint.Text), Convert.ToDateTime(txtTimeComplaint.Text),
                                                   txtNote.Text, chkSentHome.Checked, chkSentHospital.Checked, ddTimeIncident.SelectedValue.ToString(), ddPlaceIncident.SelectedValue.ToString(),
                                                   txtPhysician.Text, txtAmount.Text, txtRemarks.Text, false, "testing User");

                //DISPLAY Successful message
                MessageDialog("Complaint successfully updated.", 2);

                resetComplaintsFields();

                //Reload Complaint History
                displayComplaintHistory(lblStudNum.Text);

            } //End if validation of saving type.

        }//End of Validation of requirements.
    }


    protected void chkSentHospital_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSentHospital.Checked)
        {
            panIncident.Visible = true;
        }
        else
        {
            panIncident.Visible = false;
        }
    }


    protected void gvComplaintHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        gvComplaintHistory.PageIndex = e.NewPageIndex;
        displayComplaintHistory(lblStudNum.Text);

    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
      
        if (gvComplaintHistory.Rows.Count > 0)
        {

            DataTable dt = (DataTable)Session["COMPLAINT_HISTORY"];
            DataView dv = dt.DefaultView;

            var selEdit = (Control)sender;
            GridViewRow r = (GridViewRow)selEdit.NamingContainer;

            ViewState["TRANSACTIONCODE"] = r.Cells[1].Text;


            dv.RowFilter = "transCode = '" + ViewState["TRANSACTIONCODE"].ToString() + "'";

            if (dv.Count > 0)
            {
                DataRowView drv = dv[0];

                txtNote.Text = drv["notes"].ToString();
                txtRemarks.Text = drv["remarks"].ToString();
                txtAmount.Text = drv["amount"].ToString();
                txtPhysician.Text = drv["physician"].ToString();

                txtDateComplaint.Text = Convert.ToDateTime(drv["compDate"]).ToShortDateString();
                txtTimeComplaint.Text = Convert.ToDateTime(drv["compTime"]).ToShortTimeString();

                chkSentHome.Checked = (bool)drv["sentHome"];
                if ((bool)drv["sentHospital"])
                {
                   
                    panIncident.Visible = true;
                }
                else
                {
                    panIncident.Visible = false;
                }

                chkSentHospital.Checked = (bool)drv["sentHospital"];
                ddPlaceIncident.SelectedValue = drv["placeIncidentCode"].ToString();
                ddTimeIncident.SelectedValue = drv["timeIncidentCode"].ToString();
              
            }

            //DISPLAY COMPLAINT LIST ON GRIDVIEW

            displayPatientComplaint(ViewState["TRANSACTIONCODE"].ToString());

            //DISPLAY MEDICINE LIST ON GRIDVIEW
            displayPatientMedicine(ViewState["TRANSACTIONCODE"].ToString());

            ViewState["COMPLAINT_ACTION"] = 2; //UPDATE

            //Show remove button of complaint record
            lnkRemoveComplaintRecord.Visible = true;
        }

        //displaySelectedSection((int)ViewState["_selectedID"]);

        //panelEdit.Enabled = true;

    }


    protected void lnkResetComplaint_Click(object sender, EventArgs e)
    {
        resetComplaintsFields();
    }

    /*This will remove record of complaint record
    * together if the medicine specify on the complaint is 
    * have inventory it will regain number of quantity specify on the complaint
    */
    protected void lnkRemoveComplaintRecord_Click(object sender, EventArgs e)
    { 
        if (gvMedicineList.Rows.Count > 0)
            {
                
                //Assign Transaction Code into local string variable
                string sTransCode = ViewState["TRANSACTIONCODE"].ToString();

                //Iterate on gridview medicine list
                foreach (GridViewRow row in gvMedicineList.Rows)
                {
            
                    int iBatchId = int.Parse(row.Cells[1].Text);
                    string sMedCode = row.Cells[2].Text;
                    int iQty = int.Parse(row.Cells[4].Text);

                    oHealth.DISABLE_COMPLAINT_TRANSACTION(sTransCode, iBatchId, sMedCode, iQty, "Testing");
                }

            //Inform user about transaction
                MessageDialog("Complaint was deleted successfully.", 2);
                resetComplaintsFields();
                
            //Reload the complaint history of Patient.
                displayComplaintHistory(lblStudNum.Text);
            }
        }

}