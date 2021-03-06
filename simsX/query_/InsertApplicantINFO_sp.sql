USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spInsertApplicantINFO]    Script Date: 09/28/2015 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[spInsertApplicantINFO]

@AppTypeCode nvarchar(2), @LevelTypeCode nvarchar(3), @StrandCode nvarchar(1),
@AppDOA datetime, @AppNum nvarchar(8),@WLStatus bit,@SSIChild bit,
@SY nvarchar(9),@LastName nvarchar(50),@FirstName nvarchar(50),
@MiddleName nvarchar(50),@MI nvarchar(2),@Suffix nvarchar(4),
@FullName nvarchar(90),@GenderCode nvarchar(1), @DOB datetime, @POB nvarchar(150),@Age float,@ShortByJune bit, @ShortMonth int, @TelNo nvarchar(10),
@MobileNo nvarchar(13),@ContactPerson nvarchar(50),@AddInfo nvarchar(100),@BarangayCode nvarchar(4),
@CityCode nvarchar(3),@Email nvarchar(50), @Remarks nvarchar(250), @Stat bit,
@DateEncode datetime,@DateUpdate datetime,@UserCode nvarchar(20),
@SNUM nvarchar(8),
@Form138 bit,
@BC bit,
@Colored1x1 bit,
@BrownEnvelope bit,
@GM bit,
@Recommendation bit,
@Form137 bit,
@NCAE bit,
@Other nvarchar(150)

AS
BEGIN

	--APPLICANT TABLE
	INSERT INTO Admission.App_Info_MF
	(SY, AppNum, AppTypeCode,LevelTypeCode,StrandCode, AppDOA,WLStatus,SSIChild,
	LastName,FirstName, MiddleName, MI,Suffix,FullName, GenderCode,
	DOB,POB,Age, ShortByJune, ShortMonth, TelNo,MobileNo,ContactPerson, AddInfo, BarangayCode, CityCode,Email, Remarks, Stat,
	DateEncode,DateUpdate, UserCode)
	VALUES(@SY, @AppNum,@AppTypeCode, @LevelTypeCode, @StrandCode, @AppDOA,@WLStatus,@SSIChild,
	@LastName,@FirstName,@MiddleName,@MI,@Suffix,@FullName,@GenderCode,
	@DOB,@POB,@Age,@ShortByJune,@ShortMonth,@TelNo,@MobileNo,@ContactPerson, @AddInfo,@BarangayCode,@CityCode,@Email, @Remarks,@Stat,
	@DateEncode,@DateUpdate,@UserCode)
	
	-- Credential Area
	INSERT INTO Admission.Credential_MF(SNUM, Form138, BC, Colored1x1, BrownEnvelope, GM, Recommendation, Form137, NCAE, Other)
	VALUES(@SNUM,@Form138,@BC,@Colored1x1,@BrownEnvelope,@GM, @Recommendation, @Form137, @NCAE, @Other)
END