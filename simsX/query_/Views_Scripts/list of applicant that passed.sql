--CREATE A VIEW FOR REPORT ON APPLICANT
--THAT ALREADY PASSED
--STATCODE IS NOT NR AND RETEST IS FALSE
--02/02/2016 - RUSSEL VASQUEZ

CREATE VIEW vr_ListPassedApp
AS

SELECT ts.APPNUM, si.StudNum, ai.FullName, ai.LevelTypeCode, ai.StrandCode ,ts.OVERALL FROM Admission.App_TestSummary_MF ts
INNER JOIN Admission.App_Info_MF ai
ON ts.APPNUM = ai.AppNum
INNER JOIN Registration.Student_Info_MF si
ON ai.AppNum = si.AppNum
WHERE ts.STATCODE <> 'NR' and ts.RETEST = 0