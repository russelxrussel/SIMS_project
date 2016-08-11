-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 06-16-2016
-- Description:	SIMS- SUMMARY REPORT OF TESTING DATA STATISTICS
-- COMMAND: SELECT - INNER JOIN
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spREP_TESTING_SUMMARY_STAT
--@SY nvarchar(9)
WITH ENCRYPTION
AS
BEGIN

SELECT XLT.LevelTypeDesc, XSR.StrandName, vss.studentcount,vss.Closed_Slot, vss.Open_Slot, 
COUNT (aai.appnum) as totalApp,
COUNT (VTA.appnum) as Taken_Exam,
(COUNT (aai.appnum) - COUNT (VTA.appnum)) as Not_Taken_Exam,
COUNT (VLP.APPNUM) as Passed, 
COUNT(VLF.appnum) as Failed

FROM xSystem.LevelType_RF XLT

LEFT OUTER JOIN xSystem.TargetStudents_MF XTS
ON XLT.LevelTypeCode = XTS.LevelTypeCode
LEFT OUTER JOIN xSystem.Strand_RF XSR
ON XTS.StrandCode = XSR.StrandCode
LEFT OUTER JOIN Admission.App_Info_MF AAI
ON XLT.LevelTypeCode = AAI.LevelTypeCode and XTS.StrandCode = AAI.StrandCode
LEFT OUTER JOIN v_slot_status VSS
ON XLT.LevelTypeCode = VSS.leveltypecode and VSS.strandcode = AAI.StrandCode
--TAKEN EXAM
LEFT OUTER JOIN vr_ListTakenApp VTA
ON XLT.LevelTypeCode = VTA.LevelTypeCode AND XTS.StrandCode = VTA.StrandCode AND AAI.AppNum = VTA.APPNUM
--PASSED
LEFT OUTER JOIN vr_ListPassedApp VLP
ON XLT.LevelTypeCode = VLP.LevelTypeCode AND XTS.StrandCode = VLP.StrandCode AND AAI.AppNum = VLP.APPNUM
--FAILED
LEFT OUTER JOIN vr_ListFailedApp VLF
ON XLT.LevelTypeCode = VLF.LevelTypeCode AND XTS.StrandCode = VLF.StrandCode AND AAI.AppNum = VLF.APPNUM


GROUP BY XLT.LevelTypeDesc, XSR.StrandName, vss.studentcount,vss.Closed_Slot, vss.Open_Slot



--WHERE RSM.SY=@SY

END


   