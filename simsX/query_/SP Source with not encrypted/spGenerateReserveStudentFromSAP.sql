USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spGenerateReserveStudentFromSAP]    Script Date: 05/23/2016 11:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PULL OUT RESERVED STUDENT FROM SAP
--INSERT INTO TEMPORARY TABLE
--UPDATE RECORD 

--Russel Vasquez
--04/15/2016

ALTER PROC [dbo].[spGenerateReserveStudentFromSAP]
WITH ENCRYPTION
AS
BEGIN

SET NOCOUNT ON;

--Initial
--Declare variable to hold data
--Use to have condition in updating record on Student_MF
Declare @STAT nvarchar(2), @STUDNUM nvarchar(10)

----[1]REMOVE FIRST DATA ON TEMPORARY TABLE
DELETE FROM dbo.temp_res

--[2] INSERT FRESH DATA AGAIN INTO TEMP_RESERVE_TABLE
--WITH SELECTION QUERY AGAINST SAP DATABASE FT_ORCT TABLE
INSERT INTO dbo.temp_res(studnum,date_)
SELECT  Distinct u_studentno,u_docdate 
from [192.168.2.100].[SSI].[dbo].[@FT_ORCT]
where U_YEAR = '2016' and U_PymtFor = 'Reservation' and U_Status = 'P'



	UPDATE RS
	SET RS.StatCodeR = 'RE', RS.DatePayR = B.date_
	FROM Registration.Student_MF RS
	INNER JOIN dbo.temp_res B
	ON RS.studnum = B.studnum


END

--EXEC spGenerateReserveStudentFromSAP

--select COUNT(*) from Registration.Student_MF
--where StatCodeR = 'RE'

