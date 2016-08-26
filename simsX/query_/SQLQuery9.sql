
--Select a.SY, a.LevelTypeCode, a.TargetApplicants FROM xSystem.TargetApplicant_MF a
--left outer join Registrar.EnrollmentStat_TF b
--ON a.SY = b.SY and a.LevelTypeCode = b.LevelTypeCode


--Select LevelTypeCode, COUNT(LevelTypeCode) 
--FROM Registrar.EnrollmentStat_TF
--GROUP BY LevelTypeCode


SELECT  a.Arr, a.LevelCatCode, a.LevelTypeCode,
	COUNT(b.leveltypeCode) as ApplicantCount 
	FROM xSystem.LevelType_RF a
	LEFT Outer JOIN Admission.App_Info_MF b
	ON a.LevelTypeCode = b.LevelTypeCode
	left outer join xSystem.LevelType_RF c	
	ON a.Arr = c.Arr
	left outer join xSystem.LevelCategory_RF d
	ON a.LevelCatCode = d.LevelCatCode		
	GROUP BY a.arr, a.LevelTypeCode, a.LevelCatCode
	
--SELECT a.sy, a.LevelTypeCode, COUNT(b.leveltypeCode) FROM xSystem.TargetApplicant_MF a
--WHERE b.IniStatCode != 'N'
--LEFT OUTER JOIN Registrar.EnrollmentStat_TF b
--ON a.SY = b.sy
--Left OUTER JOIN Registrar.EnrollmentStat_TF c
--ON a.LevelTypeCode= c.leveltypeCode
--GROUP BY a.sy, a.levelTypeCode

SELECT c.Arr, a.SY, a.LevelTypeCode,
		(Select COUNT(b.leveltypeCode) 
		 from Registrar.EnrollmentStat_TF b
		 Where a.LevelTypeCode = b.levelTypeCode and a.SY = b.sy and b.IniStatCode != 'N')
		 as closedSlot, a.TargetApplicants
FROM xSystem.TargetApplicant_MF a
left outer join xSystem.LevelType_RF c
ON a.LevelTypeCode = c.LevelTypeCode
GROUP by
   c.Arr, a.SY, a.LevelTypeCode, a.TargetApplicants