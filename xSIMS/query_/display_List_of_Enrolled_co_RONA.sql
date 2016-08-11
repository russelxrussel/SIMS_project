select B.StudNum, A.LastName, A.FirstName, A.MiddleName, C.LevelTypeDesc, B.Section from Registration.Student_MF B
inner join Registration.Student_Info_MF A
ON B.StudNum = A.StudNum
INNEr join xSystem.LevelType_RF C
ON B.LevelCode = C.LevelTypeCode
where (B.StudTypeCode= 'N' or B.StudTypeCode = 'R') and StatCode = 'EN' and BO_E = 'false'
order by C.Arr,  B.Section, A.LastName
