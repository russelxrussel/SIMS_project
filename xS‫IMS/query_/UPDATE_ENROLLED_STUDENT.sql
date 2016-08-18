
--UPDATE RECORD ON STUDENT_MF AS ENROLLED
--RUSSEL 04-07-2016

use dbSIMS
go

--STUDENT MF
UPDATE RS
SET RS.StatCode = 'EN', RS.datePay = TE.date_
From Registration.Student_MF RS
INNER JOIN dbo.temp_enroll TE
ON RS.StudNum = TE.studnum

--SIBLING
UPDATE SS
SET SS.Enroll_Stat = '2'
FROM Registration.Student_Siblings_MF SS
INNER JOIN dbo.temp_enroll TE
ON SS.StudNum = TE.studnum
