-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 08/02/2016
-- Description:	SIMS- GET LIST OF PATIENT COMPLAINT  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spGET_COMPLAINT_LIST_PATIENT
@TRANSCODE nvarchar(12)
WITH ENCRYPTION
AS
BEGIN
	
	SELECT CR.complaintCode as CODE, cR.complaintDesc as Complaint
	FROM Health.Patient_Complaint_Details_TF PCD
	INNER JOIN Health.Complaint_RF CR
	ON PCD.complaintCode = CR.complaintCode 
	WHERE PCD.transCode = @TRANSCODE

	
END

