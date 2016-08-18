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
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DISPLAY_MEDICINE_TYPE();
            DISPLAY_MEDICINE_LEVEL();
        }



    }

    private void DISPLAY_MEDICINE_TYPE()
    {
        DataTable dt = oHealth.GET_MEDICINE_TYPE();

        ddMedicineType.DataSource = dt;
        ddMedicineType.DataValueField = dt.Columns["medTypeCode"].ToString();
        ddMedicineType.DataTextField = dt.Columns["TypeDesc"].ToString();
        ddMedicineType.DataBind();

        ddMedicineType.Items.Insert(0, new ListItem("-SELECT-"));
    }

    private void DISPLAY_MEDICINE_LEVEL()
    {
        DataTable dt = oHealth.GET_MEDICINE_LEVEL();

        ddMedicineLevel.DataSource = dt;
        ddMedicineLevel.DataValueField = dt.Columns["medLevelCode"].ToString();
        ddMedicineLevel.DataTextField = dt.Columns["medLevelDesc"].ToString();
        ddMedicineLevel.DataBind();

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
}