-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/25/2016
-- Description:	SIMS- GET PLACE INCIDENT  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_PLACE_INCIDENT_LIST
WITH ENCRYPTION
AS
BEGIN
	SELECT placeIncidentCode, placeIncidentDesc
	FROM Health.placeIncident_RF
	
END

