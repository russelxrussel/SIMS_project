-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/11/2016
-- Description:	SIMS- GET MEDICINE LEVEL  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_MEDICINE_LEVEL
WITH ENCRYPTION
AS
BEGIN
	SELECT medLevelCode,medLevelDesc
	FROM Health.MedicineLevel_RF
	
END

