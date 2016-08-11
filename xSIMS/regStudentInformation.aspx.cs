using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using SIMSBDAL;

public partial class regStudentInformation : System.Web.UI.Page
{
    Utilities oUtil = new Utilities();
    Student oStudent = new Student();
    xSystem oSystem = new xSystem();
    AutoNumber oAutoNumber = new AutoNumber();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
               
            displayGender();

           
            displayCitizenship();
            displayReligion();
            
          

            //HOLD RETURN VALUE OF SELECTED STUDENT AND SELECTED SIBLING CODE
            ViewState["SIB1"] = "";
            ViewState["SIB2"] = "";

            //default of barangay
            //ddArea.SelectedValue = "AL";
            //ddCity.Items.Add(ListItem, 0, "Select");
            //displayBarangay();
            displayEducTypeList();


            //Display Reserved Selection Status
            //03/15/2016
            displayReservedStatus();

            displayCity();
            displayBarangay("CAB");


            //Hold Credential status if exist or not
            ViewState["IS_STUDENTCREDENTIAL"] = false;

            //Set txtSearch the focus
            //12-02-2015
            ScriptManager.RegisterStartupScript(this, this.GetType(), "focus", "document.getElementById('" + this.txtSearch.ClientID + "').focus();", true);

            tcDetails.ActiveTabIndex = 0;


            //Disable Initial
            panContentTop.Enabled = false;
            panContentTab.Enabled = false;

           lblSYStatus.Text = "SCHOOL YEAR: " + Session["S_SY"].ToString() + " -- STATUS";

          

            //display List of Strand
            displayStrand();

            //display List of MOT
            displayMOT();

            //display Reservation Status
            displayReservedStatus();

            //display Enrollment Status
            displayEnrollmentStatus();

        }

      
       


    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        //Assigned student number from hidden field

        string _studnum = Request.Form[hfStudNum.UniqueID];

        optPrimaryFather.Checked = false;
        optPrimaryMother.Checked = false;
        optGuardian.Checked = false;

        if (oStudent.GETINFO(_studnum))
        {
            lblStudentNo.Text = oStudent.STUDNO;
            ucTxtLastName.TEXTVALUE = oStudent.LASTNAME;
            ucTxtFirstName.TEXTVALUE = oStudent.FIRSTNAME;
            ucTxtMiddleName.Text = oStudent.MIDDLENAME;
            txtMI.Text = oStudent.MI;
            txtSuffix.Text = oStudent.SUFFIX;
            txtBirthDate.Text = oStudent.DOB.ToShortDateString();
            txtPlaceOfBirth.Text = oStudent.POB;
            ddGender.SelectedValue = oStudent.GENDERCODE;
            //ddGradeLevel.SelectedValue = oStudent.LEVELCODE;
            //For Entry History
            //lblGradeLevel.Text = oStudent.ENTRY_LEVELCODE;
            
            lblCurrentLevel.Text = oStudent.CURRENT_LEVELDESC;

            //CHECK IF GRADE LEVEL IS SHS
            //05-24-2016

            if (oStudent.CURRENT_LEVELCODE == "G11" || oStudent.CURRENT_LEVELCODE == "G12")
            {
                ddStrand.Visible = true;
                lblStrandText.Visible = true;
                lnkUpdateStrand.Visible = true;
                
                //lblStrand.Text = oStudent.STRANDDESC;
                //displayStrand();


                if (string.IsNullOrEmpty(oStudent.STRANDCODE))
                {
                    //    //ddStrand.Visible = false;
                    //    //lblStrand.Text = "";
                    //    displayStrand();
                    
                    //do nothing
                    ddStrand.SelectedIndex = 0;
                }
                else
                {
                    ddStrand.SelectedValue = oStudent.STRANDCODE;
                }
                //    //ddStrand.Visible = true;
                //    //ddStrand.SelectedValue = oStudent.STRANDCODE;
                //    //ddStrand.SelectedValue = oStudent.STRANDCODE;
                //   // displayStrand(oStudent.STRANDCODE);
                //}
            }

            else
            {

                ddStrand.Visible = false;
                lblStrandText.Visible = false;
                lnkUpdateStrand.Visible = false;
            }


            ucTelNo.Text = oStudent.TELNO;
            ucMobile.Text = oStudent.MOBILENO;
            txtEmailAdd.Text = oStudent.EMAIL;
            txtAddNoStreet.Text = oStudent.STREET;
            
            ddCity.SelectedValue = oStudent.CITYCODE;
            //Display only the barangay listed on the city
            displayBarangay(ddCity.SelectedValue);
            ddArea.SelectedValue = oStudent.BARANGAYCODE;
            
            ucContactPerson.TEXTVALUE = oStudent.INITIALCONTACT;

           
            chkActive.Checked = oStudent.STATUS;

            chkSSIChild.Checked = oStudent.SSICHILD;

            
            lblCurrentSection.Text = oStudent.SECTION;
            txtLRN.Text = oStudent.LRN;
            txtBarcode.Text = oStudent.BARCODE;

            lblDateApplied.Text = Convert.ToDateTime(oStudent.DATEAPPLIED).ToShortDateString();
            lblEntrySY.Text = oStudent.ENTRYSY;


            //display MOT of Student
            if (string.IsNullOrEmpty(oStudent.MOTCODE))
            {
                ddMOT.SelectedIndex = 0;
            }
            else
            {
                ddMOT.SelectedValue = oStudent.MOTCODE;
            }

            //display reserve status
            if (string.IsNullOrEmpty(oStudent.STATCODER))
            {
                ddReservedStatus.SelectedIndex = 0;
            }
            else { ddReservedStatus.SelectedValue = oStudent.STATCODER; }

            //display enrolled status

            if (string.IsNullOrEmpty(oStudent.STATCODE))
            { ddEnrollmentStatus.SelectedIndex = 0; }
            else { ddEnrollmentStatus.SelectedValue = oStudent.STATCODE; }


            //Clear searchbox
            txtSearch.Text = "";

            //DISPLAY IMAGE OF STUDENTS
            if (string.IsNullOrEmpty(oStudent.PHOTOLOC))
            {
                //display default photo
                if (ddGender.SelectedValue == "B")
                {
                    imgStudentPicture.ImageUrl = "~/images/def_avatar/nophotoM.png";
                }
                else
                {
                    imgStudentPicture.ImageUrl = "~/images/def_avatar/nophotoF.png";
                }

            }
            else
            {
                //string picLoc = oStudent.PHOTOLOC;
                imgStudentPicture.ImageUrl = oStudent.PHOTOLOC; ; //oStudent.PHOTOLOC;
                
            }


           


            if (string.IsNullOrEmpty(oStudent.CITIZENSHIPCODE))
            {
                //SET DEFAULT TO FIRST CITIZENSHIP CODE - FILIPINO
                ddCitizenship.SelectedIndex = 0;
            }
            else
            {
                ddCitizenship.SelectedValue = oStudent.CITIZENSHIPCODE;
            }

            if (string.IsNullOrEmpty(oStudent.RELIGIONCODE))
            {
                //SET DEFAULT TO FIRST RELIGION CODE - ROMAN CATHOLIC
                ddReligion.SelectedIndex = 0;
                
            }
            else
            {
                ddReligion.SelectedValue = oStudent.RELIGIONCODE;
            }

            //load data on gridview
            displayEduBackground();


            //display List of Siblings with parameter
            displaySiblingsWP(ucTxtLastName.TEXTVALUE);
            
         
            
            tcDetails.ActiveTabIndex = 0;




            //CHECK IF have family record details
            if (oStudent.CHECK_FAMILY(lblStudentNo.Text))
            {
                ucFLastName.TEXTVALUE = oStudent.FLASTNAME;
                ucFFirstName.TEXTVALUE = oStudent.FFIRSTNAME;
                ucFMiddleName.TEXTVALUE = oStudent.FMIDDLENAME;
                ucFOccupation.TEXTVALUE = oStudent.FOCCUPATION;
                ddFCitizenship.SelectedValue = oStudent.FCITIZENSHIP;
                txtFEducAttainment.Text = oStudent.FEDUCATION;
                txtFCompany.Text = oStudent.FCOMPANY;
                txtFCompAddress.Text = oStudent.FCOMPADDRESS;
                ucFTelephone.Text = oStudent.FTELEPHONE;
                ucFMobile.Text = oStudent.FMOBILE;

                ucMLastName.TEXTVALUE = oStudent.MLASTNAME;
                ucMFirstName.TEXTVALUE = oStudent.MFIRSTNAME;
                ucMMiddleName.TEXTVALUE = oStudent.MMIDDLENAME;
                ucMOccupation.TEXTVALUE = oStudent.MOCCUPATION;
                ddMCitizenship.SelectedValue = oStudent.MCITIZENSHIP;
                txtMEducAttainment.Text = oStudent.MEDUCATION;
                txtMCompany.Text = oStudent.MCOMPANY;
                txtMCompAddress.Text = oStudent.MCOMPADDRESS;
                ucMTelephone.Text = oStudent.MTELEPHONE;
                ucMMobile.Text = oStudent.MMOBILE;

                ucGLastName.TEXTVALUE = oStudent.GLASTNAME;
                ucGFirstName.TEXTVALUE = oStudent.GFIRSTNAME;
                ucGMiddleName.TEXTVALUE = oStudent.GMIDDLENAME;
                txtGAddress.Text = oStudent.GADDRESS;
                ucGTelephone.Text = oStudent.GTELEPHONE;
                ucGMobile.Text = oStudent.GMOBILE;
                txtGRelation.Text = oStudent.GRELATION;

                if (oStudent.PRIMARYCONTACT == 1)
                {
                    optPrimaryFather.Checked = true;
                }
                else if (oStudent.PRIMARYCONTACT == 2)
                {
                    optPrimaryMother.Checked = true;
                }
                else if (oStudent.PRIMARYCONTACT == 3)
                {
                    optGuardian.Checked = true;
                }

            

                //HOLD TEMPORARY THE VALUE OF PARENTS
                ViewState["FLastName"]= oStudent.FLASTNAME;
                ViewState["FFirstName"]= oStudent.FFIRSTNAME;
                ViewState["FMiddleName"] = oStudent.FMIDDLENAME;
                ViewState["FOccupation"] = oStudent.FOCCUPATION;
                ViewState["FCitizenship"] = oStudent.FCITIZENSHIP;
                ViewState["FEducAttainment"] = oStudent.FEDUCATION;
                ViewState["FCompany"] = oStudent.FCOMPANY;
                ViewState["FCompAddress"] = oStudent.FCOMPADDRESS;
                ViewState["FTelephone"] = oStudent.FTELEPHONE;
                ViewState["FMobile"] = oStudent.FMOBILE;

                ViewState["MLastName"] = oStudent.MLASTNAME;
                ViewState["MFirstName"] = oStudent.MFIRSTNAME;
                ViewState["MMiddleName"] = oStudent.MMIDDLENAME;
                ViewState["MOccupation"] = oStudent.MOCCUPATION;
                ViewState["MCitizenship"] = oStudent.MCITIZENSHIP;
                ViewState["MEducAttainment"] = oStudent.MEDUCATION;
                ViewState["MCompany"] = oStudent.MCOMPANY;
                ViewState["MCompAddress"] = oStudent.MCOMPADDRESS;
                ViewState["MTelephone"] = oStudent.MTELEPHONE;
                ViewState["MMobile"] = oStudent.MMOBILE;

            }
            else
            {
                clearRelative();
            }


            //CHECK IF IN CREDENTIAL TABLE EXIST
            if (oStudent.GETCREDENTIALS(lblStudentNo.Text))
            {
                chkF138.Checked = oStudent.FORM138;
                chkBC.Checked = oStudent.BC;
                chk1x1Picture.Checked = oStudent.COLORED1X1;
                chkEnvelope.Checked = oStudent.BROWNENVELOPE;
                chkGoodMoral.Checked = oStudent.GM;
                chkRecommendation.Checked = oStudent.RECOMMENDATION;
                chk137.Checked = oStudent.FORM137;
                chkNCAE.Checked = oStudent.NCAE;
                chkInterview.Checked = oStudent.INTERVIEW;
                txtOthers.Text = oStudent.OTHER;

                ViewState["IS_STUDENTCREDENTIAL"] = true;
            }
            else
            {
                //clear credentials
                clearCredentials();

                ViewState["IS_STUDENTCREDENTIAL"] = false;
            }


            //displaySiblingsList(lblStudentNo.Text);

            //CHECK AND GET SIBLING CODE OF STUDENT IF EXIST
            if (oStudent.CHECK_SIBLINGEXIST(lblStudentNo.Text))
            {
                ViewState["SIB1"] = oStudent.SIBLINGCODE;
                displaySiblingsList(ViewState["SIB1"].ToString());

            }

            else
            {
                ViewState["SIB1"] = "";
                gvSiblings.DataSource = null;
                gvSiblings.DataBind();
            }


            //Enable
            panContentTop.Enabled = true;
            panContentTab.Enabled = true;

        }

        else
        {
            //Clear Fields
            lblStudentNo.Text = "";
            clearRelative();

            //Disable
            panContentTop.Enabled = false;
            panContentTab.Enabled = false;

        }


        //MAKE VISIBLE ALL PANELS
        panelAddInfo.Visible = true;
        panelEducation.Visible = true;
        panelFamily.Visible = true;
        panelSibling.Visible = true;
        panelCredential.Visible = true;
      
    }


    private void displayGender()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_GENDER();

        ddGender.DataSource = dt;
        ddGender.DataTextField = dt.Columns["GenderDesc"].ToString();
        ddGender.DataValueField = dt.Columns["GenderCode"].ToString();
        ddGender.DataBind();
    }

    private void displayCitizenship()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_CITIZENSHIP();

        ddCitizenship.DataSource = dt;
        ddCitizenship.DataTextField = dt.Columns["CitizenshipDesc"].ToString();
        ddCitizenship.DataValueField = dt.Columns["CitizenshipCode"].ToString();
        ddCitizenship.DataBind();


        ddFCitizenship.DataSource = dt;
        ddFCitizenship.DataTextField = dt.Columns["CitizenshipDesc"].ToString();
        ddFCitizenship.DataValueField = dt.Columns["CitizenshipCode"].ToString();
        ddFCitizenship.DataBind();

        ddMCitizenship.DataSource = dt;
        ddMCitizenship.DataTextField = dt.Columns["CitizenshipDesc"].ToString();
        ddMCitizenship.DataValueField = dt.Columns["CitizenshipCode"].ToString();
        ddMCitizenship.DataBind();

    }


   

    private void displayStrand()
    {
            DataTable dt = new DataTable();
            dt = oUtil.GET_LEVEL_STRAND();

            ddStrand.DataSource = dt;
            ddStrand.DataTextField = dt.Columns["StrandName"].ToString();
            ddStrand.DataValueField = dt.Columns["StrandCode"].ToString();
            ddStrand.DataBind();
        
            ddStrand.Items.Insert(0, "---");
    }

    private void displayStrand(string _strandCode)
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_LEVEL_STRAND();

        DataView dv = dt.DefaultView;
        dv.RowFilter = "StrandCode = '" + _strandCode + "'";

        ddStrand.DataSource = dv;
        ddStrand.DataTextField = dv.Table.Columns["StrandName"].ToString();
        ddStrand.DataValueField = dv.Table.Columns["StrandCode"].ToString();
        ddStrand.DataBind();

        //DataRowView drv = dv[0];

        //if (dv.Count > 0)
        //{ 
        
        
        //}
       
    }

    private void displayMOT()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_MOT();


        ddMOT.DataSource = dt;
        ddMOT.DataTextField = dt.Columns["motDescription"].ToString();
        ddMOT.DataValueField = dt.Columns["motCode"].ToString();
        ddMOT.DataBind();
    }

    private void displayReligion()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_RELIGION();


        ddReligion.DataSource = dt;
        ddReligion.DataTextField = dt.Columns["ReligionDesc"].ToString();
        ddReligion.DataValueField = dt.Columns["ReligionCode"].ToString();
        ddReligion.DataBind();
    }

    private void displayBarangay()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_BARANGAY();


        ddArea.DataSource = dt;
        ddArea.DataTextField = dt.Columns["BarangayDesc"].ToString();
        ddArea.DataValueField = dt.Columns["BarangayCode"].ToString();
        ddArea.DataBind();
    }

    private void displayReservedStatus()
    { 
     DataTable dt = oUtil.getGeneralStatus("RRE");

     ddReservedStatus.DataSource = dt;
     ddReservedStatus.DataTextField = dt.Columns["StatDesc"].ToString();
     ddReservedStatus.DataValueField = dt.Columns["StatCode"].ToString();
     ddReservedStatus.DataBind();


     ddReservedStatus.Items.Insert(0, "---");
   
    }

    private void displayEnrollmentStatus()
    {
        DataTable dt = oUtil.getGeneralStatus("REN");

        ddEnrollmentStatus.DataSource = dt;
        ddEnrollmentStatus.DataTextField = dt.Columns["StatDesc"].ToString();
        ddEnrollmentStatus.DataValueField = dt.Columns["StatCode"].ToString();
        ddEnrollmentStatus.DataBind();

        ddEnrollmentStatus.Items.Insert(0, "---");
    }

    private void displayCity()
    {
        DataTable dt = new DataTable();
        dt = oUtil.GET_CITY();

        ddCity.DataSource = dt;
        ddCity.DataTextField = dt.Columns["CityDesc"].ToString();
        ddCity.DataValueField = dt.Columns["CityCode"].ToString();
        ddCity.DataBind();

    }

    private void displayEduBackground()
    {
        DataTable dt = new DataTable();
        dt = oStudent.GET_EDUBACK(lblStudentNo.Text);

        gvEducation.DataSource = dt;
        gvEducation.DataBind();

    }

    private void displaySiblingsList(string _siblingcode)
    {
        DataTable dt = new DataTable();
        dt = oStudent.GET_SIBLINGLIST(_siblingcode);

        gvSiblings.DataSource = dt;
        gvSiblings.DataBind();
    }

    private void displaySiblings()
    {
        DataTable dt = new DataTable();
        dt = oStudent.GET_SELECTED_SIBLINGS();

        ddSiblings.DataSource = dt;
        ddSiblings.DataTextField = dt.Columns["FullName"].ToString();
        ddSiblings.DataValueField = dt.Columns["StudNum"].ToString();
        ddSiblings.DataBind();

        ddSiblings.Items.Insert(0, "--Select--");

    }

    private void displaySiblingsWP(string param)
    {
        DataTable dt = new DataTable();
        dt = oStudent.GET_SELECTED_SIBLINGS(param);

        ddSiblings.DataSource = dt;
        ddSiblings.DataTextField = dt.Columns["FullName"].ToString();
        ddSiblings.DataValueField = dt.Columns["StudNum"].ToString();
        ddSiblings.DataBind();


        ddSiblings.Items.Insert(0, "--Select--");
    }

    private void displayBarangay(string INPUT)
    {
        DataTable dt = new DataTable();
        dt =  oUtil.getBarangay(INPUT);


        ddArea.DataSource = dt;
        ddArea.DataTextField = dt.Columns["BarangayDesc"].ToString();
        ddArea.DataValueField = dt.Columns["BarangayCode"].ToString();
        ddArea.DataBind();
    }


    private void displayEducTypeList()
    {
        DataTable dtEduTypeList = new DataTable();
        dtEduTypeList = oUtil.GET_EDUBACKGROUND();

        ddEduType.DataSource = dtEduTypeList;
        ddEduType.DataTextField = dtEduTypeList.Columns["EduTypeDesc"].ToString();
        ddEduType.DataValueField = dtEduTypeList.Columns["EduTypeDesc"].ToString();
        ddEduType.DataBind();

        ddEduType.Items.Insert(0, new ListItem("Select Type"));
    }

    private void clearEducFields()
    {
        ddEduType.SelectedIndex = 0;
        txtSchoolName.Text = "";
        txtSchAddress.Text = "";
        txtYearGrad.Text = "";
    }

    private void clearRelative()
    { 
    ucFLastName.TEXTVALUE = "";
    ucFFirstName.TEXTVALUE = "";
    ucFMiddleName.TEXTVALUE = "";
    ucFOccupation.TEXTVALUE = "";
    ddFCitizenship.SelectedIndex = 0;
    txtFEducAttainment.Text = "";
    txtFCompany.Text = "";
    txtFCompAddress.Text = "";
    ucFTelephone.Text = "";
    ucFMobile.Text = "";

    ucMLastName.TEXTVALUE = ""; 
    ucMFirstName.TEXTVALUE = ""; 
    ucMMiddleName.TEXTVALUE = "";
    ucMOccupation.TEXTVALUE = "";
    ddMCitizenship.SelectedIndex = 0; 
    txtMEducAttainment.Text = "";
    txtMCompany.Text = "";
    txtMCompAddress.Text = ""; 
    ucMTelephone.Text = "";
    ucMMobile.Text = "";
     
    ucGLastName.TEXTVALUE = "";
    ucGFirstName.TEXTVALUE = ""; 
    ucGMiddleName.TEXTVALUE = "";
    txtGAddress.Text = "";
    ucGTelephone.Text = "";
    ucGMobile.Text = "";
    txtGRelation.Text = "";

    }

    private void clearCredentials()
    { 
        chkF138.Checked = false;
        chkBC.Checked = false;
        chk1x1Picture.Checked = false;
        chkEnvelope.Checked = false;
        chkGoodMoral.Checked = false;
        chkRecommendation.Checked =false;
        chk137.Checked = false;
        chkNCAE.Checked =false;
        chkInterview.Checked = false;
        txtOthers.Text = "";
    }

    private void switchRelative()
    {
        ucFLastName.TEXTVALUE = ViewState["MLastName"].ToString();
        ucFFirstName.TEXTVALUE = ViewState["MFirstName"].ToString();
        ucFMiddleName.TEXTVALUE = ViewState["MMiddleName"].ToString();
        ucFOccupation.TEXTVALUE = ViewState["MOccupation"].ToString();
        ddFCitizenship.SelectedItem.Text = ViewState["MCitizenship"].ToString();
        txtFEducAttainment.Text = ViewState["MEducAttainment"].ToString();
        txtFCompany.Text = ViewState["MCompany"].ToString();
        txtFCompAddress.Text = ViewState["MCompAddress"].ToString();
        ucFTelephone.Text = ViewState["MTelephone"].ToString();
        ucFMobile.Text = ViewState["MMobile"].ToString();

        ucMLastName.TEXTVALUE = ViewState["FLastName"].ToString();
        ucMFirstName.TEXTVALUE = ViewState["FFirstName"].ToString();
        ucMMiddleName.TEXTVALUE = ViewState["FMiddleName"].ToString();
        ucMOccupation.TEXTVALUE = ViewState["FOccupation"].ToString();
        ddMCitizenship.SelectedItem.Text = ViewState["FCitizenship"].ToString();
        txtMEducAttainment.Text = ViewState["FEducAttainment"].ToString();
        txtMCompany.Text = ViewState["FCompany"].ToString();
        txtMCompAddress.Text = ViewState["FCompAddress"].ToString();
        ucMTelephone.Text = ViewState["FTelephone"].ToString();
        ucMMobile.Text = ViewState["FMobile"].ToString();
    }




    protected void btnNewEducation_Click(object sender, EventArgs e)
    {

       
    
    }

    protected void gvEducation_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        DropDownList ddEduType = (DropDownList)e.Row.FindControl("ddEduType");
        Label lblEduType = (Label)e.Row.FindControl("lblEduType");

             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 if ((e.Row.RowState & DataControlRowState.Edit) > 0) //allow binding of dropdown from datatable
                 {
                     DataTable dtEduTypeList = new DataTable();
                     dtEduTypeList = oUtil.GET_EDUBACKGROUND();

                     ddEduType.DataSource = dtEduTypeList;
                     ddEduType.DataTextField = dtEduTypeList.Columns["EduTypeDesc"].ToString();
                     ddEduType.DataValueField = dtEduTypeList.Columns["EduTypeDesc"].ToString();
                     ddEduType.DataBind();

                     ddEduType.SelectedValue = lblEduType.Text;
                 }
             }
        

    }


    protected void gvEducation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEducation.EditIndex = e.NewEditIndex;
        displayEduBackground();

    }
    protected void gvEducation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEducation.EditIndex = -1;
        displayEduBackground();
    }

    protected void  gvEducation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    
    int id = Convert.ToInt32(gvEducation.DataKeys[e.RowIndex].Value.ToString()); //Get the value of data key
    GridViewRow row = (GridViewRow)gvEducation.Rows[e.RowIndex];

    
    DropDownList ddEduType = (DropDownList)row.FindControl("ddEduType");
    TextBox g_txtSchoolName = (TextBox)row.FindControl("txtSchoolName");
    TextBox g_txtAddress = (TextBox)row.FindControl("txtAddress");
    TextBox g_txtYear = (TextBox)row.FindControl("txtYearGrad");
        
    gvEducation.EditIndex = -1;
    oStudent.UPDATE_EDUCBACK(id, ddEduType.SelectedValue.ToString(), g_txtSchoolName.Text, g_txtAddress.Text, g_txtYear.Text, Session["U_USERID"].ToString());
    displayEduBackground();
    
    }



    protected void lnkAddEducation_Click(object sender, EventArgs e)
    {
        if (ddEduType.SelectedIndex == 0)
        {
            //do nothing
            //message here
        }

        else
        {

            oStudent.INSERT_EDUCBACK(lblStudentNo.Text, ddEduType.SelectedValue.ToString(), txtSchoolName.Text,
            txtSchAddress.Text, txtYearGrad.Text, Session["U_USERID"].ToString());

            clearEducFields();
            displayEduBackground();

            MessageDialog("Previous School added.", 1); 
        }
    }

    protected void lnkUpdateRelative_Click(object sender, EventArgs e)
    {
        //Condition will place here.

        if (optPrimaryFather.Checked == false && optPrimaryMother.Checked == false && optGuardian.Checked == false)
        {
            MessageDialog("Please Select Primary Contact", 3);
        }

        else {

            int priCon = 1;
            /*
             1 = Father
             2 = Mother
             3 = Guardian
             */

            if (optPrimaryFather.Checked)
            {
                priCon = 1;
            }
            else if (optPrimaryMother.Checked)
            {
                priCon = 2;
            }
            else if (optGuardian.Checked)
            {
                priCon = 3;
            }


        if (oStudent.CHECK_FAMILY(lblStudentNo.Text))
        {
            oStudent.UPDATE_RELATIVE(lblStudentNo.Text, ucFLastName.TEXTVALUE.ToUpper(), ucFFirstName.TEXTVALUE.ToUpper(), ucFMiddleName.TEXTVALUE.ToUpper(),
                                   ucFOccupation.TEXTVALUE.ToUpper(), ddFCitizenship.SelectedValue.ToString(), txtFEducAttainment.Text,
                                   txtFCompany.Text, txtFCompAddress.Text, ucFTelephone.Text, ucFMobile.Text,
                                   ucMLastName.TEXTVALUE.ToUpper(), ucMFirstName.TEXTVALUE.ToUpper(), ucMMiddleName.TEXTVALUE.ToUpper(),
                                   ucMOccupation.TEXTVALUE.ToUpper(), ddMCitizenship.SelectedValue.ToString(), txtMEducAttainment.Text,
                                   txtMCompany.Text, txtMCompAddress.Text, ucMTelephone.Text, ucMMobile.Text,
                                   ucGLastName.TEXTVALUE.ToUpper(), ucGFirstName.TEXTVALUE.ToUpper(), ucGMiddleName.TEXTVALUE.ToUpper(),
                                   txtGAddress.Text, ucGTelephone.Text, ucGMobile.Text, txtGRelation.Text, priCon);

            MessageDialog("Relatives updated.", 2);
        }
        else
        {
            oStudent.INSERT_RELATIVE(lblStudentNo.Text, ucFLastName.TEXTVALUE.ToUpper(), ucFFirstName.TEXTVALUE.ToUpper(), ucFMiddleName.TEXTVALUE.ToUpper(),
                                     ucFOccupation.TEXTVALUE.ToUpper(), ddFCitizenship.SelectedValue.ToString(), txtFEducAttainment.Text,
                                     txtFCompany.Text, txtFCompAddress.Text, ucFTelephone.Text, ucFMobile.Text,
                                     ucMLastName.TEXTVALUE.ToUpper(), ucMFirstName.TEXTVALUE.ToUpper(), ucMMiddleName.TEXTVALUE.ToUpper(),
                                     ucMOccupation.TEXTVALUE.ToUpper(), ddMCitizenship.SelectedValue.ToString(), txtMEducAttainment.Text,
                                     txtMCompany.Text, txtMCompAddress.Text, ucMTelephone.Text, ucMMobile.Text,
                                     ucGLastName.TEXTVALUE.ToUpper(), ucGFirstName.TEXTVALUE.ToUpper(), ucGMiddleName.TEXTVALUE.ToUpper(),
                                     txtGAddress.Text, ucGTelephone.Text, ucGMobile.Text, txtGRelation.Text, priCon);
            
            MessageDialog("Relatives successfully added.", 1);
            //clearRelative();
        }

        }
    }

    protected void lnkCredentials_Click(object sender, EventArgs e)
    {

        if ((bool)ViewState["IS_STUDENTCREDENTIAL"])
        {
            //WILL update changes in student credentials
            oStudent.UPDATE_STUDENTCREDENTIALS(lblStudentNo.Text, chkF138.Checked, chkBC.Checked, chk1x1Picture.Checked,
                                                chkEnvelope.Checked, chkGoodMoral.Checked, chkRecommendation.Checked,
                                                chk137.Checked, chkNCAE.Checked, chkInterview.Checked, txtOthers.Text);

            MessageDialog("Credentials updated.", 2);
        }
        
        else
        {
        //Will Create and Add Credentials
        oStudent.INSERT_STUDENTCREDENTIALS(lblStudentNo.Text, chkF138.Checked, chkBC.Checked, chk1x1Picture.Checked,
                                         chkEnvelope.Checked, chkGoodMoral.Checked, chkRecommendation.Checked,
                                         chk137.Checked, chkNCAE.Checked, chkInterview.Checked, txtOthers.Text);

        //Reset status of credential
        ViewState["IS_STUDENTCREDENTIAL"] = true;

        MessageDialog("Credentials added.", 1);

        
        }
        
    }

    protected void lnkUpdateStrand_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_STRANDCODE(lblStudentNo.Text, ddStrand.SelectedValue.ToString(), Session["U_USERID"].ToString());
        MessageDialog("Student Strand updated.", 2);
    }

    protected void lnkBLS_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_BLS(lblStudentNo.Text, txtBarcode.Text, txtLRN.Text, chkSSIChild.Checked, Session["U_USERID"].ToString());
        MessageDialog("Student Barcode / LRN / Employee Child.", 2);
    }

    protected void lnkUpdateStatus_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_STATUS(lblStudentNo.Text, chkActive.Checked, Session["U_USERID"].ToString());
        MessageDialog("Student Status updated.", 2);
    }

    protected void lnkUpdateMOT_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_STUDENT_MOT(lblStudentNo.Text, ddMOT.SelectedValue.ToString(), Session["U_USERID"].ToString());
        MessageDialog("MOT Updated successfully.", 2);
    }

    protected void lnkUpdateReserve_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_RESERVATION_STATUS(lblStudentNo.Text, ddReservedStatus.SelectedValue.ToString(), Session["U_USERID"].ToString());
        MessageDialog("Reservation Status updated!", 2);
    }

    protected void lnkUpdateEnrollment_Click(object sender, EventArgs e)
    {
        oStudent.UPDATE_ENROLLMENT_STATUS(lblStudentNo.Text, ddEnrollmentStatus.SelectedValue.ToString(), Session["U_USERID"].ToString());
        MessageDialog("Enrollment Status updated!", 2);
    
    }

    protected void chkTest_CheckedChanged(object sender, EventArgs e)
    {
         displaySiblings();
    }

    protected void lnkAddSibling_Click(object sender, EventArgs e)
    {
       
        string sibCode = "";
        bool chkSib1 = false;
        bool chkSib2 = false;


        if (ddSiblings.SelectedIndex == 0)
        {
            MessageDialog("Please select sibling.", 3);
        }

        else
        {

            if (oStudent.CHECK_SIBLINGEXIST(ddSiblings.SelectedValue.ToString()))
            {
                ViewState["SIB2"] = oStudent.SIBLINGCODE;
                chkSib2 = true;
            }
            else
            {
                ViewState["SIB2"] = "";
                chkSib2 = false;
            }

            //Recheck again the siblingcode of current process student
            if (oStudent.CHECK_SIBLINGEXIST(lblStudentNo.Text))
            {
                ViewState["SIB1"] = oStudent.SIBLINGCODE;
                chkSib1 = true;
            }
            else
            {
                ViewState["SIB1"] = "";
                chkSib1 = false;
            }


            ////Validate if both don't exist on sibling table

            if (chkSib1 == false && chkSib2 == false)
            {

                //Generate SiblingCode
                sibCode = oAutoNumber.SiblingNumber("SC");

                //Add both to Sibling Table
                oStudent.INSERT_SIBLINGS(lblStudentNo.Text, sibCode, 1, Session["U_USERID"].ToString());
                oStudent.INSERT_SIBLINGS(ddSiblings.SelectedValue.ToString(), sibCode, 2, Session["U_USERID"].ToString());

                //UPDATE Siblings AutoNumber
                oAutoNumber.updateSiblingNumber("SC");

                //Display refresh the list of siblings
                displaySiblingsList(sibCode);

                MessageDialog("Siblings relation setup success.", 1);
            }

            //Condition if the currently student on edit mode is true and the selected sibling is false
            else if (chkSib1 == true && chkSib2 == false)
            {
                if (oStudent.CHECK_SIBLINGORDEREXIST(ViewState["SIB1"].ToString(), Convert.ToInt32(ddSOrder.SelectedValue.ToString())))
                {
                    //Response.Write("Cant Proceed");
                    MessageDialog("Same sibling order not allowed.", 3);
                }
                else
                {
                    ViewState["SIB2"] = ViewState["SIB1"].ToString();
                    oStudent.INSERT_SIBLINGS(ddSiblings.SelectedValue.ToString(), ViewState["SIB2"].ToString(), Convert.ToInt32(ddSOrder.SelectedValue.ToString()), Session["U_USERID"].ToString());
                    //Display refresh the list of siblings
                    displaySiblingsList(ViewState["SIB2"].ToString());
                    MessageDialog("Siblings added success.", 1);
                }

            }

            ////Condition if the currently student don't have siblingcode and the selected sibling have code
            else if (chkSib1 == false && chkSib2 == true)
            {
                if (oStudent.CHECK_SIBLINGORDEREXIST(ViewState["SIB2"].ToString(), Convert.ToInt32(ddSOrder.SelectedValue.ToString())))
                {
                    //Response.Write("Cant Proceed");
                    MessageDialog("Same sibling order not allowed.", 3);
                }
                else
                {
                    ViewState["SIB1"] = ViewState["SIB2"].ToString();
                    oStudent.INSERT_SIBLINGS(lblStudentNo.Text, ViewState["SIB1"].ToString(), Convert.ToInt32(ddSOrder.SelectedValue.ToString()), Session["U_USERID"].ToString());
                    //Display refresh the list of siblings
                    displaySiblingsList(ViewState["SIB1"].ToString());
                    MessageDialog("Siblings added success.", 1);
                }
            }

            ////Condition if both are with sibling code
            else if (chkSib1 == true && chkSib2 == true)
            {
                //Condition if both the same sibling code
                if (ViewState["SIB1"].ToString() == ViewState["SIB2"].ToString())
                {
                    //Allowed the adding
                    //Response.Write("GOOD");
                    MessageDialog("Sibling already exist in the list.", 3);
                }
                else
                {
                    //Prompt a message and disallowed the process
                    //Response.Write("Error for Sibling Code mismatch");
                    MessageDialog("Both Student have different sibling relation, action suspend.", 3);

                }
            }


        
        } //End of No sibling selection condition


        
    

        //Condition in adding siblings

        //check if current student and selected sibling is the same
        //---------------------
        //if (lblStudentNo.Text == ddSiblings.SelectedValue.ToString())
        //{
        //    Response.Write("You cant add the same sibling and students selected.");
        //}
        //else if(oStudent.CHECK_SIBLINGEXIST(lblStudentNo.Text, ddSiblings.SelectedValue.ToString()))
        //{
        //    Response.Write("Sibling already exist");
        //}
        //else
        //{

        ////NEW APPROACH IN STORING SIBLING / ADDING.
        //oStudent.INSERT_SIBLINGS(lblStudentNo.Text, ddSiblings.SelectedValue.ToString(), Session["U_USERID"].ToString());
        //displaySiblingsList(lblStudentNo.Text);
        //}
    }




    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        //CONDITION IN STRANDCODE

        //if (ddGradeLevel.SelectedValue.ToString() == "G11" || ddGradeLevel.SelectedValue.ToString() == "G12")
        //{
        //    ViewState["STRAND"] = ddStrand.SelectedValue.ToString();
        //}
        //else
        //{
        //    ViewState["STRAND"] = "";
        //}

        //Condition if empty the required fields


        oStudent.UPDATE_STUDENTINFORMATION(lblStudentNo.Text,ucTxtLastName.TEXTVALUE, ucTxtFirstName.TEXTVALUE, ucTxtMiddleName.Text, txtMI.Text, txtSuffix.Text,
                                           completeName(), ddGender.SelectedValue.ToString(), Convert.ToDateTime(txtBirthDate.Text), txtPlaceOfBirth.Text, 15.5, ddCitizenship.SelectedValue.ToString(),
                                           ddReligion.SelectedValue.ToString(), ucTelNo.Text, ucMobile.Text, txtAddNoStreet.Text, ddArea.SelectedValue.ToString(), ddCity.SelectedValue.ToString(),
                                           txtEmailAdd.Text,"Testing Remarks", ucContactPerson.TEXTVALUE,chkActive.Checked,"~/photo/" + lblStudentNo.Text + ".jpg",Session["U_USERID"].ToString());
        
        MessageDialog("Student Information Updated.", 2);


       //clear employee child

       
    }


   
    private string completeName()
    {
        string suffix_use = "";
        string strComplete = "";


        ViewState["LASTNAME"] = ucTxtLastName.TEXTVALUE.ToUpper();
        ViewState["FIRSTNAME"] = ucTxtFirstName.TEXTVALUE.ToUpper();
        ViewState["MIDDLENAME"] = ucTxtMiddleName.Text.ToUpper();
        ViewState["SUFFIX"] = txtSuffix.Text.ToUpper();
        ViewState["MI"] = txtMI.Text.ToUpper();


        if (string.IsNullOrEmpty(txtSuffix.Text))
        {
            suffix_use = "";
        }
        else
        {
            suffix_use = " " + ViewState["SUFFIX"].ToString().Trim();
        }


        if (string.IsNullOrEmpty(ViewState["MI"].ToString().Trim()))
        {
            strComplete = ViewState["FIRSTNAME"].ToString().Trim() + " " + ViewState["LASTNAME"].ToString().Trim() + suffix_use;
        }
        else
        {
            strComplete = ViewState["FIRSTNAME"].ToString().Trim() + " " + ViewState["MI"].ToString().Trim() + ". " + ViewState["LASTNAME"].ToString().Trim() + suffix_use;
        }


        return strComplete;
    }


   

    protected void ddCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayBarangay(ddCity.SelectedValue.ToString());
    }

    protected void lnkSiblingOtherSel_Click(object sender, EventArgs e)
    {
        //clear first drop down
        ddSiblings.DataSource = "";
        ddSiblings.DataBind();

        //Reload All students
        displaySiblings();
         
    }

    protected void imgSwitchParent_Click(object sender, ImageClickEventArgs e)
    {
        switchRelative();
    }

  



    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }

    protected void gvSiblings_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSiblings.EditIndex = -1;
        displaySiblingsList(ViewState["SIB1"].ToString());
    }

    protected void gvSiblings_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(gvSiblings.DataKeys[e.RowIndex].Value.ToString()); //Get the value of data key
        GridViewRow row = (GridViewRow)gvSiblings.Rows[e.RowIndex];


        DropDownList ddSiblingOrder = (DropDownList)row.FindControl("ddSiblingOrder");

        if (oStudent.CHECK_SIBLINGORDEREXIST(ViewState["SIB1"].ToString(), Convert.ToInt32(ddSiblingOrder.SelectedValue.ToString())))
        {
            MessageDialog("Same sibling order not allowed.", 3);
        }
        else
        {

            gvSiblings.EditIndex = -1;
            // oStudent.UPDATE_EDUCBACK(id, ddEduType.SelectedValue.ToString(), g_txtSchoolName.Text, g_txtAddress.Text, g_txtYear.Text, Session["U_USERID"].ToString());
            oStudent.UPDATE_SIBLINGORDER(id, Convert.ToInt32(ddSiblingOrder.SelectedValue.ToString()));
            displaySiblingsList(ViewState["SIB1"].ToString());
            //Return to default state of grid view
            MessageDialog("Sibling Order Updated.", 2);
        }

    }

    protected void gvSiblings_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvSiblings.DataKeys[e.RowIndex].Value.ToString());
        //GridViewRow row = (GridViewRow)gvSiblings.Rows[e.RowIndex];

        gvSiblings.EditIndex = -1;
        oStudent.DELETE_SIBLING(id);

        MessageDialog("Sibling removal success.", 2);

        displaySiblingsList(ViewState["SIB1"].ToString());

    }
    protected void gvSiblings_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSiblings.EditIndex = e.NewEditIndex;
        displaySiblingsList(ViewState["SIB1"].ToString());
    }

    protected void gvSiblings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList ddSiblingOrder = (DropDownList)e.Row.FindControl("ddSiblingOrder");
        Label lblSiblingOrder = (Label)e.Row.FindControl("lblSiblingOrder");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0) //allow binding of dropdown from datatable
            {
                //Manually Added to dropdown list              
                ddSiblingOrder.Items.Insert(0, new ListItem("1"));
                ddSiblingOrder.Items.Insert(1, new ListItem("2"));
                ddSiblingOrder.Items.Insert(2, new ListItem("3"));
                ddSiblingOrder.Items.Insert(3, new ListItem("4"));
                ddSiblingOrder.Items.Insert(4, new ListItem("5"));
                ddSiblingOrder.Items.Insert(5, new ListItem("6"));
                ddSiblingOrder.Items.Insert(6, new ListItem("7"));
                ddSiblingOrder.Items.Insert(7, new ListItem("8"));

                //Copy the text of sibling to dropdown
                ddSiblingOrder.SelectedValue = lblSiblingOrder.Text;
            }
           
        }
        
    }




  
}