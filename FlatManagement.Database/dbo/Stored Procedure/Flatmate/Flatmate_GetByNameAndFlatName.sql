CREATE PROCEDURE [dbo].[Flatmate_GetByNameAndFlatName]
	@Flatname nvarchar(200),
	@Nickname nvarchar(100)
AS
BEGIN
	SELECT
		fm.[FlatmateId],
		fm.[FlatId],
		fm.[FullName],
		fm.[Nickname],
		fm.[BirthDate],
		fm.[FlatTenant]
	FROM dbo.Flatmate fm
	JOIN dbo.Flat f
		ON f.FlatId = fm.FlatId
	WHERE
		fm.Nickname = @Nickname
		AND f.[Name] = @Flatname
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetByNameAndFlatName] TO [fm_user]
	AS [dbo];

