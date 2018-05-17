CREATE PROCEDURE [dbo].[Account_Update]
	@AccountId int,
	@Login nvarchar(100),
	@Password nvarchar(100)
AS
BEGIN
	UPDATE dbo.Account
	SET
		[Login] = @Login,
		[Password] = @Password
	WHERE AccountId = @AccountId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_Update] TO [fm_user]
	AS [dbo];

