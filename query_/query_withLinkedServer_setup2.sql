

SELECT XLT.Arr, XTS.LevelTypeCode, XTS.StrandCode, XTS.RegularCount, 
COUNT(ZRN.appnum) as New_Student
FROM Admission.App_Info_MF AAI
INNER JOIN xSystem.TargetStudents_MF XTS
ON AAI.LevelTypeCode = XTS.LevelTypeCode AND AAI.StrandCode = XTS.StrandCode
INNER JOIN xSystem.LevelType_RF XLT
ON XTS.LevelTypeCode = XLT.LevelTypeCode
LEFT OUTER JOIN [192.168.2.5].ISAMSDB.dbo.vr_SimsReservedNew ZRN
ON AAI.AppNum = ZRN.appnum
GROUP BY XLT.Arr, XTS.LevelTypeCode, XTS.StrandCode, XTS.RegularCount
ORDER BY XLT.ARR



