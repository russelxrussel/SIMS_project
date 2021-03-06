USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateApplicantINFO]    Script Date: 09/28/2015 13:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[spUpdateApplicantINFO]

@AppTypeCode nvarchar(2), @LevelTypeCode nvarchar(3), @StrandCode nvarchar(1),
@AppDOA datetime, @AppNum nvarchar(8),@WLStatus bit,@SSIChild bit,
@LastName nvarchar(50),@FirstName nvarchar(50),
@MiddleName nvarchar(50),@MI nvarchar(2),@Suffix nvarchar(4),
@FullName nvarchar(90),@GenderCode nvarchar(1), @DOB datetime, @POB nvarchar(150),@Age float,@ShortByJune bit, @ShortMonth int, @TelNo nvarchar(10),
@MobileNo nvarchar(13),@ContactPerson nvarchar(75),@AddInfo nvarchar(100),@BarangayCode nvarchar(4),
@CityCode nvarchar(3),@Email nvarchar(50), @Remarks nvarchar(250),
@DateUpdate datetime,@UserCode nvarchar(20),
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
begin

--App_Info TABLE
UPDATE Admission.App_Info_MF 
SET AppTypeCode=@AppTypeCode,LevelTypeCode=@LevelTypeCode,StrandCode=@StrandCode, AppDOA=@AppDOA,WLStatus=@WLStatus,SSIChild=@SSIChild,
	LastName=@LastName,FirstName=@FirstName, MiddleName=@MiddleName, MI=@MI,Suffix=@Suffix,FullName=@FullName, GenderCode=@GenderCode,
	DOB=@DOB, POB=@POB,Age=@Age, ShortByJune=@ShortByJune, ShortMonth=@ShortMonth, TelNo=@TelNo,MobileNo=@MobileNo,ContactPerson=@ContactPerson,AddInfo=@AddInfo,BarangayCode=@BarangayCode,CityCode=@CityCode,Email=@Email, Remarks=@Remarks,
	DateUpdate=@DateUpdate, UserCode=@UserCode
WHERE AppNum=@AppNum


--Credential TABLE
UPDATE Admission.Credential_MF
SET Form138=@Form138, BC=@BC, Colored1x1=@Colored1x1, BrownEnvelope=@BrownEnvelope, GM=@GM, Recommendation=@Recommendation, Form137=@Form137, NCAE=@NCAE, Other=@Other
WHERE SNUM=@AppNum

end