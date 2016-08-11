-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 08/02/2016
-- Description:	SIMS- GET LIST OF PATIENT MEDICINE 
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_MEDICINE_LIST_PATIENT
@TRANSCODE nvarchar(12)
WITH ENCRYPTION
AS
BEGIN
	
	SELECT PMD.batchID AS BATCHID,PMD.medCode as CODE, HMF.medDesc as DESCRIPTION, PMD.quantity as QUANTITY 
	FROM Health.Patient_Medicine_Details_TF PMD
	INNER JOIN Health.Medicine_MF HMF
	ON PMD.medCode = HMF.medCode
	WHERE PMD.transCode = @TRANSCODE
	
END

