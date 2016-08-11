-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/13/2016
-- Description:	SIMS- GET MEDICINE LEVEL  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_COMPLAINT_LIST
WITH ENCRYPTION
AS
BEGIN
	SELECT complaintCode, complaintDesc
	FROM Health.Complaint_RF
END

