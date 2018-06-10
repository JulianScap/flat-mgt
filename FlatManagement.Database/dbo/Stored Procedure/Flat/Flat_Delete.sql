CREATE PROCEDURE [dbo].[Flat_Delete]
	@FlatId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	DELETE FROM
		dbo.Flat
	WHERE
		FlatId = @FlatId
		AND EXISTS(
			SELECT 1
			FROM dbo.Flatmate fm
			WHERE fm.[Login] = @UserLogin
				AND fm.FlatId = @FlatId
			)
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_Delete] TO [fm_user]
	AS [dbo];

