CREATE PROCEDURE [dbo].[Flatmate_GetById]
	@FlatmateId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		fm1.FlatmateId,
		fm1.[FlatId],
		fm1.[Login],
		fm1.[Password],
		fm1.[FullName],
		fm1.[NickName],
		fm1.[BirthDate],
		fm1.[FlatTenant]
	FROM
		dbo.Flatmate fm1
	JOIN dbo.Flatmate fm2
		ON fm1.FlatId = fm2.FlatId
			AND fm2.[Login] = @UserLogin
	WHERE
		fm1.FlatmateId = @FlatmateId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetById] TO [fm_user]
	AS [dbo];

