-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 06-06-2016
-- Description:	SIMS- REPORT SUMMARY STATISTICS
-- COMMAND: SELECT - INNER JOIN
-- =============================================
USE dbSIMS
GO

ALTER PROCEDURE spREP_SUMMARY_STAT
@SY nvarchar(9)
WITH ENCRYPTION
AS
BEGIN

SELECT XLT.LevelTypeDesc, 
COUNT (VRO.studnum) AS R_OLD,
COUNT(VRN.studnum) as R_NEW, 
(COUNT (VRO.studnum) + COUNT(VRN.studnum)) AS R_TOTAL,
COUNT (VRBO.studnum) AS RB_OLD,
COUNT(VRBN.studnum) as RB_NEW, 
(COUNT (VRBO.studnum) + COUNT(VRBN.studnum)) AS RB_TOTAL,
COUNT (VEO.studnum) AS E_OLD,
COUNT (VEN.studnum) AS E_NEW,
(COUNT (VEO.studnum) + COUNT (VEN.studnum))  AS E_TOTAL,
COUNT (VEBO.studnum) AS EB_OLD,
COUNT (VEBN.studnum) AS EB_NEW,
(COUNT (VEBO.studnum) + COUNT (VEBN.studnum)) AS EB_TOTAL


FROM xSystem.LevelType_RF XLT
LEFT OUTER JOIN Registration.Student_MF RSM
ON XLT.LevelTypeCode = RSM.LevelCode
-- RESERVATION
LEFT OUTER JOIN v_ReserveList_NEW VRN
ON RSM.StudNum = VRN.studnum and XLT.LevelTypeCode = VRN.LevelCode
LEFT OUTER JOIN v_ReserveList_OLD VRO
ON RSM.StudNum = VRO.STUDNUM and XLT.LevelTypeCode = VRO.LevelCode

-- RESERVATION - BACKOUT
LEFT OUTER JOIN v_ReserveList_BACKOUT_NEW VRBN
ON RSM.StudNum = VRBN.studnum and XLT.LevelTypeCode = VRBN.LevelCode
LEFT OUTER JOIN v_ReserveList_BACKOUT_OLD VRBO
ON RSM.StudNum = VRBO.STUDNUM and XLT.LevelTypeCode = VRBO.LevelCode


--ENROLLMENT
LEFT OUTER JOIN v_enrolledList_OLD VEO
ON RSM.StudNum = VEO.studnum and XLT.LevelTypeCode = VEO.levelcode
LEFT OUTER JOIN v_enrolledlist_NEW VEN
ON RSM.StudNum = VEN.studnum and XLT.LevelTypeCode = VEN.levelcode

--ENROLLED - BACKOUT
LEFT OUTER JOIN v_enrolledList_BACKOUT_OLD VEBO
ON RSM.StudNum = VEBO.studnum and XLT.LevelTypeCode = VEBO.levelcode
LEFT OUTER JOIN v_enrolledList_BACKOUT_NEW VEBN
ON RSM.StudNum = VEBN.studnum and XLT.LevelTypeCode = VEBN.levelcode

WHERE RSM.SY=@SY

GROUP BY XLT.LevelTypeDesc	
END


   