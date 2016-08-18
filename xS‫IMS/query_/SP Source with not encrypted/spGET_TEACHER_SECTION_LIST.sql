-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/14/2016
-- Description:	SIMS- GET TEACHER SECTION LIST  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spGET_TEACHER_SECTION_LIST
WITH ENCRYPTION
AS
BEGIN
	
	SELECT RTS.id, RTS.SY, RTS.levelCode, RTS.strandCode, RTS.sectionCode, UPPER(RTS.levelCode + '-' + RTS.sectionCode) as levelSection,RTS.roomID,
	RTS.teacherID, UPPER(RTS.schedDesc) as Schedule, UPPER(URL.roomDescription)as roomDescription, USL.sectionDesc,
	UPPER(XUC.Uname)as TeacherName, RTS.bldgDesc
	FROM Registration.TeacherSectionList_MF RTS 
	INNER JOIN Utilities.RoomList_RF URL
	ON RTS.roomID = URL.roomID
	INNER JOIN Utilities.SectionList_RF USL
	ON RTS.sectionCode = USL.sectionCode
	left outer JOIN xSystem.UserCredentials_RF XUC
	on RTS.teacherID = XUC.UserId
	
END
