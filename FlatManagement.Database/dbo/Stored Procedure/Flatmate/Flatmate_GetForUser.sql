CREATE PROCEDURE [dbo].[Flatmate_GetForUser]
	@Login nvarchar(100)
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
		[Login] = @Login
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetForUser] TO [fm_user]
	AS [dbo];

