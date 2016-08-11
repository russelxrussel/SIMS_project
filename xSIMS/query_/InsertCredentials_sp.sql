CREATE PROCEDURE spInsertCredentials
@SNUM nvarchar(8),
@Form138 bit,
@BC bit,
@Colored1x1 bit,
@BrownEnvelope bit,
@GM bit,
@Form137 bit,
@Other nvarchar(150)

AS
BEGIN
	INSERT INTO Admission.Credential_MF(SNUM, Form138, BC, Colored1x1, BrownEnvelope, GM, Form137, Other)
	VALUES(@SNUM,@Form138,@BC,@Colored1x1,@BrownEnvelope,@GM, @Form137, @Other)
END