-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-25-2016
-- Description:	SIMS- COMPLAINT SUMMARY
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spInsert_COMPLAINT_SUMMARY
@TRANSCODE nvarchar(12),
@SY nvarchar(9),
@PATIENTNUM nvarchar(10),
@COMPDATE datetime,
@COMPTIME datetime,
@NOTES nvarchar(250),
@SENTHOME bit,
@SENTHOSPITAL bit,
@TIMEINCIDENTCODE nvarchar(4),
@PLACEINCIDENTCODE nvarchar(4),
@PHYSICIAN nvarchar(50),
@AMOUNT nvarchar(10),
@REMARKS nvarchar(250),
@PATIENTTYPE bit,
@USERID nvarchar(50)  

WITH ENCRYPTION
AS

BEGIN
 
  INSERT INTO 
  Health.Patient_Complaint_Summary_TF(transcode,SY, patientNum,compDate,compTime,
  notes,sentHome,sentHospital,timeIncidentCode,placeIncidentCode,physician,
  amount,remarks,patientType,DU,userID)
  VALUES
  (@TRANSCODE,@SY,@PATIENTNUM,@COMPDATE,@COMPTIME,@NOTES,@SENTHOME,@SENTHOSPITAL,
  @TIMEINCIDENTCODE,@PLACEINCIDENTCODE,@PHYSICIAN,@AMOUNT,@REMARKS,@PATIENTTYPE,
  GETDATE(),@USERID)
  	

END
