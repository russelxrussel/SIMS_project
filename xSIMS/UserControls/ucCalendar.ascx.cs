using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucCalendar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public DateTime CalendarValue
    {

        get { return Convert.ToDateTime(txtCalendar.Text); }
        set { txtCalendar.Text = value.ToString(); }
    }

        public DateTime textBoxValue()
        {
           DateTime dtime = new DateTime();
            try
            {
               dtime = Convert.ToDateTime(txtCalendar.Text);
            }

            catch
            { 
            
            }

            return dtime;
        }

}