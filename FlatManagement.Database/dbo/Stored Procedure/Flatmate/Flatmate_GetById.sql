CREATE PROCEDURE [dbo].[Flatmate_GetById]
	@FlatmateId int
AS
BEGIN
	SELECT
		FlatmateId,
		[FlatId],
		[FullName],
		[Nickname],
		[BirthDate],
		[FlatTenant]
	FROM
		dbo.Flatmate
	WHERE
		FlatmateId = @FlatmateId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetById] TO [fm_user]
	AS [dbo];

