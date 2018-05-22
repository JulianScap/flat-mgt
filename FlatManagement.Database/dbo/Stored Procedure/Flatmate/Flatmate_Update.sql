CREATE PROCEDURE [dbo].[Flatmate_Update]
	@FlatmateId int,
	@FlatId int,
	@FullName nvarchar(500),
	@NickName nvarchar(100),
	@BirthDate date,
	@Login nvarchar(100),
	@Password nvarchar(100),
	@FlatTenant bit
AS
BEGIN
	UPDATE dbo.Flatmate
	SET
		[FlatId] = @FlatId,
		[FullName] = @FullName,
		[NickName] = @NickName,
		[BirthDate] = @BirthDate,
		[FlatTenant] = @FlatTenant,
		[Login] = @Login
	WHERE FlatmateId = @FlatmateId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Update] TO [fm_user]
	AS [dbo];

