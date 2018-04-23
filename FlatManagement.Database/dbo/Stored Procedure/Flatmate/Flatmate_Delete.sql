CREATE PROCEDURE [dbo].[Flatmate_Delete]
	@FlatmateId int
AS
BEGIN
	DELETE FROM
		dbo.Flatmate
	WHERE
		FlatmateId = @FlatmateId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Delete] TO [fm_user]
	AS [dbo];

