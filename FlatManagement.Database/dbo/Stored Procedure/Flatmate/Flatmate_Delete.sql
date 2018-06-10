CREATE PROCEDURE [dbo].[Flatmate_Delete]
	@FlatmateId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	DECLARE @FlatId int;
	SELECT @FlatId = FlatId FROM dbo.Flatmate WHERE [Login] = @UserLogin;


	DELETE FROM
		dbo.Flatmate
	WHERE
		FlatmateId = @FlatmateId AND FlatId = @FlatId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Delete] TO [fm_user]
	AS [dbo];

