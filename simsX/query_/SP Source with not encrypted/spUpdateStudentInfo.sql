USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudentInfo]    Script Date: 05/21/2016 15:33:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* UPDATE STUDENT VITAL INFORMATION
RUSSEL VASQUEZ
*/

ALTER PROC [dbo].[spUpdateStudentInfo]
@STUDNUM nvarchar(7),
--@LRN nvarchar(20),
--@CURRENT_LEVELCODE nvarchar(3),
--@CURRENT_SECTION nvarchar(1),
--@STRAND_CODE nvarchar(1),
--@SSICHILD bit,
@LASTNAME nvarchar(50),
@FIRSTNAME nvarchar(50),
@MIDDLENAME nvarchar(50),
@MI nvarchar(2),
@SUFFIX nvarchar(4),
@FULLNAME nvarchar(90),
@GENDERCODE nvarchar(1),
@DOB datetime,
@POB nvarchar(150),
@AGE float,
@CITIZENSHIPCODE nvarchar(3),
@RELIGIONCODE nvarchar(3),
@TELNO nvarchar(50),
@MOBILENO nvarchar(50),
@STREET nvarchar(150),
@BARANGAYCODE nvarchar(5),
@CITYCODE nvarchar(3),
@EMAIL nvarchar(50),
@REMARKS nvarchar(250),
@INITIALCONTACT nvarchar(50),
@STATUS bit,
@PHOTOPATH nvarchar(20),
@USERID nvarchar(20)

WITH ENCRYPTION
AS
BEGIN

UPDATE Registration.Student_Info_MF
SET LastName=@LASTNAME,FirstName=@FIRSTNAME,MiddleName=@MIDDLENAME,MI=@MI,Suffix=@SUFFIX,
FullName=@FULLNAME,GenderCode=@GENDERCODE,DOB=@DOB,POB=@POB,Age=@AGE,CitizenshipCode=@CITIZENSHIPCODE, ReligionCode=@RELIGIONCODE, TelNo=@TELNO,MobileNo=@MOBILENO,
Street=@STREET,BarangayCode=@BARANGAYCODE,CityCode=@CITYCODE,Email=@EMAIL,Remarks=@REMARKS,InitialContact=@INITIALCONTACT,
Status=@STATUS,PhotoPath=@PHOTOPATH,DateUpdate=GETDATE(),UserID=@USERID
WHERE StudNum=@STUDNUM


--UPDATE STUDENT NAME IN STUDENT_MF TABLE
UPDATE Registration.Student_MF
SET StudName = UPPER(@LASTNAME) + ', ' + UPPER(@FIRSTNAME) + ' ' + UPPER(@MI) + '.'
WHERE StudNum = @STUDNUM

--Current_LevelCode=@CURRENT_LEVELCODE, current_section=@CURRENT_SECTION,StrandCode=@STRAND_CODE,

UPDATE [192.168.2.100].[SSI].[dbo].[@FT_OCRD]
SET U_NAME=UPPER(@LASTNAME) + ', ' + UPPER(@FIRSTNAME) + ' ' + UPPER(@MI) + '.',
	NAME= UPPER(@LASTNAME) + ', ' + UPPER(@FIRSTNAME) + ' ' + UPPER(@MI) + '.',
	U_Action='U',U_Processed='N',U_ForProcess='Y'
	WHERE U_StudentNo=@STUDNUM 

END