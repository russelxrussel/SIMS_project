-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/13/2016
-- Description:	SIMS- GET MEDICINE LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_MEDICINE_LIST
WITH ENCRYPTION
AS
BEGIN
	SELECT medCode, medDesc, medTypeCode, medLevelCode
	FROM Health.Medicine_MF
END

