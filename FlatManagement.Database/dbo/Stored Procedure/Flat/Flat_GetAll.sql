CREATE PROCEDURE [dbo].[Flat_GetAll]
AS
BEGIN
	SELECT
		FlatId,
		[Name],
		[Address]
	FROM
		dbo.Flat
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_GetAll] TO [fm_user]
	AS [dbo];

