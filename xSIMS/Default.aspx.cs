using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using SIMSBDAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class _Default : System.Web.UI.Page 
{
    Utilities util = new Utilities();

    Health oHealth = new Health();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        displayCity();
      //  GetMenuItems();
        displayHealthIlness();
    

        }


       
    }


    private void displayHealthIlness()
    {
        DataTable dt = new DataTable();
        dt = oHealth.GET_STUDENT_ILLNESS();
        

        CheckBoxList1.DataSource = dt;
        CheckBoxList1.DataTextField = dt.Columns["IllDesc"].ToString();
        CheckBoxList1.DataValueField = dt.Columns["IllCode"].ToString();
        CheckBoxList1.DataBind();
    }


    private void displayCity()
    {
        DataSet ds = new DataSet();
        ds = util.getTest();
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        
        
        GridView1.DataSource = dt;
        GridView1.DataBind();

        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = dt.Columns["CityDesc"].ToString();
        DropDownList1.DataValueField = dt.Columns["CityCode"].ToString();
        DropDownList1.DataBind();
    
    }

    private void GetMenuItems()
    {
        string cs = ConfigurationManager.ConnectionStrings["CSSIMS"].ConnectionString;
        SqlConnection cn = new SqlConnection(cs);
        SqlDataAdapter da = new SqlDataAdapter("spMenuListData", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["ParentID"]);

        foreach (DataRow levelRowTop in ds.Tables[0].Rows)
        {
            MenuItem TopMenuItem = new MenuItem();
            TopMenuItem.Text = levelRowTop["MenuText"].ToString();
            TopMenuItem.NavigateUrl = levelRowTop["URL"].ToString();
            TopMenuItem.ImageUrl = "~/images/nav/mmenu.png";

            DataRow[] levelRowChilds = levelRowTop.GetChildRows("ChildRows");
            foreach (DataRow levelRowChild in levelRowChilds)
            {
                MenuItem ChildMenuItem = new MenuItem();
                ChildMenuItem.Text = levelRowChild["MenuText"].ToString();
                ChildMenuItem.NavigateUrl = levelRowChild["URL"].ToString();
                ChildMenuItem.ImageUrl = "~/images/nav/smenu.png";

                TopMenuItem.ChildItems.Add(ChildMenuItem);
            }

            Menu1.Items.Add(TopMenuItem);
        }



    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Write("check");
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompleteList(string prefixText, int count, string contextKey)
    {
        string[] names = { "Russel", "Rose", "Rex", "Vasquze", "Valguna", "Veti", "AdaD", "Aadad" };
        var nameList = from tmp in names where tmp.ToLower().StartsWith(prefixText) select tmp;
        return nameList.ToArray();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ConnectionInfo myConnection = new ConnectionInfo();
        myConnection.ServerName = "PROGRAMMER-PC";
        myConnection.DatabaseName = "dbSIMS";
        myConnection.UserID = "sa";
        myConnection.Password = "p@ssword";
       
        setDBLogonReport(myConnection);

        ReportDocument rdoc = new ReportDocument();

        rdoc.Load(Server.MapPath("~/reports/admevalreport2.rpt"));
        CrystalReportViewer1.ReportSource = rdoc;
        CrystalReportViewer1.DataBind();
    }


    private void setDBLogonReport(ConnectionInfo cnInfo)
    {

        TableLogOnInfos mytableloginfos = new TableLogOnInfos();
        mytableloginfos = CrystalReportViewer1.LogOnInfo;


        foreach (TableLogOnInfo mytablelogininfo in mytableloginfos)
        {
            mytablelogininfo.ConnectionInfo = cnInfo;
        }

    }
}
