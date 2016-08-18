using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucProperText : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string TEXTVALUE
    {
        get { return txtValue.Text;}

        set { txtValue.Text = value; }
    }
}