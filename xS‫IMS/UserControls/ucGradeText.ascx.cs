using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucGradeText : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private double gradeinput = 0.0;

    public double GRADEINPUT
    {
        get { return Convert.ToDouble(txtGrade.Text); }
        set { txtGrade.Text = value.ToString(); }
    }


    public double Grade()
    {
        double x = 0.0;
        try
        {
         x =   Convert.ToDouble(txtGrade.Text);
        }

        catch

        { 
        
        
        }
        return x;
    }
}