USE dbSIMS
GO


CREATE PROC spUPDATE_HEALTH_APPLICANT_TO_STUDENT
WITH ENCRYPTION
AS

BEGIN

UPDATE HI
SET HI.SNUM = RI.StudNum 
FROM Health.Stud_Health_Info_MF HI
INNER JOIN Registration.Student_Info_MF RI
ON HI.SNUM = RI.AppNum
INNER JOIN Registration.Student_MF RS
ON RS.StudNum = RI.StudNum
WHERE RS.StatCode = 'EN' and RS.BO_E = 'false'


UPDATE HI
SET HI.SNUM = RI.StudNum 
FROM Health.Stud_GivenMed_MF HI
INNER JOIN Registration.Student_Info_MF RI
ON HI.SNUM = RI.AppNum
INNER JOIN Registration.Student_MF RS
ON RS.StudNum = RI.StudNum
WHERE RS.StatCode = 'EN' and RS.BO_E = 'false'


UPDATE HI
SET HI.SNUM = RI.StudNum 
FROM Health.Stud_Illness_MF HI
INNER JOIN Registration.Student_Info_MF RI
ON HI.SNUM = RI.AppNum
INNER JOIN Registration.Student_MF RS
ON RS.StudNum = RI.StudNum
WHERE RS.StatCode = 'EN' and RS.BO_E = 'false' 

END