-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET CITY LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_CITY_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select CityCode,CityDesc 
from Utilities.CityProvince_RF 
order by Arr
	
END
