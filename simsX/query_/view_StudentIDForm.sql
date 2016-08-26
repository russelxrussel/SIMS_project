
-- VIEW FOR STUDENT ID INFORMATION REPORT
-- RUSSEL VASQUEZ
-- 03/04/2016

ALTER VIEW vr_RegIDForm
AS
SELECT SGS.StudNum,SGS.LevelTypeCode,SGS.StudTypeCode, (si.LastName + ', ' + si.FirstName + ' ' + si.MI + '.') as StudName,
(CASE WHEN RSR.PrimaryContactID = 1 THEN (UPPER(RSR.FFirstName) + ' ' + UPPER(LEFT(rsr.FMiddleName,1)) + '. ' + UPPER(RSR.FLastName)) 
					  WHEN RSR.PrimaryContactID = 2 THEN (UPPER(RSR.MFirstName) + '. ' + UPPER(LEFT(rsr.MMiddleName,1)) + ' ' + UPPER(RSR.MLastName)) 
					  WHEN RSR.PrimaryContactID = 3 THEN (UPPER(RSR.GFirstName) + '. ' + UPPER(LEFT(rsr.GMiddleName,1)) + ' ' + UPPER(RSR.GLastName)) 
					  END) as contactName,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN 'FATHER' 
					  WHEN RSR.PrimaryContactID = 2 THEN 'MOTHER'
					  WHEN RSR.PrimaryContactID = 3 THEN UPPER(RSR.GRelation)
					  END) as Relation,
					  
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN UPPER(RSR.FCompAddress)
					  WHEN RSR.PrimaryContactID = 2 THEN UPPER(RSR.MCompAddress) 
					  WHEN RSR.PrimaryContactID = 3 THEN UPPER(RSR.GAddress) 
					  END) as contactAddress,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN RSR.Ftelephone
					  WHEN RSR.PrimaryContactID = 2 THEN RSR.Mtelephone
					  WHEN RSR.PrimaryContactID = 3 THEN RSR.Gtelephone 
					  END) as contactTelephone,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN RSR.FMobile
					  WHEN RSR.PrimaryContactID = 2 THEN RSR.MMobile
					  WHEN RSR.PrimaryContactID = 3 THEN RSR.GMobile 
					  END) as contactMobile 
FROM Registration.Student_General_Status_MF SGS
INNER JOIN Registration.Student_Info_MF SI
ON SGS.StudNum = SI.StudNum
INNER JOIN Registration.Student_Relative_MF RSR
ON SGS.StudNum = RSR.StudNum


--SELECTION WITH CASE SAMPLE
/*
SELECT STUDNUM, (CASE WHEN RSR.PrimaryContactID = 1 THEN (UPPER(RSR.FFirstName) + ' ' + UPPER(LEFT(rsr.FMiddleName,1)) + ' ' + UPPER(RSR.FLastName)) 
					  WHEN RSR.PrimaryContactID = 2 THEN (UPPER(RSR.MFirstName) + ' ' + UPPER(LEFT(rsr.MMiddleName,1)) + ' ' + UPPER(RSR.MLastName)) 
					  WHEN RSR.PrimaryContactID = 3 THEN (UPPER(RSR.GFirstName) + ' ' + UPPER(LEFT(rsr.GMiddleName,1)) + ' ' + UPPER(RSR.GLastName)) 
					  END) as contactName,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN 'FATHER' 
					  WHEN RSR.PrimaryContactID = 2 THEN 'MOTHER'
					  WHEN RSR.PrimaryContactID = 3 THEN UPPER(RSR.GRelation)
					  END) as Relation,
					  
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN UPPER(RSR.FCompAddress)
					  WHEN RSR.PrimaryContactID = 2 THEN UPPER(RSR.MCompAddress) 
					  WHEN RSR.PrimaryContactID = 3 THEN UPPER(RSR.GAddress) 
					  END) as contactAddress,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN RSR.Ftelephone
					  WHEN RSR.PrimaryContactID = 2 THEN RSR.Mtelephone
					  WHEN RSR.PrimaryContactID = 3 THEN RSR.Gtelephone 
					  END) as contactTelephone,
					  (CASE WHEN RSR.PrimaryContactID = 1 THEN RSR.FMobile
					  WHEN RSR.PrimaryContactID = 2 THEN RSR.MMobile
					  WHEN RSR.PrimaryContactID = 3 THEN RSR.GMobile 
					  END) as contactMobile
FROM Registration.Student_Relative_MF RSR

*/
