CREATE PROCEDURE [dbo].[Flat_GetById]
	@FlatId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		f.FlatId,
		f.[Name],
		f.[Address]
	FROM
		dbo.Flat f
	JOIN dbo.Flatmate fm
		ON fm.FlatId = f.FlatId
	WHERE
		fm.[Login] = @UserLogin
		AND f.FlatId = @FlatId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_GetById] TO [fm_user]
	AS [dbo];

