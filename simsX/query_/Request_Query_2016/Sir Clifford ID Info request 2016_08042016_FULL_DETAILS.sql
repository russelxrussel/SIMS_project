use dbSIMS
go

SELECT A.StudNum,C.LastName, C.FirstName, C.MI, C.GenderCode ,(D.LevelTypeDesc + ' - ' + A.section) as Level_Section,B.contactName,B.Relation,
(CASE WHEN B.contactTelephone = '' or B.contactTelephone IS NULL THEN B.contactMobile 
 ELSE B.contactTelephone + ' / ' + B.contactMobile END)as Contact, b.contactAddress, E.motDescription
FROM Registration.Student_MF A
INNER JOIN vr_RegIDForm B
ON A.StudNum = B.StudNum
INNER JOIN Registration.Student_Info_MF C
ON A.StudNum = C.StudNum
INNER JOIN xSystem.LevelType_RF D
ON A.LevelCode = D.LevelTypeCode
LEFT OUTER JOIN Utilities.MOT_RF E
ON C.motCode =  E.motCode
WHERE A.StatCode = 'EN' and A.BO_E = 'false'
