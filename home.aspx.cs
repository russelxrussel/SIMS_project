using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMSBDAL;
using System.Data;
using System.Web.UI.HtmlControls; //to call div tag in code behind


public partial class home : System.Web.UI.Page
{
    xSystem oSystem = new xSystem();
    Applicant oApplicant = new Applicant();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DEFAULT SCHOOL YEAR
          //  Session["S_SY"] = "2015-2016";
            displayTotalReservedCount();
            
            //For OLD Student
          //  displayReserveStudent();

            //For NEW Student
            displayReserveStudentNew();
            
            //TOTAL RESERVED 
            //04-19-2016
            displayReservedStudentTOTAL();
        }


        loadChart();

        //Will load controls in genControl Pane
        dynamicControl();

        if (Session["S_SY"] != null)
        {
            displayDynamicControlSlotInitial(Session["S_SY"].ToString());
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }


        //lnkWaitListed.Text = countWL().ToString();
        //lnkssiChild.Text = countSSIC().ToString();

        //lblTotalCountApplicant.Text = countTotalApplicant().ToString();
       
        displayApplicantCountDetails();

        dsh2.Visible = false; 
    }

    private void loadChart()
    {
        DataTable dt = oSystem.getTargetApplicant();
        DataView dv = dt.DefaultView;

      //  Chart1.Titles["Title1"].Text = "Target Students for SY:" + Session["S_SY"].ToString();

        Chart1.Series["Series1"].Points.DataBindXY(dv, "LevelTypeCode", dv, "StudentCount");
  
      
        //This will make interval per row into one the default is 5
        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
    }

   

    private void dynamicControl()
    {
        DataTable dt = oSystem.getCountApplicant();

        DataView dv = dt.DefaultView;
        dv.Sort = "Arr";
        DataTable dtSorted = dv.ToTable();

        foreach (DataRow dr in dtSorted.Rows)
        {
            Panel pnlCon = new Panel();
            HtmlGenericControl myDiv = new HtmlGenericControl();

            Label lbl = new Label();
            LinkButton lbtn = new LinkButton();
           
            lbl.Text = dr["LevelTypeCode"].ToString();
            lbtn.Text = dr["ApplicantCount"].ToString();
            
            //Use this for session to get the leveltypeCode
            lbtn.ID = dr["levelTypeCode"].ToString();

            if (dr["LevelCatCode"].ToString() == "JHS")
            {
                myDiv.Attributes.Add("class", "divBackDynamicE");
            }

            else if (dr["LevelCatCode"].ToString() == "SHS")
            {
                myDiv.Attributes.Add("class", "divBackDynamicS");
            }
            else if (dr["LevelCatCode"].ToString() == "GS")
            {
                myDiv.Attributes.Add("class", "divBackDynamicG");
            }

            else
            {
                myDiv.Attributes.Add("class", "divBackDynamicN");
            }

            lbl.Attributes.Add("class", "lblDynamicTitle");
            myDiv.Controls.Add(lbl);
            lbtn.Attributes.Add("class", "lblDynamicLinkValue");
            myDiv.Controls.Add(lbtn);
            
            lbtn.Click += new EventHandler(dynamicButtonClick);

            genControl.Controls.Add(myDiv);


           

        }

    }

 

    private void displayDynamicControlSlotInitial(string SY)
    {  
        //DataTable dt = oSystem.getTargetApplicant();
        //DataView dv = dt.DefaultView;

        //dv.RowFilter = "SY='" + Session["S_SY"] + "'";

        //foreach (DataRowView drv in dv)
        //{
        //    Label lbl = new Label();
        //    lbl.Text = drv["LevelTypeCode"].ToString() + " = " + drv["TargetApplicants"].ToString() + "<br/>";

        //    pIniSlot.Controls.Add(lbl);
        //}

        DataTable dt = oSystem.getSlotDetails(SY);
        DataView dv = new DataView(dt, "", "Arr Asc", DataViewRowState.CurrentRows);
       // DataView dv = dt.DefaultView;



        gvSlotDetails.DataSource = dv;
        gvSlotDetails.DataBind();
        

    
    }

    private void displayReserveStudent()
    {
        DataTable dt = oApplicant.getStudentReserveList();
        
        gvListOfReserve.DataSource = dt;
        gvListOfReserve.DataBind();
    }

    private void displayReserveStudentNew()
    {
        DataTable dt = oApplicant.getStudentReserveNewList();

        gvListOfReserveNew.DataSource = dt;
        gvListOfReserveNew.DataBind();
    }

    private void displayReservedStudentTOTAL()
    {
        DataTable dt = oApplicant.getStudentTOTALReservedList();

        gvListTotalReserve.DataSource = dt;
        gvListTotalReserve.DataBind();
    }

    private void displayTotalReservedCount()
    {
        lnkTotalReservedCount.Text = oApplicant.getStudentTotalReservedCount().ToString();
    }

    private int countWL()
    {
        DataTable dt = oApplicant.getApplicant();
        DataRow[] dr = dt.Select("WLStatus = '" + true + "'");
        int count = dr.Length;

        return count;
    }

    private int countSSIC()
    {
        DataTable dt = oApplicant.getApplicant();
        DataRow[] dr = dt.Select("SSIChild = '" + true + "'");
        int count = dr.Length;

        return count;
    }

    //private int countTotalApplicant()
    //{
    //    DataTable dt = oApplicant.getDetailsApplicant();
    //   // DataRow[] dr = dt.Select("Status = '" + true + "'");
    //    int count = dt.Rows.Count;

    //    return count;
    //}


    private void displayApplicantCountDetails()
    {
        DataSet ds = oApplicant.getApplicantCountDetails();
        DataTable dtTotalCount = ds.Tables[0];
        DataTable dtMale = ds.Tables[1];
        DataTable dtFemale = ds.Tables[2];

        DataRow drCountApp = dtTotalCount.Rows[0];
        lnkTotalCountApplicant.Text = drCountApp["TotalApplicant"].ToString();

        DataRow drCountMale = dtMale.Rows[0];
        lnkAppMaleCount.Text = drCountMale["Male"].ToString();

        DataRow drCountFemale = dtFemale.Rows[0];
        lnkAppFemaleCount.Text = drCountFemale["Female"].ToString();
    }


    //private int countTotalMaleApplicant()
    //{
    //    DataTable dt = oApplicant.getDetailsApplicant();
    //    DataRow[] dr = dt.Select("GenderCode = '" +  + "'");
    //    int count = dt.Rows.Count;

    //    return count;
    //}


     protected void dynamicButtonClick(object sender, EventArgs e)
     {

         var sel = (LinkButton)sender;
         Session["A_APPLICANTTYPECODE"] = sel.ID;
        
         Session["A_STATTYPE"] = "LEVELTYPECODESELECTION";
 //        Response.Write(sel.Text);
         DisplayWindow("appList.aspx");
     }

     private void DisplayWindow(string url)
     {
         string s = "window.open('" + url + "', '_blank', 'width=850, height=600, left=0, top=0,resizable=no');";
         ScriptManager.RegisterClientScriptBlock(this, this.Page.GetType(), "ReportScript", s, true);
     }

     protected void lnkWaitListed_Click(object sender, EventArgs e)
     {
         Session["A_STATTYPE"] = "WAITLISTEDSELECTION";
         DisplayWindow("appList.aspx");
     }


     protected void lnkssiChild_Click(object sender, EventArgs e)
     {
         Session["A_STATTYPE"] = "SSICHILDSELECTION";
         DisplayWindow("appList.aspx");
     }

     protected void lnkTotalCountApplicant_Click(object sender, EventArgs e)
     {
         //Default All
         Session["A_STATTYPE"] = "ALL";
         DisplayWindow("appList.aspx");

     }
     protected void lnkAppMaleCount_Click(object sender, EventArgs e)
     {
         Session["A_STATTYPE"] = "BOYS";
         DisplayWindow("appList.aspx");
     }
     protected void lnkAppFemaleCount_Click(object sender, EventArgs e)
     {
         Session["A_STATTYPE"] = "GIRLS";
         DisplayWindow("appList.aspx");
     }
}