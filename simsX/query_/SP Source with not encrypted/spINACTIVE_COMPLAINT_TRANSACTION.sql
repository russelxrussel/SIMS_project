-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-25-2016
-- Description:	SIMS- COMPLAINT TRANSACTION
-- COMMAND: DELETE
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spINACTIVE_COMPLAINT_TRANSACTION 
@TRANSCODE nvarchar(12),
@USERID	nvarchar(50)
WITH ENCRYPTION
AS

BEGIN
 
  UPDATE Health.Patient_Complaint_Summary_TF
  SET compStatus = 0, DU=GETDATE(), userID=@USERID
  WHERE transCode = @TRANSCODE
  
END
