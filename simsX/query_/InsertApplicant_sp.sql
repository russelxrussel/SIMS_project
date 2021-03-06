USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spInsertApplicant]    Script Date: 09/17/2015 18:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[spInsertApplicant]

@AppTypeCode nvarchar(2), @LevelTypeCode nvarchar(3), @StrandCode nvarchar(1),
@AppDOA datetime, @AppNum nvarchar(8),@WLStatus bit,@SSIChild bit,
@SY nvarchar(9),@LastName nvarchar(50),@FirstName nvarchar(50),
@MiddleName nvarchar(50),@MI nvarchar(2),@Suffix nvarchar(4),
@FullName nvarchar(90),@GenderCode nvarchar(1), @DOB datetime,@Age float,@ShortByJune bit, @ShortMonth int, @TelNo nvarchar(10),
@MobileNo nvarchar(13),@AddInfo nvarchar(100),@BarangayCode nvarchar(4),
@CityCode nvarchar(3),@Stat bit,
@DateEncode datetime,@DateUpdate datetime,@UserCode nvarchar(20)

AS
BEGIN
	INSERT INTO Admission.App_Info_MF
	(SY, AppNum, AppTypeCode,LevelTypeCode,StrandCode, AppDOA,WLStatus,SSIChild,
	LastName,FirstName, MiddleName, MI,Suffix,FullName, GenderCode,
	DOB,Age, ShortByJune, ShortMonth, TelNo,MobileNo,AddInfo,BarangayCode,CityCode,Stat,
	DateEncode,DateUpdate, UserCode)
	VALUES(@SY, @AppNum,@AppTypeCode, @LevelTypeCode, @StrandCode, @AppDOA,@WLStatus,@SSIChild,
	@LastName,@FirstName,@MiddleName,@MI,@Suffix,@FullName,@GenderCode,
	@DOB,@Age, @ShortByJune,@ShortMonth, @TelNo,@MobileNo,@AddInfo,@BarangayCode,@CityCode,@Stat,
	@DateEncode,@DateUpdate,@UserCode)
END
