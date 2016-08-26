use dbSIMS
go


Select A.StudNum, A.STUDNAME, (B.FFirstName + ' ' + LEFT(B.FMiddleName,1) + '. ' + B.FLastName) AS Father, 
B.FCitizenship,b.FOccupation, upper(b.FEducation) as Father_Education,
(B.MFirstName + ' ' + LEFT(B.MMiddleName,1) + '. ' + B.MLastName) AS Mother, 
b.MCitizenship,  B.MOccupation, upper(b.MEducation) as Mother_Education
From Registration.Student_MF A
INNER JOIN Registration.Student_Relative_MF B
ON A.StudNum = B.StudNum
WHERE A.StatCode = 'EN' and A.BO_E = 'false'
order by A.StudName
