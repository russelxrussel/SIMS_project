--FOR TABULAR REPORT GENERATION
--RUSSEL VASQUEZ
--02/17/2016

select lt.arr,lt.LevelTypeCode, ai.StrandCode, ts.StudentCount, count(*) as ct,
ts.StudentCount - COUNT(*) as TOTAL, ts.StudentCount - COUNT(vp.APPNUM) as Open_Slot,
COUNT(vp.APPNUM) as passed, COUNT(vf.appnum) as failed
from xSystem.LevelType_RF lt
left outer join Admission.App_Info_MF ai
ON lt.LevelTypeCode = ai.LevelTypeCode
left outer join xSystem.TargetStudents_MF ts
ON lt.LevelTypeCode = ts.LevelTypeCode and ai.StrandCode = ts.StrandCode
left outer join dbo.vr_ListPassedApp vp
on ai.AppNum = vp.APPNUM and lt.LevelTypeCode = vp.LevelTypeCode and ai.StrandCode = vp.StrandCode
left outer join dbo.vr_ListFailedApp vf
on ai.AppNum = vf.APPNUM and lt.LevelTypeCode = vf.LevelTypeCode and ai.StrandCode = vf.StrandCode
GROUP by lt.arr,lt.LevelTypeCode,ai.StrandCode, ts.StudentCount
ORDER BY lt.Arr


--(Select COUNT (*) from Admission.App_TestSummary_MF ats where ats.STATCODE <> 'NR' AND ats.RETEST =0) as passed
