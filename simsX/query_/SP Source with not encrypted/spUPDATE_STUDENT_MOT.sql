USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/24/2016
-- Description:	SIMS- UPDATE STUDENT MODE OF TRANSPORTATION
-- COMMAND: UPDATE
-- =============================================

CREATE PROC [dbo].[spUPDATE_STUDENT_MOT]
@MOTCODE nvarchar(1),
@STUDNUM nvarchar(7),
@USERID nvarchar(25)

WITH ENCRYPTION
AS
BEGIN

UPDATE Registration.Student_Info_MF
SET motCode=@MOTCODE, DateUpdate=GETDATE(),UserID=@USERID
WHERE StudNum=@STUDNUM




END