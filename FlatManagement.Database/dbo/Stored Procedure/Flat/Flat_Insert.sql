CREATE PROCEDURE [dbo].[Flat_Insert]
	@Name nvarchar(200),
	@Address nvarchar(1000),
	@FlatId int output
AS
BEGIN
	INSERT INTO dbo.Flat ([Name], [Address]) VALUES (@Name, @Address);
	SET @FlatId = SCOPE_IDENTITY();
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_Insert] TO [fm_user]
	AS [dbo];

