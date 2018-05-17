CREATE PROCEDURE [dbo].[Account_Delete]
	@AccountId int
AS
BEGIN
	DELETE FROM
		dbo.Account
	WHERE
		AccountId = @AccountId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Account_Delete] TO [fm_user]
	AS [dbo];

