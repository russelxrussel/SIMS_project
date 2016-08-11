using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucMobile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string MOBILEVALUE
    {
        get { return txtMobileNo.Text; }
        set { txtMobileNo.Text = value; }
    }

    public string textBoxValue()
    {

        string textValue = "";

        textValue = txtMobileNo.Text;

        return textValue;
    }

}