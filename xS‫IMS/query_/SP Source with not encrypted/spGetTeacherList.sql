
-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 
-- Description:	SIMS-  
-- COMMAND:
-- =============================================
USE dbSIMS
GO
CREATE PROCEDURE spGetTeacherList
WITH ENCRYPTION
AS
BEGIN
SELECT UserId,Uname FROM xSystem.UserCredentials_RF
where UType = 'T'
END
