--CONSOLIDATE STATISTICS 
--GUIDANCE ADMISSION REPORT
--RUSEL VASQUEZ 03/08/2016

ALTER VIEW vr_consolidatedStat_GUI AS
SELECT xlt.Arr, XLT.LevelTypeDesc,  XS.StrandCode, COUNT (*) AS Total_Applicant, 
COUNT(VTE.Appnum) AS Taken_Exam, COUNT(*) - COUNT(VTE.Appnum) AS Not_Yet_Taken_Exam,
COUNT(VPA.APPNUM) AS Passed, COUNT(VFA.AppNum) AS Failed
FROM xSystem.LevelType_RF XLT
LEFT OUTER JOIN Admission.App_Info_MF AAI
ON XLT.LevelTypeCode = AAI.LevelTypeCode
LEFT OUTER JOIN xSystem.Strand_RF XS
ON XLT.LevelTypeCode = XS.LevelTypeCode and AAI.StrandCode = XS.StrandCode
LEFT OUTER JOIN dbo.vr_ListTakeAppExam VTE
ON AAI.AppNum = VTE.AppNum AND XLT.LevelTypeCode = VTE.LevelTypeCode and AAI.StrandCode = VTE.StrandCode
LEFT OUTER JOIN dbo.vr_ListPassedApp VPA
ON AAI.AppNum = VPA.APPNUM AND XLT.LevelTypeCode = VPA.LevelTypeCode AND AAI.StrandCode = VPA.StrandCode
LEFT OUTER JOIN dbo.vr_ListFailedApp VFA
ON AAI.AppNum = VFA.APPNUM AND XLT.LevelTypeCode = VFA.LevelTypeCode AND AAI.StrandCode = VFA.StrandCode
GROUP BY XLT.Arr, XLT.LevelTypeDesc, XS.StrandCode
