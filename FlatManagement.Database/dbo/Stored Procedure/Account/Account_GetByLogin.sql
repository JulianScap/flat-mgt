CREATE PROCEDURE [dbo].[Account_GetByLogin]
	@Login nvarchar(100)
AS
BEGIN
	SELECT
		AccountId,
		[Login],
		[Password]
	FROM
		dbo.Account
	WHERE
		[Login] = @Login
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_GetByLogin] TO [fm_user]
	AS [dbo];

