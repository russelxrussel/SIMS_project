-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET RELIGION LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_RELIGION_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select ReligionCode, ReligionDesc 
from Utilities.Religion_RF 
order by Arr
	
END
