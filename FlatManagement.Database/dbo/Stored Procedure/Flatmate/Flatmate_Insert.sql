CREATE PROCEDURE [dbo].[Flatmate_Insert]
	@FlatId int,
	@FullName nvarchar(500),
	@NickName nvarchar(100),
	@BirthDate date,
	@FlatTenant bit,
	@Login nvarchar(100),
	@Password nvarchar(100),
	@UserLogin nvarchar(100),
	@FlatmateId int output
AS
BEGIN
	--DECLARE @UserFlatId int;
	--SELECT @UserFlatId = [FlatId] FROM dbo.Flatmate where [Login] = @UserLogin

	--IF @UserFlatId = @FlatId
	--BEGIN
		INSERT INTO dbo.Flatmate ([FlatId], [FullName], [NickName], [BirthDate], [FlatTenant], [Login], [Password])
			VALUES (@FlatId, @FullName, @NickName, @BirthDate, @FlatTenant, @Login, 'To initialise');
		SET @FlatmateId = SCOPE_IDENTITY();
	--END
	--ELSE
	--BEGIN
	--	SET @FlatmateId = 0;
	--END
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Insert] TO [fm_user]
	AS [dbo];

