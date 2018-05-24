CREATE PROCEDURE [dbo].[Flatmate_GetAll]
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
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetAll] TO [fm_user]
	AS [dbo];

