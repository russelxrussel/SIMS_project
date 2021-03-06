USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spGenerateReserveStudentFromSAP]    Script Date: 04/14/2016 21:15:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[spGenerateReserveStudentFromSAP]
AS
BEGIN

SET NOCOUNT ON;

--Initial
--Declare variable to hold data
--Use to have condition in updating record on Student_MF
Declare @STAT nvarchar(2)

----[1]REMOVE FIRST DATA ON TEMPORARY TABLE
DELETE FROM dbo.temp_res

--[2] INSERT FRESH DATA AGAIN INTO TEMP_RESERVE_TABLE
--WITH SELECTION QUERY AGAINST SAP DATABASE FT_ORCT TABLE
INSERT INTO dbo.temp_res(studnum,date_)
SELECT  Distinct u_studentno,u_docdate 
from [192.168.2.100].[SSI].[dbo].[@FT_ORCT]
where U_YEAR = '2016' and U_PymtFor = 'Reservation' and U_Status = 'P'

--SUBTITUTE STATUS 
SELECT @STAT= RS.StatCode 
FROM Registration.Student_MF RS

IF(@STAT = '' OR @STAT IS NULL)
BEGIN
	UPDATE RS
	SET RS.StatCode = 'RE', RS.DatePay = B.date_
	FROM Registration.Student_MF RS
	INNER JOIN dbo.temp_res B
	ON RS.studnum = B.studnum
END 

END

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
