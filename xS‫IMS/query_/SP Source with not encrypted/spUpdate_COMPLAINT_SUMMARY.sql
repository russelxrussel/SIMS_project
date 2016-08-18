-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 08-05-2016
-- Description:	SIMS- COMPLAINT SUMMARY
-- COMMAND: UPDATE
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spUpdate_COMPLAINT_SUMMARY
@TRANSCODE nvarchar(12),
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
@USERID nvarchar(50)  

WITH ENCRYPTION
AS

BEGIN
 
 
  UPDATE Health.Patient_Complaint_Summary_TF
  SET
  compDate=@COMPDATE,compTime=@COMPTIME,notes=@NOTES,
  sentHome=@SENTHOME,sentHospital=@SENTHOSPITAL,
  timeIncidentCode=@TIMEINCIDENTCODE,placeIncidentCode=@PLACEINCIDENTCODE,
  physician=@PHYSICIAN,amount=@AMOUNT,remarks=@REMARKS,
  DU=GETDATE(),userID=@USERID
  WHERE
  transCode=@TRANSCODE
  	

END
