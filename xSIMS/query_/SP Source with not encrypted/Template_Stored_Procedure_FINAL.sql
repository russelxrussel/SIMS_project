-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05-18-2016
-- Description:	SIMS- REPORT CLASS LIST  
-- COMMAND: SELECT - INNER JOIN
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spREP_SECTIONLIST
WITH ENCRYPTION
AS
BEGIN
SELECT RTS.id, RTS.SY, RTS.levelCode, RTS.sectionCode, UPPER(RTS.levelCode + '-' + RTS.sectionCode) as levelSection,RTS.roomID,
	RTS.teacherID, UPPER(RTS.schedDesc) as Schedule, UPPER(URL.roomDescription)as roomDescription, USL.sectionDesc,
	UPPER(XUC.Uname)as TeacherName, RSM.StudNum, 
	(CASE WHEN RSI.ReligionCode = 'CAT' THEN RSM.StudName 
		  ELSE RSM.StudName + ' *' END) as StudendName, RSI.ReligionCode
	FROM Registration.TeacherSectionList_MF RTS 
	INNER JOIN Utilities.RoomList_RF URL
	ON RTS.roomID = URL.roomID
	INNER JOIN Utilities.SectionList_RF USL
	ON RTS.sectionCode = USL.sectionCode
	LEFT OUTER JOIN xSystem.UserCredentials_RF XUC
	on RTS.teacherID = XUC.UserId
	INNER JOIN Registration.Student_MF RSM
	ON RTS.sectionCode = RSM.Section AND RTS.roomID = RSM.roomID
	INNER JOIN Registration.Student_Info_MF RSI
	ON RSM.StudNum = RSI.StudNum
END


   