use dbSIMS
go
Select B.StudNum,RIGHT(A.AppNum,4)as AppNum,F.LevelCatCode, A.Entry_LevelCode,LEFT(A.Entry_SY,4)as Entry_Year, A.Entry_Date, A.LastName, A.FirstName, A.MiddleName, A.StudTypeCode,
A.Street as m_add1, C.BarangayDesc as m_add2, D.CityDesc as m_add3, '' as perm1, '' as perm2, '' as perm3, '' as zip1, '' as zip2, a.TelNo as tel_no1, a.MobileNo as tel_no2,
A.DOB,A.POB, A.CitizenshipCode, 'S' as civil_status, A.GenderCode, A.ReligionCode, A.Email as email1, '' as email2, 
A.MobileNo, '' as pager_no, E.FLastName, E.FFirstName, E.FMiddleName, E.FCompAddress, '' AS cp_addr2, '' AS cp_addr3, '' AS zipcode3, E.FTelephone, E.FMobile, 'Father' as relation1, 'Mother' as relation2,
E.MLastName, E.MFirstName, E.MMiddleName, E.MCompAddress,'' AS cp2_addr2, '' AS cp2_addr3, '' as zipcode4, E.MTelephone, E.MMobile
from Registration.Student_Info_MF A
INNER JOIN Registration.Student_MF B
ON A.StudNum = B.StudNum
LEFT OUTER JOIN Utilities.Barangay_RF C
ON A.BarangayCode = C.BarangayCode
LEFT OUTER JOIN Utilities.CityProvince_RF D
ON A.CityCode = D.CityCode
LEFT OUTER JOIN Registration.Student_Relative_MF E
on A.StudNum = E.StudNum
INNER JOIN xSystem.LevelType_RF F
ON A.Entry_LevelCode = F.LevelTypeCode

where B.StatCode = 'EN' AND B.BO_E = 'false' and (B.StudTypeCode = 'N' or B.StudTypeCode = 'R')
ORDER by AppNum