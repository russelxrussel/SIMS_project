USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentsActive]    Script Date: 05/13/2016 10:24:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--GET LIST OF STUDENT
--WITH ACTIVE STATUS AND NO SECTION YET
--RUSSEL VASQUEZ
--05/13/2016

ALTER PROC [dbo].[spGetStudentsActiveWithSection]
WITH ENCRYPTION
AS
BEGIN
	Select RSM.StudNum, RSM.StudName, RSM.LevelCode, RSM.StrandCode, RSM.StudTypeCode, RSM.Section, RSM.roomID, RSI.GenderCode 
	From Registration.Student_MF RSM
	INNER JOIN Registration.Student_Info_MF RSI
	ON RSM.StudNum = RSI.StudNum
	where RSM.StatCode = 'EN'
END
