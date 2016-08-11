use dbSIMS
go

SELECT A.StudNum, A.StudName, B.LevelTypeDesc, A.Section from Registration.Student_MF A
INNER JOIN xSystem.LevelType_RF B
ON A.LevelCode = B.LevelTypeCode
WHERE A.StatCode = 'EN' and A.BO_E = 'false'
ORDER BY B.Arr, A.STUDNAME