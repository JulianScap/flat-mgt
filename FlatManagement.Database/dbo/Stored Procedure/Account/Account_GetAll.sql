CREATE PROCEDURE [dbo].[Account_GetAll]
AS
BEGIN
	SELECT
		AccountId,
		[Login],
		[Password]
	FROM
		dbo.Account
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_GetAll] TO [fm_user]
	AS [dbo];

