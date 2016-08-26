using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace SIMSBDAL
{

    public class Health: cBase
    {
        #region "Property Fields"
        
        public string MEDCODE { get; set; }
        public string MEDDESC { get; set; }
        public string MEDGENERICNAME { get; set; }
        public string MEDTYPE { get; set; }
        public string MEDLEVEL { get; set; }
        
        
        #endregion


        #region "GET-SELECT FUNCTIONS"


        public DataTable GET_APPLICANT_CLINIC_LIST()
        {

            DataTable dt = new DataTable();
            string strSQL = "sp_ApplicantClinicList";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;

        }

        public DataTable GET_STUDENT_ILLNESS()
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT * from xSystem.Health_Illness_RF Order by Arr";
            dt = queryCommandDT(strSQL);
            return dt;
        }

        public DataTable GET_STUDENT_MEDICINE_GIVEN()
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT * from xSystem.Health_GivenMed_RF Order by Arr";
            dt = queryCommandDT(strSQL);
            return dt;
        }


        public DataTable GET_COMPLAINT_LIST()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_COMPLAINT_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;   
        }

        public DataTable GET_MEDICINE_LIST()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_MEDICINE_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;   
        }

        public DataTable GET_MEDICINE_BATCH_LIST()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_MEDICINE_BATCH";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;  
        }
        

        //07.25.2016

        public DataTable GET_TIMEINCIDENT_LIST()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_TIME_INCIDENT_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;  
        }

        public DataTable GET_PLACEINCIDENT_LIST()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_PLACE_INCIDENT_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;
        }


        public DataTable GET_COMPLAINT_HISTORY(string _PATIENTNUM)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGET_COMPLAINT_HISTORY", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PATIENTNUM", _PATIENTNUM);


                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        //08/05/2016
        public DataTable GET_COMPLAINT_PATIENT_LIST(string _TRANSCODE)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGET_COMPLAINT_LIST_PATIENT", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TRANSCODE", _TRANSCODE);


                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GET_MEDICINE_PATIENT_LIST(string _TRANSCODE)
        { 
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGET_MEDICINE_LIST_PATIENT", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TRANSCODE", _TRANSCODE);


                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;

        }
        public DataSet RET_STUDENT_HEALTH_DETAILS(string _SNUM)
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


        public bool GET_EXIST_HEALTH_RECORD(string _SNUM)
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

        


        /*
         ================================================
         SETUP - MEDICINE GET
         ================================================ 
        */

        public DataTable GET_MEDICINE_TYPE()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_MEDICINE_TYPE";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;   

        }

        public DataTable GET_MEDICINE_LEVEL()
        {
            DataTable dt = new DataTable();
            string strSQL = "spGET_MEDICINE_LEVEL";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;

        }

        #endregion


        #region "INSERT-UPDATE-DELETE FUNCTIONS"


        public void INSERT_STUDENT_ILLNESS(string _snum, string _illnesscode, bool _ischecked)
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

        public void INSERT_STUDENT_MEDICINE_GIVEN(string _snum, string _medCode, bool _ischecked)
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

        public void INSERT_STUDENT_HEALTH_DETAILS(string _snum, bool _iscongenital, string _congenital,
                                        bool _ishospitalized, string _dateHospitalized, string _reasonhospitalized,
                                        bool _isminormajor, string _minormajor, string _dateminormajor,
                                        bool _isaccident, string _accident, string _dateaccident, string _parentRemarks,
                                        string _nurserRemarks, string _illOthers, string _healthStatusCode, int _AppstatusCode,
                                        DateTime _DI, string _USERID)
        {

            //SqlDateTime sdtHospitalizedNull;
            //SqlDateTime sdtMinorMajorDateNull;
            //SqlDateTime sdtSeriousAccidentDateNull;


            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "INSERT INTO Health.Stud_Health_Info_MF(SNUM,IsCongenital,CongenitalDesc,IsHospitalized,DateHospitalized,ReasonHospitalized, " +
                                "IsMinorMajor, MinorMajorDesc, MinorMajorDate,IsSeriousAccident,SeriousAccidentDesc,SeriousAccidentDate,ParentRemarks,NurseRemarks,illOthers,HealthStatusCode,DI,UserID) " +
                                "VALUES(@SNUM, @IsCongenital, @CongenitalDesc,@IsHospitalized,@DateHospitalized,@ReasonHospitalized, " +
                                "@IsMinorMajor,@MinorMajorDesc,@MinorMajorDate,@IsSeriousAccident,@SeriousAccidentDesc,@SeriousAccidentDate, " +
                                "@ParentRemarks,@NurseRemarks,@illOthers,@HealthStatusCode,@DI,@USERID)";



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
                    cmd.Parameters.AddWithValue("@DateHospitalized", _dateHospitalized);
                    //cmd.Parameters.Add(new SqlParameter("@DateHospitalized", _dateHospitalized));
                    //sdtHospitalizedNull = SqlDateTime.Null;
                    //if (_dateHospitalized == "")
                    //{
                    //    cmd.Parameters["@DateHospitalized"].Value = sdtHospitalizedNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@DateHospitalized"].Value = DateTime.Parse(_dateHospitalized);
                    //}

                    cmd.Parameters.AddWithValue("@ReasonHospitalized", _reasonhospitalized);
                    cmd.Parameters.AddWithValue("@IsMinorMajor", _isminormajor);
                    cmd.Parameters.AddWithValue("@MinorMajorDesc", _minormajor);
                    cmd.Parameters.AddWithValue("@MinorMajorDate", _dateminormajor);
                    //cmd.Parameters.Add(new SqlParameter("@MinorMajorDate", _dateminormajor));
                    //sdtMinorMajorDateNull = SqlDateTime.Null;
                    //if (_dateminormajor == "")
                    //{
                    //    cmd.Parameters["@MinorMajorDate"].Value = sdtMinorMajorDateNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@MinorMajorDate"].Value = DateTime.Parse(_dateminormajor);
                    //}


                    cmd.Parameters.AddWithValue("@IsSeriousAccident", _isaccident);
                    cmd.Parameters.AddWithValue("@SeriousAccidentDesc", _accident);
                    cmd.Parameters.AddWithValue("@SeriousAccidentDate", _dateaccident);
                    //cmd.Parameters.Add(new SqlParameter("@SeriousAccidentDate", _dateaccident));
                    //sdtSeriousAccidentDateNull = SqlDateTime.Null;
                    //if (string.IsNullOrEmpty(_dateaccident) || _dateaccident == "")
                    //{
                    //    cmd.Parameters["@SeriousAccidentDate"].Value = sdtSeriousAccidentDateNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@SeriousAccidentDate"].Value = DateTime.Parse(_dateaccident);
                    //}

                    cmd.Parameters.AddWithValue("@ParentRemarks", _parentRemarks);
                    cmd.Parameters.AddWithValue("@NurseRemarks", _nurserRemarks);
                    cmd.Parameters.AddWithValue("@HealthStatusCode", _healthStatusCode);
                    cmd.Parameters.AddWithValue("@illOthers", _illOthers);

                    cmd.Parameters.AddWithValue("@DI", _DI);
                    cmd.Parameters.AddWithValue("@UserID", _USERID);




                    cmd.ExecuteNonQuery();

                    /*COMMENTED 12/15/2015
                    //Another table interaction
                    string strSQLUpdateAppTrails = "UPDATE Admission.App_Trail_TF SET statCode=@statusCode " +
                                           "WHERE AppNum=@snum";
                        
                    cmd = new SqlCommand(strSQLUpdateAppTrails,cn, sqlTrans);
                    cmd.Parameters.AddWithValue("@snum", _snum);
                    cmd.Parameters.AddWithValue("@statusCode", _AppstatusCode);
                    cmd.ExecuteNonQuery();
                    */
                    sqlTrans.Commit();

                }

                catch
                {
                    //Don't Continue the transaction of Saving
                    sqlTrans.Rollback();
                }

            }
        }






        public void UPDATE_STUDENT_ILLNESS(string _snum, string _illnesscode, bool _isChecked)
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

        public void UPDATE_STUDENT_MEDICINE_GIVEN(string _snum, string _medCode, bool _isChecked)
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


        public void UPDATE_STUDENT_HEALTH_DETAILS(string _snum, bool _iscongenital, string _congenital,
                                        bool _ishospitalized, string _dateHospitalized, string _reasonhospitalized,
                                        bool _isminormajor, string _minormajor, string _dateminormajor,
                                        bool _isaccident, string _accident, string _dateaccident, string _parentRemarks,
                                        string _nurserRemarks, string _illOthers, string _healthStatusCode,
                                        DateTime _DU, string _USERID)
        {




            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "UPDATE Health.Stud_Health_Info_MF SET " +
                                "IsCongenital=@IsCongenital,CongenitalDesc=@CongenitalDesc, " +
                                "IsHospitalized=@IsHospitalized,DateHospitalized=@DateHospitalized,ReasonHospitalized=@ReasonHospitalized, " +
                                "IsMinorMajor=@IsMinorMajor, MinorMajorDesc=@MinorMajorDesc, MinorMajorDate=@MinorMajorDate, " +
                                "IsSeriousAccident=@IsSeriousAccident,SeriousAccidentDesc=@SeriousAccidentDesc,SeriousAccidentDate=@SeriousAccidentDate, " +
                                "ParentRemarks=@ParentRemarks,NurseRemarks=@NurseRemarks,illOthers=@illOthers,HealthStatusCode=@HealthStatusCode, DU=@DU, UserID=@USERID " +
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
                    cmd.Parameters.AddWithValue("@DateHospitalized", _dateHospitalized);
                    //cmd.Parameters.Add(new SqlParameter("@DateHospitalized", _dateHospitalized));
                    //sdtHospitalizedNull = SqlDateTime.Null;
                    //if (_dateHospitalized == "")
                    //{
                    //    cmd.Parameters["@DateHospitalized"].Value = sdtHospitalizedNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@DateHospitalized"].Value = DateTime.Parse(_dateHospitalized);
                    //}

                    cmd.Parameters.AddWithValue("@ReasonHospitalized", _reasonhospitalized);
                    cmd.Parameters.AddWithValue("@IsMinorMajor", _isminormajor);
                    cmd.Parameters.AddWithValue("@MinorMajorDesc", _minormajor);
                    cmd.Parameters.AddWithValue("@MinorMajorDate", _dateminormajor);
                    //cmd.Parameters.Add(new SqlParameter("@MinorMajorDate", _dateminormajor));
                    //sdtMinorMajorDateNull = SqlDateTime.Null;
                    //if (_dateminormajor == "")
                    //{
                    //    cmd.Parameters["@MinorMajorDate"].Value = sdtMinorMajorDateNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@MinorMajorDate"].Value = DateTime.Parse(_dateminormajor);
                    //}


                    cmd.Parameters.AddWithValue("@IsSeriousAccident", _isaccident);
                    cmd.Parameters.AddWithValue("@SeriousAccidentDesc", _accident);
                    cmd.Parameters.AddWithValue("@SeriousAccidentDate", _dateaccident);
                    //cmd.Parameters.Add(new SqlParameter("@SeriousAccidentDate", _dateaccident));
                    //sdtSeriousAccidentDateNull = SqlDateTime.Null;
                    //if (_dateaccident == "")
                    //{
                    //    cmd.Parameters["@SeriousAccidentDate"].Value = sdtSeriousAccidentDateNull;
                    //}
                    //else
                    //{
                    //    cmd.Parameters["@SeriousAccidentDate"].Value = DateTime.Parse(_dateaccident);
                    //}

                    cmd.Parameters.AddWithValue("@ParentRemarks", _parentRemarks);
                    cmd.Parameters.AddWithValue("@NurseRemarks", _nurserRemarks);
                    cmd.Parameters.AddWithValue("@HealthStatusCode", _healthStatusCode);
                    cmd.Parameters.AddWithValue("@illOthers", _illOthers);

                    cmd.Parameters.AddWithValue("@DU", _DU);
                    cmd.Parameters.AddWithValue("@USERID", _USERID);



                    cn.Open();

                    cmd.ExecuteNonQuery();
                    //}
                    //catch { }//Message HERE 
                }
            }
        }




        //UPDATE APPLICANT STATUS TRAIL TABLE
        public void UPDATE_APPLICANT_STATUS_TRAIL(string _snum, int _statusCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spApplicantClearHealth";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _snum);
                    cmd.Parameters.AddWithValue("@HEALTHSTAT", _statusCode);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


        /*
     ================================================
     SETUP - MEDICINE TRANSACTION
     ================================================ 
     */
        public void INSERT_MEDICINE(string _medCode, string _medDesc, string _medGenericName, string _medTypeCode, string _medLevelCode, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spINSERT_MEDICINE";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MEDCODE",_medCode);
                    cmd.Parameters.AddWithValue("@MEDDESC",_medDesc);
                    cmd.Parameters.AddWithValue("@MEDGENERICNAME", _medGenericName);
                    cmd.Parameters.AddWithValue("@MEDTYPECODE",_medTypeCode);
                    cmd.Parameters.AddWithValue("@MEDLEVELCODE", _medLevelCode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

   
    /* 
     TRANSACTION CRUD ON COMPLAINT SECTION
     * 07.25.2016
     *INSERT LOGS OF COMPLAINTS
     */

        public void INSERT_COMPLAINT_SUMMARY(string _transCode, string _sy, string _patientNum, DateTime _compDate, DateTime _compTime,
                                             string _notes, bool _sentHome, bool _sentHospital, string _timeIncidentCode,
                                             string _placeIncidentCode, string _physician, string _amount, string _remarks,
                                             bool _patientType, string _userID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spInsert_COMPLAINT_SUMMARY";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TRANSCODE", _transCode);
                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@PATIENTNUM", _patientNum);
                    cmd.Parameters.AddWithValue("@COMPDATE", _compDate);
                    cmd.Parameters.AddWithValue("@COMPTIME", _compTime);
                    cmd.Parameters.AddWithValue("@NOTES", _notes);
                    cmd.Parameters.AddWithValue("@SENTHOME", _sentHome);
                    cmd.Parameters.AddWithValue("@SENTHOSPITAL", _sentHospital);
                    cmd.Parameters.AddWithValue("@TIMEINCIDENTCODE", _timeIncidentCode);
                    cmd.Parameters.AddWithValue("@PLACEINCIDENTCODE", _placeIncidentCode);
                    cmd.Parameters.AddWithValue("@PHYSICIAN", _physician);
                    cmd.Parameters.AddWithValue("@AMOUNT", _amount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cmd.Parameters.AddWithValue("@PATIENTTYPE", _patientType);
                    cmd.Parameters.AddWithValue("@USERID", _userID);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        
        }


        public void INSERT_PATIENT_COMPLAINT_DETAILS(string _transCode, string _complaintCode)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spInsert_COMPLAINT_DETAILS";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TRANSCODE", _transCode);
                    cmd.Parameters.AddWithValue("@COMPLAINTCODE", _complaintCode);
                   

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void INSERT_PATIENT_MEDICINE_DETAILS(string _transCode, string _medCode, int _quantity, int _batchID, bool _isCountable)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spInsert_PATIENT_MEDICINE_DETAILS";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TRANSCODE", _transCode);
                    cmd.Parameters.AddWithValue("@MEDCODE", _medCode);
                    cmd.Parameters.AddWithValue("@QUANTITY", _quantity);
                    cmd.Parameters.AddWithValue("@BATCHID", _batchID);
                    cmd.Parameters.AddWithValue("@ISCOUNTABLE", _isCountable);


                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



      


        public void UPDATE_COMPLAINT_SUMMARY(string _transCode, DateTime _compDate, DateTime _compTime,
                                             string _notes, bool _sentHome, bool _sentHospital, string _timeIncidentCode,
                                             string _placeIncidentCode, string _physician, string _amount, string _remarks,
                                             bool _patientType, string _userID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spUpdate_COMPLAINT_SUMMARY";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TRANSCODE", _transCode);
                    cmd.Parameters.AddWithValue("@COMPDATE", _compDate);
                    cmd.Parameters.AddWithValue("@COMPTIME", _compTime);
                    cmd.Parameters.AddWithValue("@NOTES", _notes);
                    cmd.Parameters.AddWithValue("@SENTHOME", _sentHome);
                    cmd.Parameters.AddWithValue("@SENTHOSPITAL", _sentHospital);
                    cmd.Parameters.AddWithValue("@TIMEINCIDENTCODE", _timeIncidentCode);
                    cmd.Parameters.AddWithValue("@PLACEINCIDENTCODE", _placeIncidentCode);
                    cmd.Parameters.AddWithValue("@PHYSICIAN", _physician);
                    cmd.Parameters.AddWithValue("@AMOUNT", _amount);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cmd.Parameters.AddWithValue("@USERID", _userID);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


        //Make Complaint Record Inactive
        public void DISABLE_COMPLAINT_TRANSACTION(string _transcode, int _batchID, string _medCode, int _quantity, string _userID)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spINACTIVE_COMPLAINT_TRANSACTION";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TRANSCODE", _transcode);
                    cmd.Parameters.AddWithValue("@BATCHID", _batchID);
                    cmd.Parameters.AddWithValue("@MEDCODE", _medCode);
                    cmd.Parameters.AddWithValue("@QUANTITY", _quantity);
                    cmd.Parameters.AddWithValue("@USERID", _userID);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        //Transaction of Medicine

        public void UPDATE_MEDICINE_STOCK_DOWN(int _batchID, string _medCode, int _quantity)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                string strSQL = "spUPDATE_MEDICINE_STOCK_DOWN";

                using (SqlCommand cmd = new SqlCommand(strSQL, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BATCHID", _batchID);
                    cmd.Parameters.AddWithValue("@MEDCODE", _medCode);
                    cmd.Parameters.AddWithValue("@QUANTITY", _quantity);


                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


        #endregion




     



        

   
        


    }



}


