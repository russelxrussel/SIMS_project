-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/25/2016
-- Description:	SIMS- GET STRAND LIST
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_STRAND_LIST
WITH ENCRYPTION
AS
BEGIN
	
Select StrandCode, StrandName 
from xSystem.Strand_RF 
order by ID
	
END
