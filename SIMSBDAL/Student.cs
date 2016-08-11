using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace SIMSBDAL
{
    public class Student: cBase
    {

        #region "PROPERTY-FIELDS"


        public string STUDNO { get; set; }
        public string APPNUM { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string FULLNAME { get; set; }
        public string MI { get; set; }
        public string SUFFIX { get; set; }
        public DateTime DOB { get; set; }
        public string POB { get; set; }
        public string GENDERCODE { get; set; }
        public string TELNO { get; set; }
        public string MOBILENO { get; set; }
        public string EMAIL { get; set; }
        public string STREET { get; set; }
        public string CITYCODE { get; set; }
        public string BARANGAYCODE { get; set; }
        public string INITIALCONTACT { get; set; }
        public bool STATUS { get; set; }
        public bool SSICHILD { get; set; }
        public string ENTRY_LEVELCODE { get; set; }
        public string CURRENT_LEVELCODE { get; set; }
        public string CURRENT_LEVELDESC { get; set; }




        public string SECTION { get; set; }
        public string CITIZENSHIPCODE { get; set; }
        public string RELIGIONCODE { get; set; }

        //For Display Info purposes of applicant stage entry
        public string DATEAPPLIED {get;set;}
        public string ENTRYSY { get; set; }

        public string LRN { get; set; }
        public string STRANDCODE { get; set; }
        public string STRANDDESC { get; set; }
        public string PHOTOLOC { get; set; }

        public string MOTCODE { get; set; }
        public string MOTDESC { get; set; }

        //PRIMARY CONTACT PERSON - INFO
        public string COMPLETE_ADDRESS { get; set; }
        public string PRIMARY_CONTACT_PERSON { get; set; }
        public string CONTACT_RELATION { get; set; }
        public string CONTACT_NUMBERS { get; set; }

        public string BARCODE { get; set; }


        //FROM STUDENT_MF
        public string STATCODER { get; set; } //STATUS FOR RESERVE
        public string STATCODE { get; set; } //STATUS FOR ENROLLED


        /* 
         FIELDS FOR FAMILY
         
         */
        public string FLASTNAME { get; set; }
        public string FFIRSTNAME { get; set; }
        public string FMIDDLENAME { get; set; }
        public string FOCCUPATION { get; set; }
        public string FCITIZENSHIP { get; set; }
        public string FEDUCATION { get; set; }
        public string FCOMPANY { get; set; }
        public string FCOMPADDRESS { get; set; }
        public string FTELEPHONE { get; set; }
        public string FMOBILE { get; set; }

        public string MLASTNAME { get; set; }
        public string MFIRSTNAME { get; set; }
        public string MMIDDLENAME { get; set; }
        public string MOCCUPATION { get; set; }
        public string MCITIZENSHIP { get; set; }
        public string MEDUCATION { get; set; }
        public string MCOMPANY { get; set; }
        public string MCOMPADDRESS { get; set; }
        public string MTELEPHONE { get; set; }
        public string MMOBILE { get; set; }

        public string GLASTNAME { get; set; }
        public string GFIRSTNAME { get; set; }
        public string GMIDDLENAME { get; set; }
        public string GADDRESS { get; set; }
        public string GTELEPHONE { get; set; }
        public string GMOBILE { get; set; }
        public string GRELATION { get; set; }
        public int PRIMARYCONTACT { get; set; }


        //CREDENTIALS
        public bool FORM138 {get; set;}
        public bool BC { get; set; }
        public bool COLORED1X1 { get; set; }
        public bool BROWNENVELOPE { get; set; }
        public bool GM { get; set; }
        public bool RECOMMENDATION { get; set; }
        public bool FORM137 { get; set; }
        public bool NCAE { get; set; }
        public bool INTERVIEW { get; set; }
        public string OTHER { get; set; }
        










        /*Fields for Sibling */
        public string SIBLINGCODE { get; set; }

        #endregion


        #region "INSERT-UPDATE-DELETE FUNCTIONS"


        //INSERT RECORD OF APPLICANT TO REGISTRATION OF STUDENTS
        public void MTAPPTOSTUDENT(string _appnum, string _studnum, string _levelcatcode ,string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spMTAppToStudent", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@APPNUM", _appnum);
                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@LEVELCATCODE", _levelcatcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();



                }
            }


        }
       
       


        //INSERT spInsertStudentEducBack
        public void INSERT_EDUCBACK(string _studnum, string _edutype, string _schoolname, string _address, string _yeargrad, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertStudentEducBack", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@EDUTYPE", _edutype);
                    cmd.Parameters.AddWithValue("@SCHOOLNAME", _schoolname);
                    cmd.Parameters.AddWithValue("@ADDRESS", _address);
                    cmd.Parameters.AddWithValue("@YEARGRAD", _yeargrad);
                    cmd.Parameters.AddWithValue("@USERID", _userid);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        //INSERT RELATIVE
        public void INSERT_RELATIVE(string _studnum, string _flastname, string _ffirstname, string _fmiddlename, 
                                    string _foccupation, string _fcitizenship, string _feducation, 
                                    string _fcompany, string _fcompaddress, string _ftelephone, string _fmobile,
                                    string _mlastname, string _mfirstname, string _mmiddlename, 
                                    string _moccupation, string _mcitizenship, string _meducation, 
                                    string _mcompany, string _mcompaddress, string _mtelephone, string _mmobile,
                                    string _glastname, string _gfirstname, string _gmiddlename, 
                                    string _gaddress, string _gtelephone, string _gmobile, string _grelation, int _primarycontactid)
                                 
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertStudentRelative", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@FLASTNAME", _flastname);
                    cmd.Parameters.AddWithValue("@FFIRSTNAME", _ffirstname);
                    cmd.Parameters.AddWithValue("@FMIDDLENAME", _fmiddlename);
                    cmd.Parameters.AddWithValue("@FOCCUPATION", _foccupation);
                    cmd.Parameters.AddWithValue("@FCITIZENSHIP", _fcitizenship);
                    cmd.Parameters.AddWithValue("@FEDUCATION", _feducation);
                    cmd.Parameters.AddWithValue("@FCOMPANY", _fcompany);
                    cmd.Parameters.AddWithValue("@FCOMPADDRESS", _fcompaddress);
                    cmd.Parameters.AddWithValue("@FTELEPHONE", _ftelephone);
                    cmd.Parameters.AddWithValue("@FMOBILE", _fmobile);
                    
                    cmd.Parameters.AddWithValue("@MLASTNAME", _mlastname);
                    cmd.Parameters.AddWithValue("@MFIRSTNAME", _mfirstname);
                    cmd.Parameters.AddWithValue("@MMIDDLENAME", _mmiddlename);
                    cmd.Parameters.AddWithValue("@MOCCUPATION", _moccupation);
                    cmd.Parameters.AddWithValue("@MCITIZENSHIP", _mcitizenship);
                    cmd.Parameters.AddWithValue("@MEDUCATION", _meducation);
                    cmd.Parameters.AddWithValue("@MCOMPANY", _mcompany);
                    cmd.Parameters.AddWithValue("@MCOMPADDRESS", _mcompaddress);
                    cmd.Parameters.AddWithValue("@MTELEPHONE", _mtelephone);
                    cmd.Parameters.AddWithValue("@MMOBILE", _mmobile);

                    cmd.Parameters.AddWithValue("@GLASTNAME", _glastname);
                    cmd.Parameters.AddWithValue("@GFIRSTNAME", _gfirstname);
                    cmd.Parameters.AddWithValue("@GMIDDLENAME", _gmiddlename);
                    cmd.Parameters.AddWithValue("@GADDRESS", _gaddress);
                    cmd.Parameters.AddWithValue("@GTELEPHONE", _gtelephone);
                    cmd.Parameters.AddWithValue("@GMOBILE", _gmobile);
                    cmd.Parameters.AddWithValue("@GRELATION", _grelation);
                    cmd.Parameters.AddWithValue("@PRIMARYCONTACTID", _primarycontactid);

                    cmd.ExecuteNonQuery();

                }
            }
        }



        //INSERT CREDENTIALS
        public void INSERT_STUDENTCREDENTIALS(string _studnum, bool _form138, bool _bc, bool _colored1x1,
                                           bool _brownenvelope, bool _gm, bool _recommendation,
                                           bool _form137, bool _ncae, bool _interview, string _other)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertStudentCredentials", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@SNUM", _studnum);
                    cmd.Parameters.AddWithValue("@Form138", _form138);
                    cmd.Parameters.AddWithValue("@BC", _bc);
                    cmd.Parameters.AddWithValue("@Colored1x1", _colored1x1);
                    cmd.Parameters.AddWithValue("@BrownEnvelope", _brownenvelope);
                    cmd.Parameters.AddWithValue("@GM", _gm);
                    cmd.Parameters.AddWithValue("@Recommendation", _gm);
                    cmd.Parameters.AddWithValue("@Form137", _form138);
                    cmd.Parameters.AddWithValue("@NCAE", _ncae);
                    cmd.Parameters.AddWithValue("@Interview", _interview);
                    cmd.Parameters.AddWithValue("@Other", _other);


                    cmd.ExecuteNonQuery();



                }
            }
        }

        //INSERT SIBLINGS
        public void INSERT_SIBLINGS(string _studnum, string _siblingcode, int _siblingorder, string _userid)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertStudentSibling", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@SIBLINGCODE", _siblingcode);
                    cmd.Parameters.AddWithValue("@SIBLINGORDER", _siblingorder);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();



                }
            }
        }

        


        //UPDATE RELATIVE
        public void UPDATE_RELATIVE(string _studnum, string _flastname, string _ffirstname, string _fmiddlename,
                                   string _foccupation, string _fcitizenship, string _feducation,
                                   string _fcompany, string _fcompaddress, string _ftelephone, string _fmobile,
                                   string _mlastname, string _mfirstname, string _mmiddlename,
                                   string _moccupation, string _mcitizenship, string _meducation,
                                   string _mcompany, string _mcompaddress, string _mtelephone, string _mmobile,
                                   string _glastname, string _gfirstname, string _gmiddlename,
                                   string _gaddress, string _gtelephone, string _gmobile, string _grelation, int _primarycontactid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentRelative", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@FLASTNAME", _flastname);
                    cmd.Parameters.AddWithValue("@FFIRSTNAME", _ffirstname);
                    cmd.Parameters.AddWithValue("@FMIDDLENAME", _fmiddlename);
                    cmd.Parameters.AddWithValue("@FOCCUPATION", _foccupation);
                    cmd.Parameters.AddWithValue("@FCITIZENSHIP", _fcitizenship);
                    cmd.Parameters.AddWithValue("@FEDUCATION", _feducation);
                    cmd.Parameters.AddWithValue("@FCOMPANY", _fcompany);
                    cmd.Parameters.AddWithValue("@FCOMPADDRESS", _fcompaddress);
                    cmd.Parameters.AddWithValue("@FTELEPHONE", _ftelephone);
                    cmd.Parameters.AddWithValue("@FMOBILE", _fmobile);

                    cmd.Parameters.AddWithValue("@MLASTNAME", _mlastname);
                    cmd.Parameters.AddWithValue("@MFIRSTNAME", _mfirstname);
                    cmd.Parameters.AddWithValue("@MMIDDLENAME", _mmiddlename);
                    cmd.Parameters.AddWithValue("@MOCCUPATION", _moccupation);
                    cmd.Parameters.AddWithValue("@MCITIZENSHIP", _mcitizenship);
                    cmd.Parameters.AddWithValue("@MEDUCATION", _meducation);
                    cmd.Parameters.AddWithValue("@MCOMPANY", _mcompany);
                    cmd.Parameters.AddWithValue("@MCOMPADDRESS", _mcompaddress);
                    cmd.Parameters.AddWithValue("@MTELEPHONE", _mtelephone);
                    cmd.Parameters.AddWithValue("@MMOBILE", _mmobile);

                    cmd.Parameters.AddWithValue("@GLASTNAME", _glastname);
                    cmd.Parameters.AddWithValue("@GFIRSTNAME", _gfirstname);
                    cmd.Parameters.AddWithValue("@GMIDDLENAME", _gmiddlename);
                    cmd.Parameters.AddWithValue("@GADDRESS", _gaddress);
                    cmd.Parameters.AddWithValue("@GTELEPHONE", _gtelephone);
                    cmd.Parameters.AddWithValue("@GMOBILE", _gmobile);
                    cmd.Parameters.AddWithValue("@GRELATION", _grelation);
                    cmd.Parameters.AddWithValue("@PRIMARYCONTACTID", _primarycontactid);

                    cmd.ExecuteNonQuery();

                }
            }
        }



     
        //UPDATE EDUCATIONAL BACKGROUND
        public void UPDATE_EDUCBACK(int _id, string _edutype, string _schoolname, string _address, string _yeargrad, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentEducBack", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@EDUTYPE", _edutype);
                    cmd.Parameters.AddWithValue("@SCHOOLNAME", _schoolname);
                    cmd.Parameters.AddWithValue("@ADDRESS", _address);
                    cmd.Parameters.AddWithValue("@YEARGRAD", _yeargrad);
                    cmd.Parameters.AddWithValue("@USERID", _userid);
                    cmd.ExecuteNonQuery();



                }
            }
        }



        //UPDATE STUDENT VITAL INFORMATION
        public void UPDATE_STUDENTINFORMATION(string _studnum, string _lastname, string _firstname, string _middlename,
                                               string _mi, string _suffix, string _fullname, string _gendercode, DateTime _dob,
                                               string _pob, double _age, string _citizenshipcode, string _religioncode, string _telno, string _mobileno, string _street,
                                               string _barangaycode, string _citycode, string _email, string _remarks,
                                               string _initialContact, bool _status, string _photopath, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentInfo", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    //cmd.Parameters.AddWithValue("@LRN", _lrn);
                    ////cmd.Parameters.AddWithValue("@CURRENT_LEVELCODE", _currentlevelcode);
                    ////cmd.Parameters.AddWithValue("@CURRENT_SECTION", _current_section);
                    ////cmd.Parameters.AddWithValue("@STRAND_CODE", _strandcode);
                    //cmd.Parameters.AddWithValue("@SSICHILD", _ssichild);
                    cmd.Parameters.AddWithValue("@LASTNAME", _lastname);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", _firstname);
                    cmd.Parameters.AddWithValue("@MIDDLENAME", _middlename);
                    cmd.Parameters.AddWithValue("@MI", _mi);
                    cmd.Parameters.AddWithValue("@SUFFIX", _suffix);
                    cmd.Parameters.AddWithValue("@FULLNAME",_fullname);
                    cmd.Parameters.AddWithValue("@GENDERCODE", _gendercode);
                    cmd.Parameters.AddWithValue("@DOB",_dob);
                    cmd.Parameters.AddWithValue("@POB",_pob);
                    cmd.Parameters.AddWithValue("@AGE",_age);
                    cmd.Parameters.AddWithValue("@CITIZENSHIPCODE", _citizenshipcode);
                    cmd.Parameters.AddWithValue("@RELIGIONCODE", _religioncode);
                    cmd.Parameters.AddWithValue("@TELNO", _telno);
                    cmd.Parameters.AddWithValue("@MOBILENO", _mobileno);
                    cmd.Parameters.AddWithValue("@STREET", _street);
                    cmd.Parameters.AddWithValue("@BARANGAYCODE", _barangaycode);
                    cmd.Parameters.AddWithValue("@CITYCODE", _citycode);
                    cmd.Parameters.AddWithValue("@EMAIL", _email);
                    cmd.Parameters.AddWithValue("@REMARKS", _remarks);
                    cmd.Parameters.AddWithValue("@INITIALCONTACT", _initialContact);
                    cmd.Parameters.AddWithValue("@STATUS", _status);
                    cmd.Parameters.AddWithValue("@PHOTOPATH", _photopath);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();



                }
            }
        
        }


        //UPDATE STUDENT CREDENTIALS
        public void UPDATE_STUDENTCREDENTIALS(string _studnum, bool _form138, bool _bc, bool _colored1x1,
                                            bool _brownenvelope, bool _gm, bool _recommendation,
                                            bool _form137, bool _ncae, bool _interview, string _other)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentCredentials", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@Form138", _form138);
                    cmd.Parameters.AddWithValue("@BC", _bc);
                    cmd.Parameters.AddWithValue("@Colored1x1", _colored1x1);
                    cmd.Parameters.AddWithValue("@BrownEnvelope", _brownenvelope);
                    cmd.Parameters.AddWithValue("@GM", _gm);
                    cmd.Parameters.AddWithValue("@Recommendation", _gm);
                    cmd.Parameters.AddWithValue("@Form137", _form138);
                    cmd.Parameters.AddWithValue("@NCAE", _ncae);
                    cmd.Parameters.AddWithValue("@Interview", _interview);
                    cmd.Parameters.AddWithValue("@Other", _other);
                  

                    cmd.ExecuteNonQuery();



                }
            }
        }
        //REMOVE SELECTED SIBLINGS
        public void DELETE_SIBLING(int _id)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spDeleteSibling", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE SIBLING ORDER
        public void UPDATE_SIBLINGORDER(int _id, int _siblingorder)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentSiblings", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _id);
                    cmd.Parameters.AddWithValue("@SIBLINGORDER", _siblingorder);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //UPDATE MODE OF STUDENT TRANSPORTATION
        public void UPDATE_STUDENT_MOT(string _studnum, string _motcode, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_MOT", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@MOTCODE", _motcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UPDATE_STRANDCODE(string _studnum, string _strandcode, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_STRAND", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@STRANDCODE",_strandcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE STUDENT STATUS
        public void UPDATE_STATUS(string _studnum, bool _status, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_STATUS", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@STATUS", _status);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE BARCODE, LRN, SSI CHILD
        public void UPDATE_BLS(string _studnum, string _barcode, string _lrn, bool _ssichild, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_BARCODE_LRN_SSICHILD", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@BARCODE", _barcode);
                    cmd.Parameters.AddWithValue("@LRN", _lrn);
                    cmd.Parameters.AddWithValue("@SSICHILD", _ssichild);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }
 
        //UPDATE RESERVATION STATUS
        public void UPDATE_RESERVATION_STATUS(string _studnum, string _statcoder, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_RESERVATION_STATUS", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@STATCODER", _statcoder);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE ENROLLMENT STATUS
        public void UPDATE_ENROLLMENT_STATUS(string _studnum, string _statcode, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_STUDENT_ENROLLMENT_STATUS", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@STATCODE", _statcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //
        #endregion



        #region "GET-DISPLAY FUNCTION AREA"


        public bool GETINFO(string _studnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spGetStudentInformation", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);


                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            STUDNO = dr["StudNum"].ToString();
                            APPNUM = dr["AppNum"].ToString();
                            LASTNAME = dr["LastName"].ToString();
                            FIRSTNAME = dr["FirstName"].ToString();
                            MIDDLENAME = dr["MiddleName"].ToString();
                            MI = dr["MI"].ToString();
                            ENTRY_LEVELCODE = dr["Entry_LevelCode"].ToString();
                            CURRENT_LEVELCODE = dr["Current_LevelCode"].ToString();
                            CURRENT_LEVELDESC = dr["LevelTypeDesc"].ToString();
                            SUFFIX = dr["Suffix"].ToString();
                            DOB = (DateTime) dr["DOB"];
                            POB = dr["POB"].ToString();
                            GENDERCODE = dr["GenderCode"].ToString();

                            TELNO = dr["Telno"].ToString();
                            MOBILENO = dr["MobileNo"].ToString();
                            EMAIL = dr["Email"].ToString(); 
                            STREET = dr["Street"].ToString();
                            CITYCODE = dr["CityCode"].ToString();
                            BARANGAYCODE = dr["BarangayCode"].ToString();
                            INITIALCONTACT = dr["InitialContact"].ToString();
                            STATUS = (bool)dr["Status"];
                            SSICHILD = (bool)dr["SSIChild"];

                            SECTION = dr["current_section"].ToString();
                            CITIZENSHIPCODE = dr["CitizenshipCode"].ToString();
                            RELIGIONCODE = dr["ReligionCode"].ToString();

                            LRN = dr["LRN"].ToString();
                            BARCODE = dr["Barcode"].ToString();
                            STRANDCODE = dr["Strandcode"].ToString();
                            STRANDDESC = dr["StrandName"].ToString();

                            //MODE OF TRANSPORTATION
                            MOTCODE = dr["motCode"].ToString();

                            PHOTOLOC = dr["PhotoPath"].ToString();

                            DATEAPPLIED = dr["Entry_Date"].ToString();
                            ENTRYSY = dr["Entry_Sy"].ToString();

                            //FROM STUDENT MF DATA
                            STATCODER = dr["statcoder"].ToString();
                            STATCODE = dr["statcode"].ToString();

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


        public bool GETINFO_HEALTH(string _studnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spGET_HEALTH_INFO", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);


                    SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            STUDNO = dr["StudNum"].ToString();
                            FULLNAME = dr["FullName"].ToString();
                            CURRENT_LEVELDESC = dr["LevelTypeDesc"].ToString();
                            SECTION = dr["section"].ToString();
                            PRIMARY_CONTACT_PERSON = dr["ContactName"].ToString();
                            CONTACT_RELATION = dr["Relation"].ToString();
                            CONTACT_NUMBERS = dr["Contact"].ToString();
                            COMPLETE_ADDRESS = dr["ContactAddress"].ToString();
                            MOTDESC = dr["motDescription"].ToString();
                            PHOTOLOC = dr["PhotoPath"].ToString();

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
        public bool GETCREDENTIALS(string _studnum)
        { 
         bool x = false;

         using (SqlConnection cn = new SqlConnection(CS))
         {

             using (SqlCommand cmd = new SqlCommand("spDisplayStudentCredentials", cn))
             {
                 cn.Open();

                 cmd.CommandType = CommandType.StoredProcedure;

                 cmd.Parameters.AddWithValue("@STUDNUM", _studnum);


                 SqlDataReader dr = cmd.ExecuteReader();// cmd.ExecuteNonQuery();
                 if (dr.HasRows)
                 {
                     x = true;

                     while (dr.Read())
                     {
                         //GET THE PUBLIC PROPERTY
                         FORM138 = (bool)dr["FORM138"];
                         BC = (bool)dr["BC"];
                         COLORED1X1 = (bool)dr["COLORED1X1"];
                         BROWNENVELOPE = (bool)dr["BROWNENVELOPE"];
                         GM = (bool)dr["GM"];
                         RECOMMENDATION = (bool)dr["RECOMMENDATION"];
                         FORM137 = (bool)dr["FORM137"];
                         NCAE = (bool)dr["NCAE"];
                         INTERVIEW = (bool)dr["INTERVIEW"];
                         OTHER = dr["OTHER"].ToString();
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

        public DataTable GET_EDUBACK(string _studnum)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGetStudentEduBack", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable GET_SIBLINGLIST(string _siblingcode)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplaySiblingList", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SIBLINGCODE", _siblingcode);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        
        }

        public DataTable GET_SELECTED_SIBLINGS(string _lastname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGetStudentSibling", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LASTNAME", _lastname);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        //Default without parameter
        public DataTable GET_SELECTED_SIBLINGS()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGetStudentSibling_Default", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public bool CHECK_FAMILY(string _studnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spCheckStudentExist", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);


                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            FLASTNAME = dr["FLASTNAME"].ToString();
                            FFIRSTNAME = dr["FFIRSTNAME"].ToString();
                            FMIDDLENAME = dr["FMIDDLENAME"].ToString();
                            FOCCUPATION = dr["FOCCUPATION"].ToString();
                            FCITIZENSHIP = dr["FCITIZENSHIP"].ToString();
                            FEDUCATION = dr["FEDUCATION"].ToString();
                            FCOMPANY = dr["FCOMPANY"].ToString();
                            FCOMPADDRESS = dr["FCOMPADDRESS"].ToString();
                            FTELEPHONE = dr["FTELEPHONE"].ToString();
                            FMOBILE = dr["FMOBILE"].ToString();

                            MLASTNAME = dr["MLASTNAME"].ToString();
                            MFIRSTNAME = dr["MFIRSTNAME"].ToString();
                            MMIDDLENAME = dr["MMIDDLENAME"].ToString();
                            MOCCUPATION = dr["MOCCUPATION"].ToString();
                            MCITIZENSHIP = dr["MCITIZENSHIP"].ToString();
                            MEDUCATION = dr["MEDUCATION"].ToString();
                            MCOMPANY = dr["MCOMPANY"].ToString();
                            MCOMPADDRESS = dr["MCOMPADDRESS"].ToString();
                            MTELEPHONE = dr["MTELEPHONE"].ToString();
                            MMOBILE = dr["MMOBILE"].ToString();

                            GLASTNAME = dr["GLASTNAME"].ToString();
                            GFIRSTNAME = dr["GFIRSTNAME"].ToString();
                            GMIDDLENAME = dr["GMIDDLENAME"].ToString();
                            GADDRESS = dr["GADDRESS"].ToString();
                            GTELEPHONE = dr["GTELEPHONE"].ToString();
                            GMOBILE = dr["GMOBILE"].ToString();
                            GRELATION = dr["GRELATION"].ToString();

                            PRIMARYCONTACT = Convert.ToInt32(dr["PrimaryContactID"].ToString());

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

        //Will check and get if exist
        public bool CHECK_SIBLINGEXIST(string _studnum)
        { 
           bool x = false;

           using (SqlConnection cn = new SqlConnection(CS))
           {

               using (SqlCommand cmd = new SqlCommand("spCheckStudentSiblings", cn))
               {
                   cn.Open();

                   cmd.CommandType = CommandType.StoredProcedure;

                   cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                   
                   SqlDataReader dr = cmd.ExecuteReader();
                   if (dr.HasRows)
                   {
                       x = true;

                       while (dr.Read())
                       {
                           SIBLINGCODE = dr["SiblingCode"].ToString();
                       }

                   }
                   else
                   {
                       x = false;
                   }
               }

               return x;
           }

        }


        public bool CHECK_SIBLINGORDEREXIST(string _siblingcode, int _siblingorder)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spCheckStudentSiblingsOrder", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SIBLINGCODE", _siblingcode);
                    cmd.Parameters.AddWithValue("@SIBLINGORDER", _siblingorder);


                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        x = true;

                    }
                    else
                    {
                        x = false;
                    }
                }

                return x;
            }

        }


       

        //Display List of Student With Balance-Deliquent

        public DataTable GETDELIQUENTLIST()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spDisplayDeliquentAccount", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        #endregion



  
        



        #region "INSERT/UPDATE/DELETE FUNCTIONS"
        //INSERT SECTION
        
        public void INSERT_STUDENTSTATUS(string _studnum, string _sy, string _leveltypecode, string _statcode, string _userid)
        {

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertStudentStatus", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@LEVELTYPECODE", _leveltypecode);
                    cmd.Parameters.AddWithValue("@STATCODE", _statcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();



                }
            }
        }

        public void UPDATE_STUDENTSTATUS(string _studnum, string _sy, string _statcode, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentStatus", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@STATCODE", _statcode);
                    cmd.Parameters.AddWithValue("@USERID", _userid);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        
        //Update Section - 05/13/2016
        public void UPDATE_STUDENTSECTION(string _studnum, string _section, int _roomid, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateStudentSection", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);
                    cmd.Parameters.AddWithValue("@SECTION", _section);
                    cmd.Parameters.AddWithValue("@ROOMID", _roomid);
                    cmd.Parameters.AddWithValue("@USERID", _userid);


                    cmd.ExecuteNonQuery();
                }
            }

        }



        //05-14-2016
        //INSERT NEW RECORD ON TEACHER SECTION
        public void INSERT_TEACHERSECTION(string _sy, string _levelcode, string _sectioncode, int _roomid, string _teacherid,
                                        string _scheddesc, string _buildingdedesc, string _userid)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spInsert_TEACHER_SECTION_LIST", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@LEVELCODE", _levelcode);
                    //cmd.Parameters.AddWithValue("@STRANDCODE", _strandcode);
                    cmd.Parameters.AddWithValue("@SECTIONCODE", _sectioncode);
                    cmd.Parameters.AddWithValue("@ROOMID", _roomid);
                    cmd.Parameters.AddWithValue("@TEACHERID", _teacherid);
                    cmd.Parameters.AddWithValue("@SCHEDDESC", _scheddesc);
                    cmd.Parameters.AddWithValue("@BUILDINGDESC", _buildingdedesc);
                    cmd.Parameters.AddWithValue("@USERID", _userid);


                    cmd.ExecuteNonQuery();
                }
            }
        
        }

        //05-23-2016
        //UPDATE TEACHER SECTION
        public void UPDATE_TEACHERSECTION(string _sy, string _levelcode, string _sectioncode, int _roomid, string _teacherid,
                                        string _scheddesc, string _buildingdedesc, string _userid, int _id)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spUPDATE_TEACHER_SECTION_LIST", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SY", _sy);
                    cmd.Parameters.AddWithValue("@LEVELCODE", _levelcode);
                    cmd.Parameters.AddWithValue("@SECTIONCODE", _sectioncode);
                    cmd.Parameters.AddWithValue("@ROOMID", _roomid);
                    cmd.Parameters.AddWithValue("@TEACHERID", _teacherid);
                    cmd.Parameters.AddWithValue("@SCHEDDESC", _scheddesc);
                    cmd.Parameters.AddWithValue("@BUILDINGDESC", _buildingdedesc);
                    cmd.Parameters.AddWithValue("@USERID", _userid);
                    cmd.Parameters.AddWithValue("@ID", _id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion


        
        #region "GET/DISPLAY/CHECK FUNCTION AREA"
        //GET SECTION

        //public DataTable GET_ACTIVESTUDENTS()
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection cn = new SqlConnection(CS))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("spDisplayActiveStudent", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = cmd;
        //            da.Fill(dt);
        //        }
        //    }

        //    return dt;
        //}

        public bool CHECK_STUDENTSTATUSEXIST(string _studnum)
        {
            bool x = false;

            using (SqlConnection cn = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("spCheckStudentStatus", cn))
                {
                    cn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@STUDNUM", _studnum);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        x = true;

                        while (dr.Read())
                        {
                            STATCODE = dr["Statcode"].ToString();
                        }

                    }
                    else
                    {
                        x = false;
                    }
                }

                return x;
            }

        }

        //GET STUDENTS FROM STUDENT INFORMATION FOR STATUS ASSIGNMENT
        public DataTable GET_STUDENTS_NO_SECTION()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGetStudentsActiveNoSection", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GET_TEACHER_SECTION_LIST()
        {
 
            DataTable dt = new DataTable();
            string strSQL = "spGET_TEACHER_SECTION_LIST";
            dt = queryCommandDT_StoredProc(strSQL);
            return dt;   
        }

        public DataTable GET_STUDENTS_WITH_SECTION()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("spGetStudentsActiveWithSection", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }
        #endregion


    }
}
