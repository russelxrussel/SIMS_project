-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-27-2016
-- Description:	SIMS- PATIENT MEDICINE DETAILS
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spInsert_PATIENT_MEDICINE_DETAILS
@TRANSCODE nvarchar(12),
@MEDCODE nvarchar(4),
@QUANTITY int,
@BATCHID int  

WITH ENCRYPTION
AS

BEGIN
 
  INSERT INTO 
  Health.Patient_Medicine_Details_TF(transcode,medCode, quantity, batchID)
  VALUES
  (@TRANSCODE,@MEDCODE,@QUANTITY, @BATCHID)
  	

END
