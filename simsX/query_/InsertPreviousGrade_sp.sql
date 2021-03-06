USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spInsertPreviousGrade]    Script Date: 09/15/2015 14:56:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spInsertPreviousGrade]
@SNUM nvarchar(8),
@ENGTOTAL float, @SCITOTAL float, @MATHTOTAL float,
@FIRSTTOTAL float, @SECONDTOTAL float,@THIRDTOTAL float,@FOURTHTOTAL float,
@ENG1 float, @ENG2 float, @ENG3 float, @ENG4 float,
@SCI1 float, @SCI2 float, @SCI3 float, @SCI4 float,
@MATH1 float,@MATH2 float,@MATH3 float,@MATH4 float,
@LOWERENG bit, @LOWERSCI bit, @LOWERMATH bit,
@FINALAVERAGE float,
@DATEENCODE datetime, @DATEUPDATE datetime, @USERCODE nvarchar(50)

AS
BEGIN
	INSERT INTO Admission.PreviousGrade_MF(Snum,EngTotal,SciTotal,MathTotal,FirstTotal,SecondTotal,ThirdTotal,FourthTotal,
	Eng1,Eng2,Eng3,Eng4,Sci1,Sci2,Sci3,Sci4,Math1,Math2,Math3,Math4,LowerEng,LowerSci,LowerMath,FinalAverage,DateEncode, DateUpdate, UserCode)
	VALUES(@SNUM,@ENGTOTAL,@SCITOTAL,@MATHTOTAL,@FIRSTTOTAL,@SECONDTOTAL,@THIRDTOTAL,@FOURTHTOTAL,
	@ENG1,@ENG2,@ENG3,@ENG4,@SCI1,@SCI2,@SCI3,@SCI4,@MATH1,@MATH2,@MATH3,@MATH4,@LOWERENG,@LOWERSCI,@LOWERMATH,@FINALAVERAGE, @DATEENCODE,@DATEUPDATE,@USERCODE)
END