CREATE PROCEDURE [dbo].[Account_Insert]
	@Login nvarchar(100),
	@Password nvarchar(100),
	@AccountId int output
AS
BEGIN
	INSERT INTO dbo.Account ([Login], [Password]) VALUES (@Login, @Password);
	SET @AccountId = SCOPE_IDENTITY();
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_Insert] TO [fm_user]
	AS [dbo];

