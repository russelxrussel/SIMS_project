using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

using SIMSBDAL;

public partial class SIMSMaster : System.Web.UI.MasterPage
{

    //SESSION WARNING VARIABLES
    //Public values here can be late-bound to javascript in the ASPX page.
    public int iWarningTimeoutInMilliseconds;
    public int iSessionTimeoutInMilliseconds;
    public string sTargetURLForSessionTimeout;

    userMenu objMenu = new userMenu();



    //This will make master page be name rather than ctl00
    protected void Page_Init(object sender, EventArgs e)
    {
        ID = "master";
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //SESSION WARNING
        //In a real app, stuff these values into web.config.
        sTargetURLForSessionTimeout = "login.aspx?Reason=Timeout";
        int iNumberOfMinutesBeforeSessionTimeoutToWarnUser = 1;

        //Get the sessionState timeout (from web.config).
        //If not set there, the default is 20 minutes.
        int iSessionTimeoutInMinutes = Session.Timeout;

        //Compute our timeout values, one for
        //our warning, one for session termination.
        int iWarningTimeoutInMinutes = iSessionTimeoutInMinutes -
            iNumberOfMinutesBeforeSessionTimeoutToWarnUser;

        iWarningTimeoutInMilliseconds = iWarningTimeoutInMinutes * 60 * 1000;

        iSessionTimeoutInMilliseconds = iSessionTimeoutInMinutes * 60 * 1000;

        //string cname = ConfigurationManager.AppSettings["CSSIMS"].ToString();
        //Response.Write(cname);
        


        if (!IsPostBack)
        {
            //SESSION WARNING
            //Don't show the warning message div tag until later.
            //Setting the property here so we can see the div at design-time.
            divSessionTimeoutWarning.Style.Add("display", "none;");

            //displayMenu2();
            showMenus();
            //display user info


            if (Session["U_USERID"] != null)
            {

             //   lblUserId.Text = Session["U_USERID"].ToString();
                lblUserName.Text = Session["U_USERNAME"].ToString();
                lblDate.Text = Session["S_SERVERDATE"].ToString();
             //   lblSY.Text = Session["S_SY"].ToString();

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

        }

  
   
    }

    protected void btnContinueWorking_Click(object sender, EventArgs e)
    {
        //Do nothing. But the Session will be refreshed as a result of 
        //this method being called, which is its entire purpose.
    }

    private void displayMenu()
    {
        DataSet ds = new DataSet();
       // ds = objMenu.displayUserMenu();

        ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["ParentID"]);

        foreach (DataRow levelRowTop in ds.Tables[0].Rows)
        {
            MenuItem TopMenuItem = new MenuItem();
            TopMenuItem.Text = "    " + levelRowTop["MenuText"].ToString();
            TopMenuItem.NavigateUrl = levelRowTop["URL"].ToString();
            TopMenuItem.ImageUrl = "~/images/nav/main.png";

            DataRow[] levelRowChilds = levelRowTop.GetChildRows("ChildRows");
            foreach (DataRow levelRowChild in levelRowChilds)
            {
                MenuItem ChildMenuItem = new MenuItem();
                ChildMenuItem.Text = "   " + levelRowChild["MenuText"].ToString();
                ChildMenuItem.NavigateUrl = levelRowChild["URL"].ToString();
                ChildMenuItem.ImageUrl = "~/images/nav/submain.png";

                TopMenuItem.ChildItems.Add(ChildMenuItem);
            }

            userMenu.Items.Add(TopMenuItem);
        }

    }

    private void displayMenu2()
    {
        DataSet ds = new DataSet();
        ds = objMenu.displayUserMenu(Session["U_USERID"].ToString());

        //First Relationship ChildMenu to ParentMenu 
        ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ParentID"], ds.Tables[1].Columns["ParentID"]);
        
        //SecondRelationship LeafMenu to ChildMenu
        ds.Relations.Add("ChildLeaf", ds.Tables[1].Columns["ChildID"], ds.Tables[2].Columns["ChildID"]);
       
        foreach (DataRow levelRowTop in ds.Tables[0].Rows)
        {
            MenuItem TopMenuItem = new MenuItem();
            TopMenuItem.Text = "    " + levelRowTop["MenuText"].ToString();
            TopMenuItem.NavigateUrl = levelRowTop["URL"].ToString();
            TopMenuItem.ImageUrl = "~/images/nav/earth.png";
            
            DataRow[] levelRowChilds = levelRowTop.GetChildRows("ChildRows");
            foreach (DataRow levelRowChild in levelRowChilds)
            {
                MenuItem ChildMenuItem = new MenuItem();
                ChildMenuItem.Text = "   " + levelRowChild["MenuText"].ToString();
                ChildMenuItem.NavigateUrl = levelRowChild["URL"].ToString();
                ChildMenuItem.ImageUrl = "~/images/nav/submain.png";

                DataRow[] levelRowLeafs = levelRowChild.GetChildRows("ChildLeaf");
                foreach (DataRow levelRowLeaf in levelRowLeafs)
                {

                    MenuItem LeafMenuItem = new MenuItem();
                    LeafMenuItem.Text = " " + levelRowLeaf["MenuText"].ToString();
                    LeafMenuItem.NavigateUrl = levelRowLeaf["URL"].ToString();
                    LeafMenuItem.ImageUrl = "~/images/nav/pages.png";
                    
                    ChildMenuItem.ChildItems.Add(LeafMenuItem);
               
                }


                TopMenuItem.ChildItems.Add(ChildMenuItem); 
                
            }

            

            userMenu.Items.Add(TopMenuItem);
        }

    }


    private void showMenus()
    {
        DataSet ds = objMenu.displayMenu();
        //DataSet ds = objMenu.displayUserMenu(Session["U_USERID"].ToString());

        ds.Relations.Add("ChildRows", ds.Tables[0].Columns["MenuID"], ds.Tables[0].Columns["ParentID"]);

        foreach (DataRow menu in ds.Tables[0].Rows)
        {

            if (string.IsNullOrEmpty(menu["ParentID"].ToString()))
            {
                MenuItem TopMenuItem = new MenuItem();
                TopMenuItem.Text = "    " + menu["MenuText"].ToString();
                TopMenuItem.NavigateUrl = menu["URL"].ToString();
                TopMenuItem.ImageUrl = "~/images/nav/mainmenu.png";


                subMenus(menu, TopMenuItem);
                
                userMenu.Items.Add(TopMenuItem);
            }
        
        }
    }

    //Recursive function that will loop
    private void subMenus(DataRow drow, MenuItem childMenus)
    {
        DataRow[] childRows = drow.GetChildRows("ChildRows");
       
        foreach (DataRow child in childRows)
        {
            MenuItem childMenu = new MenuItem();
            childMenu.Text = " " + child["MenuText"].ToString();
            childMenu.NavigateUrl = child["URL"].ToString();
            childMenu.ImageUrl = "~/images/nav/submenu.png";
            
            childMenus.ChildItems.Add(childMenu);

            if (child.GetChildRows("ChildRows").Length > 0)
            {
                subMenus(child, childMenu);
            }
        }
    
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        cleanUserSession();
    }

    private void cleanUserSession()
    {
        Session["U_USERNAME"] = "";
        Session["U_USERID"] = "";
        Response.Redirect("~/login.aspx");
    }

}
