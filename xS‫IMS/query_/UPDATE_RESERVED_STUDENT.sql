
--UPDATE RECORD ON STUDENT_MF AS RESERVED
--RUSSEL 04-07-2016

use dbSIMS
go

UPDATE RS
SET RS.StatCode = 'RE', RS.datePay = T.date_
From Registration.Student_MF RS
INNER JOIN dbo.temp_res T
ON RS.StudNum = T.studnum