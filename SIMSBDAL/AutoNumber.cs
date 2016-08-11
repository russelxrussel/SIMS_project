using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace SIMSBDAL
{
    public class AutoNumber: cBase
    {

       
        public int SERIESNUMBER { get; set; }

        public string ISAMSAPPNUMBER { get; set; }

        public string appNumber(string PREFIX)
        {
            SERIESNUMBER = 0;
            ISAMSAPPNUMBER = "";
            string PrefixCode = "";
            string AutoNumber = "";

            //try
            //{
                using (SqlConnection cn = new SqlConnection(CS))
                { 
                    string strSQL = "Select CodePrefix, Series from xSystem.AutoNumber_RF where codePrefix = '" + PREFIX + "'";
                    
                        using(SqlCommand cmd = new SqlCommand(strSQL,cn))
                        {
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    PrefixCode = dr["CodePrefix"].ToString();

                                    if ((int)dr["Series"] > 0)
                                    {

                                        SERIESNUMBER = (int)dr["Series"] + 1;

                                        //format Applicant AutoNumber
                                        if (SERIESNUMBER > 999)
                                        {
                                            AutoNumber = PrefixCode + "-" + SERIESNUMBER;
                                            ISAMSAPPNUMBER = SERIESNUMBER.ToString();
                                        }

                                        else if (SERIESNUMBER > 99)
                                        {
                                            AutoNumber = PrefixCode + "-" + "0" + SERIESNUMBER;
                                            ISAMSAPPNUMBER = "0" + SERIESNUMBER.ToString();
                                        }

                                        else if (SERIESNUMBER > 9)
                                        {
                                            AutoNumber = PrefixCode + "-" + "00" + SERIESNUMBER;
                                            ISAMSAPPNUMBER = "00" + SERIESNUMBER.ToString();
                                        }

                                        else
                                        {
                                            AutoNumber = PrefixCode + "-" + "000" + SERIESNUMBER;
                                            ISAMSAPPNUMBER = "000" + SERIESNUMBER.ToString();
                                        }

                                    }

                                    else
                                    {
                                        SERIESNUMBER = SERIESNUMBER + 1;
                                        AutoNumber = PrefixCode + "-" + "000" + SERIESNUMBER;
                                        
                                        ISAMSAPPNUMBER = "000" + SERIESNUMBER.ToString();
                                    }
                                }

                            }

                        
                        }
                }

            //}

            //catch { 
            
            //}


            return AutoNumber;
        
        }


        private int displayLastSeries(string PREFIX)
        {
            int Series = 0;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select Series from xSystem.AutoNumber_RF where codePrefix = '" + PREFIX + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Series = (int)dr["Series"];
                    }
                }
            }

             return Series;
        }



        public void updateAppNumber(string PREFIX)
        {
            //Will Add +1 to series to update series number
            //int Series = displayLastSeries(PREFIX) + 1;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("Update xSystem.AutoNumber_RF SET series=" + SERIESNUMBER + " WHERE CodePrefix=@prefix", cn))
            {
                cmd.Parameters.AddWithValue("@prefix", PREFIX);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            
            }
        }
    }
}
