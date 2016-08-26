using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



    public class ass_class
    {
        public static string CS = ConfigurationManager.ConnectionStrings["CSISAMS"].ToString();

        public string STUDNO { get; set; }
        public string APPNUM { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string MI { get; set; }
        public DateTime DOB { get; set; }



        public string LEVELTYPE { get; set; }
        public string LEVELDESC { get; set; }

        public string DESIGTYPE { get; set; }
        public double FEEAMT { get; set; }

        public string DC { get; set; }
        public double TA { get; set; }

        public double ATFF { get; set; }
        public double AMFF { get; set; }
        public char EChild { get; set; }
        public string SIBCODE { get; set; }
        public string SiblingCod { get; set; }

        static string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CSISAMS"].ConnectionString;
        static string DB2 = System.Configuration.ConfigurationManager.ConnectionStrings["CSSIMS"].ConnectionString;
        static string SAPCN = System.Configuration.ConfigurationManager.ConnectionStrings["CSSAP1"].ConnectionString;
        // this is for just executing sql command with no value to return
        public static void SqlExecute_isams(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB2))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }


        public static void SqlExecute_sap(string sql)
        {
            using (SqlConnection conn = new SqlConnection(SAPCN))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
        // with this you will be able to return a value
        public static object SqlReturn_isams(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Connection.Open();
                object result = (object)cmd.ExecuteScalar();
                return result;
            }
        }


        // with this you will be able to return a value
        public static object SqlReturn(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB2))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Connection.Open();
                object result = (object)cmd.ExecuteScalar();
                return result;
            }
        }

        // with this you can retrieve an entire table or part of it
        public static DataTable SqlDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

        // sooner or later you will probably use stored procedures. 
        // you can use this in order to execute a stored procedure with 1 parameter
        // it will work for returning a value or just executing with no returns
        public static object SP_Level(string StoredProcedure, string PrmName1, object Param1)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter(PrmName1, Param1.ToString()));
                cmd.Connection.Open();
                object obj = new object();
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        public static object Sproc_Lev(string StoredProcedure, string prname1, string prname2)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.Parameters.AddWithValue("@v_level_type", int.Parse(prname1));
                cmd.Parameters.AddWithValue("@v_level_code", int.Parse(prname2));
                cmd.Parameters.Add("level_desc", SqlDbType.VarChar, 50);
                cmd.Parameters["level_desc"].Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                object obj = new object();
                obj = cmd.ExecuteScalar();
                return obj;

            }
        }

        public bool GETLDESC(string _levelcode)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(DB2))
            {

                using (SqlCommand cmd = new SqlCommand("sp_GetLevelDesc", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.AddWithValue("@v_level_type", _leveltype);
                    cmd.Parameters.AddWithValue("@v_levtypcode", _levelcode);

                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            LEVELDESC = dr["LevelTypeDesc"].ToString();
                        }
                    }
                    else
                    {
                        x = false;
                    }


                }
            }

            return x;
        }




        public bool dtTFMF(string _levelcode, string _sy, string _ps)
        {

            bool x = false;
            //DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(DB2))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAssess", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@v_levCode", _levelcode);
                    cmd.Parameters.AddWithValue("@v_schyear", _sy);
                    cmd.Parameters.AddWithValue("@v_psch", _ps);
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);
                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            ATFF = double.Parse(dr["tot_tuit"].ToString());
                            AMFF = double.Parse(dr["tot_misc"].ToString());
                        }
                    }
                    else
                    {
                        x = false;
                    }


                }

            }
            return x;
        }


        public bool GETPY(string _studno, string _sy)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("proc_GetPymt", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@v_stud_no", _studno);
                    cmd.Parameters.AddWithValue("@v_sy", _sy);

                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;
                        TA = 0;
                        while (dr.Read())
                        {
                            DC = dr["desigfee_code"].ToString();
                            TA = TA + double.Parse(dr["tran_amt"].ToString());
                        }
                    }
                    else
                    {
                        x = false;
                    }


                }
            }

            return x;
        }

        public bool GETPY_SAP(string _studno, string _sy)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(SAPCN))
            {

                using (SqlCommand cmd = new SqlCommand("GetORCT", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@v_U_StudentNo", _studno);
                    cmd.Parameters.AddWithValue("@v_U_Year", _sy);
                    cmd.Parameters.AddWithValue("@v_U_Semester", '0');

                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;
                        TA = 0;
                        while (dr.Read())
                        {
                            // DC = dr["desigfee_code"].ToString();
                            TA = TA + double.Parse(dr["U_Amount"].ToString());
                        }
                    }
                    else
                    {
                        x = false;
                    }


                }
            }

            return x;
        }

        public static DataTable GetSibs(string _stud_no)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))

            using (SqlCommand cmd = new SqlCommand("proc_GetSiblings", cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@v_studno", _stud_no);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }

            return dt;
        }

        public static DataTable GetMOP(string prname1, string _sy)
        {
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("proc_GetPymt", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@v_stud_no", prname1));
                cmd.Parameters.Add(new SqlParameter("@v_sy", _sy));
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }

        }

        public static DataTable GetSib2(string prname1)
        {

            using (SqlConnection cn = new SqlConnection(DB2))
            {
                SqlCommand cmd = new SqlCommand("spDisplaySiblingList_C", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SIBLINGCODE", prname1));
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }

        }

        public static object RValue(string StoredProcedure, string PrmName1, object Param1)
        {
            using (SqlConnection conn = new SqlConnection(DB2))
            {
                if (Param1 != null)
                {
                    SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(PrmName1, Param1.ToString()));
                    cmd.Connection.Open();
                    object obj = new object();
                    obj = cmd.ExecuteScalar();


                    if ((obj == null) || obj == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        return obj;
                    }
                }
                else
                {

                    return 0;
                }

            }
        }

        public static object RValue2(string StoredProcedure, string PrmName1, object Param1, string PrmName2, object Param2)
        {
            using (SqlConnection conn = new SqlConnection(DB2))
            {
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter(PrmName1, Param1.ToString()));
                cmd.Parameters.Add(new SqlParameter(PrmName2, Param2.ToString()));
                cmd.Connection.Open();
                object obj = new object();
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }



        public static DataTable drop_down(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DB2))
            {
                //sql = "Select SYStart from SchoolYear_RF DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

        public bool GETSibCod(string _studno)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(DB2))
            {

                using (SqlCommand cmd = new SqlCommand("spCheckStudentSiblings", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STUDNUM", _studno);


                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;
                        TA = 0;
                        while (dr.Read())
                        {
                            SiblingCod = dr["SiblingCode"].ToString();

                        }
                    }
                    else
                    {
                        x = false;
                    }


                }
            }

            return x;
        }


        public bool GetPrevBalance(string _studno)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(DB2))
            {

                using (SqlCommand cmd = new SqlCommand("Select StudNo from [Assessment].[PrevBalance] where StudNo='" + _studno + "'", cn))
                {
                    cn.Open();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@STUDNUM", _studno);
                    cmd.CommandType = CommandType.Text;


                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;
                        TA = 0;
                        while (dr.Read())
                        {
                            SiblingCod = dr["StudNo"].ToString();

                        }
                    }
                    else
                    {
                        x = false;
                    }


                }
            }

            return x;
        }



    }
