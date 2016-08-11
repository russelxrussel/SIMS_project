using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//using assForm;
using SIMSBDAL;

public partial class actgPenalty : System.Web.UI.Page
{
    AutoNumber oAutoNumber = new AutoNumber();

    public static string CS1 = ConfigurationManager.ConnectionStrings["CSSIMS"].ToString();
    public static string CSAP = ConfigurationManager.ConnectionStrings["CSSAP1"].ToString();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displaySY();
            InitializeMOP();
            
        }
    }


    private void displaySY()
    {
        drpSY.DataSource = ass_class.drop_down("Select * from xSystem.SchoolYear_RF ORDER BY SYStart DESC");
        drpSY.DataTextField = "SYStart";
        drpSY.DataValueField = "SYStart";
        drpSY.DataBind();

        drpSY.Items.Insert(0, new ListItem("--Select School Year--"));
        
    }


    private void InitializeMOP()
    {
        string sy;
        sy = drpSY.Text;
        drpMOP.DataSource = ass_class.drop_down("Select * from [dbo].[Act_Pymt_Schme_RF]");
        drpMOP.DataTextField = "pymt_desc";
        drpMOP.DataValueField = "pymt_schme";
        drpMOP.DataBind();

        drpMOP.Items.Insert(0, new ListItem("--Select MOP--"));
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Double instbal;
        Double penamt;
        String PNNo;
        Double cnt;

        //delete start

        ass_class.SqlExecute("Delete FROM [Penalty].[PenaltyTF]");
        ass_class.SqlExecute("Delete FROM [Penalty].[PN_ARINVPYMT]");
        ass_class.SqlExecute("Delete FROM [Penalty].[PN_ARINVFEES]");
        //ass_class.SqlExecute("Update [xSystem].[AutoNumber_RF] SET Series='0' where CodePrefix='PN'");

        //delete end

        //save to Penalty_MF
        using (SqlConnection CSAP1 = new SqlConnection(CSAP))
        {
            using (SqlCommand cmd1 = new SqlCommand("spCompPenalty", CSAP1))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                 cmd1.Parameters.AddWithValue("@v_duedate",txtDated.Text);
                 cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                cnt = 0;
                while (reader.Read())
                {
                    using (SqlConnection CS1a = new SqlConnection(CS1))
                    {
                        using (SqlCommand command1 = new SqlCommand("spInsertPenaltyTF", CS1a))
                        {

                            command1.CommandType = CommandType.StoredProcedure;
                            CS1a.Open();

                            command1.Parameters.AddWithValue("@v_TranName", Convert.ToString(txtDated.Text));
                            command1.Parameters.AddWithValue("@v_TranDate", txtDated.Text);
                            command1.Parameters.AddWithValue("@v_StudNo", reader["CardCode"].ToString());
                            command1.Parameters.AddWithValue("@v_SY", drpSY.Text);
                            command1.Parameters.AddWithValue("@v_MOP", drpMOP.Text);
                            command1.Parameters.AddWithValue("@v_DueDate", txtDated.Text);
                            command1.Parameters.AddWithValue("@v_InstNum", reader["InstlmntID"].ToString());
                            command1.Parameters.AddWithValue("@v_InstAmt", reader["InsTotal"].ToString());
                            //balance
                            instbal = Convert.ToDouble(reader["InsTotal"].ToString()) - Convert.ToDouble(reader["PaidToDate"].ToString());
                            command1.Parameters.AddWithValue("@v_InstBalance", instbal);
                            command1.Parameters.AddWithValue("@v_PenaltyPerc", "0.01");
                            //penalty amt
                            penamt = instbal * .01;

                            command1.Parameters.AddWithValue("@v_PenaltyAmt", penamt);
                            command1.Parameters.AddWithValue("@v_DateUpd", DateTime.Now.ToString());
                            command1.Parameters.AddWithValue("@v_UserName", "dbo");
                            
                            if (penamt > 0)
                            {
                                command1.ExecuteNonQuery();

                                //SIMS -ARINVFEES


                                int autoCode;
                                string Acode;


                                autoCode = 0;

                                autoCode = autoCode + 1;
                                Acode = "PN" + autoCode;



                                string SubString = drpSY.Text.Substring(drpSY.Text.Length - 2);


                                PNNo = oAutoNumber.assNumber("PN", SubString).ToString();
                                oAutoNumber.updateAssNumber("PN");


                                using (SqlConnection CSAP11 = new SqlConnection(CS1))
                                {

                                    using (SqlCommand command11 = new SqlCommand("CrPNARInvFees", CSAP11))
                                    {

                                        command11.CommandType = CommandType.StoredProcedure;
                                        CSAP11.Open();

                                        command11.Parameters.AddWithValue("@v_Code", PNNo);
                                        command11.Parameters.AddWithValue("@v_Name", PNNo);
                                        command11.Parameters.AddWithValue("@v_U_Docdate", DateTime.Now.ToString("M/d/yyyy"));
                                        command11.Parameters.AddWithValue("@v_U_DocDueDate", txtDated.Text);
                                        command11.Parameters.AddWithValue("@v_U_DocType", "S");
                                        command11.Parameters.AddWithValue("@v_U_PymtMethod", "CA");
                                        command11.Parameters.AddWithValue("@v_U_StudentNo", reader["CardCode"].ToString());
                                        command11.Parameters.AddWithValue("@v_U_Name", reader["CardName"].ToString());
                                        command11.Parameters.AddWithValue("@v_U_Fee", "342000");
                                        command11.Parameters.AddWithValue("@v_U_Description", "Service Income-Miscellaneous");
                                        command11.Parameters.AddWithValue("@v_U_Quantity", 0);
                                        command11.Parameters.AddWithValue("@v_U_Amount", penamt);
                                        command11.Parameters.AddWithValue("@v_U_TaxCode", "OV-E");
                                        command11.Parameters.AddWithValue("@v_U_Year", drpSY.Text);
                                        command11.Parameters.AddWithValue("@v_U_Semester", "0");
                                        command11.Parameters.AddWithValue("@v_U_DocNum", PNNo);
                                        command11.ExecuteNonQuery();

                                    }
                                }
                                //updaTE YNG FOR PROCESS
                                ass_class.SqlExecute("Update [Penalty].[PN_ARINVFEES] SET U_ForProcess='Y' where U_DocNum='" + PNNo + "'");

                                //END UPDATE NG FOR PROCESS

                                //SIMS - ARINVFEES (End)


                                //START SIMS - ARINVPYMT
                                using (SqlConnection CSSAP2 = new SqlConnection(CS1))
                                {
                                    using (SqlCommand cmd13 = new SqlCommand("CrPNARInvPYMT", CSSAP2))
                                    {
                                        // insno = insno + 1;
                                        cmd13.CommandType = CommandType.StoredProcedure;
                                        CSSAP2.Open();

                                        cmd13.Parameters.AddWithValue("@v_Code", PNNo);
                                        cmd13.Parameters.AddWithValue("@v_Name", PNNo);
                                        cmd13.Parameters.AddWithValue("@v_U_DocNum", PNNo);
                                        cmd13.Parameters.AddWithValue("@v_U_InsNo", "1");
                                        cmd13.Parameters.AddWithValue("@v_U_DocDueDate", DateTime.Now.ToString("M/d/yyyy"));
                                        cmd13.Parameters.AddWithValue("@v_U_StudentNo", reader["CardCode"].ToString());
                                        cmd13.Parameters.AddWithValue("@v_U_Name", reader["CardName"].ToString());
                                        cmd13.Parameters.AddWithValue("@v_U_Amount", penamt);


                                        cmd13.ExecuteNonQuery();
                                    }
                                }

                                //updaTE YNG FOR PROCESS
                                ass_class.SqlExecute("Update [Penalty].[PN_ARINVPYMT] SET U_ForProcess='Y' where U_DocNum='" + PNNo + "'");

                                //END UPDATE NG FOR PROCESS



                                //END SIMS - ARINVPYMT

                                cnt = cnt + 1;


                            }


                            }
                            
                        }
                        
                    }

                  

                 reader.Close();
           // }

               // }
                 Response.Write("<script type=\"text/javascript\">alert('Total NUmber of Processed:  ' + '" + cnt + "');</script>");
                 }
           
            }
        
        }
    private void MessageDialog(string str, int iconType)
    {
        string scriptSTR = "message('" + str + "', '" + iconType + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensahe", scriptSTR, true);
    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>window.open('rep_ListPenalty.aspx');</script>");
    }
   
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        Double cnt1;
        //send from SIMS to SAP ARINVFEES -start
        using (SqlConnection CS11 = new SqlConnection(CS1))
        {
            string strsql = "SELECT * FROM [Penalty].[PN_ARINVFEES]";
            SqlCommand comnd = new SqlCommand(strsql, CS11);
            comnd.CommandType = CommandType.Text;
            CS11.Open();
            {

                cnt1 = 0;
                SqlDataReader rdr = comnd.ExecuteReader();
                if (rdr.HasRows)
                { 
                    while (rdr.Read())
                    {
                        //SAVE TO SAP ARINVFEES
                        using (SqlConnection CSAP21 = new SqlConnection(CSAP))
                        {

                            using (SqlCommand command11 = new SqlCommand("CrARInvFees", CSAP21))
                            {

                                command11.CommandType = CommandType.StoredProcedure;
                                CSAP21.Open();

                                command11.Parameters.AddWithValue("@v_Code", rdr["Code"].ToString());
                                command11.Parameters.AddWithValue("@v_Name", rdr["Name"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Docdate", rdr["U_Docdate"].ToString());
                                command11.Parameters.AddWithValue("@v_U_DocDueDate", rdr["U_DocDueDate"].ToString());
                                command11.Parameters.AddWithValue("@v_U_DocType", rdr["U_DocType"].ToString());
                                command11.Parameters.AddWithValue("@v_U_PymtMethod", rdr["U_PymtMethod"].ToString());
                                command11.Parameters.AddWithValue("@v_U_StudentNo", rdr["U_StudentNo"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Name", rdr["U_Name"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Fee", rdr["U_Fee"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Description", rdr["U_Description"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Quantity", rdr["U_Quantity"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Amount", rdr["U_Amount"].ToString());
                                command11.Parameters.AddWithValue("@v_U_TaxCode", rdr["U_TaxCode"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Year", rdr["U_Year"].ToString());
                                command11.Parameters.AddWithValue("@v_U_Semester", rdr["U_Semester"].ToString());
                                command11.Parameters.AddWithValue("@v_U_DocNum", rdr["U_DocNum"].ToString());
                                command11.ExecuteNonQuery();

                            }
                        }
                        //updaTE YNG FOR PROCESS
                        ass_class.SqlExecute_sap("Update [@FT_ARINVFEES] SET U_ForProcess='Y' where U_DocNum='" + rdr["U_DocNum"].ToString() + "'");

                        //END UPDATE NG FOR PROCESS

                        //SIMS - ARINVFEES (End)


                        //SAVE TO SAP ARINVFEES END

                        
                    }
                    rdr.Close();
                }
            }
        }

        //send from SIMS to SAP ARINVFEES-end

        //send from SIMS to SAP ARINVPYMT -start
        using (SqlConnection CS12 = new SqlConnection(CS1))
        {
            string strsql = "SELECT * FROM [Penalty].[PN_ARINVPYMT]";
            SqlCommand comnd1 = new SqlCommand(strsql, CS12);
            comnd1.CommandType = CommandType.Text;
            CS12.Open();
            {
                SqlDataReader rdr = comnd1.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        using (SqlConnection CSSAP2 = new SqlConnection(CSAP))
                        {
                            using (SqlCommand cmd1 = new SqlCommand("CrARInvPYMT", CSSAP2))
                            {
                                // insno = insno + 1;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                CSSAP2.Open();

                                cmd1.Parameters.AddWithValue("@v_Code", rdr["Code"].ToString());
                                cmd1.Parameters.AddWithValue("@v_Name", rdr["Name"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_DocNum", rdr["U_DocNum"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_InsNo", rdr["U_InsNo"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_DocDueDate", rdr["U_DocDueDate"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_StudentNo", rdr["U_StudentNo"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_Name", rdr["U_Name"].ToString());
                                cmd1.Parameters.AddWithValue("@v_U_Amount", rdr["U_Amount"].ToString());


                                cmd1.ExecuteNonQuery();
                            }
                         }

                        //updaTE YNG FOR PROCESS
                            ass_class.SqlExecute_sap("Update [@FT_ARINVPYMT] SET U_ForProcess='Y' where U_DocNum='" + rdr["U_DocNum"].ToString() + "'");

                        //END UPDATE NG FOR PROCESS

                        //SAVE TO SAP ARINVPYMT END
                            cnt1 = cnt1 + 1;
                    }
                     rdr.Close();
                     Response.Write("<script type=\"text/javascript\">alert('Total NUmber of Sent Transaction:  ' + '" + cnt1 + "');</script>");
           
                }

             }
                
           }
           
}

        //send from SIMS to SAP ARINVPYMT-end

    

       
}

