using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;

public partial class sysSlotSetup : System.Web.UI.Page
{
    xSystem oSystem = new xSystem();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["U_USERID"] = "TERE";

        Session["U_USERNAME"] = "DADASD";
        Session["S_SERVERDATE"] = DateTime.Now;
        Session["S_SY"] = "2016-2017";

        if (!IsPostBack)
        {
            //Load to drop down data.
            displayLevelCategory();
            displayLevelType();
        }
    }


    private void displayLevelType()
    {
        DataTable dt = new DataTable();
        dt = oSystem.getApplicantLevel(ddLevelCategory.SelectedValue.ToString());

        ddLevelType.DataSource = dt;
        ddLevelType.DataTextField = dt.Columns["LevelTypeDesc"].ToString();
        ddLevelType.DataValueField = dt.Columns["LevelTypeCode"].ToString();
        ddLevelType.DataBind();
    }

    private void displayLevelCategory()
    {
        DataTable dt = new DataTable();
        dt = oSystem.getLevelCategory();

        ddLevelCategory.DataSource = dt;
        ddLevelCategory.DataTextField = dt.Columns["LevelCatDesc"].ToString();
        ddLevelCategory.DataValueField = dt.Columns["LevelCatCode"].ToString();
        ddLevelCategory.DataBind();
    }


    protected void ddLevelCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayLevelType();
    }
}