USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spGenerateEnrolledStudentFromSAP]    Script Date: 05/23/2016 11:37:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PULL OUT ENROLLED STUDENT FROM SAP
--INSERT INTO TEMPORARY TABLE
--UPDATE RECORD 

--Russel Vasquez
--04/15/2016

ALTER PROC [dbo].[spGenerateEnrolledStudentFromSAP]
WITH ENCRYPTION
AS

BEGIN

SET NOCOUNT ON;

--Initial
--Declare variable to hold data
--Use to have condition in updating record on Student_MF
--Declare @STUDNUM nvarchar(10), @STAT nvarchar(2)

----[1]REMOVE FIRST DATA ON TEMPORARY TABLE
DELETE FROM dbo.temp_enroll

--[2] INSERT FRESH DATA AGAIN INTO TEMP_RESERVE_TABLE
--WITH SELECTION QUERY AGAINST SAP DATABASE FT_ORCT TABLE
INSERT INTO dbo.temp_enroll(studnum,date_, or_)
SELECT distinct U_studentno, u_docdate, u_docnum
from [192.168.2.100].[SSI].[dbo].[@FT_ORCT]
where U_simsref <> '0' and U_simsref <> '' and  U_pymtfor = 'UPON ENROLLMENT' and U_Year = '2016' and U_Status = 'P'

--U_simsref <> '0' and U_simsref <> '' and 
--SUBTITUTE STATUS 
--SELECT @STAT= RS.StatCode 
--FROM Registration.Student_MF RS

--IF(@STAT <> 'EN')
--BEGIN
	UPDATE RS
	SET RS.StatCode= 'EN', RS.DatePay = B.date_, RS.ORNum = B.or_
	FROM Registration.Student_MF RS
	INNER JOIN dbo.temp_enroll B
	ON RS.studnum = B.studnum
--END 

--UPDATE HEALTH APPLICANT TO STUDENT NUMBER
--06-28-2016
EXEC spUPDATE_HEALTH_APPLICANT_TO_STUDENT

END

	--UPDATE RS
	--SET RS.StatCode= '', RS.DatePay = '', RS.ORNum = ''
	--FROM Registration.Student_MF RS

--EXEC spGenerateEnrolledStudentFromSAP

--select COUNT(*) from Registration.Student_MF
--where StatCode = 'EN'

--select COUNT(*) from dbo.temp_res

--select COUNT(*) from Registration.Student_MF
--WHERE StatCode = 'EN'

--UPDATE A
--SET A.stat = 'RE'
--FROM dbo.temp_extra A
--INNER JOIN [192.168.2.100].[SSI].[dbo].[@FT_ORCT] B
--ON A.studnum = B.u_studentno
--WHERE B.U_YEAR = '2016' and B.U_PymtFor = 'Reservation' and B.U_Status = 'P'


--SELECT distinct U_studentno
--from [192.168.2.100].[SSI].[dbo].[@FT_ORCT]
--where U_pymtfor = 'UPON ENROLLMENT' and U_Year = '2016' and U_Status = 'P'
