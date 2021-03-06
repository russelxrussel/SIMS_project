USE [dbSIMS]
GO
/****** Object:  Trigger [Admission].[tr_ToSysAudit]    Script Date: 10/08/2015 10:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [Admission].[tr_ToApplicantStatusTrail_ForInsert] 
   ON  [Admission].[App_Info_MF] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	Declare @id int, @KeyId nvarchar(8),		
			@UserCode nvarchar(20), @DU Datetime,
			@StatCode nvarchar(1)
	
	Select @KeyId=AppNum, @UserCode=Usercode 
		   From Inserted 	
		  
			--Set StatCode default to 1
			SET @StatCode = 1
			
			SET @DU = Getdate()
			
			
	
			INSERT INTO Admission.App_Trail_TF
			VALUES(@KeyID,@StatCode,@DU,@UserCode)
	
END
