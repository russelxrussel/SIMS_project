USE [dbSIMS]
GO

/****** Object:  StoredProcedure [dbo].[spGenerateEnrolledStudentFromSAP]    Script Date: 04/14/2016 21:10:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[spGenerateEnrolledStudentFromSAP]
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
INSERT INTO dbo.temp_enroll(studnum,date_)
SELECT distinct U_studentno, u_docdate
from [192.168.2.100].[SSI].[dbo].[@FT_ORCT]
where U_simsref <> '0' and U_simsref <> '' and U_pymtfor = 'UPON ENROLLMENT' and U_Year = '2016'

--SUBTITUTE STATUS 
--SELECT @STAT= RS.StatCode 
--FROM Registration.Student_MF RS

--IF(@STAT <> 'EN')
--BEGIN
	UPDATE RS
	SET RS.StatCode= 'EN', RS.DatePay = B.date_
	FROM Registration.Student_MF RS
	INNER JOIN dbo.temp_enroll B
	ON RS.studnum = B.studnum
--END 

END

--EXEC spGenerateEnrolledStudentFromSAP
EXEC spGenerateReserveStudentFromSAP

--select COUNT(*) from Registration.Student_MF
--where StatCode = 'RE'

--select COUNT(*) from dbo.temp_res

--select COUNT(*) from Registration.Student_MF
--WHERE StatCode = 'EN'

--UPDATE A
--SET A.stat = 'RE'
--FROM dbo.temp_extra A
--INNER JOIN [192.168.2.100].[SSI].[dbo].[@FT_ORCT] B
--ON A.studnum = B.u_studentno
--WHERE B.U_YEAR = '2016' and B.U_PymtFor = 'Reservation' and B.U_Status = 'P'

GO


