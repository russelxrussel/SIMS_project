USE [dbSIMS]
GO

/****** Object:  View [dbo].[vr_IDSource]    Script Date: 06/29/2016 13:58:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 06/29/2016
-- Description:	SIMS- GET STUDENT INFORMATION AND CONTACTS
-- COMMAND: SELECT
-- =============================================

ALTER PROC spGET_HEALTH_INFO
@STUDNUM nvarchar(7)
WITH ENCRYPTION
AS
BEGIN

SELECT C.FullName, A.StudNum,D.LevelTypeDesc, A.section,B.contactName,B.Relation,
(CASE WHEN B.contactTelephone = '' or B.contactTelephone IS NULL THEN B.contactMobile 
 ELSE B.contactTelephone + ' / ' + B.contactMobile END)as Contact, b.contactAddress, E.motDescription,c.Barcode,  REPLACE(C.PhotoPath, '~/photo/', 'X:\photo\') as picture, C.PhotoPath
FROM Registration.Student_MF A
INNER JOIN vr_RegIDForm B
ON A.StudNum = B.StudNum
INNER JOIN Registration.Student_Info_MF C
ON A.StudNum = C.StudNum
INNER JOIN xSystem.LevelType_RF D
ON A.LevelCode = D.LevelTypeCode
LEFT OUTER JOIN Utilities.MOT_RF E
ON C.motCode =  E.motCode
WHERE A.StudNum=@STUDNUM

END
GO


