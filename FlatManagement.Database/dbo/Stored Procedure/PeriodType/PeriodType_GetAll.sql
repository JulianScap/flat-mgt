CREATE PROCEDURE [dbo].[PeriodType_GetAll]
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		PeriodTypeId,
		[Name]
	FROM
		[ref].[PeriodType]
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[PeriodType_GetAll] TO [fm_user]
	AS [dbo];

