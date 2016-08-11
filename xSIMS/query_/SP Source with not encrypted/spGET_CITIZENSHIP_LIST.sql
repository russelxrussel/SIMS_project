-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET CITIZENSHIP LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_CITIZENSHIP_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select CitizenshipCode, CitizenshipDesc 
from Utilities.Citizenship_RF 
order by Arr
	
END
