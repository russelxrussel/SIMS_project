USE dbSIMS 
GO

SELECT A.StudNum, A.LastName, A.FirstName, a.MI, a.GenderCode, H.LevelTypeDesc, b.Section, UPPER(A.InitialContact) ContactPerson, A.TelNo, A.MobileNo,
UPPER(A.Street) as street, C.BarangayDesc, D.CityDesc, E.motDescription
FROM Registration.Student_Info_MF A
INNER JOIN Registration.Student_MF B
ON A.StudNum = B.StudNum
LEFT OUTER JOIN Utilities.Barangay_RF C
ON A.BarangayCode = C.BarangayCode
LEFT OUTER JOIN Utilities.CityProvince_RF D
ON A.CityCode = D.CityCode
LEFT OUTER JOIN Utilities.MOT_RF E
ON A.motCode = E.motCode
LEFT OUTER JOIN Utilities.Religion_RF F
ON A.ReligionCode = F.ReligionCode
LEFT OUTER JOIN Utilities.Citizenship_RF G
ON A.CitizenshipCode = G.CitizenshipCode
LEFT OUTER JOIN xSystem.LevelType_RF H
ON B.LevelCode = H.LevelTypeCode

WHERE B.StatCode = 'EN' and B.BO_E = 'false'
ORDER BY H.Arr, B.StudName

