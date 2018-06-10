CREATE PROCEDURE [dbo].[Flatmate_GetForUser]
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		FlatmateId,
		[FlatId],
		[Login],
		[Password],
		[FullName],
		[NickName],
		[BirthDate],
		[FlatTenant]
	FROM
		dbo.Flatmate
	WHERE
		[Login] = @UserLogin
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetForUser] TO [fm_user]
	AS [dbo];

