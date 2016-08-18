USE dbSIMS
GO

select A.StudNum, B.LastName, B.FirstName, B.MI, B.FirstName,
B.DOB, B.Age, B.GenderCode, 'PS', A.LevelCode, '2', A.Section, A.StudName
FROM Registration.Student_MF A
INNER JOIN Registration.Student_Info_MF B
ON A.StudNum = B.StudNum
INNER JOIN vr_IDSource C
ON A.StudNum = C.StudNum
where A.StatCode = 'EN' and A.BO_E = 'false' and (LevelCode  = 'P2' or LevelCode  = 'P1')
