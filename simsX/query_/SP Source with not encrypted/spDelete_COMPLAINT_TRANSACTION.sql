-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-25-2016
-- Description:	SIMS- COMPLAINT TRANSACTION
-- COMMAND: DELETE
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spDelete_COMPLAINT_TRANSACTION
@TRANSCODE nvarchar(12)
WITH ENCRYPTION
AS

BEGIN
 
  DELETE Health.Patient_Complaint_Summary_TF
  WHERE transCode = @TRANSCODE
  
  DELETE Health.Patient_Complaint_Details_TF
  where transCode = @TRANSCODE
  
  DELETE Health.Patient_Medicine_Details_TF
  where transCode = @TRANSCODE
  

END
