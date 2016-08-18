using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucContactNo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string TELVALUE
    {
        get { return txtContactNo.Text; }
        set { txtContactNo.Text = value; }
    }

    public string textBoxValue()
    {

        string textValue = "";

        textValue = txtContactNo.Text; 

        return textValue;
    }

}