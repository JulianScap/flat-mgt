CREATE PROCEDURE [dbo].[Flatmate_GetByFlatId]
	@FlatId int
AS
BEGIN
	SELECT
		FlatmateId,
		[FlatId],
		[Login],
		[Password],
		[FullName],
		[Nickname],
		[BirthDate],
		[FlatTenant]
	FROM
		dbo.Flatmate
	WHERE
		[FlatId] = @FlatId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetByFlatId] TO [fm_user]
	AS [dbo];

