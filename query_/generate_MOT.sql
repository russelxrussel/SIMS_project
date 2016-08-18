

select A.StudNum, A.FullName, C.LevelCode, C.Section, B.motDescription  
from Registration.Student_Info_MF A
inner join Utilities.MOT_RF B
on A.motCode = B.motCode
inner join Registration.Student_MF C
on A.StudNum = C.StudNum
where a.motCode is not null or a.motCode = '' or a.motCode <> 'N'
ORDER BY A.motCode, C.LevelCode