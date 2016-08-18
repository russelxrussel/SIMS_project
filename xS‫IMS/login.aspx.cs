using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using isamsDecrypt;
using SIMSBDAL;

public partial class login : System.Web.UI.Page
{
    decrpytClass decrypt = new decrpytClass();
    xSystem oLogin = new xSystem();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
   
        }

        //Set the focus
        //12-02-2015
        ScriptManager.RegisterStartupScript(this, this.GetType(), "focus", "document.getElementById('" + this.txtUserId.ClientID + "').focus();", true);
  
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //SETUP MASTER INFORMATION
        //Execute and get the fields
        oLogin.getMasterSetupDetails();

        Session["X_APP_PREFIX"] = oLogin.AppPrefix;
        Session["X_STUDENT_PREFIX"] = oLogin.StudPrefix;
    }



    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Pass the password of user to 
        string getUserPassword = oLogin.getPassword(txtUserId.Text);
        
        //Hold password that had been pullout from database
        string decryptPassword = decrypt.decryptPassword(getUserPassword.ToString());
        decryptPassword.Trim();


        //string userid = oLogin.UserId.ToString();

        //Check if user exist
        if (oLogin.flgUser)
        {
            //Check if userid and password encoded was match against database
            if (string.Equals(txtUserId.Text, oLogin.UserId.ToString(), StringComparison.CurrentCultureIgnoreCase) && txtPassword.Text == decryptPassword.ToString())
            {
                if (oLogin.UserStat)
                {
                    Session["U_USERID"] = oLogin.UserId;
                    Session["U_USERNAME"] = oLogin.UserName;

                    //Get SErver time
                    Session["S_SERVERDATE"] = oLogin.GetServerDate().ToLongDateString();
                    
                    //Get Active School Year
                    Session["S_SY"] = oLogin.GetActiveSY();

                    //Get Start Year for ISAMS
                    Session["STARTYEAR"] = oLogin.SYSTART;

                    Response.Redirect("~/home.aspx");
                   
                    //Testing insert
                    //Successfully insert new record
                 //oLogin.INSERT_SAP_BP(6, "VASQUEZ, RUSSEL", "111-1111","VASQUEZ, RUSSEL", 1, "Grade 1","", "Standard", "", "N", "Y", "G1");

                   // oLogin.UPDATE_SAP_BP("16-0055","G11","PP","U","N","Y");

                   

                }
                else { Response.Write("User was deactivated"); }
            }
            else
            {
                //Response.Write("Wrong");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "dialog", "fncsave();", true);
            }
            //       txtUserId.Text = decryptPassword.ToString() + " " + oLogin.UserName.ToString() + " " + oLogin.UserStat.ToString();


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "dialog", "fncsave();", true);
        }
    }
}