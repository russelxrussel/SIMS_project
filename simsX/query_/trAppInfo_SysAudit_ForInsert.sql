

USE [dbSIMS]
GO
/****** Object:  Trigger [Admission].[tr_ToSysAudit_ForInsert]    Script Date: 10/08/2015 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Russel Vasquez
-- Create date: 10/08/2015
-- Description:	This will insert record to xSystem.SysAudit_MF
-- =============================================
ALTER TRIGGER [Admission].[tr_ToSysAudit_ForInsert] 
   ON  [Admission].[App_Info_MF] 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	Declare @id int, @KeyId nvarchar(8),
			@TableTrigger nvarchar(50),@Action nvarchar(250),
			@UserCode nvarchar(20), @DU Datetime
	
	Select @Id=id, @KeyId=AppNum, @UserCode=Usercode 
		   From Inserted 	
		  
			SET @TableTrigger = 'App_Info_MF'
			SET @DU = Getdate()
			
			SET @Action = 'Applicant with ' + @KeyId +
						  ' was inserted at ' + cast(@DU as nvarchar(20)) +
						  ' by ' + @UserCode
	
			INSERT INTO xSystem.Sys_Audit_MF
			VALUES(@KeyID, @TableTrigger, @Action, @DU, @UserCode)
	
END
