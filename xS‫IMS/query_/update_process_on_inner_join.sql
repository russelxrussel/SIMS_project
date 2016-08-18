--UPDATE STATUS OF STUDENT
--IN INNER JOIN

UPDATE SI
SET SI.Status = 1
From Registration.Student_Info_MF SI
INNER JOIN Registration.Student_MF S
ON SI.StudNum = S.StudNum
