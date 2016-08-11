using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace SIMSBDAL
{


    public class Applicant: cBase
    {

        public int retAppInfo { get; set; }
        public int retAppPrevGrade { get; set; }


        public void newApplicant(string SY, string APPTYPECODE, string LEVELTYPECODE, string STRANDCODE, DateTime APPDOA, string APPNUM,
                                 bool WLSTATUS, bool SSICHILD, string LASTNAME, string FIRSTNAME, string MIDDLENAME,
                                 string MI, string SUFFIX, string FULLNAME, string GENDERCODE, DateTime DOB, string POB, double AGE, string AGEONJUNE, bool SHORTBYJUNE, int SHORTMONTH, string TELNO,
                                 string MOBILENO, string CONTACTPERSON, string ADDINFO, string BARANGAYCODE, string CITYCODE, string EMAIL, string REMARKS, bool Status, bool _appbackout, 
                                 DateTime DATEENCODE, DateTime DATEUPDATE, string USERCODE,
                                string SNUM, bool FORM138, bool BC, bool COLORED1X1, bool BROWNENVELOPE, bool GM, bool RECOMMENDATION, bool FORM137, bool NCAE, string OTHER,
                                double ENGTOTAL, double SCITOTAL, double MATHTOTAL, double FIRSTTOTAL, double SECONDTOTAL, double THIRDTOTAL,
                                double FOURTHTOTAL, double ENG1, double ENG2, double ENG3, double ENG4, double SCI1, double SCI2, double SCI3, double SCI4,
                                double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE, double FINALAVERAGE2)
       
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                cn.Open();

                SqlTransaction sqlTrans = cn.BeginTransaction();

                try
                {
                       SqlCommand cmd = new SqlCommand("spInsertApplicantINFO", cn, sqlTrans);
                    
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SY", SY);
                        cmd.Parameters.AddWithValue("@AppTypeCode", APPTYPECODE);
                        cmd.Parameters.AddWithValue("@LevelTypeCode", LEVELTYPECODE);
                        cmd.Parameters.AddWithValue("@StrandCode", STRANDCODE);
                        cmd.Parameters.AddWithValue("@AppDOA", APPDOA);
                        cmd.Parameters.AddWithValue("@AppNum", APPNUM);
                        cmd.Parameters.AddWithValue("@WLStatus", WLSTATUS);
                        cmd.Parameters.AddWithValue("@SSIChild", SSICHILD);
                        cmd.Parameters.AddWithValue("@LastName", LASTNAME);
                        cmd.Parameters.AddWithValue("@FirstName", FIRSTNAME);
                        cmd.Parameters.AddWithValue("@MiddleName", MIDDLENAME);
                        cmd.Parameters.AddWithValue("@MI", MI);
                        cmd.Parameters.AddWithValue("@Suffix", SUFFIX);
                        cmd.Parameters.AddWithValue("@FullName", FULLNAME);
                        cmd.Parameters.AddWithValue("@GenderCode", GENDERCODE);
                        cmd.Parameters.AddWithValue("@DOB", DOB);
                        cmd.Parameters.AddWithValue("@POB", POB);
                        cmd.Parameters.AddWithValue("@Age", AGE);
                        cmd.Parameters.AddWithValue("@AgeOnJune", AGEONJUNE);
                        cmd.Parameters.AddWithValue("@ShortByJune", SHORTBYJUNE);
                        cmd.Parameters.AddWithValue("@ShortMonth", SHORTMONTH);
                        cmd.Parameters.AddWithValue("@TelNo", TELNO);
                        cmd.Parameters.AddWithValue("@MobileNo", MOBILENO);
                        cmd.Parameters.AddWithValue("@ContactPerson", CONTACTPERSON);
                        cmd.Parameters.AddWithValue("@AddInfo", ADDINFO);
                        cmd.Parameters.AddWithValue("@BarangayCode", BARANGAYCODE);
                        cmd.Parameters.AddWithValue("@CityCode", CITYCODE);
                        cmd.Parameters.AddWithValue("@Email", EMAIL);
                        cmd.Parameters.AddWithValue("@Remarks", REMARKS);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@APPBACKOUT", _appbackout);
                        cmd.Parameters.AddWithValue("@DateEncode", DATEENCODE);
                        cmd.Parameters.AddWithValue("@DateUpdate", DATEUPDATE);
                        cmd.Parameters.AddWithValue("@UserCode", USERCODE);

                        //CREDENTIALS
                        cmd.Parameters.AddWithValue("@SNUM", SNUM);
                        cmd.Parameters.AddWithValue("@Form138", FORM138);
                        cmd.Parameters.AddWithValue("@BC", BC);
                        cmd.Parameters.AddWithValue("@Colored1x1", COLORED1X1);
                        cmd.Parameters.AddWithValue("@BrownEnvelope", BROWNENVELOPE);
                        cmd.Parameters.AddWithValue("@GM", GM);
                        cmd.Parameters.AddWithValue("@Recommendation", RECOMMENDATION);
                        cmd.Parameters.AddWithValue("@Form137", FORM137);
                        cmd.Parameters.AddWithValue("@NCAE", NCAE);
                        cmd.Parameters.AddWithValue("@Other", OTHER);


                    retAppInfo = cmd.ExecuteNonQuery();
                        

                     //PREVIOUS GRADE
                    cmd = new SqlCommand("spInsertPreviousGrade", cn, sqlTrans);
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SNUM", SNUM);
                    cmd.Parameters.AddWithValue("@ENGTOTAL", ENGTOTAL);
                    cmd.Parameters.AddWithValue("@SCITOTAL", SCITOTAL);
                    cmd.Parameters.AddWithValue("@MATHTOTAL", MATHTOTAL);
                    cmd.Parameters.AddWithValue("@FIRSTTOTAL", FIRSTTOTAL);
                    cmd.Parameters.AddWithValue("@SECONDTOTAL", SECONDTOTAL);
                    cmd.Parameters.AddWithValue("@THIRDTOTAL", THIRDTOTAL);
                    cmd.Parameters.AddWithValue("@FOURTHTOTAL", FOURTHTOTAL);
                    cmd.Parameters.AddWithValue("@ENG1", ENG1);
                    cmd.Parameters.AddWithValue("@ENG2", ENG2);
                    cmd.Parameters.AddWithValue("@ENG3", ENG3);
                    cmd.Parameters.AddWithValue("@ENG4", ENG4);
                    cmd.Parameters.AddWithValue("@SCI1", SCI1);
                    cmd.Parameters.AddWithValue("@SCI2", SCI2);
                    cmd.Parameters.AddWithValue("@SCI3", SCI3);
                    cmd.Parameters.AddWithValue("@SCI4", SCI4);
                    cmd.Parameters.AddWithValue("@MATH1", MATH1);
                    cmd.Parameters.AddWithValue("@MATH2", MATH2);
                    cmd.Parameters.AddWithValue("@MATH3", MATH3);
                    cmd.Parameters.AddWithValue("@MATH4", MATH4);
                    cmd.Parameters.AddWithValue("@LOWERENG", LOWERENG);
                    cmd.Parameters.AddWithValue("@LOWERSCI", LOWERSCI);
                    cmd.Parameters.AddWithValue("@LOWERMATH", LOWERMATH);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE", FINALAVERAGE);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE2", FINALAVERAGE2);
                    cmd.Parameters.AddWithValue("@DATEENCODE", DATEENCODE);
                    cmd.Parameters.AddWithValue("@DATEUPDATE", DATEUPDATE);
                    cmd.Parameters.AddWithValue("@USERCODE", USERCODE);
                    
                   retAppPrevGrade = cmd.ExecuteNonQuery();
                    

                    //SAVE the Entry
                    sqlTrans.Commit();

                    
                    }


                catch
                {
                    //Pull back the entry no save will be done.
                    sqlTrans.Rollback();
                }

            }

         
        
        }

        public void newApplicantISAMs(string _appno, string _appdate, string _apptype,
                                       string _lname, string _fname, string _mname,
                                       string _entrylevelcode, string _entryleveltype,
                                       string _entryYear, string _mail1, string _mail2,
                                       string _mail3, string _bday, 
                                       string _natCode, string _civilStatus, string _gender, double _prevgrade, string _dateEncode, string _usercode)
        {
            using (SqlConnection cn = new SqlConnection(ISAMSCS))
            {
                // string strSQL = "spInsertApplicant";
                string strSQL = "Insert Into Appl_Info_MF(appl_no,appl_date,appl_type,appl_lname,appl_fname,appl_mname, " +
                                "entry_level_code,entry_level_type,entry_year,mail_addr1, mail_addr2, mail_addr3, bday, natl_Code, civil_stat, sex, final_grade, date_time_sys,log_user_name) " +
                                "Values(@AppNo,@AppDate,@AppType,@Applname,@Appfname,@Appmname,@EntryLevelCode,@EntryLevelType, " +
                                "@EntryYear,@Mail1,@Mail2,@Mail3,@Bday,@natCode, @civilStatus, @gender,@finalgrade, @dateEncode, @userCode)";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@AppNo",_appno);
                    cmd.Parameters.AddWithValue("@AppDate", _appdate);
                    cmd.Parameters.AddWithValue("@AppType", _apptype);
                    cmd.Parameters.AddWithValue("@Applname", _lname);
                    cmd.Parameters.AddWithValue("@Appfname", _fname);
                    cmd.Parameters.AddWithValue("@Appmname", _mname);
                    cmd.Parameters.AddWithValue("@EntryLevelCode", _entrylevelcode);
                    cmd.Parameters.AddWithValue("@EntryLevelType", _entryleveltype);
                    cmd.Parameters.AddWithValue("@EntryYear", _entryYear);
                    cmd.Parameters.AddWithValue("@Mail1", _mail1);
                    cmd.Parameters.AddWithValue("@Mail2", _mail2);
                    cmd.Parameters.AddWithValue("@Mail3", _mail3);
                    cmd.Parameters.AddWithValue("@Bday", _bday);
                    cmd.Parameters.AddWithValue("@natCode", _natCode);
                    cmd.Parameters.AddWithValue("@civilStatus", _civilStatus);
                    cmd.Parameters.AddWithValue("@gender", _gender);
                    cmd.Parameters.AddWithValue("@finalgrade", _prevgrade);
                    cmd.Parameters.AddWithValue("@dateEncode", _dateEncode);
                    cmd.Parameters.AddWithValue("@userCode", _usercode);

                    cmd.ExecuteNonQuery();
                }
            }
        
        }

        public void updateApplicant(string APPTYPECODE, string LEVELTYPECODE, string STRANDCODE, DateTime APPDOA, string APPNUM,
                                 bool WLSTATUS, bool SSICHILD, string LASTNAME, string FIRSTNAME, string MIDDLENAME,
                                 string MI, string SUFFIX, string FULLNAME, string GENDERCODE, DateTime DOB,string POB, double AGE, string AGEONJUNE, bool SHORTBYJUNE, int SHORTMONTH, string TELNO,
                                 string MOBILENO, string CONTACTPERSON, string ADDINFO, string BARANGAYCODE, string CITYCODE, string EMAIL, string REMARKS, bool STAT, bool _appbackout,
                                 DateTime DATEENCODE, DateTime DATEUPDATE, string USERCODE,
                                 bool FORM138, bool BC, bool COLORED1X1, bool BROWNENVELOPE, bool GM, bool RECOMMENDATION, bool FORM137, bool NCAE, string OTHER)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                // string strSQL = "spInsertApplicant";

                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantINFO", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppTypeCode", APPTYPECODE);
                    cmd.Parameters.AddWithValue("@LevelTypeCode", LEVELTYPECODE);
                    cmd.Parameters.AddWithValue("@StrandCode", STRANDCODE);
                    cmd.Parameters.AddWithValue("@AppDOA", APPDOA);
                    cmd.Parameters.AddWithValue("@AppNum", APPNUM);
                    cmd.Parameters.AddWithValue("@WLStatus", WLSTATUS);
                    cmd.Parameters.AddWithValue("@SSIChild", SSICHILD);
                    cmd.Parameters.AddWithValue("@LastName", LASTNAME);
                    cmd.Parameters.AddWithValue("@FirstName", FIRSTNAME);
                    cmd.Parameters.AddWithValue("@MiddleName", MIDDLENAME);
                    cmd.Parameters.AddWithValue("@MI", MI);
                    cmd.Parameters.AddWithValue("@Suffix", SUFFIX);
                    cmd.Parameters.AddWithValue("@FullName", FULLNAME);
                    cmd.Parameters.AddWithValue("@GenderCode", GENDERCODE);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@POB", POB);
                    cmd.Parameters.AddWithValue("@Age", AGE);
                    cmd.Parameters.AddWithValue("@AgeOnJune", AGEONJUNE);
                    cmd.Parameters.AddWithValue("@ShortByJune", SHORTBYJUNE);
                    cmd.Parameters.AddWithValue("@ShortMonth", SHORTMONTH);
                    cmd.Parameters.AddWithValue("@TelNo", TELNO);
                    cmd.Parameters.AddWithValue("@MobileNo", MOBILENO);
                    cmd.Parameters.AddWithValue("@ContactPerson", CONTACTPERSON);
                    cmd.Parameters.AddWithValue("@AddInfo", ADDINFO);
                    cmd.Parameters.AddWithValue("@BarangayCode", BARANGAYCODE);
                    cmd.Parameters.AddWithValue("@CityCode", CITYCODE);
                    cmd.Parameters.AddWithValue("@Email", EMAIL);
                    cmd.Parameters.AddWithValue("@Remarks", REMARKS);
                    cmd.Parameters.AddWithValue("@Status", STAT);
                    cmd.Parameters.AddWithValue("@APPBACKOUT", _appbackout);
                    cmd.Parameters.AddWithValue("@DateUpdate", DATEUPDATE);
                    cmd.Parameters.AddWithValue("@UserCode", USERCODE);

                    //CREDENTIALS
                    cmd.Parameters.AddWithValue("@Form138", FORM138);
                    cmd.Parameters.AddWithValue("@BC", BC);
                    cmd.Parameters.AddWithValue("@Colored1x1", COLORED1X1);
                    cmd.Parameters.AddWithValue("@BrownEnvelope", BROWNENVELOPE);
                    cmd.Parameters.AddWithValue("@GM", GM);
                    cmd.Parameters.AddWithValue("@Recommendation", RECOMMENDATION);
                    cmd.Parameters.AddWithValue("@Form137", FORM137);
                    cmd.Parameters.AddWithValue("@NCAE", NCAE);
                    cmd.Parameters.AddWithValue("@Other", OTHER);

                    cn.Open();
                    cmd.ExecuteNonQuery();


                    

                }

            }
        
        }

     


        public void PreviousGrade(string SNUM, double ENGTOTAL, double SCITOTAL, double MATHTOTAL, double FIRSTTOTAL, double SECONDTOTAL, double THIRDTOTAL,
                                  double FOURTHTOTAL, double ENG1, double ENG2, double ENG3, double ENG4, double SCI1, double SCI2, double SCI3, double SCI4,
                                  double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE, double FINALAVERAGE2,
                                  DateTime DATENCODE, DateTime DATEUPDATE, string USERCODE)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertPreviousGrade", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SNUM", SNUM);
                    cmd.Parameters.AddWithValue("@ENGTOTAL", ENGTOTAL);
                    cmd.Parameters.AddWithValue("@SCITOTAL", SCITOTAL);
                    cmd.Parameters.AddWithValue("@MATHTOTAL", MATHTOTAL);
                    cmd.Parameters.AddWithValue("@FIRSTTOTAL", FIRSTTOTAL);
                    cmd.Parameters.AddWithValue("@SECONDTOTAL", SECONDTOTAL);
                    cmd.Parameters.AddWithValue("@THIRDTOTAL", THIRDTOTAL);
                    cmd.Parameters.AddWithValue("@FOURTHTOTAL", FOURTHTOTAL);
                    cmd.Parameters.AddWithValue("@ENG1", ENG1);
                    cmd.Parameters.AddWithValue("@ENG2", ENG2);
                    cmd.Parameters.AddWithValue("@ENG3", ENG3);
                    cmd.Parameters.AddWithValue("@ENG4", ENG4);
                    cmd.Parameters.AddWithValue("@SCI1", SCI1);
                    cmd.Parameters.AddWithValue("@SCI2", SCI2);
                    cmd.Parameters.AddWithValue("@SCI3", SCI3);
                    cmd.Parameters.AddWithValue("@SCI4", SCI4);
                    cmd.Parameters.AddWithValue("@MATH1", MATH1);
                    cmd.Parameters.AddWithValue("@MATH2", MATH2);
                    cmd.Parameters.AddWithValue("@MATH3", MATH3);
                    cmd.Parameters.AddWithValue("@MATH4", MATH4);
                    cmd.Parameters.AddWithValue("@LOWERENG", LOWERENG);
                    cmd.Parameters.AddWithValue("@LOWERSCI", LOWERSCI);
                    cmd.Parameters.AddWithValue("@LOWERMATH", LOWERMATH);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE", FINALAVERAGE);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE2", FINALAVERAGE2);
                    cmd.Parameters.AddWithValue("@DATEENCODE", DATENCODE);
                    cmd.Parameters.AddWithValue("@DATEUPDATE", DATEUPDATE);
                    cmd.Parameters.AddWithValue("@USERCODE", USERCODE);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    

                }
            }
            
        }


        public void updatePreviousGrade(string SNUM, double ENGTOTAL, double SCITOTAL, double MATHTOTAL, double FIRSTTOTAL, double SECONDTOTAL, double THIRDTOTAL,
                                  double FOURTHTOTAL, double ENG1, double ENG2, double ENG3, double ENG4, double SCI1, double SCI2, double SCI3, double SCI4,
                                  double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE, double FINALAVERAGE2,
                                  DateTime DATEUPDATE, string USERCODE)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdatePreviousGrade", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SNUM", SNUM);
                    cmd.Parameters.AddWithValue("@ENGTOTAL", ENGTOTAL);
                    cmd.Parameters.AddWithValue("@SCITOTAL", SCITOTAL);
                    cmd.Parameters.AddWithValue("@MATHTOTAL", MATHTOTAL);
                    cmd.Parameters.AddWithValue("@FIRSTTOTAL", FIRSTTOTAL);
                    cmd.Parameters.AddWithValue("@SECONDTOTAL", SECONDTOTAL);
                    cmd.Parameters.AddWithValue("@THIRDTOTAL", THIRDTOTAL);
                    cmd.Parameters.AddWithValue("@FOURTHTOTAL", FOURTHTOTAL);
                    cmd.Parameters.AddWithValue("@ENG1", ENG1);
                    cmd.Parameters.AddWithValue("@ENG2", ENG2);
                    cmd.Parameters.AddWithValue("@ENG3", ENG3);
                    cmd.Parameters.AddWithValue("@ENG4", ENG4);
                    cmd.Parameters.AddWithValue("@SCI1", SCI1);
                    cmd.Parameters.AddWithValue("@SCI2", SCI2);
                    cmd.Parameters.AddWithValue("@SCI3", SCI3);
                    cmd.Parameters.AddWithValue("@SCI4", SCI4);
                    cmd.Parameters.AddWithValue("@MATH1", MATH1);
                    cmd.Parameters.AddWithValue("@MATH2", MATH2);
                    cmd.Parameters.AddWithValue("@MATH3", MATH3);
                    cmd.Parameters.AddWithValue("@MATH4", MATH4);
                    cmd.Parameters.AddWithValue("@LOWERENG", LOWERENG);
                    cmd.Parameters.AddWithValue("@LOWERSCI", LOWERSCI);
                    cmd.Parameters.AddWithValue("@LOWERMATH", LOWERMATH);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE", FINALAVERAGE);
                    cmd.Parameters.AddWithValue("@FINALAVERAGE2", FINALAVERAGE2);
                    cmd.Parameters.AddWithValue("@DATEUPDATE", DATEUPDATE);
                    cmd.Parameters.AddWithValue("@USERCODE", USERCODE);

                    cn.Open();

                    cmd.ExecuteNonQuery();


                }
            }
        
        }



       

        /// <summary>
        /// GETTING DATA SECTION
        /// </summary>
        /// <returns></returns>

        public DataTable getApplicant()
        { 
            DataTable dt = new DataTable();
            //string strSQL = "Select AppNum, Fullname, levelTypeCode, WLStatus, SSIChild, LevelTypeCode, GenderCode from Admission.App_Info_MF order by FirstName";
            //string strSQL = "SELECT a.AppNum, a.Fullname, a.levelTypeCode, a.WLStatus, a.SSIChild, a.LevelTypeCode, a.GenderCode, b.Remarks as statRemarks " + 
            //                "From Admission.App_Info_MF a INNER JOIN xSystem.ApplicantStatusTrail_RF b " +
            //                "ON a.StatCode = b.statCode Order by Fullname";
            string strSQL = "sp_ApplicantListTrail";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;
      
        }

        public DataSet getApplicantCountDetails()
        {
            DataSet ds = new DataSet();
            string strSQL = "spCountApplicantDetails";
            ds = queryCommandDS_StoredProc(strSQL);
            return ds;
        }

        public DataTable getDetailsApplicant()
        {
         DataTable dt = new DataTable();
         string strSQL = "SELECT * from vAppInfoCredentials";
         dt = queryCommandDT(strSQL);
         return dt;
        }

        public DataTable getPrevGrade()
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT SNUM, Eng1,Eng2,Eng3,Eng4,Sci1,Sci2,Sci3,Sci4,Math1,Math2,Math3,Math4 from Admission.PreviousGrade_MF";
            dt = queryCommandDT(strSQL);
            return dt;
        }


        //ISAMS SOURCE - RESERVATION LIST OLD
        //11-5-2015
        //modify SIMS SOURCE - RESERVATION LIST OLD
        //04-19-2016
        public DataTable getStudentReserveList()
        {
            DataTable dt = new DataTable();
            //string strSQL = "Sims_CountReservedStudentOLD";
            string strSQL = "spCountReserveStudent_OLD";
            //string strSQL = "Select Count(*) from Student_MF where studtype = 'O' and statcode = 'EN'";
            //dt = ISAMSqueryCommandDT_StoredProc(strSQL);
            dt = queryCommandDT(strSQL);
            return dt;
        }

        //ISAMS SOURCE - RESERVATION LIST NEW
        //modify SIMS SOURCE - RESERVATION LIST NEW
        //04-19-2016
        public DataTable getStudentReserveNewList()
        {
            DataTable dt = new DataTable();
            //string strSQL = "Sims_CountReservedStudentNEW";
            //dt = ISAMSqueryCommandDT_StoredProc(strSQL);

            string strSQL = "spCountReserveStudent_NEW";
            dt = queryCommandDT(strSQL);
            return dt;
        }

        //SIMS SOURCE - TOTAL RESERVED
        //04-19-2016
        public DataTable getStudentTOTALReservedList()
        {
            DataTable dt = new DataTable();
            //string strSQL = "Sims_CountReservedStudentNEW";
            //dt = ISAMSqueryCommandDT_StoredProc(strSQL);

            string strSQL = "spCountTOTALReserveStudent";
            dt = queryCommandDT(strSQL);
            return dt;
        }

        public DataTable getORTestingList()
        { 
            DataTable dt = new DataTable();
            string strSQL = "Sims_DisplayTestingOR";
            dt = ISAMSqueryCommandDT_StoredProc(strSQL);
            return dt;
        }


        //CHECKING TESTING receipt no in ISAMS
        public bool CHECKING_OR_INPUT(string _input)
        {
            bool x = false;
            using (SqlConnection cn = new SqlConnection(ISAMSCS))
            {
                using (SqlCommand cmd = new SqlCommand("Sims_CheckTestingOR", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RECEIPTNO",  _input);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        x = true;
                    }
                    else
                    {
                        x = false;
                    }

                }
            }

            return x;
        }


        public int getStudentTotalReservedCount()
        {
            int iCount = 0;
            using (SqlConnection cn = new SqlConnection(ISAMSCS))
            {
                string strSQL = "Sims_CountReservedStudent";

                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                iCount = (int)cmd.ExecuteScalar();
            }

            return iCount;
        }

    }


    //CLASS FOR SCHEDULING AND ENCODING OF APPLICANT SCREENING RESULT

    public class ApplicantSchedule: cBase
    {
        
        //FIELDS
        public string _OR { get; set; }
        public int _EXAMID { get; set; }
        public int _INTID { get; set; }
        public int _SCHEDSTAT { get; set; }
        public bool _ISFREE { get; set; }
        public bool _ISPASSED { get; set; }


        //Inserting Appicant Schedule
        public void InsertApplicantSchedule(string _appNum, string _orNum, int _examID, int _intID, 
                                            int _schedStat, bool _isfree, DateTime _di, string _userCode)
        {
            {
                using (SqlConnection cn = new SqlConnection(CS))
                {

                    using (SqlCommand cmd = new SqlCommand("spInsertApplicantSchedule", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@APPNUM", _appNum);
                        cmd.Parameters.AddWithValue("@OR", _orNum);
                        cmd.Parameters.AddWithValue("@EXAMID", _examID);
                        cmd.Parameters.AddWithValue("@INTID", _intID);
                        cmd.Parameters.AddWithValue("@SCHEDSTAT", _schedStat);
                        cmd.Parameters.AddWithValue("@ISFREE", _isfree);
                        cmd.Parameters.AddWithValue("@DI", _di);
                        cmd.Parameters.AddWithValue("@USERCODE", _userCode);

                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public void UpdateApplicantSchedule(string _appNum, string _orNum, int _examID, int _intID,
                                            int _schedStat, bool _isfree, DateTime _du, string _userCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
              
                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantSchedule", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appNum);
                    cmd.Parameters.AddWithValue("@OR", _orNum);
                    cmd.Parameters.AddWithValue("@EXAMID", _examID);
                    cmd.Parameters.AddWithValue("@INTID", _intID);
                    cmd.Parameters.AddWithValue("@SCHEDSTAT", _schedStat);
                    cmd.Parameters.AddWithValue("@ISFREE", _isfree);
                    cmd.Parameters.AddWithValue("@DU", _du);
                    cmd.Parameters.AddWithValue("@USERCODE", _userCode);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        
        //Decrease available slot of scheduled by one in Screening Schedule setup
        public void updateScreeingSetupSlot(int _id)
        { 
             using (SqlConnection cn = new SqlConnection(CS))
            {
              
                using (SqlCommand cmd = new SqlCommand("spUpdateScreeningSetupSlot", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);
                     cn.Open();

                    cmd.ExecuteNonQuery();
                }
             }
        }

        

        public bool checkExistAppInSchedule(string _appNum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select AppNum,AppOR,ExamID,IntID,SchedStat,isfree,ispassed from [Admission].[App_ScreeningSchedule_MF] where AppNum ='" + _appNum + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        x = true;
                        while (dr.Read())
                        {
                            _OR = dr["AppOR"].ToString();
                            _EXAMID = (int)dr["ExamID"];
                            _INTID = (int)dr["IntID"];
                            _SCHEDSTAT = (int)dr["SchedStat"];
                            _ISFREE = (bool)dr["ISFREE"];
                            _ISPASSED = (bool)dr["IsPassed"];
                        }

                    }

                    else
                    {
                        x = false;
                    }

                    return x;
                }
            }

        }

        //check if receiptno in use
        public bool CHECK_EXIST_OR(string _or)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select AppOR from [Admission].[App_ScreeningSchedule_MF] where AppOR ='" + _or + "'";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        x = true;
                    }

                    else
                    {
                        x = false;
                    }

                    return x;
                }
            }
        }
   
        //Displaying List of Applicant for Scheduling
        public DataTable getApplicantForScheduling()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayApplicantForScheduling", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


    

        //Display on each row inside gridview base on exam type parameter I- Interview / E-Examination
        //Stored Procedure
        //11-12-2015 Russel Vasquez
        
        
        public DataTable getScheduleList(string _ExamType)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayExamScheduleList", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ScreeningCode", _ExamType);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        //UPDATE APPLICANT STATUS TRAIL TABLE
        public void UPDATE_ApplicantStatusTrail(string _snum, int _statusCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spApplicantClearSchedule";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _snum);
                    cmd.Parameters.AddWithValue("@SCHEDSTAT", _statusCode);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

 

    }// End of Scheduling Class


    public class   ApplicantTesting : cBase
    {
        //Fields
        public string _APPNUM { get; set; }
        public string _FULLNAME { get; set; }
        public string _LEVELTYPECODE { get; set; }
        public DateTime _DOB { get; set; }
        public double _PREVGRADE { get; set; }
        public string _EXAMSCHED { get; set; }
        public string _INTSCHED { get; set; }
        public string _AGEBYJUNE { get; set; }
        public string _GENDERCODE { get; set; }
        public bool _RETESTSTATUS { get; set; }

        //FOR SAP STUDENT NAME COMBINATION
        public string _SAP_FN_FORMAT { get; set; }

        public string _LEVELCATCODE { get; set; }
        //For Retrieval of Testing Record
        public string _SCORES { get; set; }
        public string _RESULT { get; set; }

        //SUMMARY Retrieval
        public string _PREV { get; set; }
        public string _PREVRESULT { get; set; }
        public string _ASSESSMENT { get; set; }
        public string _OVERALL { get; set; }
        public string _OBSERVATION { get; set; }
        public string _STATCODE { get; set; }


        //RESULT SLIP Retrieval 02/16/2016
        public DateTime _DATECREATED { get; set; }
        public string _ADDRESSTO { get; set; }
        public DateTime _DATEEXPIRED { get; set; }
        public int _RESULTTYPE { get; set; }


        //--------------------------------------------------------

        //Display Applicant Information Briefly
        //11-23-2015
        public bool displayApplicantInfo(string _appnum)
        {
            bool x = false;

          using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayApplicantInfoForTesting", cn))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        x = true;
                        while (rdr.Read())
                        {
                            _APPNUM = rdr["AppNum"].ToString();
                            _FULLNAME = rdr["Fullname"].ToString();
                            _SAP_FN_FORMAT = rdr["StandardFullName"].ToString();
                            _LEVELCATCODE = rdr["LevelCatCode"].ToString();
                            _LEVELTYPECODE = rdr["LevelTypeCode"].ToString();
                            _DOB = (DateTime) rdr["DOB"];

                            if (Convert.ToDouble(rdr["FinalAverage"]) == 0 || string.IsNullOrEmpty(rdr["FinalAverage"].ToString()))
                            //if(Convert.ToDouble(rdr["FinalAverage"]) == 0 || rdr["FinalAverage"])
                            {
                                _PREVGRADE = (double)rdr["FinalAverage2"];
                            }
                            else
                            {
                                _PREVGRADE = (double)rdr["FinalAverage"];
                            }

                            //THIS CONDITION WILL IDENTIFY HOW TESTING 
                            //PROCEDURE WILL ACT.
                            //RUSSEL VASQUEZ 01/29/2016
                            if (Convert.ToInt32(rdr["SchedStat"].ToString()) == 4)
                            {
                                _RETESTSTATUS = true;
                            }
                            else
                            {
                                _RETESTSTATUS = false;
                            }


                            _EXAMSCHED = rdr["ExamSched"].ToString();
                            _INTSCHED = rdr["IntSched"].ToString();
                            _AGEBYJUNE = rdr["AgeOnJune"].ToString();
                            _GENDERCODE = rdr["GenderCode"].ToString();
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

        /*Retrieve Record
         * Changes Entry if applicant not yet and need for re-evaluating Passed
         * 11/27/2015
         * Russel Vasquez
        */

        public bool ExistAppTest(string _appnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spCheckAppTest", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {

                        while (rdr.Read())
                        {
                            _SCORES = rdr["Scores"].ToString();
                        
                        }

                        x = true;
                    }
                    else
                    {
                        x = false;
                    }
                }
            }

            return x;
        }

        //Will check if applicant already exist on student information
        public bool CHECKAPPEXISTSTUDENT(string _appnum)
        {  
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spCheckApplicantInRegistrationExist", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {

                        x = true;
                    }
                    else
                    {
                        x = false;
                    }
                }
            }

            return x;
        
        }

        //Check applicant record on result slip table
        public bool CHECK_APPRESULTSLIP(string _appnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spCheckAppResultSlip", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {

                        while (rdr.Read())
                        {
                            _DATECREATED = Convert.ToDateTime(rdr["DateCreated"]);
                            _ADDRESSTO = rdr["AddressTo"].ToString();
                            _DATEEXPIRED = Convert.ToDateTime(rdr["DateExpired"]);
                            _RESULTTYPE = Convert.ToInt16(rdr["ResultType"]);
                        }

                        x = true;
                    }
                    else
                    {
                        x = false;
                    }
                }
            }

            return x;
        }



        public void UPDATE_APPLICANT_SCHEDULE_STATUS(string _appnum)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantScheduleStatusToDisable", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DISPLAY testing list Components
        public DataTable displayTestingList(string _levelType)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayApplicantTestingList", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LEVELTYPE", _levelType);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
     
        }

        //RETRIEVE SCORES OF APPLICANT
        public bool RetrieveTestingRecord(string _appnum, string _ttcode)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spRetrieveTestResult", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@TTCODE", _ttcode);

                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        x = true;

                        while (rdr.Read())
                        {
                            _SCORES = rdr["Scores"].ToString();
                            _RESULT = rdr["Result"].ToString();

                            _PREV = rdr["PREV"].ToString();
                            _PREVRESULT = rdr["PREVRESULT"].ToString();
                             _ASSESSMENT = rdr["ASSESSMENTRESULT"].ToString();
                            _OVERALL = rdr["OVERALL"].ToString();
                            _OBSERVATION = rdr["OBSERVATION"].ToString();
                            _STATCODE = rdr["STATCODE"].ToString();
                        }

                      
                    }

                }
            }

            return x;
            

        }
        
        //DISPLAY LIST OF APPLICANT THAT PASSED 
        public DataTable DISPLAY_APPLICANTPASSED()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT APPNUM, Fullname, LeveltypeCode FROM vr_ListPassedApp order by Name", cn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        //Display List of Applicant That passed with Parameter
        public DataTable DISPLAY_APPLICANTPASSED(string _levelType)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT APPNUM, Fullname, LeveltypeCode FROM vr_ListPassedApp where LevelTypeCode=@LEVELTYPE order by Name",cn))
                {
                    cmd.Parameters.AddWithValue("@LEVELTYPE", _levelType);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable DISPLAY_APPLICANTFAILED()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT APPNUM, Fullname, LeveltypeCode FROM vr_ListFailedApp order by Name", cn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }
        //Display List of Applicant That passed with Parameter
        public DataTable DISPLAY_APPLICANTFAILED(string _levelType)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT APPNUM, Fullname, LeveltypeCode FROM vr_ListFailedApp where LevelTypeCode=@LEVELTYPE order by Name", cn))
                {
                    cmd.Parameters.AddWithValue("@LEVELTYPE", _levelType);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        /* TRANSACTION AREA */

        //INSERT APPLICANT TEST RESULT

        public void INSERTRESULT(string _appnum, string _ttcode, double _scores, double _result, bool _retest, string _usercode)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertApplicantTestResult", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@TTCODE", _ttcode);
                    cmd.Parameters.AddWithValue("@SCORES", _scores);
                    cmd.Parameters.AddWithValue("@RESULT", _result);
                    cmd.Parameters.AddWithValue("@RETEST", _retest);
                    cmd.Parameters.AddWithValue("@USERCODE", _usercode);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }


        public void INSERTSUMMARYRESULT(string _appnum, double _prev, double _prevresult, double _assessmentresult,
                                        double _overall, string _observation, string _statcode, bool _retest, string _usercode)

        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertApplicantTestSummary", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@PREV",_prev);
                    cmd.Parameters.AddWithValue("@PREVRESULT",_prevresult);
                    cmd.Parameters.AddWithValue("@ASSESSMENTRESULT", _assessmentresult);
                    cmd.Parameters.AddWithValue("@OVERALL", _overall);
                    cmd.Parameters.AddWithValue("@OBSERVATION", _observation);
                    cmd.Parameters.AddWithValue("@STATCODE", _statcode);
                    cmd.Parameters.AddWithValue("@RETEST", _retest);
                    cmd.Parameters.AddWithValue("@USERCODE", _usercode);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        
        }

        //INSERT INTO Result Slip Table 02-16-2016
        public void INSERT_RESULTSLIP(string _appnum, DateTime _dateCreated, string _addressTo, DateTime _dateExpired, int _resultType, string _userId)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertApplicantResultSlip", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@DATECREATED", _dateCreated);
                    cmd.Parameters.AddWithValue("@ADDRESSTO", _addressTo);
                    cmd.Parameters.AddWithValue("@DATEEXPIRED", _dateExpired);
                    cmd.Parameters.AddWithValue("@RESULTTYPE", _resultType);
                    cmd.Parameters.AddWithValue("@USERID", _userId);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //UPDATE APPLICANT TEST RESULT

        public void UPDATERESULT(string _appnum, string _ttcode, double _scores, double _result, string _usercode)
        {
         using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantTestResult", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@TTCODE", _ttcode);
                    cmd.Parameters.AddWithValue("@SCORES", _scores);
                    cmd.Parameters.AddWithValue("@RESULT", _result);
                    cmd.Parameters.AddWithValue("@USERCODE", _usercode);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UPDATESUMMARYRESULT(string _appnum, double _prev, double _prevresult, double _assessmentresult,
                                        double _overall, string _observation, string _statcode, string _usercode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantTestSummary", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@PREV", _prev);
                    cmd.Parameters.AddWithValue("@PREVRESULT", _prevresult);
                    cmd.Parameters.AddWithValue("@ASSESSMENTRESULT", _assessmentresult);
                    cmd.Parameters.AddWithValue("@OVERALL", _overall);
                    cmd.Parameters.AddWithValue("@OBSERVATION", _observation);
                    cmd.Parameters.AddWithValue("@STATCODE", _statcode);
                    cmd.Parameters.AddWithValue("@USERCODE", _usercode);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        
        //UPDATE APPLICANT RESULT SLIP
        public void UPDATE_RESULTSLIP(string _appnum, DateTime _dateCreated, string _addressTo, DateTime _dateExpired, int _resultType, string _userId)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateApplicantResultSlip", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@DATECREATED", _dateCreated);
                    cmd.Parameters.AddWithValue("@ADDRESSTO", _addressTo);
                    cmd.Parameters.AddWithValue("@DATEEXPIRED", _dateExpired);
                    cmd.Parameters.AddWithValue("@RESULTTYPE", _resultType);
                    cmd.Parameters.AddWithValue("@USERID", _userId);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
        //

    }//END OF CLASS

    //CLASS of HEALTH APPLICANT

  






}//End of Namespace
