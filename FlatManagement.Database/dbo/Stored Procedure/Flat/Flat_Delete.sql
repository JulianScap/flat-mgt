CREATE PROCEDURE [dbo].[Flat_Delete]
	@FlatId int
AS
BEGIN
	DELETE FROM
		dbo.Flat
	WHERE
		FlatId = @FlatId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_Delete] TO [fm_user]
	AS [dbo];

