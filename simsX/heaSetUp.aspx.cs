using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIMSBDAL;


public partial class heaSetUp : System.Web.UI.Page
{
    Health oHealth = new Health();
    Utilities oUtilities = new Utilities();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DISPLAY_MEDICINE_TYPE();
            DISPLAY_MEDICINE_LEVEL();

            DISPLAY_MEDICINE_LIST();
        }



    }


    protected void lnkSave_Click(object sender, EventArgs e)
    {
        if (txtMedicineCode.Text == "" || string.IsNullOrEmpty(txtMedicineDesc.Text) || txtMedicineDesc.Text == "" || string.IsNullOrEmpty(txtMedicineDesc.Text) || ddMedicineType.SelectedIndex == 0 || ddMedicineLevel.SelectedIndex == 0)
        {
           // Response.Write("Error");

            string message = "Error";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", sb.ToString());
        }
        else
        { 
        oHealth.INSERT_MEDICINE(txtMedicineCode.Text, txtMedicineDesc.Text, txtGenericName.Text, ddMedicineType.SelectedValue.ToString(), ddMedicineLevel.SelectedValue.ToString(),"test");
        CLEAR_MEDICINE_INPUT();

        }

    }


    /*
   ========================================
   METHOD DECLARATION AREA
   ========================================
   */

    #region "METHOD AREA"
    
    private void DISPLAY_MEDICINE_TYPE()
    {
        oUtilities.GENERIC_DROPDOWN(ddMedicineType,oHealth.GET_MEDICINE_TYPE(), "medTypeCode", "TypeDesc");
        ddMedicineType.Items.Insert(0, new ListItem("-SELECT-"));
    }

    private void DISPLAY_MEDICINE_LEVEL()
    {
        oUtilities.GENERIC_DROPDOWN(ddMedicineLevel, oHealth.GET_MEDICINE_LEVEL(), "medLevelCode", "medLevelDesc");
        ddMedicineLevel.Items.Insert(0, new ListItem("-SELECT-"));
    }

    private void CLEAR_MEDICINE_INPUT()
    {
        txtMedicineCode.Text = "";
        txtMedicineDesc.Text = "";
        txtGenericName.Text = "";
        ddMedicineLevel.SelectedIndex = 0;
        ddMedicineType.SelectedIndex = 0;
    }


    //Get list of Medicine
    private void DISPLAY_MEDICINE_LIST()
    {
        oUtilities.GENERIC_DROPDOWN(ddMedicineList, oHealth.GET_MEDICINE_LIST(), "medCode", "medDesc");
        ddMedicineList.Items.Insert(0, new ListItem("-SELECT-"));
    }
    #endregion
}

