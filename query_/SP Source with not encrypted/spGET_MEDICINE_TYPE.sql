-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/11/2016
-- Description:	SIMS- GET MEDICINE TYPE  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_MEDICINE_TYPE
WITH ENCRYPTION
AS
BEGIN
	SELECT medTypeCode,TypeDesc 
	FROM Health.MedicineType_RF
	
END

