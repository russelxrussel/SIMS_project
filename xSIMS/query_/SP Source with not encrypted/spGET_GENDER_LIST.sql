-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET GENDER LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_GENDER_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select GenderCode,GenderDesc 
from Utilities.Gender_RF 
order by ID
	
END
