CREATE PROCEDURE [dbo].[Flatmate_Insert]
	@FlatId int,
	@FullName nvarchar(500),
	@Nickname nvarchar(100),
	@BirthDate date,
	@FlatTenant bit,
	@FlatmateId int output
AS
BEGIN
	INSERT INTO dbo.Flatmate ([FlatId], [FullName], [Nickname], [BirthDate], [FlatTenant])
		VALUES (@FlatId, @FullName, @Nickname, @BirthDate, @FlatTenant);
	SET @FlatmateId = SCOPE_IDENTITY();
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Insert] TO [fm_user]
	AS [dbo];

