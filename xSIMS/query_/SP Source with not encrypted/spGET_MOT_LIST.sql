-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 05/23/2016
-- Description:	SIMS- GET MOT LIST  
-- COMMAND: SELECT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spGET_MOT_LIST
WITH ENCRYPTION
AS
BEGIN
	
	SELECT motCode, motDescription 
	FROM Utilities.MOT_RF 
	ORDER by id
	 
	
END
