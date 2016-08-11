using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;
//using CrystalDecisions.ReportSource;
//using CrystalDecisions.Reporting;


public partial class applicant : System.Web.UI.Page
{
    Utilities objUtil = new Utilities();
    AutoNumber objAuto = new AutoNumber();
    Applicant objApp = new Applicant();
    xSystem oSystem = new xSystem();
    Student oStudent = new Student();

    DataTable dtApplicant;
    DataTable dtApplicantPrevGrade;



    //Button from UserControl Commands


    /* ViewState["CURRENTACTION"] DETAILS VALUE
     * This will be implemented on imgSave Button Control
     0 = NO ACTION
     1 = NEW --> SAVE
     2 = EDIT --> UPDATE
     
     */



    protected void Page_Init(object sender, EventArgs e)
    {
        //initialize the value before page was render
        
        //Value for Report Parameter name AppNum
        ViewState["RP_APPNUM"] = "";

     



    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //DISPLAY LIST OF APPLICANT
            displayListOfApplicant();

            displayApplicantTypeList();
            displayLevelType();
            displayApplicantStrand();
            displayGender();
            displayCity();

            //load list of barangay
            displayBarangay();

  
            //Dispaly Baranggay Initially
           //displayBarangay(ddCity.SelectedValue.ToString());

            //Initial State
            //Hide previous grade for initial load
            panStrand.Visible = false;

            chkNCAE.Enabled = false;
            chkInterview.Enabled = false;

            chkActive.Checked = true;
            
            //disable visibility of panel conrtol 2 compose of save and return
            panControl2.Visible = false;


            //DisplayList of Deliquent Student
            //01-21-2016
            displayDeliquentList();

        }


    }


    private bool checkExistApplicant(string LASTNAME, string FIRSTNAME, string MIDDLENAME)
    {
        bool x = false;

        dtApplicant = new DataTable();
        dtApplicant = objApp.getDetailsApplicant();
      
        DataRow[] dr;
        dr = dtApplicant.Select("LastName = '" + LASTNAME + "' AND FirstName= '" + FIRSTNAME + "' AND MiddleName='" + MIDDLENAME + "'");

        x = (dr.Length > 0 ? true : false);
     

        return x;
    }

    private void displaySearchApplicant(string INPUT)
    {

        dtApplicant = new DataTable();
        dtApplicant = objApp.getDetailsApplicant();

        DataRow[] dr;
        dr = dtApplicant.Select("AppNum = '" + INPUT + "'");

        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                //ucDateApplication.textBoxValue = row["AppDOA"].ToString();
                ucDateApplication.CalendarValue = Convert.ToDateTime(row["AppDOA"]);
                ddAppType.SelectedValue = row["AppTypeCode"].ToString();
                ddAppLevel.SelectedValue = row["LevelTypeCode"].ToString();
                txtBirthDate.Text = row["DOB"].ToString();
                txtPlaceOfBirth.Text = row["POB"].ToString();

                //if (row["AppTypeCode"].ToString() != "NA")
                //{
                //    panelPreviousGrade.Visible = true;
                  displayPrevGrade_SearchByID(INPUT);
                //}

                if (row["LevelTypeCode"].ToString() == "G11" || row["LevelTypeCode"].ToString() == "G12")
                {
                    ddStrandType.SelectedValue = row["StrandCode"].ToString();
                    panStrand.Visible = true;

                    Session["A_STRAND?"] = "YES";
                }
                else
                {
                    panStrand.Visible = false;
                    Session["A_STRAND?"] = "NO";
                }

                chkWaitListed.Checked = (bool)row["WLStatus"];
                chkSSIChild.Checked = (bool)row["SSIChild"];

                ucTxtLastName.TEXTVALUE = row["LastName"].ToString();
                ucTxtFirstName.TEXTVALUE = row["FirstName"].ToString();
                ucTxtMiddleName.TEXTVALUE = row["MiddleName"].ToString();
                txtMI.Text = row["MI"].ToString();
                txtSuffix.Text = row["Suffix"].ToString();

                ddGender.SelectedValue = row["GenderCode"].ToString();
                ucTelNo.TELVALUE = row["TelNo"].ToString();
                ucMobile.MOBILEVALUE = row["MobileNo"].ToString();
                ucContactPerson.TEXTVALUE = row["ContactPerson"].ToString();
                txtAddNoStreet.Text = row["AddInfo"].ToString();
                ddArea.SelectedValue = row["BarangayCode"].ToString();
                ddCity.SelectedValue = row["CityCode"].ToString();
                txtEmailAdd.Text = row["Email"].ToString();
                txtRemarks.Text = row["Remarks"].ToString();
                chkActive.Checked = (bool)row["Status"];
                chkAppBackOut.Checked = (bool)row["AppBackOut"];
                //Credentials
                chkF138.Checked = (bool) row["Form138"];
                chkBC.Checked = (bool)row["BC"];
                chk1x1Picture.Checked = (bool)row["Colored1x1"];
                chkEnvelope.Checked = (bool)row["BrownEnvelope"];
                chkGoodMoral.Checked = (bool)row["GM"];
                chkRecommendation.Checked = (bool)row["Recommendation"];
                chk137.Checked = (bool)row["Form137"];
                chkNCAE.Checked = (bool)row["NCAE"];
                txtOthers.Text = row["Other"].ToString();


              
            }
        }
   


    }

    private void displayPrevGrade_SearchByID(string INPUT)
    {
        dtApplicantPrevGrade = new DataTable();
        dtApplicantPrevGrade = objApp.getPrevGrade();

       
        DataRow[] dr;
        dr = dtApplicantPrevGrade.Select("SNUM = '" + INPUT + "'");

        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                
                eng1.GRADEINPUT = Convert.ToDouble(row["Eng1"]);
                eng2.GRADEINPUT = Convert.ToDouble(row["Eng2"]);
                eng3.GRADEINPUT = Convert.ToDouble(row["Eng3"]);
                eng4.GRADEINPUT = Convert.ToDouble(row["Eng4"]);

                sci1.GRADEINPUT = Convert.ToDouble(row["Sci1"]);
                sci2.GRADEINPUT = Convert.ToDouble(row["Sci2"]);
                sci3.GRADEINPUT = Convert.ToDouble(row["Sci3"]);
                sci4.GRADEINPUT = Convert.ToDouble(row["Sci4"]);

                mat1.GRADEINPUT = Convert.ToDouble(row["Math1"]);
                mat2.GRADEINPUT = Convert.ToDouble(row["Math2"]);
                mat3.GRADEINPUT = Convert.ToDouble(row["Math3"]);
                mat4.GRADEINPUT = Convert.ToDouble(row["Math4"]);

                double average = applicantAverage();
                lblAverage.Text = average.ToString("0.00");

               
            }
        }


    }

    private void displayListOfApplicant()
    {
        DataTable dt = new DataTable();
        dt = objApp.getApplicant();


        gvApplicant.DataSource = dt;
        gvApplicant.DataBind();
    }

    private void displaySearchViaName(string INPUT)
    {
        DataTable dt = new DataTable();
        dt = objApp.getApplicant();

        DataView dv = new DataView(dt);
        dv.RowFilter = "Fullname like '%" + txtSearch.Text + "%'";

        gvApplicant.DataSource = dv;
        gvApplicant.DataBind();
    }

 

    private void displayApplicantTypeList()
    {
        DataTable dt = new DataTable();
        dt = objUtil.getApplicantType();

        ddAppType.DataSource = dt;
        ddAppType.DataTextField = dt.Columns["AppTypeDesc"].ToString();
        ddAppType.DataValueField = dt.Columns["AppTypeCode"].ToString();
        ddAppType.DataBind();
    }

    private void displayLevelType()
    {
        DataTable dt = new DataTable();
        dt = objUtil.getApplicantLevel();

        ddAppLevel.DataSource = dt;
        ddAppLevel.DataTextField = dt.Columns["LevelTypeDesc"].ToString();
        ddAppLevel.DataValueField = dt.Columns["LevelTypeCode"].ToString();
        ddAppLevel.DataBind();
    }

    private void displayApplicantStrand()
    {
        DataTable dt = new DataTable();
        dt = objUtil.GET_LEVEL_STRAND();
       
        ddStrandType.DataSource = dt;
        ddStrandType.DataTextField = dt.Columns["StrandName"].ToString();
        ddStrandType.DataValueField = dt.Columns["StrandCode"].ToString();
        ddStrandType.DataBind();

      //  ddStrandType.Items.Insert(0, "--Select--");
    }

    private void displayGender()
    {
        DataTable dt = new DataTable();
        dt = objUtil.GET_GENDER();

        ddGender.DataSource = dt;
        ddGender.DataTextField = dt.Columns["GenderDesc"].ToString();
        ddGender.DataValueField = dt.Columns["GenderCode"].ToString();
        ddGender.DataBind();
    }

    private void displayBarangay(string INPUT)
    {
        DataTable dt = new DataTable();
        dt = objUtil.getBarangay(INPUT);


        ddArea.DataSource = dt;
        ddArea.DataTextField = dt.Columns["BarangayDesc"].ToString(); 
        ddArea.DataValueField = dt.Columns["BarangayCode"].ToString();
        ddArea.DataBind();
    }

    private void displayBarangay()
    {
        DataTable dt = new DataTable();
        dt = objUtil.GET_BARANGAY();


        ddArea.DataSource = dt;
        ddArea.DataTextField = dt.Columns["BarangayDesc"].ToString();
        ddArea.DataValueField = dt.Columns["BarangayCode"].ToString();
        ddArea.DataBind();
    }


    private void displayCity()    
    { 
         DataTable dt = new DataTable();
         dt = objUtil.GET_CITY();

         ddCity.DataSource = dt;
         ddCity.DataTextField = dt.Columns["CityDesc"].ToString();
         ddCity.DataValueField = dt.Columns["CityCode"].ToString();
         ddCity.DataBind();
    
    }


    private void displayDeliquentList()
    {
        DataTable dt = new DataTable();
        dt = oStudent.GETDELIQUENTLIST();

        gvDeliquent.DataSource = dt;
        gvDeliquent.DataBind();
    
    }



    protected void ddAppLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //PRE SCHOOL AGE
        if (ddAppLevel.SelectedValue == "P1" || ddAppLevel.SelectedValue == "P2" || ddAppLevel.SelectedValue == "P3" || ddAppLevel.SelectedValue == "G1")
        {
            panShortMonth.Enabled = true;
        }

        else
        {
            panShortMonth.Enabled = false;
            chkShort.Checked = false;
            txtShortMonth.Text = int.Parse("0").ToString();
        }


        if (ddAppLevel.SelectedValue == "G11" || ddAppLevel.SelectedValue == "G12")
        {
            panStrand.Visible = true;

            chkNCAE.Enabled = true;
            chkNCAE.Checked = false;

            chkInterview.Enabled = true;
            chkInterview.Checked = false;

        }  

        else
         {
             panStrand.Visible = false;

             chkNCAE.Enabled = false;
             chkNCAE.Checked = false;

             chkInterview.Enabled = false;
             chkInterview.Checked = false;


        }
        
        

    }

   

 

    //Compute Average of Applicant

    private double applicantAverage()
    {
        double average = 0.0;

        int eCount=0, sCount=0, mCount=0;

        double e1, e2, e3, e4, s1, s2, s3, s4, m1, m2, m3, m4;

        double eTotal, sTotal, mTotal, gp1Total, gp2Total, gp3Total, gp4Total;

        double LOWER = 80.0;


        e1 = eng1.Grade();
        e2 = eng2.Grade();
        e3 = eng3.Grade();
        e4 = eng4.Grade();

        if (string.IsNullOrEmpty(eng1.ToString()) || eng1.Grade() == 0)
        {
            eCount = eCount + 0;
        }
        else
        {
            eCount = eCount + 1;
        }

        if (string.IsNullOrEmpty(eng2.ToString()) || eng2.Grade() == 0)
        {
            eCount = eCount + 0;
        }
        else
        {
            eCount = eCount + 1;
        }

        if (string.IsNullOrEmpty(eng3.ToString()) || eng3.Grade() == 0)
        {
            eCount = eCount + 0;
        }
        else
        {
            eCount = eCount + 1;
        }

        if (string.IsNullOrEmpty(eng4.ToString()) || eng4.Grade() == 0)
        {
            eCount = eCount + 0;
        }
        else
        {
            eCount = eCount + 1;
        }

        eTotal = (e1 + e2 + e3 + e4) / eCount;


        s1 = sci1.Grade();
        s2 = sci2.Grade();
        s3 = sci3.Grade();
        s4 = sci4.Grade();

        if (string.IsNullOrEmpty(sci1.ToString()) || sci1.Grade() == 0)
        {
            sCount = sCount + 0;
        }
        else
        {
            sCount = sCount + 1;
        }

        if (string.IsNullOrEmpty(sci2.ToString()) || sci2.Grade() == 0)
        {
            sCount = sCount + 0;
        }
        else
        {
            sCount = sCount + 1;
        }

        if (string.IsNullOrEmpty(sci3.ToString()) || sci3.Grade() == 0)
        {
            sCount = sCount + 0;
        }
        else
        {
            sCount = sCount + 1;
        }

        if (string.IsNullOrEmpty(sci4.ToString()) || sci4.Grade() == 0)
        {
            sCount = sCount + 0;
        }
        else
        {
            sCount = sCount + 1;
        }


        sTotal = (s1 + s2 + s3 + s4) / sCount;

        m1 = mat1.Grade();
        m2 = mat2.Grade();
        m3 = mat3.Grade();
        m4 = mat4.Grade();

        if (string.IsNullOrEmpty(mat1.ToString()) || mat1.Grade() == 0)
        {
            mCount = mCount + 0;
        }
        else
        {
            mCount = mCount + 1;
        }

        if (string.IsNullOrEmpty(mat2.ToString()) || mat2.Grade() == 0)
        {
            mCount = mCount + 0;
        }
        else
        {
            mCount = mCount + 1;
        }

        if (string.IsNullOrEmpty(mat3.ToString()) || mat3.Grade() == 0)
        {
            mCount = mCount + 0;
        }
        else
        {
            mCount = mCount + 1;
        }

        if (string.IsNullOrEmpty(mat4.ToString()) || mat4.Grade() == 0)
        {
            mCount = mCount + 0;
        }
        else
        {
            mCount = mCount + 1;
        }

        mTotal = (m1 + m2 + m3 + m4) / mCount;

        if (eCount == 0 || sCount == 0 || mCount == 0)
        {
            eTotal = 0;
            sTotal = 0;
            mTotal = 0;
        }
 
        engTotal.Text = eTotal.ToString("0.00");
        sciTotal.Text = sTotal.ToString("0.00");
        matTotal.Text = mTotal.ToString("0.00");
 
        gp1Total = (e1 + s1 + m1) / 3;
        gp2Total = (e2 + s2 + m2) / 3;
        gp3Total = (e3 + s3 + m3) / 3;
        gp4Total = (e4 + s4 + m4) / 3;


        lblGP1.Text = gp1Total.ToString("0.00");
        lblGP2.Text = gp2Total.ToString("0.00");
        lblGP3.Text = gp3Total.ToString("0.00");
        lblGP4.Text = gp4Total.ToString("0.00");

        average = (eTotal + sTotal + mTotal) / 3;
        
        lblAverage.Text = average.ToString("0.00");

        ViewState["FINALAVERAGE"] = average.ToString("0.00");

        //Place generated data to viewstate
        ViewState["ENGTOTAL"] = eTotal.ToString("0.00");
        ViewState["SCITOTAL"] = sTotal.ToString("0.00");
        ViewState["MATHTOTAL"] = mTotal.ToString("0.00");

        ViewState["FIRSTTOTAL"] = gp1Total.ToString("0.00");
        ViewState["SECONDTOTAL"] = gp2Total.ToString("0.00");
        ViewState["THIRDTOTAL"] = gp3Total.ToString("0.00");
        ViewState["FOURTHTOTAL"] = gp4Total.ToString("0.00");

        ViewState["ENG1"] = e1;
        ViewState["ENG2"] = e2;
        ViewState["ENG3"] = e3;
        ViewState["ENG4"] = e4;

        ViewState["SCI1"] = s1;
        ViewState["SCI2"] = s2;
        ViewState["SCI3"] = s3;
        ViewState["SCI4"] = s4;

        ViewState["MATH1"] = m1;
        ViewState["MATH2"] = m2;
        ViewState["MATH3"] = m3;
        ViewState["MATH4"] = m4;

        
        //Validate user input if there is below 80 
        ViewState["LOWERENG"] = false;
        ViewState["LOWERSCI"] = false;
        ViewState["LOWERMATH"] = false;

        //English
        if (e1 != 0)
        { 
            if(e1 < LOWER)
                ViewState["LOWERENG"] = true;
        }

        if (e2 != 0)
        {
            if (e2 < LOWER)
                ViewState["LOWERENG"] = true;
        }

        if (e3 != 0)
        {
            if (e3 < LOWER)
                ViewState["LOWERENG"] = true;
        }

        if (e4 != 0)
        {
            if (e4 < LOWER)
                ViewState["LOWERENG"] = true;
        }

        //Science
        if (s1 != 0)
        {
            if (s1 < LOWER)
                ViewState["LOWERSCI"] = true;
        }

        if (s2 != 0)
        {
            if (s2 < LOWER)
                ViewState["LOWERSCI"] = true;
        }

        if (s3 != 0)
        {
            if (s3 < LOWER)
                ViewState["LOWERSCI"] = true;
        }

        if (s4 != 0)
        {
            if (s4 < LOWER)
                ViewState["LOWERSCI"] = true;
        }
         
        
        //Mathematics
        if (m1 != 0)
        {
            if (m1 < LOWER)
                ViewState["LOWERMATH"] = true;
        }

        if (m2 != 0)
        {
            if (m2 < LOWER)
                ViewState["LOWERMATH"] = true;
        }

        if (m3 != 0)
        {
            if (m3 < LOWER)
                ViewState["LOWERMATH"] = true;
        }

        if (m4 != 0)
        {
            if (m4 < LOWER)
                ViewState["LOWERMATH"] = true;
        }


        ////Display on the remark
        if ((bool)ViewState["LOWERENG"] || (bool)ViewState["LOWERSCI"] || (bool)ViewState["LOWERMATH"])
        {
            //txtRemarks.Text = "There is grade below 80 in major subjects";
        }
        //else
        //{ //txtRemarks.Text = "Clear on previous grade"; }
       


        return average;


    }

    //Compute Age of Applicant
    private void computeApplicantAge()
    {
        int ageNow;

        DateTime dtDOB = DateTime.Parse(txtBirthDate.Text);
        Age age = new Age(dtDOB);
        ageNow = (int)age.Years; //Actual Age


        //For admission age on JUNE
       

        int getMonthToday = (int)DateTime.Now.Month;
        int getMonthOnJune;
        int getMonthTotal;
        int totalMonthOnJune; 
       
        //Get the difference of month today and 12 then add the month of June which equal to 6
        getMonthOnJune = (12 - getMonthToday) + 6;

        //Add the result of getMonthOnJune then add it to month total of birthdate
        getMonthTotal = (int)age.Months + getMonthOnJune;

        //Condition if total getMonthTotal was over or equal to 12
            if (getMonthTotal >= 12)
            {
                totalMonthOnJune = getMonthTotal - 12;
            }
            else
            {
                totalMonthOnJune = getMonthTotal;
            }
            
       
       

        ViewState["AGE"] = 0.0;
        ViewState["AGEBYJUNE"] = 0.0;

        string fullAge = (int)age.Years + "." + (int)age.Months;
        ViewState["AGE"] = fullAge;
        
        string strAgeByJune = (int)age.Years + "." + totalMonthOnJune;
        ViewState["AGEBYJUNE"] = strAgeByJune;

    }

    private string generateApplicantNumber()
    {

        string x = "";

       // x = objAuto.appNumber(oSystem.AppPrefix);
       x = objAuto.appNumber(Session["X_APP_PREFIX"].ToString());

        return x;
        
    
    }

    private string completeName()
    {
        string strComplete = "";

        
        ViewState["LASTNAME"] = ucTxtLastName.TEXTVALUE.ToUpper();
        ViewState["FIRSTNAME"] = ucTxtFirstName.TEXTVALUE.ToUpper();
        ViewState["MIDDLENAME"] = ucTxtMiddleName.TEXTVALUE.ToUpper();
        ViewState["SUFFIX"] = txtSuffix.Text.ToUpper();
        ViewState["MI"] = txtMI.Text.ToUpper();

        if (string.IsNullOrEmpty(txtSuffix.Text))
        {
            strComplete = ViewState["FIRSTNAME"].ToString().Trim() + " " + ViewState["MI"].ToString().Trim() + ". " + ViewState["LASTNAME"].ToString().Trim();
        }
        else
        {
            strComplete = ViewState["FIRSTNAME"].ToString().Trim() + " " + ViewState["MI"].ToString().Trim() + ". " + ViewState["LASTNAME"].ToString().Trim() + ", " + ViewState["SUFFIX"].ToString().Trim();
        }


        return strComplete;
    }

  

    protected void ddAppType_SelectedIndexChanged(object sender, EventArgs e)
    {

    
 
    }

    protected void computePreviousGrade_Click(object sender, EventArgs e)
    {
        applicantAverage();
    }


   
  


    
     protected void imgNew_Click(object sender, ImageClickEventArgs e)
     {
         //SET Save process
         ViewState["CURRENTACTION"] = 1;

         //Initial Value of Baranggay.
         displayBarangay(ddCity.SelectedValue.ToString());
         
         panControls.Visible = false;
         panControl1.Visible = false;

         panControl2.Visible = true;
         panNew.Visible = true;
         clearData();

         chkActive.Checked = true;
     }

     protected void imgReturn_Click(object sender, ImageClickEventArgs e)
     {

         panControls.Visible = true;
         panControl1.Visible = true;

         panNew.Visible = false;
         panControl2.Visible = false;

         txtSearch.Text = "";
         clearData();
     }

     protected void gvApplicant_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gvApplicant.PageIndex = e.NewPageIndex;
         displayListOfApplicant();
     }



   

     protected void imgSave_Click(object sender, ImageClickEventArgs e)
     {
         saveData();
     }


     private void clearData()
     { 
     
         //all viewstate

         //------ PREVIOUS GRADE SECTION -----

         ViewState["FINALAVERAGE"] = "0.00";
     
         ViewState["ENGTOTAL"] = "0.00";
         ViewState["SCITOTAL"] = "0.00";
         ViewState["MATHTOTAL"] = "0.00";

         ViewState["FIRSTTOTAL"] = "0.00";
         ViewState["SECONDTOTAL"] ="0.00";
         ViewState["THIRDTOTAL"] = "0.00";
         ViewState["FOURTHTOTAL"] ="0.00";

         ViewState["ENG1"] = "0.00";
         ViewState["ENG2"] = "0.00";
         ViewState["ENG3"] = "0.00";
         ViewState["ENG4"] = "0.00";

         ViewState["SCI1"] = "0.00";
         ViewState["SCI2"] = "0.00";
         ViewState["SCI3"] = "0.00";
         ViewState["SCI4"] = "0.00";

         ViewState["MATH1"] = "0.00";
         ViewState["MATH2"] = "0.00";
         ViewState["MATH3"] = "0.00";
         ViewState["MATH4"] = "0.00";

         ViewState["LOWERENG"] = null;
         ViewState["LOWERSCI"] = null;
         ViewState["LOWERMATH"] = null;

         engTotal.Text = "";
         sciTotal.Text = "";
         matTotal.Text = "";

         lblGP1.Text = "";
         lblGP2.Text = "";
         lblGP3.Text = "";
         lblGP4.Text = "";


         eng1.GRADEINPUT = 0.0;
         eng2.GRADEINPUT = 0.0;
         eng3.GRADEINPUT = 0.0;
         eng4.GRADEINPUT = 0.0;

         sci1.GRADEINPUT = 0.0;
         sci2.GRADEINPUT = 0.0;
         sci3.GRADEINPUT = 0.0;
         sci4.GRADEINPUT = 0.0;

         mat1.GRADEINPUT = 0.0;
         mat2.GRADEINPUT = 0.0;
         mat3.GRADEINPUT = 0.0;
         mat4.GRADEINPUT = 0.0;

         lblAverage.Text = "";
         lblAverage2.Text = "";

         //Age for Admission
         //ucAgeAdmission.GRADEINPUT = 0.0;

         //SET ALL CHECKBOX TO FALSE
         chk137.Checked = false;
         chk1x1Picture.Checked = false;
         chkBC.Checked = false;
         chkEnvelope.Checked = false;
         chkF138.Checked = false;
         chkGoodMoral.Checked = false;
         chkNCAE.Checked = false;
         chkRecommendation.Checked = false;
         chkShort.Checked = false;
         chkSSIChild.Checked = false;
         chkWaitListed.Checked = false;
         chkActive.Checked = false;
         chkAppBackOut.Checked = false;

         //VIEW STATE 
         ViewState["SHORTMONTHVALUE"] = 0;
         ViewState["STRANDTYPE"] = "";
         ViewState["AGE"] = 0.0;

         ViewState["LASTNAME"] = "";
         ViewState["FIRSTNAME"] = "";
         ViewState["MIDDLENAME"] = "";
         ViewState["SUFFIX"] = "";
         ViewState["MI"] = "";

         ucTxtFirstName.TEXTVALUE = "";
         ucTxtLastName.TEXTVALUE = "";
         ucTxtMiddleName.TEXTVALUE = "";
         ucContactPerson.TEXTVALUE = "";
         txtMI.Text = "";
         txtSuffix.Text = "";
         txtEmailAdd.Text = "";
         txtRemarks.Text = "";
         txtAddNoStreet.Text = "";

         ucDateApplication.CalendarValue = DateTime.Now;
         txtBirthDate.Text = "";
         txtPlaceOfBirth.Text = "";

         ucTelNo.TELVALUE = "";
         ucMobile.MOBILEVALUE = "";
         

     }

     private void saveData()
     {
         //Call method
        
         completeName();
         computeApplicantAge();
         applicantAverage();

         //Default value of months in nursery to Grade 1
         if (string.IsNullOrEmpty(txtShortMonth.Text))
         {
             ViewState["SHORTMONTHVALUE"] = 0;
         }
         else
         {
             ViewState["SHORTMONTHVALUE"] = int.Parse(txtShortMonth.Text);
         }

         if (ddAppLevel.SelectedValue.ToString() == "G11" || ddAppLevel.SelectedValue.ToString() == "G12")
         {
             ViewState["STRANDTYPE"] = ddStrandType.SelectedValue.ToString();
         }

         else
         {
             
             ViewState["STRANDTYPE"] = "";
         }



         //Check second validation information
         if (string.IsNullOrEmpty(ucTelNo.TELVALUE) && string.IsNullOrEmpty(ucMobile.MOBILEVALUE) || string.IsNullOrEmpty(ucContactPerson.TEXTVALUE))
         {
           
             MessageDialog("Please fill up either Contact Person and tel # or mobile # or Address.", 3);
         }

         //Age condition 
         //else if (Convert.ToDouble(ViewState["AGEBYJUNE"]) <= 2.10)
         //{
         //    MessageDialog("Age must be greater that 2 years and 10 months old.", 3);
         //}


         //Optional in Credentials Condition
         else if (chkBC.Checked == false)
         {
             if (ddAppType.SelectedValue.ToString() == "NA")
             {
                 MessageDialog("Birth Certificate Required for New Applicant", 3);
             }

             else
             {
                 MessageDialog("Birth Certificate and Form 138 required for Transferree/Returnee Applicant", 3);
             }
         }
   



         //GO AND SAVE THE DETAILS
         else
         {


            //VERIFY ACTION 
             if ((int)ViewState["CURRENTACTION"] == 1)
            {
                //Get the resutl from function
                bool existApplicant = checkExistApplicant(ViewState["LASTNAME"].ToString(), ViewState["FIRSTNAME"].ToString(), ViewState["MIDDLENAME"].ToString());
                                
                if (existApplicant)
                {
                 MessageDialog("Record already Exist.", 3);
                }

                else
                {

                //Delaying generation of number a split of seconds
                //11-23-2015
                //Russel Vasquez
                Random rndNum = new Random();
                int genRand = rndNum.Next(1, 1000);
                System.Threading.Thread.Sleep(genRand);
                
                //Assigning Generated Applicant Number
                ViewState["APPLICANTNUMBER"] = generateApplicantNumber().ToString();

                 //INSERT INTO ADMISSION.APP_INFO_MF
                 //Commented today 12/15/2015
                
                 //For No Previous Grade
                if (string.IsNullOrEmpty(lblAverage2.Text))
                {
                    lblAverage2.Text = "0";
                }
                
                 objApp.newApplicant(Session["S_SY"].ToString(), ddAppType.SelectedValue.ToString(), ddAppLevel.SelectedValue.ToString(), ViewState["STRANDTYPE"].ToString(), ucDateApplication.textBoxValue(), ViewState["APPLICANTNUMBER"].ToString(), chkWaitListed.Checked, chkSSIChild.Checked,
                 ViewState["LASTNAME"].ToString().Trim(), ViewState["FIRSTNAME"].ToString().Trim(), ViewState["MIDDLENAME"].ToString().Trim(), ViewState["MI"].ToString().Trim(), txtSuffix.Text, completeName().ToString(), ddGender.SelectedValue.ToString(), DateTime.Parse(txtBirthDate.Text), txtPlaceOfBirth.Text, Convert.ToDouble(ViewState["AGE"]),ViewState["AGEBYJUNE"].ToString(), chkShort.Checked, (int)ViewState["SHORTMONTHVALUE"],
                 ucTelNo.TELVALUE, ucMobile.MOBILEVALUE, ucContactPerson.TEXTVALUE, txtAddNoStreet.Text, ddArea.SelectedValue.ToString(), ddCity.SelectedValue.ToString(), txtEmailAdd.Text, txtRemarks.Text, chkActive.Checked, chkAppBackOut.Checked, DateTime.Now, DateTime.Now, Session["U_USERID"].ToString(),
                 ViewState["APPLICANTNUMBER"].ToString(), chkF138.Checked, chkBC.Checked, chk1x1Picture.Checked, chkEnvelope.Checked, chkGoodMoral.Checked, chkRecommendation.Checked, chk137.Checked, chkNCAE.Checked, txtOthers.Text,
                  Convert.ToDouble(ViewState["ENGTOTAL"]),
                  Convert.ToDouble(ViewState["SCITOTAL"]), Convert.ToDouble(ViewState["MATHTOTAL"]), Convert.ToDouble(ViewState["FIRSTTOTAL"]),
                  Convert.ToDouble(ViewState["SECONDTOTAL"]), Convert.ToDouble(ViewState["THIRDTOTAL"]), Convert.ToDouble(ViewState["FOURTHTOTAL"]),
                  Convert.ToDouble(ViewState["ENG1"]), Convert.ToDouble(ViewState["ENG2"]), Convert.ToDouble(ViewState["ENG3"]), Convert.ToDouble(ViewState["ENG4"]),
                  Convert.ToDouble(ViewState["SCI1"]), Convert.ToDouble(ViewState["SCI2"]), Convert.ToDouble(ViewState["SCI3"]), Convert.ToDouble(ViewState["SCI4"]),
                  Convert.ToDouble(ViewState["MATH1"]), Convert.ToDouble(ViewState["MATH2"]), Convert.ToDouble(ViewState["MATH3"]), Convert.ToDouble(ViewState["MATH4"]),
                  Convert.ToBoolean(ViewState["LOWERENG"]), Convert.ToBoolean(ViewState["LOWERSCI"]), Convert.ToBoolean(ViewState["LOWERMATH"]), Convert.ToDouble(ViewState["FINALAVERAGE"]), Convert.ToDouble(lblAverage2.Text));
                   

                 if (objApp.retAppInfo > 0 && objApp.retAppPrevGrade > 0)
                 {


                 /*Insert Record to ISAMS - 10/21/2015
                    
                  * */
                //Date string
                 string appLevelCode = "";
                 string appLevelType = "";
                
                 switch (ddAppLevel.SelectedValue)
                 { 
                     case "P1":
                         appLevelCode = "1";
                         appLevelType = "P";
                         break;

                     case "P2":
                         appLevelCode = "2";
                         appLevelType = "P";
                         break;

                     case "P3":
                         appLevelCode = "3";
                         appLevelType = "P";
                         break;

                     case "G1":
                         appLevelCode = "1";
                         appLevelType = "G";
                         break;

                     case "G2":
                         appLevelCode = "2";
                         appLevelType = "G";
                         break;

                     case "G3":
                         appLevelCode = "3";
                         appLevelType = "G";
                         break;

                     case "G4":
                         appLevelCode = "4";
                         appLevelType = "G";
                         break;

                     case "G5":
                         appLevelCode = "5";
                         appLevelType = "G";
                         break;

                     case "G6":
                         appLevelCode = "6";
                         appLevelType = "G";
                         break;

                     case "G7":
                         appLevelCode = "I";
                         appLevelType = "H";
                         break;

                     case "G8":
                         appLevelCode = "II";
                         appLevelType = "H";
                         break;

                     case "G9":
                         appLevelCode = "III";
                         appLevelType = "H";
                         break;

                     case "G10":
                         appLevelCode = "IV";
                         appLevelType = "H";
                         break;

                     case "G11":
                         appLevelCode = "11";
                         appLevelType = "R";
                         break;


                     case "G12":
                         appLevelCode = "12";
                         appLevelType = "R";
                         break;



                 }
                 
                 string sex = "";
                 if (ddGender.SelectedValue.ToString() == "B")
                 {
                     sex = "M";
                 }
                 else
                 {
                     sex = "F";
                    
                 }

                 string dateApplied = ucDateApplication.textBoxValue().ToShortDateString();
                
                 //ISAMS Issue 50 characters only allowed 11/10/2015
                 //string concatAdd1 = txtAddNoStreet.Text;
                 //string addrisams = concatAdd1.Substring(0, 50);

                //Temporary commented 01/26/2016
                 
                 double _isamsprevgrade = 0;
                 if (Convert.ToDouble(ViewState["FINALAVERAGE"]) == 0 || string.IsNullOrEmpty(lblAverage.Text))
                 {
                     _isamsprevgrade = Convert.ToDouble(lblAverage2.Text);
                 }
                 else
                 {
                     _isamsprevgrade = Convert.ToDouble(ViewState["FINALAVERAGE"]);
                 }


                 objApp.newApplicantISAMs(objAuto.ISAMSAPPNUMBER, dateApplied, ddAppType.SelectedValue, ViewState["LASTNAME"].ToString().Trim(), ViewState["FIRSTNAME"].ToString().Trim(), ViewState["MIDDLENAME"].ToString().Trim(), appLevelCode, appLevelType, Session["STARTYEAR"].ToString(),
                                     txtAddNoStreet.Text, ddArea.SelectedItem.Text, ddCity.SelectedItem.Text, txtBirthDate.Text, "FIL", "S", sex, _isamsprevgrade, DateTime.Now.ToString(), Session["U_USERID"].ToString());
                

                 //INSERT INTO PREVIOUS GRADE
                /* if (ddAppType.SelectedValue.ToString() != "NA")
                 {
                    //as of 9-28-2015 regardless of NEW OR TRANS Applicant
                 objApp.PreviousGrade(ViewState["APPLICANTNUMBER"].ToString(), Convert.ToDouble(ViewState["ENGTOTAL"]),
                 Convert.ToDouble(ViewState["SCITOTAL"]), Convert.ToDouble(ViewState["MATHTOTAL"]), Convert.ToDouble(ViewState["FIRSTTOTAL"]),
                 Convert.ToDouble(ViewState["SECONDTOTAL"]), Convert.ToDouble(ViewState["THIRDTOTAL"]), Convert.ToDouble(ViewState["FOURTHTOTAL"]),
                 Convert.ToDouble(ViewState["ENG1"]), Convert.ToDouble(ViewState["ENG2"]), Convert.ToDouble(ViewState["ENG3"]), Convert.ToDouble(ViewState["ENG4"]),
                 Convert.ToDouble(ViewState["SCI1"]), Convert.ToDouble(ViewState["SCI2"]), Convert.ToDouble(ViewState["SCI3"]), Convert.ToDouble(ViewState["SCI4"]),
                 Convert.ToDouble(ViewState["MATH1"]), Convert.ToDouble(ViewState["MATH2"]), Convert.ToDouble(ViewState["MATH3"]), Convert.ToDouble(ViewState["MATH4"]),
                 Convert.ToBoolean(ViewState["LOWERENG"]), Convert.ToBoolean(ViewState["LOWERSCI"]), Convert.ToBoolean(ViewState["LOWERMATH"]), Convert.ToDouble(ViewState["FINALAVERAGE"]), DateTime.Now,
                 DateTime.Now, Session["U_USERID"].ToString());
                 }
                     */

                 //Will update Series of AutoNumber
                 objAuto.updateAppNumber(Session["X_APP_PREFIX"].ToString());
                     


                 messageLocal.Text = "";

                 MessageDialog("APPLICANT #:" + ViewState["APPLICANTNUMBER"].ToString() + "<br/>" + "Name: " + completeName().ToString() + "<br/>" +
                                 "Successfully Saved!", 1);
                 clearData();

                 displayListOfApplicant();

                 }

                } 
                
       

             }
            
             //Action of Edit

             else if ((int)ViewState["CURRENTACTION"] == 2)
             {
                 objApp.updateApplicant(ddAppType.SelectedValue.ToString(), ddAppLevel.SelectedValue.ToString(), ViewState["STRANDTYPE"].ToString(), ucDateApplication.textBoxValue(), ViewState["APPLICANTNUMBER"].ToString(), chkWaitListed.Checked, chkSSIChild.Checked,
                               ViewState["LASTNAME"].ToString().Trim(), ViewState["FIRSTNAME"].ToString().Trim(), ViewState["MIDDLENAME"].ToString().Trim(), ViewState["MI"].ToString().Trim(), txtSuffix.Text, completeName().ToString(), ddGender.SelectedValue.ToString(), DateTime.Parse(txtBirthDate.Text), txtPlaceOfBirth.Text, Convert.ToDouble(ViewState["AGE"]), ViewState["AGEBYJUNE"].ToString(),chkShort.Checked, (int)ViewState["SHORTMONTHVALUE"],
                               ucTelNo.TELVALUE, ucMobile.MOBILEVALUE, ucContactPerson.TEXTVALUE, txtAddNoStreet.Text, ddArea.SelectedValue.ToString(), ddCity.SelectedValue.ToString(), txtEmailAdd.Text, txtRemarks.Text, chkActive.Checked, chkAppBackOut.Checked, DateTime.Now, DateTime.Now, Session["U_USERID"].ToString(),
                               chkF138.Checked, chkBC.Checked, chk1x1Picture.Checked, chkEnvelope.Checked, chkGoodMoral.Checked, chkRecommendation.Checked, chk137.Checked, chkNCAE.Checked, txtOthers.Text);

                 //UPDATEPREVIOUS GRADE
                 //if (ddAppType.SelectedValue.ToString() != "NA")
                 //{
                 //as of 9-28-2015 regardless of NEW OR TRANS Applicant
                 double ave2 = 0;
                 if (string.IsNullOrEmpty(lblAverage2.Text))
                 {
                     ave2 = 0;
                 }
                 else
                 { 
                 ave2 = Convert.ToDouble(lblAverage2.Text);
                 }
                     objApp.updatePreviousGrade(ViewState["APPLICANTNUMBER"].ToString(), Convert.ToDouble(ViewState["ENGTOTAL"]),
                     Convert.ToDouble(ViewState["SCITOTAL"]), Convert.ToDouble(ViewState["MATHTOTAL"]), Convert.ToDouble(ViewState["FIRSTTOTAL"]),
                     Convert.ToDouble(ViewState["SECONDTOTAL"]), Convert.ToDouble(ViewState["THIRDTOTAL"]), Convert.ToDouble(ViewState["FOURTHTOTAL"]),
                     Convert.ToDouble(ViewState["ENG1"]), Convert.ToDouble(ViewState["ENG2"]), Convert.ToDouble(ViewState["ENG3"]), Convert.ToDouble(ViewState["ENG4"]),
                     Convert.ToDouble(ViewState["SCI1"]), Convert.ToDouble(ViewState["SCI2"]), Convert.ToDouble(ViewState["SCI3"]), Convert.ToDouble(ViewState["SCI4"]),
                     Convert.ToDouble(ViewState["MATH1"]), Convert.ToDouble(ViewState["MATH2"]), Convert.ToDouble(ViewState["MATH3"]), Convert.ToDouble(ViewState["MATH4"]),
                     Convert.ToBoolean(ViewState["LOWERENG"]), Convert.ToBoolean(ViewState["LOWERSCI"]), Convert.ToBoolean(ViewState["LOWERMATH"]), Convert.ToDouble(ViewState["FINALAVERAGE"]), ave2,
                     DateTime.Now, Session["U_USERID"].ToString());
                 //}

                          
                 
                 MessageDialog("APPLICANT #:" + ViewState["APPLICANTNUMBER"].ToString() + "<br/>" + "Name: " + completeName().ToString() + "<br/>" +
                                 "Successfully Updated!", 2);
                 
               

                 clearData();
                 displayListOfApplicant();

                 //return to main appliant UI
                 //panControls.Visible = true;
                 //panNew.Visible = false;
                 panControls.Visible = true;
                 panControl1.Visible = true;
                 panNew.Visible = false;
                 panControl2.Visible = false;
             }

             else //
             {
                 MessageDialog("No Action was selected.", 2);
             }
             //return to main appliant UI
             //panControls.Visible = true;
             //panNew.Visible = false;
      

         }//End of IF ELSE Main
     }

 

     protected void imgEdit_Click(object sender, ImageClickEventArgs e)
     {
        
         //THIS WILL GET THE CELL VALUE OF SELECTED ROW IN GRIDVIEW VIA COMMAND WITHIN TEMPLATE FIELDS.
         var selEdit = (Control)sender;
         GridViewRow r = (GridViewRow)selEdit.NamingContainer;
         string selAppNum = r.Cells[2].Text;

         displaySearchApplicant(selAppNum);
         
         //SET Update process
         ViewState["CURRENTACTION"] = 2;

         //Set Applicant Number
         ViewState["APPLICANTNUMBER"] = selAppNum;

         panControls.Visible = false;
         panControl1.Visible = false;

         panNew.Visible = true;
         panControl2.Visible = true;
        
         
         
     }
     protected void imgSearch_Click(object sender, ImageClickEventArgs e)
     {
         displaySearchViaName(txtSearch.Text);
     }


   


     protected void ddCity_SelectedIndexChanged(object sender, EventArgs e)
     {  
         displayBarangay(ddCity.SelectedValue.ToString());
     }

     protected void imgPrint_Click(object sender, ImageClickEventArgs e)
     {
         var selEdit = (Control)sender;
         GridViewRow r = (GridViewRow)selEdit.NamingContainer;
         string selAppNum = r.Cells[2].Text;


        Session["A_APPLICANTNO"] = selAppNum;
         
         //Parameter for Report Selection on Evaluation Sheet
         //09-30-2015
        Session["A_STRAND?"] = checkApplicantStrand(selAppNum);

        //displayReport(ViewState["RP_APPNUM"].ToString());
        PRINT_NOW("rep_app_aes.aspx");
     

     }

     private bool checkApplicantStrand(string INPUT)
     {
         bool x = false;

        dtApplicant = new DataTable();
        dtApplicant = objApp.getDetailsApplicant();

        DataRow[] dr;
        dr = dtApplicant.Select("AppNum = '" + INPUT + "'");

        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                if (string.IsNullOrEmpty(row["StrandCode"].ToString()))
                {
                    x = false;
                }
                else
                {
                    x = true;
                }

            }
        }

         return x;
     }



     protected void gvApplicant_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {

             Image imgIcon = (Image)e.Row.Cells[1].FindControl("imgIcon");

             //Check if applicant have record
             if (e.Row.Cells[0].Text == "B")
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

     protected void ddArea_SelectedIndexChanged(object sender, EventArgs e)
     {

     }

     private void PRINT_NOW(string url)
     {
         string s = "window.open('" + url + "', 'popup_window', 'width=850, height=600, left=0, top=0, resizable=yes');";
         ScriptManager.RegisterClientScriptBlock(this, this.Page.GetType(), "ReportScript", s, true);
     }


     //Calling message function
     private void MessageDialog(string str, int iconType)
     {
         string scriptSTR = "message('" + str + "', '" + iconType + "');";
         ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
     }

     protected void gvDeliquent_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gvDeliquent.PageIndex = e.NewPageIndex;
         displayDeliquentList();
     }
}