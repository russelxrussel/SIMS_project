-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/13/2016
-- Description:	SIMS- GET MEDICINE BATCH
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spGET_MEDICINE_BATCH
WITH ENCRYPTION
AS
BEGIN
	SELECT BatchID, medCode, minLevel, stockOnHand, CONVERT(varchar, expirationDate, 110) as expirationDate
	FROM Health.Medicine_Stock_MF
	WHERE stockOnHand <> 0
	order by expirationdate asc
END

