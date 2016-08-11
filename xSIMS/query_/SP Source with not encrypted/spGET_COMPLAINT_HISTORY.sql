-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 08/02/2016
-- Description:	SIMS- GET COMPLAINT HISTORY  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spGET_COMPLAINT_HISTORY
@PATIENTNUM nvarchar(8)
WITH ENCRYPTION
AS
BEGIN
	
	SELECT PCS.patientNum, PCS.transCode,CR.complaintDesc, PCS.compDate 
	FROM Health.Patient_Complaint_Summary_TF PCS
	INNER JOIN Health.Patient_Complaint_Details_TF PCD
	ON PCS.transCode = PCD.transCode
	INNER JOIN Health.Complaint_RF CR
	ON PCD.complaintCode = CR.complaintCode 
	WHERE PCS.patientNum = @PATIENTNUM
	
	ORDER BY compDate desc
	
END

