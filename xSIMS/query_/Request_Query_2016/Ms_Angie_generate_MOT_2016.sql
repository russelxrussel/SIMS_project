

select A.StudNum, A.FullName, D.LevelTypeDesc, C.Section, B.motDescription  
from Registration.Student_Info_MF A
left outer join Utilities.MOT_RF B
on A.motCode = B.motCode
inner join Registration.Student_MF C
on A.StudNum = C.StudNum
INNER JOIN xSystem.LevelType_RF D
ON C.LevelCode = D.LevelTypeCode
WHERE C.StatCode = 'EN' and C.BO_E = 'false'
ORDER BY D.Arr, C.Section,  A.LastName,  A.motCode