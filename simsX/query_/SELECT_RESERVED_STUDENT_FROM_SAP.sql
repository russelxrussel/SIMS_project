/****** Script for SelectTopNRows command from SSMS  ******/
SELECT Distinct u_studentno,u_docdate
FROM [SSI].[dbo].[@FT_ORCT]
where U_YEAR = '2016' and U_PymtFor = 'Reservation' and U_Status = 'P'
order by u_studentno

