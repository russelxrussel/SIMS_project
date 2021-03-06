USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/24/2016
-- Description:	SIMS- UPDATE STUDENT RESERVATION
-- COMMAND: UPDATE
-- =============================================

ALTER PROC [dbo].[spUPDATE_STUDENT_RESERVATION_STATUS]
@STATCODER nvarchar(3),
@STUDNUM nvarchar(7),
@USERID nvarchar(25)

WITH ENCRYPTION
AS
BEGIN

IF @STATCODER = 'RB' 
	BEGIN
		UPDATE Registration.Student_MF
		SET StatCodeR=@STATCODER, BO_R= 'true', DU=GETDATE(),UserID=@USERID
		WHERE StudNum=@STUDNUM
	END

	ELSE
	
		UPDATE Registration.Student_MF
		SET StatCodeR=@STATCODER, DU=GETDATE(),UserID=@USERID
		WHERE StudNum=@STUDNUM


END