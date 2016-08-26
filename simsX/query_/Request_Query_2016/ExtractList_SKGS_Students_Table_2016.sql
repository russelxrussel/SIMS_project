USE dbSIMS
GO

select A.StudNum, A.StudName, B.LastName, B.MiddleName, B.MI, 
C.contactAddress, B.GenderCode, C.contactName, C.Contact, A.DatePay, '','','',A.StudName
FROM Registration.Student_MF A
INNER JOIN Registration.Student_Info_MF B
ON A.StudNum = B.StudNum
INNER JOIN vr_IDSource C
ON A.StudNum = C.StudNum
where A.StatCode = 'EN' and A.BO_E = 'false' and LevelCode  = 'P3'
