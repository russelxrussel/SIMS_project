
-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 06-30-2016
-- Description:	SIMS- UPDATE AGE OF STUDENTS
-- COMMAND: UPDATE
-- =============================================
USE dbSIMS
GO

CREATE PROC spUPDATE_AGE_STUDENTS
WITH ENCRYPTION
AS
BEGIN
DECLARE @today datetime
SET @today = GETDATE()

UPDATE Registration.Student_Info_MF
SET Age = DATEDIFF(YEAR,DOB,@today)
	      -CASE WHEN MONTH(@today)*100 + DAY(@today) < MONTH(DOB)*100+DAY(DOB)
		  THEN 1 ELSE 0 END

END
		  