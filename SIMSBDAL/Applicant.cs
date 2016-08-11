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
                                 string MI, string SUFFIX, string FULLNAME, string GENDERCODE, DateTime DOB, string POB, double AGE, bool SHORTBYJUNE, int SHORTMONTH, string TELNO,
                                 string MOBILENO, string CONTACTPERSON, string ADDINFO, string BARANGAYCODE, string CITYCODE, string EMAIL, string REMARKS, bool Status, 
                                 DateTime DATEENCODE, DateTime DATEUPDATE, string USERCODE,
                                string SNUM, bool FORM138, bool BC, bool COLORED1X1, bool BROWNENVELOPE, bool GM, bool RECOMMENDATION, bool FORM137, bool NCAE, string OTHER,
                                double ENGTOTAL, double SCITOTAL, double MATHTOTAL, double FIRSTTOTAL, double SECONDTOTAL, double THIRDTOTAL,
                                double FOURTHTOTAL, double ENG1, double ENG2, double ENG3, double ENG4, double SCI1, double SCI2, double SCI3, double SCI4,
                                double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE)
       
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
                                       string _natCode, string _civilStatus, string _gender, string _dateEncode, string _usercode)
        {
            using (SqlConnection cn = new SqlConnection(ISAMSCS))
            {
                // string strSQL = "spInsertApplicant";
                string strSQL = "Insert Into Appl_Info_MF(appl_no,appl_date,appl_type,appl_lname,appl_fname,appl_mname, " +
                                "entry_level_code,entry_level_type,entry_year,mail_addr1, mail_addr2, mail_addr3, bday, natl_Code, civil_stat, sex, date_time_sys,log_user_name) " +
                                "Values(@AppNo,@AppDate,@AppType,@Applname,@Appfname,@Appmname,@EntryLevelCode,@EntryLevelType, " +
                                "@EntryYear,@Mail1,@Mail2,@Mail3,@Bday,@natCode, @civilStatus, @gender, @dateEncode, @userCode)";

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
                    cmd.Parameters.AddWithValue("@dateEncode", _dateEncode);
                    cmd.Parameters.AddWithValue("@userCode", _usercode);

                    cmd.ExecuteNonQuery();
                }
            }
        
        }

        public void updateApplicant(string APPTYPECODE, string LEVELTYPECODE, string STRANDCODE, DateTime APPDOA, string APPNUM,
                                 bool WLSTATUS, bool SSICHILD, string LASTNAME, string FIRSTNAME, string MIDDLENAME,
                                 string MI, string SUFFIX, string FULLNAME, string GENDERCODE, DateTime DOB,string POB, double AGE, bool SHORTBYJUNE, int SHORTMONTH, string TELNO,
                                 string MOBILENO, string CONTACTPERSON, string ADDINFO, string BARANGAYCODE, string CITYCODE, string EMAIL, string REMARKS, bool STAT,
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
                                  double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE,
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
                                  double MATH1, double MATH2, double MATH3, double MATH4, bool LOWERENG, bool LOWERSCI, bool LOWERMATH, double FINALAVERAGE,
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


    }


    //CLASS FOR SCHEDULING AND ENCODING OF APPLICANT SCREENING RESULT

    public class ApplicantSchedule: cBase
    {
    
     //Inserting Appicant Schedule
        public void InsertApplicantSchedule(string _appNum, string _orNum, string _screeningCode, string _userCode)
        {
            {
                using (SqlConnection cn = new SqlConnection(CS))
                {
                    string strSQL = "INSERT INTO Admission.App_ScreeningSchedule_MF(AppNum,AppOR,ScreeningCode,UserCode) " +
                                    "VALUES (@AppNum, @ORNum, @ScreeningCode, @UserCode)";

                    using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@AppNum", _appNum);
                        cmd.Parameters.AddWithValue("@ORNum", _orNum);
                        cmd.Parameters.AddWithValue("@ScreeningCode", _screeningCode);
                        cmd.Parameters.AddWithValue("@UserCode", _userCode);

                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }




        public bool checkExistInSchedule(string _appNum, string _screeningCode)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select ScreeningCode, AppNum  from [Admission].[App_ScreeningSchedule_MF] where ScreeningCode = '" + _screeningCode + "' and AppNum ='" + _appNum + "'";

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
        public DataTable getApplicantForScheduling(string _AppTypeCode, string _LevelTypeCode)
        {

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayApplicantForScheduling", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppTypeCode", _AppTypeCode);
                    cmd.Parameters.AddWithValue("@LevelTypeCode", _LevelTypeCode);
                    
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable getScheduleList(string _levelType)
        {

            string ExamOnly = "E";
            string strSQL = "";

            DataTable dt = new DataTable();

            /*Validate Level Type
            //Nursery to Grade3 Schedule display will be Examination only
            //While the rest Both Examination and Interview
            //10/09/2015 as Ms. Rona Info
            Russel Vasquez */

            if (_levelType == "P1" || _levelType == "P2" || _levelType =="P3" || _levelType =="G1" || _levelType =="G2" || _levelType == "G3")
            {
                strSQL = "Select a.ID, a.Sdate, a.Stime, a.SDesc, b.ScreeningDesc, b.ScreeningCode " +
                               "From Admission.ScreeningSetup_RF a " +
                               "Inner Join Utilities.ScreeningType_RF b " +
                               "On a.ScreeningCode = b.ScreeningCode " +
                               "Where a.Status= '" + true + "' and a.ScreeningCode ='" + ExamOnly + "' Order by a.Sdate Desc";
            }

            else
            {
                strSQL = "Select a.ID, a.Sdate, a.Stime, a.SDesc, b.ScreeningDesc, b.ScreeningCode " +
                               "From Admission.ScreeningSetup_RF a " +
                               "Inner Join Utilities.ScreeningType_RF b " +
                               "On a.ScreeningCode = b.ScreeningCode " +
                               "Where a.Status= '" + true + "' Order by a.Sdate Desc";
            }

            dt = queryCommandDT(strSQL);

            return dt;
        }



    }// End of Scheduling Class



    public class Health : cBase
    {

        public DataTable getApplicantClinicList()
        {

            DataTable dt = new DataTable();
            //string strSQL = "Select AppNum, Fullname, levelTypeCode, WLStatus, SSIChild, LevelTypeCode, GenderCode from Admission.App_Info_MF order by FirstName";
            //string strSQL = "SELECT a.AppNum, a.Fullname, a.levelTypeCode, a.WLStatus, a.SSIChild, a.LevelTypeCode, a.GenderCode, b.Remarks as statRemarks " + 
            //                "From Admission.App_Info_MF a INNER JOIN xSystem.ApplicantStatusTrail_RF b " +
            //                "ON a.StatCode = b.statCode Order by Fullname";
            string strSQL = "sp_ApplicantClinicList";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;

        }

        public DataTable getHealthIllness()
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT * from xSystem.Health_Illness_RF Order by Arr";
            dt = queryCommandDT(strSQL);
            return dt;
        }

        public DataTable getMedicineMayGiven()
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT * from xSystem.Health_GivenMed_RF Order by Arr";
            dt = queryCommandDT(strSQL);
            return dt;
        }


        //public DataTable retrieveHealthIllness()
        //{
        //    DataTable dt = new DataTable();
           
        //    string strSQL = "Select SIF.SNUM, SIF.IllnessCode, SIF.IsChecked, XSIF.IllnessDesc, XSIF.CatID " +
        //                    "From Health.Stud_Illness_MF SIF " +
        //                    "INNER JOIN xSystem.Health_Illness_RF XSIF " +
        //                    "ON SIF.IllnessCode = XSIF.IllnessCode";
            
        //    dt = queryCommandDT(strSQL);
        //    return dt;
        //}

        //public DataTable retrieveHealthMedicine()
        //{
        //    DataTable dt = new DataTable();

        //    string strSQL = "Select SGM.SNUM, SGM.MedCode, SGM.IsChecked, XSGM.MedDesc " +
        //                    "From Health.Stud_GivenMed_MF SGM " + 
        //                    "INNER JOIN xSystem.Health_GivenMed_RF XSGM " +
        //                    "ON SGM.MedCode = XSGM.MedCode ";
        //    dt = queryCommandDT(strSQL);
        //    return dt;
        //}


        public DataSet retrieveHealth(string _SNUM)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spRetrieveHealth", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SNUM", _SNUM);
                 

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }

            return ds;
            
        }

        
        public bool ExsistRecord(string _SNUM)
        {

            bool x = false;


            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "Select snum from Health.Stud_Health_Info_MF where SNUM= '" + _SNUM + "'";

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



        //Transaction

        public void insertIllness(string _snum, string _illnesscode, bool _ischecked)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "INSERT INTO Health.Stud_Illness_MF(SNUM,IllnessCode,IsChecked) " +
                                "VALUES(@SNUM, @IllnessCode, @IsChecked)";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@SNUM", _snum);
                        cmd.Parameters.AddWithValue("@IllnessCode", _illnesscode);
                        cmd.Parameters.AddWithValue("@IsChecked", _ischecked);

                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                    catch { }//Message HERE 
                }
            }



        }
        public void insertMedicine(string _snum, string _medCode, bool _ischecked)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "INSERT INTO Health.Stud_GivenMed_MF(SNUM,MedCode,IsChecked) " +
                                "VALUES(@SNUM, @MedCode, @IsChecked)";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@SNUM", _snum);
                        cmd.Parameters.AddWithValue("@MedCode", _medCode);
                        cmd.Parameters.AddWithValue("@IsChecked", _ischecked);

                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                    catch { }//Message HERE 
                }
            }

        }
      
        public void insertHealthRecord(string _snum, bool _iscongenital, string _congenital,
                                        bool _ishospitalized, string _dateHospitalized, string _reasonhospitalized,
                                        bool _isminormajor, string _minormajor, string _dateminormajor,
                                        bool _isaccident, string _accident, string _dateaccident, string _parentRemarks,
                                        string _nurserRemarks, string _healthStatusCode, int _AppstatusCode)
        {

            SqlDateTime sdtHospitalizedNull;
            SqlDateTime sdtMinorMajorDateNull;
            SqlDateTime sdtSeriousAccidentDateNull;

            
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "INSERT INTO Health.Stud_Health_Info_MF(SNUM,IsCongenital,CongenitalDesc,IsHospitalized,DateHospitalized,ReasonHospitalized, " +
                                "IsMinorMajor, MinorMajorDesc, MinorMajorDate,IsSeriousAccident,SeriousAccidentDesc,SeriousAccidentDate,ParentRemarks,NurseRemarks,HealthStatusCode) " +
                                "VALUES(@SNUM, @IsCongenital, @CongenitalDesc,@IsHospitalized,@DateHospitalized,@ReasonHospitalized, " +
                                "@IsMinorMajor,@MinorMajorDesc,@MinorMajorDate,@IsSeriousAccident,@SeriousAccidentDesc,@SeriousAccidentDate, " +
                                "@ParentRemarks,@NurseRemarks,@HealthStatusCode)";



                cn.Open();
                SqlTransaction sqlTrans = cn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(strSQL, cn, sqlTrans);
                        //cmd.Parameters.Add(new SqlParameter("@DateHospitalized", SqlDbType.DateTime));
                        cmd.Parameters.AddWithValue("@SNUM", _snum);
                        cmd.Parameters.AddWithValue("@IsCongenital", _iscongenital);
                        cmd.Parameters.AddWithValue("@CongenitalDesc", _congenital);
                        cmd.Parameters.AddWithValue("@IsHospitalized", _ishospitalized);
                        //cmd.Parameters.AddWithValue("@DateHospitalized", _dateHospitalized);
                        cmd.Parameters.Add(new SqlParameter("@DateHospitalized", _dateHospitalized));
                        sdtHospitalizedNull = SqlDateTime.Null;
                        if (_dateHospitalized == "")
                        {
                            cmd.Parameters["@DateHospitalized"].Value = sdtHospitalizedNull;
                        }
                        else
                        {
                            cmd.Parameters["@DateHospitalized"].Value = DateTime.Parse(_dateHospitalized);
                        }
   
                        cmd.Parameters.AddWithValue("@ReasonHospitalized", _reasonhospitalized);
                        cmd.Parameters.AddWithValue("@IsMinorMajor", _isminormajor);
                        cmd.Parameters.AddWithValue("@MinorMajorDesc", _minormajor);
                       // cmd.Parameters.AddWithValue("@MinorMajorDate", _dateminormajor);
                        cmd.Parameters.Add(new SqlParameter("@MinorMajorDate", _dateminormajor));
                        sdtMinorMajorDateNull = SqlDateTime.Null;
                        if (_dateminormajor == "")
                        {
                            cmd.Parameters["@MinorMajorDate"].Value = sdtMinorMajorDateNull;
                        }
                        else
                        {
                            cmd.Parameters["@MinorMajorDate"].Value = DateTime.Parse(_dateminormajor);
                        }


                        cmd.Parameters.AddWithValue("@IsSeriousAccident", _isaccident);
                        cmd.Parameters.AddWithValue("@SeriousAccidentDesc", _accident);
                       // cmd.Parameters.AddWithValue("@SeriousAccidentDate", _dateaccident);
                        cmd.Parameters.Add(new SqlParameter("@SeriousAccidentDate", _dateaccident));
                        sdtSeriousAccidentDateNull = SqlDateTime.Null;
                        if (_dateaccident == "")
                        {
                            cmd.Parameters["@SeriousAccidentDate"].Value = sdtSeriousAccidentDateNull;
                        }
                        else
                        {
                            cmd.Parameters["@SeriousAccidentDate"].Value = DateTime.Parse(_dateaccident);
                        }

                        cmd.Parameters.AddWithValue("@ParentRemarks", _parentRemarks);
                        cmd.Parameters.AddWithValue("@NurseRemarks", _nurserRemarks);
                        cmd.Parameters.AddWithValue("@HealthStatusCode", _healthStatusCode);
                        


                   

                        cmd.ExecuteNonQuery();

                        //Another table interaction
                        string strSQLUpdateAppTrails = "UPDATE Admission.App_Trail_TF SET statCode=@statusCode " +
                                               "WHERE AppNum=@snum";
                        
                        cmd = new SqlCommand(strSQLUpdateAppTrails,cn, sqlTrans);
                        cmd.Parameters.AddWithValue("@snum", _snum);
                        cmd.Parameters.AddWithValue("@statusCode", _AppstatusCode);
                        cmd.ExecuteNonQuery();

                        sqlTrans.Commit();

                    }

                    catch
                    {
                    //Don't Continue the transaction of Saving
                    sqlTrans.Rollback();
                    }

            }
        }




     

        public void updateIllness(string _snum, string _illnesscode, bool _isChecked)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "UPDATE Health.Stud_Illness_MF SET IsChecked=@isChecked " +
                                "WHERE SNUM=@snum and IllnessCode=@IllnessCode ";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.Parameters.AddWithValue("@snum", _snum);
                    cmd.Parameters.AddWithValue("@IllnessCode", _illnesscode);
                    cmd.Parameters.AddWithValue("@isChecked", _isChecked);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        
        }

        public void updateMedicineGiven(string _snum, string _medCode, bool _isChecked)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "UPDATE Health.Stud_GivenMed_MF SET IsChecked=@isChecked " +
                                "WHERE SNUM=@snum and MedCode=@MedCode";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.Parameters.AddWithValue("@snum", _snum);
                    cmd.Parameters.AddWithValue("@MedCode", _medCode);
                    cmd.Parameters.AddWithValue("@isChecked", _isChecked);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


        public void updateHealthDetails(string _snum, bool _iscongenital, string _congenital,
                                        bool _ishospitalized, string _dateHospitalized, string _reasonhospitalized,
                                        bool _isminormajor, string _minormajor, string _dateminormajor,
                                        bool _isaccident, string _accident, string _dateaccident, string _parentRemarks,
                                        string _nurserRemarks, string _healthStatusCode)
        {

            SqlDateTime sdtHospitalizedNull;
            SqlDateTime sdtMinorMajorDateNull;
            SqlDateTime sdtSeriousAccidentDateNull;


            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "UPDATE Health.Stud_Health_Info_MF SET " +
                                "IsCongenital=@IsCongenital,CongenitalDesc=@CongenitalDesc, " +
                                "IsHospitalized=@IsHospitalized,DateHospitalized=@DateHospitalized,ReasonHospitalized=@ReasonHospitalized, " +
                                "IsMinorMajor=@IsMinorMajor, MinorMajorDesc=@MinorMajorDesc, MinorMajorDate=@MinorMajorDate, " +
                                "IsSeriousAccident=@IsSeriousAccident,SeriousAccidentDesc=@SeriousAccidentDesc,SeriousAccidentDate=@SeriousAccidentDate, " +
                                "ParentRemarks=@ParentRemarks,NurseRemarks=@NurseRemarks,HealthStatusCode=@HealthStatusCode " +
                                "Where SNUM=@SNUM";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    //try
                    //{
                    //cmd.Parameters.Add(new SqlParameter("@DateHospitalized", SqlDbType.DateTime));
                    cmd.Parameters.AddWithValue("@SNUM", _snum);
                    cmd.Parameters.AddWithValue("@IsCongenital", _iscongenital);
                    cmd.Parameters.AddWithValue("@CongenitalDesc", _congenital);
                    cmd.Parameters.AddWithValue("@IsHospitalized", _ishospitalized);
                    //cmd.Parameters.AddWithValue("@DateHospitalized", _dateHospitalized);
                    cmd.Parameters.Add(new SqlParameter("@DateHospitalized", _dateHospitalized));
                    sdtHospitalizedNull = SqlDateTime.Null;
                    if (_dateHospitalized == "")
                    {
                        cmd.Parameters["@DateHospitalized"].Value = sdtHospitalizedNull;
                    }
                    else
                    {
                        cmd.Parameters["@DateHospitalized"].Value = DateTime.Parse(_dateHospitalized);
                    }

                    cmd.Parameters.AddWithValue("@ReasonHospitalized", _reasonhospitalized);
                    cmd.Parameters.AddWithValue("@IsMinorMajor", _isminormajor);
                    cmd.Parameters.AddWithValue("@MinorMajorDesc", _minormajor);
                    // cmd.Parameters.AddWithValue("@MinorMajorDate", _dateminormajor);
                    cmd.Parameters.Add(new SqlParameter("@MinorMajorDate", _dateminormajor));
                    sdtMinorMajorDateNull = SqlDateTime.Null;
                    if (_dateminormajor == "")
                    {
                        cmd.Parameters["@MinorMajorDate"].Value = sdtMinorMajorDateNull;
                    }
                    else
                    {
                        cmd.Parameters["@MinorMajorDate"].Value = DateTime.Parse(_dateminormajor);
                    }


                    cmd.Parameters.AddWithValue("@IsSeriousAccident", _isaccident);
                    cmd.Parameters.AddWithValue("@SeriousAccidentDesc", _accident);
                    // cmd.Parameters.AddWithValue("@SeriousAccidentDate", _dateaccident);
                    cmd.Parameters.Add(new SqlParameter("@SeriousAccidentDate", _dateaccident));
                    sdtSeriousAccidentDateNull = SqlDateTime.Null;
                    if (_dateaccident == "")
                    {
                        cmd.Parameters["@SeriousAccidentDate"].Value = sdtSeriousAccidentDateNull;
                    }
                    else
                    {
                        cmd.Parameters["@SeriousAccidentDate"].Value = DateTime.Parse(_dateaccident);
                    }

                    cmd.Parameters.AddWithValue("@ParentRemarks", _parentRemarks);
                    cmd.Parameters.AddWithValue("@NurseRemarks", _nurserRemarks);
                    cmd.Parameters.AddWithValue("@HealthStatusCode", _healthStatusCode);



                    cn.Open();

                    cmd.ExecuteNonQuery();
                    //}
                    //catch { }//Message HERE 
                }
            }
        }



        public void updateApplicantStatusTrail(string _snum, int _statusCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "UPDATE Admission.App_Trail_TF SET statCode=@statusCode " +
                                "WHERE AppNum=@snum";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.Parameters.AddWithValue("@snum", _snum);
                    cmd.Parameters.AddWithValue("@statusCode", _statusCode);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

    }//End of Health Class






}//End of Namespace
