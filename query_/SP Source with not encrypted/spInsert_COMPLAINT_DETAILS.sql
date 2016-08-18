-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07-27-2016
-- Description:	SIMS- COMPLAINT DETAILS
-- COMMAND: INSERT
-- =============================================
USE dbSIMS
GO

CREATE PROCEDURE spInsert_COMPLAINT_DETAILS
@TRANSCODE nvarchar(12),
@COMPLAINTCODE nvarchar(4)  

WITH ENCRYPTION
AS

BEGIN
 
  INSERT INTO 
  Health.Patient_Complaint_Details_TF(transcode,complaintCode)
  VALUES
  (@TRANSCODE,@COMPLAINTCODE)
  	

END
