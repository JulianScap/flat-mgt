CREATE FUNCTION dbo.[Flatmate_Exists]
(
	@FlatmateId int,
	@Login nvarchar(100)
)
RETURNS bit
AS
BEGIN
	DECLARE @Result bit, @Count int;

	SELECT @Count = COUNT(1)
		FROM dbo.Flatmate
		WHERE [Login] = @Login
			AND FlatmateId <> @FlatmateId;

	SET @Result = IIF(@Count > 0, 1, 0);

	RETURN @Result;
END
GO

GRANT EXECUTE
	ON OBJECT::[dbo].[Flatmate_Exists] TO [fm_user]
	AS [dbo];
