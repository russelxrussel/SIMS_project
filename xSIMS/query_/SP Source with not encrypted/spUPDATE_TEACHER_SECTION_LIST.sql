-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05-23-2016
-- Description:	SIMS- TEACHER SECTION LIST 
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spUPDATE_TEACHER_SECTION_LIST
@ID int,
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
 
	UPDATE Registration.TeacherSectionList_MF
	SET SY=@SY, levelCode=@LEVELCODE,sectionCode=@SECTIONCODE,
	roomID=@ROOMID,teacherID=@TEACHERID,schedDesc=@SCHEDDESC,
	bldgDesc=@BUILDINGDESC,DU=GETDATE(),userID=@USERID
	WHERE id=@ID 
 
	--INSERT INTO Registration.TeacherSectionList_MF
	--VALUES(@SY,@LEVELCODE,@SECTIONCODE,@ROOMID,@TEACHERID,@SCHEDDESC,@BUILDINGDESC,
	--GETDATE(),GETDATE(),@USERID) 
END
