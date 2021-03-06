USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/24/2016
-- Description:	SIMS- UPDATE STUDENT ENROLLMENT
-- COMMAND: UPDATE
-- =============================================

ALTER PROC [dbo].[spUPDATE_STUDENT_ENROLLMENT_STATUS]
@STATCODE nvarchar(3),
@STUDNUM nvarchar(7),
@USERID nvarchar(25)

WITH ENCRYPTION
AS
BEGIN

IF @STATCODE = 'EB' 
	BEGIN
		UPDATE Registration.Student_MF
		SET StatCode=@STATCODE, BO_E='true', 
		StatCodeR='RB', BO_R= 'true', DU=GETDATE(),UserID=@USERID
		WHERE StudNum=@STUDNUM
	END

	ELSE
	
		UPDATE Registration.Student_MF
		SET StatCode=@STATCODE, DU=GETDATE(),UserID=@USERID
		WHERE StudNum=@STUDNUM


END