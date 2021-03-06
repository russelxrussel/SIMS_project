USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentInformation]    Script Date: 05/24/2016 16:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* GET SPECIFIC INFORMATION OF STUDENT
   RUSSEL VASQUEZ
   12/03/2015
   RE: 03/17/2016
*/

ALTER PROC [dbo].[spGetStudentInformation]
@STUDNUM nvarchar(7)
WITH ENCRYPTION
AS
BEGIN
SELECT * FROM Registration.Student_Info_MF RSI
LEFT OUTER JOIN xSystem.LevelType_RF XLT
ON RSI.Current_LevelCode = XLT.LevelTypeCode
LEFT OUTER JOIN xSystem.Strand_RF XSR
ON RSI.StrandCode = XSR.StrandCode
LEFT OUTER JOIN Registration.Student_MF RSM
ON RSI.StudNum = RSM.StudNum
WHERE RSI.StudNum = @STUDNUM

END

