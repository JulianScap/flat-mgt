﻿CREATE PROCEDURE [dbo].[Flatmate_GetByLogin]
	@Login nvarchar(100),
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		FlatmateId,
		[FlatId],
		[Login],
		[Password],
		[FullName],
		[NickName],
		[BirthDate],
		[FlatTenant]
	FROM
		dbo.Flatmate
	WHERE
		[Login] = @Login
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_GetByLogin] TO [fm_user]
	AS [dbo];

