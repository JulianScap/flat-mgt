CREATE PROCEDURE [dbo].[Account_GetById]
	@AccountId int
AS
BEGIN
	SELECT
		AccountId,
		[Login],
		[Password]
	FROM
		dbo.Account
	WHERE
		AccountId = @AccountId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_GetById] TO [fm_user]
	AS [dbo];

