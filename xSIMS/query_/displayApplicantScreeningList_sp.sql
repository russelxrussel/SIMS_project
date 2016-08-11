--WILL DISPLAY LIST OF APPLICANT ON SETTING UP APPLICANT TESTING SCHEDULE
--10/08/2015
--CREATED BY: RUSSEL VASQUEZ

Alter proc spDisplayScreeningList

@AppTypeCode nvarchar(2),
@LevelTypeCode nvarchar(3)

AS
BEGIN

	
	SELECT a.SY, a.AppNum, a.FullName 
	FROM Admission.App_Info_MF a
	INNER JOIN Admission.App_Trail_TF b
	ON a.AppNum = b.AppNum
	WHERE a.Status = 'true' and a.LevelTypeCode=@LevelTypeCode and a.AppTypeCode=@AppTypeCode and  (b.statCode = 2 or b.statCode = 1)

END 
