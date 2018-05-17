CREATE PROCEDURE [dbo].[Flatmate_GetAll]
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
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetAll] TO [fm_user]
	AS [dbo];

