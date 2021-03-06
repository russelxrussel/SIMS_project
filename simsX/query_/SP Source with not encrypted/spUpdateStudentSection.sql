USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudentSection]    Script Date: 05/17/2016 15:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/17/2016
-- Description:	SIMS-Update Section of Student
-- =============================================

ALTER PROCEDURE [dbo].[spUpdateStudentSection]
@STUDNUM nvarchar(7),
@SECTION nvarchar(1),
@ROOMID int,
@USERID nvarchar(50)
WITH ENCRYPTION
AS
BEGIN
	--UPDATE STUDENT_MF TABLE
	UPDATE Registration.Student_MF
	SET Section = @SECTION, roomid=@ROOMID, UserID=@USERID, DU = GETDATE()
	WHERE StudNum = @STUDNUM
	
	--UPDATE STUDENT_INFO_MF TABLE
	update Registration.Student_Info_MF
	SET Current_Section = @SECTION, UserID=@USERID, DateUpdate = GETDATE()
	WHERE StudNum = @STUDNUM
	
	--UPDATE SAP_OCRD TABLE
	UPDATE [192.168.2.100].[SSI].[dbo].[@FT_OCRD]
	SET U_Section=@SECTION,U_Action='U',
	U_Processed='N',U_ForProcess='Y'
	WHERE U_StudentNo=@STUDNUM 

END

--SELECT * FROM Registration.Student_MF
--WHERE Section = 'D'

--SELECT * FROM Registration.Student_Info_MF
--WHERE Current_Section = 'C'

--SELECT * FROM [192.168.2.100].[SSI].[dbo].[@FT_OCRD]
--WHERE U_Section = 'C'

