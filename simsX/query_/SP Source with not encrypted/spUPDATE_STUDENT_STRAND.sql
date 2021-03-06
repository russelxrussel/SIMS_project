USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/24/2016
-- Description:	SIMS- UPDATE STUDENT STRAND OF GRADE 11
-- COMMAND: UPDATE
-- =============================================

CREATE PROC [dbo].[spUPDATE_STUDENT_STRAND]
@STRANDCODE nvarchar(1),
@STUDNUM nvarchar(7),
@USERID nvarchar(25)

WITH ENCRYPTION
AS
BEGIN


UPDATE Registration.Student_Info_MF
SET StrandCode=@STRANDCODE, DateUpdate=GETDATE(),UserID=@USERID
WHERE StudNum=@STUDNUM

UPDATE Registration.Student_MF
SET StrandCode=@STRANDCODE, DU =GETDATE(),
UserID = @USERID
WHERE StudNum=@STUDNUM


END