-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/25/2016
-- Description:	SIMS- GET TIME INCIDENT  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spGET_TIME_INCIDENT_LIST
WITH ENCRYPTION
AS
BEGIN

	SELECT timeIncidentCode, timeIncidentDesc
	FROM Health.TimeIncident_RF
	
END

