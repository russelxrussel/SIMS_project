-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET GENDER LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_BARANGAY_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select BarangayCode,BarangayDesc 
from Utilities.Barangay_RF
	
END
