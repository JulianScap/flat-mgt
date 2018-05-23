CREATE PROCEDURE [dbo].[Flatmate_SavePassword]
	@FlatmateId int,
	@Password nvarchar(100)
AS
BEGIN
	UPDATE dbo.Flatmate
	SET
		[Password] = @Password
	WHERE FlatmateId = @FlatmateId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_SavePassword] TO [fm_user]
	AS [dbo];

