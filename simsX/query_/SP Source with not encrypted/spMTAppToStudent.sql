USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spMTAppToStudent]    Script Date: 06/28/2016 15:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* COPY INFORMATION FROM APPLICANT TO STUDENT INFO
   UPDATE STATUS ON APPLICANT INFO
   RUSSEL VASQUEZ
   12/02/2015	
*/

ALTER PROC [dbo].[spMTAppToStudent]
@APPNUM nvarchar(8),
@STUDNUM nvarchar(7),
@USERID	nvarchar(20),
@LEVELCATCODE nvarchar(3)

WITH ENCRYPTION
AS
BEGIN

/*
COPY RECORD FROM APPLICANT TO STUDENT INFORMATION 
12/02/2015
*/
INSERT INTO Registration.Student_Info_MF(StudNum, AppNum, StudTypeCode, Entry_SY, Entry_LevelCode,Current_LevelCode,
StrandCode, Entry_Date, SSIChild, LastName, FirstName, MiddleName, MI, Suffix,
FullName,GenderCode,DOB,POB, Age, TelNo, MobileNo, street,BarangayCode,CityCode,Email,
Remarks, initialContact, DateEncode, UserID)
SELECT @STUDNUM, b.AppNum, b.AppTypeCode, b.SY, b.LevelTypeCode,b.LevelTypeCode,b.StrandCode, b.AppDOA, b.SSIChild,
b.LastName, b.FirstName, b.MiddleName, b.MI, b.Suffix, (b.lastname + ', ' + b.FirstName + ' ' + b.mi + '.') FuName, b.GenderCode, b.DOB, 
b.POB, b.Age, b.TelNo, b.MobileNo, b.AddInfo, b.BarangayCode, b.CityCode, b.Email,
b.Remarks, b.ContactPerson, GETDATE(), @USERID
FROM Admission.App_Info_MF b
WHERE b.AppNum= @APPNUM

---OTHER INSERTION
INSERT INTO Registration.Credential_MF(SNUM,Form138,BC,Colored1x1,BrownEnvelope,GM,Recommendation,
Form137,NCAE,Interview,Other)
SELECT @STUDNUM,c.Form138,c.BC,c.Colored1x1,c.BrownEnvelope,c.GM,c.Recommendation,
c.Form137,c.NCAE,c.Interview,c.Other
FROM Admission.Credential_MF c
WHERE c.SNUM = @APPNUM

--ANOTHER INSERTION ON STUDENT_MF
--03-02-2016
INSERT INTO Registration.Student_MF(StudNum,StudName,LevelCatCode,LevelCode,SY,StrandCode,StudTypeCode, UserId)
SELECT @STUDNUM,(d.lastname + ', ' + d.FirstName + ' ' + d.mi + '.') as FuName,@LEVELCATCODE,d.LevelTypeCode,d.SY,d.StrandCode, 'N', @USERID 
FROM Admission.App_Info_MF d
WHERE d.AppNum = @APPNUM

--UPDATE CLINIC INFORMATION
--06-28-2016
UPDATE Health.Stud_Health_Info_MF
SET SNUM = @STUDNUM
WHERE SNUM = @APPNUM

UPDATE Health.Stud_GivenMed_MF
SET SNUM =@STUDNUM
WHERE SNUM = @APPNUM

UPDATE Health.Stud_Illness_MF
SET SNUM = @STUDNUM
WHERE SNUM = @APPNUM

END 