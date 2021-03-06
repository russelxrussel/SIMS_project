USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spCountCurrentApplicant]    Script Date: 10/05/2015 10:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--This stored procedure will display
--Count of applicant base on per level
--Russel 10/03/2015

ALTER Proc [dbo].[spCountCurrentApplicant]
AS
BEGIN
SELECT  a.Arr, a.LevelCatCode, a.LevelTypeCode,
	COUNT(b.leveltypeCode) as ApplicantCount 
	FROM xSystem.LevelType_RF a
	LEFT Outer JOIN Admission.App_Info_MF b
	ON a.LevelTypeCode = b.LevelTypeCode
	left outer join xSystem.LevelType_RF c	
	ON a.Arr = c.Arr
	left outer join xSystem.LevelCategory_RF d
	ON a.LevelCatCode = d.LevelCatCode		
	GROUP BY a.arr, a.LevelTypeCode, a.LevelCatCode
	
END 