using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMSBDAL;


public partial class admTestingDataEntry : System.Web.UI.Page
{
    ApplicantTesting oTesting = new ApplicantTesting();
    ApplicantSchedule oAppScheduled = new ApplicantSchedule();
    Utilities oUtilities = new Utilities();
    AutoNumber oAutoNumber = new AutoNumber();
    Student oStudent = new Student();
    xSystem oSystem = new xSystem();

    Applicant oApplicant = new Applicant();


    //hold the status of applicant if RETEST
    private bool _bRetest { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {

        //testB.Attributes.Add("onblur", "comPercentage(master_ContentPlaceHolder1_testB,master_ContentPlaceHolder1_txtSearch)");
        //testB.Attributes.Add("onblur", "testGridView()");
        if (!IsPostBack)
        {
            //DISPLAY LIST OF RECOMMENDATION SELECTION
            //11/26/2015
            displayRecommendationSelection();

            panelContent.Visible = false;

            //Set txtSearch the focus
            //12-02-2015
            ScriptManager.RegisterStartupScript(this, this.GetType(), "focus", "document.getElementById('" + this.txtSearch.ClientID + "').focus();", true);

            //Hold Status of applicant if Retest or Not 
            ViewState["RETESTSTATUS"] = false;
            ViewState["CANCELSAVE"] = false;
        }

        
       
    }



    private void displayTestingListToGV(string LEVELTYPE)
    {
        DataTable dt = new DataTable();
        dt = oTesting.displayTestingList(LEVELTYPE);
        gvTestingDE.DataSource = dt;
        gvTestingDE.DataBind();
    }

    private void displayApplicantDetails(string _fullname)
    {
       //clear fields
        clearItems();
        string _appnum = Request.Form[hfAppNum.UniqueID];

        if (oTesting.displayApplicantInfo(_appnum))
        {
            lblAppNum.Text = oTesting._APPNUM;
            lblFullName.Text = oTesting._SAP_FN_FORMAT; //'oTesting._FULLNAME;
            
            lblLevelTypeCode.Text = "Level Applying: " + oTesting._LEVELCATCODE + "-" + oTesting._LEVELTYPECODE;
            ViewState["LEVELTYPECODE"] = oTesting._LEVELTYPECODE;
            ViewState["LEVELCATCODE"] = oTesting._LEVELCATCODE;
            lblDOB.Text = "DOB: " + oTesting._DOB.ToShortDateString() + "||   AGE: " + oTesting._AGEBYJUNE;
            txtPrevGrade.Text = oTesting._PREVGRADE.ToString();
            lblExamInfo.Text = "EXAMINATION: " + oTesting._EXAMSCHED;
            
            if (oTesting._GENDERCODE == "B")
            {
                imgPictures.ImageUrl = "images/iconLabel/boy_E.png";
            }
            else
            {
                imgPictures.ImageUrl = "images/iconLabel/girl_E.png";
            }

            if (!string.IsNullOrEmpty(oTesting._INTSCHED))
            {
                lblIntInfo.Text = "INTERVIEW: " + oTesting._INTSCHED;
            }
            else
            {
                lblIntInfo.Text = "INTERVIEW: Not Applicable";
            }

            txtSearch.Text = "";

            panelContent.Visible = true;
            
            //GET the value of RETEST STATUS 
            ViewState["RETESTSTATUS"] = oTesting._RETESTSTATUS;

            //CHECK if APPLICANT ALREADY STUDENT. IF TRUE = DISABLE RECOMMENDATION SELECTION 
            if (oTesting.CHECKAPPEXISTSTUDENT(lblAppNum.Text))
            {
                ddRecommendation.Enabled = false;
            }
            else
            {
                ddRecommendation.Enabled = true;
            }

            //Display Entry on Gridview the Testing
            displayTestingListToGV(oTesting._LEVELTYPECODE);
            
            //Check if Applicant test record exist retrieve
            if (oTesting.ExistAppTest(lblAppNum.Text))
            {
               
                foreach (GridViewRow row in gvTestingDE.Rows)
                {

                    TextBox txtScores = (TextBox)row.Cells[2].FindControl("Scores");
                    string ttcode = row.Cells[4].Text;
                    Label lresult = (Label)row.Cells[3].FindControl("Result");
                  
                    if (oTesting.RetrieveTestingRecord(lblAppNum.Text, ttcode))
                    {
                        txtScores.Text = oTesting._SCORES;
                        lresult.Text = oTesting._RESULT;

                        //Commented to display the original admission previous grade 03/14/2016 
                        //txtPrevGrade.Text = oTesting._PREV;

                        //From original admission previous grade
                        txtPrevGrade.Text = oTesting._PREVGRADE.ToString();
                        lblPrev.Text = oTesting._PREVRESULT;
                        lblAssessment.Text = oTesting._ASSESSMENT;
                        lblOverall.Text = oTesting._OVERALL;
                        txtObservation.Text = oTesting._OBSERVATION;
                        ddRecommendation.SelectedValue = oTesting._STATCODE;

                    }

                }

            }

       

           
            

        }

        else
        {

            //Message system detect that applicant doesn't not encoded in scheduling
           MessageDialog("Applicant schedule not yet assign.", 3);
           clearItems();
        }
        
    }


    //Calling message function
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }

   

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        displayApplicantDetails(txtSearch.Text);

    }
    protected void tb_TextChanged(object sender, EventArgs e)
    {
        lblIntInfo.Text = "Testing";
    }
    protected void gvTestingDE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == DataControlRowState.Alternate))
        //    {
        //       // Label lExamDate = (Label)e.Row.Cells[2].FindControl("lblExamDate");
           

        //    TextBox txtScores = (TextBox)e.Row.Cells[2].FindControl("Scores");
        //    TextBox txtTry = (TextBox)e.Row.Cells[1].FindControl("Percentage");

        //    //txtScores.Text = "0";
        //    //txtTry.Text = "0";

        //    //        //txtScores.Text = e.Row.Cells[1].Text;

          
        //    //    //txtScores.Attributes.Add("onblur", "comPercentage(master_ContentPlaceHolder1_testB,master_ContentPlaceHolder1_gvTestingDE_txtTry)");
        //    //    txtTry.Attributes["onblur"] = "javascript: return testCom('" + int.Parse(txtScores.Text) + "', '" + int.Parse(txtTry.ClientID) + "')";
          
        //    }
        //}

    }

    protected void gvTestingDE_RowCreated(object sender, GridViewRowEventArgs e)
    {
       

    }

    protected void displayRecommendationSelection()
    {
        DataTable dt = oUtilities.getGeneralStatus("GUI");
        
        ddRecommendation.DataSource = dt;
        ddRecommendation.DataTextField = dt.Columns["STATDESC"].ToString();
        ddRecommendation.DataValueField = dt.Columns["STATCODE"].ToString();
        ddRecommendation.DataBind();

        ddRecommendation.Items.Insert(0, new ListItem("--Select Status"));
    }


   
        public void InsertExamResults()
        {


            double source = 0;
            double input = 0;
            double result = 0;

            foreach (GridViewRow r in gvTestingDE.Rows)
            {
                Label lsource = (Label)r.Cells[1].FindControl("lblPercentage");
                TextBox linput = (TextBox)r.Cells[2].FindControl("Scores");
                Label lresult = (Label)r.Cells[3].FindControl("Result");
                string ttcode = r.Cells[4].Text;

                if (!string.IsNullOrEmpty(lsource.Text))
                {
                    source = Convert.ToDouble(lsource.Text);
                }
                else
                {
                    source = 0;
                }


                if (!string.IsNullOrEmpty(linput.Text))
                {
                    input = Convert.ToDouble(linput.Text);
                }

                else
                {
                    input = 0;
                }
              
                
                
                result =  ((source * input) / 100);

                lresult.Text = result.ToString();



                if ((bool)ViewState["RETESTSTATUS"]) 
                {
                  oTesting.INSERTRESULT(lblAppNum.Text, ttcode, input, result,true, Session["U_USERID"].ToString());
                }
                else
                {
                   oTesting.INSERTRESULT(lblAppNum.Text, ttcode, input, result, false, Session["U_USERID"].ToString());
                }
            }

            
    }


        public void UpdateExamResults()
        {
            double source = 0;
            double input = 0;
            double result = 0;

            foreach (GridViewRow r in gvTestingDE.Rows)
            {
                Label lsource = (Label)r.Cells[1].FindControl("lblPercentage");
                TextBox linput = (TextBox)r.Cells[2].FindControl("Scores");
                Label lresult = (Label)r.Cells[3].FindControl("Result");
                string ttcode = r.Cells[4].Text;

                if (!string.IsNullOrEmpty(lsource.Text))
                {
                    source = Convert.ToDouble(lsource.Text);
                }
                else
                {
                    source = 0;
                }


                if (!string.IsNullOrEmpty(linput.Text))
                {
                    input = Convert.ToDouble(linput.Text);
                }

                else
                {
                    input = 0;
                }



                result = ((source * input) / 100);

                lresult.Text = result.ToString();

                oTesting.UPDATERESULT(lblAppNum.Text, ttcode, input, result, Session["U_USERID"].ToString());
            }

            
        }


        private void clearItems()
        {
            lblAppNum.Text = "";
            lblFullName.Text = "";
            lblIntInfo.Text = "";
            lblExamInfo.Text = "";
            lblDOB.Text = "";
            lblLevelTypeCode.Text = "";
            lblPrev.Text = "";
            lblAssessment.Text = "";
            lblOverall.Text = "";

            txtObservation.Text = "";
            txtPrevGrade.Text = "";

            imgPictures.ImageUrl = "";

            ddRecommendation.SelectedIndex = 0;


            panelContent.Visible = false;

            txtSearch.Text = "";
            ViewState["LEVELTYPECODE"] = "";
            ViewState["LEVELCATCODE"] = "";
        
        }


        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
         /*Calling a function that will recompute Percentage Result and save in the database
        * 11/26/2015
        * Russel Vasquez
         * */

            //Condition User should select recommendation
            if (ddRecommendation.SelectedIndex == 0)
            {
                MessageDialog("Please select recommendation.", 3);
                ViewState["CANCELSAVE"] = true;
            }

                //Second condition
            else if (string.IsNullOrEmpty(lblOverall.Text))
            {
                MessageDialog("Please insert exam value.", 3);
                ViewState["CANCELSAVE"] = true;
            }

            else
            {
 
                //IF Applicant already have record on testing table
                if (oTesting.ExistAppTest(lblAppNum.Text))
                {

                    if ((bool)ViewState["RETESTSTATUS"] == true) 
                     {
                     //If APPLICANT IS IN RETEST STATUS ON SCREENING
                     //CREATE ADDITIONAL RECORD FOR REFERENCE PURPOSES
                     //RUSSEL VASQUEZ 01/29/2016

                     oTesting.INSERTSUMMARYRESULT(lblAppNum.Text, Convert.ToDouble(txtPrevGrade.Text),
                     Convert.ToDouble(lblPrev.Text), Convert.ToDouble(lblAssessment.Text), Convert.ToDouble(lblOverall.Text),
                     txtObservation.Text, ddRecommendation.SelectedValue.ToString(), true, Session["U_USERID"].ToString());
                     
                      InsertExamResults();

                      }
                           
                     else
                     
                      {
                    //UPDATE
                    UpdateExamResults();

                    oTesting.UPDATESUMMARYRESULT(lblAppNum.Text, Convert.ToDouble(txtPrevGrade.Text),
                    Convert.ToDouble(lblPrev.Text), Convert.ToDouble(lblAssessment.Text), Convert.ToDouble(lblOverall.Text),
                    txtObservation.Text, ddRecommendation.SelectedValue.ToString(), Session["U_USERID"].ToString());
                     }
  
                  MessageDialog("Record Successfully updated.", 2);

                  
                }

                else
                {
                   
                    try
                    {

                        oTesting.INSERTSUMMARYRESULT(lblAppNum.Text, Convert.ToDouble(txtPrevGrade.Text),
                        Convert.ToDouble(lblPrev.Text), Convert.ToDouble(lblAssessment.Text), Convert.ToDouble(lblOverall.Text),
                        txtObservation.Text, ddRecommendation.SelectedValue.ToString(), false, Session["U_USERID"].ToString());


                        InsertExamResults();
                        ViewState["CANCELSAVE"] = false;
 
                        //MessageDialog("Data Entry Successfully saved. ", 1);

                    }
                    catch (Exception err)
                    {
                        MessageDialog("Error: " + err.ToString(), 3);
                    }
                
                }

            }
                

            //Other Intructions
            

                if (ddRecommendation.SelectedValue.ToString() != "NR" && ddRecommendation.SelectedIndex != 0) //NOT RECOMMENDED is false
                {
                    if (oTesting.CHECKAPPEXISTSTUDENT(lblAppNum.Text) == false)
                    {

                        //SAVE or UPDATE APPLICANT AND GENERATE STUDENT NO.

                        //try
                        //{
                        //    Insert into Student Information and update applicant status into student.
                            oStudent.MTAPPTOSTUDENT(lblAppNum.Text, oAutoNumber.studNumber(Session["X_STUDENT_PREFIX"].ToString()),ViewState["LEVELCATCODE"].ToString(), Session["U_USERID"].ToString());
                            MessageDialog(lblFullName.Text + " successfully passed the entrance Examination <br/> Generated Student #: " + oAutoNumber.studNumber(Session["X_STUDENT_PREFIX"].ToString()), 1);

                            string genStudNo = oAutoNumber.studNumber(Session["X_STUDENT_PREFIX"].ToString());

                            //INSERT NEW RECORD TO SAP
                            //WORKING - TEMPORARILY DISABLED

                        //GL Account
                            string BP_GLAcct = "";
                            if (ViewState["LEVELCATCODE"].ToString() == "PS")
                            {
                                BP_GLAcct = "114110";
                            }
                            else if (ViewState["LEVELCATCODE"].ToString() == "GS")
                            {
                                BP_GLAcct = "114120";
                            }
                            else if (ViewState["LEVELCATCODE"].ToString() == "JHS")
                            {
                                BP_GLAcct = "114130";
                            }
                            else if (ViewState["LEVELCATCODE"].ToString() == "SHS")
                            {
                                BP_GLAcct = "114140";
                            }

                            oSystem.INSERT_SAP_BP(genStudNo, lblFullName.Text, genStudNo, lblFullName.Text, ViewState["LEVELTYPECODE"].ToString(), "N", "", "", "A", "N", "Y", BP_GLAcct);
                                                                          

                            //Update Auto Number of Student Number
                            oAutoNumber.updateStudNumber(Session["X_STUDENT_PREFIX"].ToString());

                            //This function will disable status of applicant from scheduling 
                            oTesting.UPDATE_APPLICANT_SCHEDULE_STATUS(lblAppNum.Text);
                        //}
                        //catch(Exception err) {
                        //    MessageDialog("Error Occured: " + err.ToString(), 3);
                        //}

                    }


                }

                else {
         
                    MessageDialog(lblFullName.Text + " Entrace exam result saved.", 2);
                }

       
            clearItems();
            
        
        }

}