CREATE PROCEDURE [dbo].[Flat_GetById]
	@FlatId int
AS
BEGIN
	SELECT
		FlatId,
		[Name],
		[Address]
	FROM
		dbo.Flat
	WHERE
		FlatId = @FlatId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_GetById] TO [fm_user]
	AS [dbo];

