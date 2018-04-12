CREATE PROCEDURE [dbo].[Flat_Update]
	@FlatId int,
	@Name nvarchar(200),
	@Address nvarchar(1000)
AS
BEGIN
	UPDATE dbo.Flat
	SET
		[Name] = @Name,
		[Address] = @Address
	WHERE FlatId = @FlatId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Flat_Update] TO [fm_user]
	AS [dbo];

