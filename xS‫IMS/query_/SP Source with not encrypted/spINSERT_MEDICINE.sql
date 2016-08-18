-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-11-2016
-- Description:	SIMS- MEDICINE 
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spINSERT_MEDICINE
@MEDCODE nvarchar(3),
@MEDDESC nvarchar(75),
@MEDGENERICNAME nvarchar(75),
@MEDTYPECODE nvarchar(3),
@MEDLEVELCODE nvarchar(3),
@USERID nvarchar(50)  

WITH ENCRYPTION
AS

BEGIN
 
 INSERT INTO Health.Medicine_MF(medCode,medDesc,medGenericName,medTypeCode,medLevelCode,DU,userID)
 VALUES(@MEDCODE,@MEDDESC,@MEDGENERICNAME,@MEDTYPECODE,@MEDLEVELCODE,GETDATE(), @USERID)
	
END
