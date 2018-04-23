CREATE PROCEDURE [dbo].[Flatmate_Update]
	@FlatmateId int,
	@FlatId int,
	@FullName nvarchar(500),
	@Nickname nvarchar(100),
	@BirthDate date,
	@FlatTenant bit
AS
BEGIN
	UPDATE dbo.Flatmate
	SET
		[FlatId] = @FlatId,
		[FullName] = @FullName,
		[Nickname] = @Nickname,
		[BirthDate] = @BirthDate,
		[FlatTenant] = @FlatTenant
	WHERE FlatmateId = @FlatmateId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Update] TO [fm_user]
	AS [dbo];

