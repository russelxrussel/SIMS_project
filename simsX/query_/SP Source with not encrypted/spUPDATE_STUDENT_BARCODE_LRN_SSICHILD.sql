USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 06/01/2016
-- Description:	SIMS- UPDATE STUDENT BARCODE, LRN, SSICHILD
-- COMMAND: UPDATE
-- =============================================

CREATE PROC [dbo].[spUPDATE_STUDENT_BARCODE_LRN_SSICHILD]
@BARCODE nvarchar(50),
@LRN nvarchar(50),
@SSICHILD bit,
@STUDNUM nvarchar(7),
@USERID nvarchar(25)

WITH ENCRYPTION
AS
BEGIN

UPDATE Registration.Student_Info_MF
SET Barcode=@BARCODE, LRN=@LRN,SSIChild=@SSICHILD, 
DateUpdate=GETDATE(),UserID=@USERID
WHERE StudNum=@STUDNUM




END