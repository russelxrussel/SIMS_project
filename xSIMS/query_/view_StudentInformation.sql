--STUDENT INFORMATION REPORT
--BASIC INFORMATION
--AGE COMPUTED BASE ON THE DATE REPORT GENERATED
--RUSSEL VASQUEZ
--03/04/2016

ALTER VIEW vr_RegStudentInformation
AS
SELECT SI.StudNum, XLT.LevelTypeDesc, (si.LastName + ', ' + si.FirstName + ' ' + si.MI + '.') as StudName,si.DOB,CONVERT(int,datediff(d,si.dob,getdate())/365.25) as Age, UPPER(SI.POB) as POB, si.GenderCode,
		UC.CitizenshipDesc,UR.ReligionDesc, SI.TelNo, SI.MobileNo, UPPER(SI.Street) as Street, UB.BarangayDesc, UCT.CityDesc, 
		UPPER(RSR.FFirstName) + ' ' + UPPER(LEFT(rsr.FMiddleName,1)) + '. ' + UPPER(RSR.FLastName) as Father,
		UPPER(RSR.MFirstName) + ' ' + UPPER(LEFT(rsr.MMiddleName,1)) + '. ' + UPPER(RSR.MLastName) as Mother,
		UPPER(RSR.GFirstName) + ' ' + UPPER(LEFT(rsr.GMiddleName,1)) + '. ' + UPPER(RSR.GLastName) as Guardian,
		RSR.FCompany,RSR.FCompAddress,RSR.FOccupation,RSR.FCitizenship, RSR.FEducation,RSR.FTelephone, RSR.FMobile,
		RSR.MCompany,RSR.MCompAddress,RSR.MOccupation, RSR.MCitizenship, RSR.MEducation,RSR.MTelephone, RSR.MMobile,
		RSR.GAddress, RSR.GTelephone, RSR.GMobile, RSR.GRelation, RSS.SiblingCode
FROM Registration.Student_Info_MF SI
INNER JOIN Registration.Student_General_Status_MF SGS
ON SI.StudNum = SGS.StudNum
LEFT OUTER JOIN xSystem.LevelType_RF XLT
ON SI.Current_LevelCode = XLT.LevelTypeCode
LEFT OUTER JOIN Registration.Student_Relative_MF RSR
ON SI.StudNum = RSR.StudNum
LEFT OUTER JOIN Utilities.Citizenship_RF UC
ON SI.CitizenshipCode = UC.CitizenshipCode
LEFT OUTER JOIN Utilities.Religion_RF UR
ON SI.ReligionCode = UR.ReligionCode
LEFT OUTER JOIN Utilities.Barangay_RF UB
ON SI.BarangayCode = UB.BarangayCode
LEFT OUTER JOIN Utilities.CityProvince_RF UCT
ON SI.CityCode = UCT.CityDesc
LEFT OUTER JOIN Registration.Student_Siblings_MF RSS
ON SI.StudNum = RSS.StudNum

