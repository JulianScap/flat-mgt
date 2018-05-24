﻿CREATE PROCEDURE [dbo].[Flat_GetForUser]
	@Login nvarchar(100)
AS
BEGIN
	SELECT
		f.[FlatId],
		f.[Name],
		f.[Address]
	FROM
		dbo.Flat f
	JOIN dbo.Flatmate fm
		ON fm.FlatId = f.FlatId
	WHERE
		fm.[Login] = @Login
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_GetForUser] TO [fm_user]
	AS [dbo];

