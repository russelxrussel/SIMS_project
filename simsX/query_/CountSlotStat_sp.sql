USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spSlotDetails]    Script Date: 10/05/2015 16:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Proc [dbo].[spSlotDetails]
@SY nvarchar(9)
AS
BEGIN

SELECT c.Arr, a.SY, a.LevelTypeCode, a.TargetApplicants,
		(Select COUNT(b.leveltypeCode) 
		 From Registrar.EnrollmentStat_TF b
		 Where a.LevelTypeCode = b.levelTypeCode and a.SY = @SY and b.IniStatCode != 'N')
		 as ClosedSlot,
		 (a.TargetApplicants -(Select COUNT(b.leveltypeCode) 
		 From Registrar.EnrollmentStat_TF b
		 Where a.LevelTypeCode = b.levelTypeCode and a.SY = @SY and b.IniStatCode != 'N')) as OpenSlot
FROM xSystem.TargetApplicant_MF a
left outer join xSystem.LevelType_RF c
ON a.LevelTypeCode = c.LevelTypeCode
GROUP by
   c.Arr, a.SY, a.LevelTypeCode, a.TargetApplicants

END