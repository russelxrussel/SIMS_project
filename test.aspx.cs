using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDummyDataToGrid();
        }
    }

    protected void test_Click(object sender, EventArgs e)
    {
        Random rndNum = new Random();

        int genRand = rndNum.Next(1, 1000);
        System.Threading.Thread.Sleep(genRand);
        Response.Write("Testing Display" + genRand );

        foreach (GridViewRow r in GridView1.Rows)
        {

            //string sCode = r.Cells[4].Text;

            string sCode = r.Cells[2].FindControl("tot").ToString();
            Response.Write("etoo=" + sCode);
        }

      

    }

    private void BindDummyDataToGrid()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Description", typeof(string)));
        dt.Columns.Add(new DataColumn("Price", typeof(string)));

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Description"] = "Nike";
        dr["Price"] = "1000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["RowNumber"] = 2;
        dr["Description"] = "Converse";
        dr["Price"] = "800";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["RowNumber"] = 3;
        dr["Description"] = "Adidas";
        dr["Price"] = "500";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["RowNumber"] = 4;
        dr["Description"] = "Reebok";
        dr["Price"] = "750";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["RowNumber"] = 5;
        dr["Description"] = "Vans";
        dr["Price"] = "1100";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["RowNumber"] = 6;
        dr["Description"] = "Fila";
        dr["Price"] = "200";
        dt.Rows.Add(dr);


        //Bind the Gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }


}