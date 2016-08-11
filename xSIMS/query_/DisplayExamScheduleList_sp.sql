--Display list of Schedule Title
CREATE proc DisplayExamScheduleList
@ScreeningCode nvarchar(1)
AS
Begin

SELECT id, STitle from Admission.ScreeningSetup_RF
Where ScreeningCode = @ScreeningCode
ORDER by Sdate Desc

End