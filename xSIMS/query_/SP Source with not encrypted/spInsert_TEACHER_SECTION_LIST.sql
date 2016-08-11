-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05-14-2016
-- Description:	SIMS- TEACHER SECTION LIST 
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spInsert_TEACHER_SECTION_LIST
@SY nvarchar(9),
@LEVELCODE nvarchar(3),
@SECTIONCODE nvarchar(2),
@ROOMID	int,
@TEACHERID nvarchar(50),
@SCHEDDESC nvarchar(50),
@BUILDINGDESC nvarchar(50),
@USERID nvarchar(50)  

WITH ENCRYPTION
AS

BEGIN
 
	INSERT INTO Registration.TeacherSectionList_MF
	VALUES(@SY,@LEVELCODE,@SECTIONCODE,@ROOMID,@TEACHERID,@SCHEDDESC,@BUILDINGDESC,
	GETDATE(),GETDATE(),@USERID) 
END
