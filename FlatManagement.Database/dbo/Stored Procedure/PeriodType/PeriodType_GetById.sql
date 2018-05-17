CREATE PROCEDURE [dbo].[PeriodType_GetById]
	@PeriodTypeId int
AS
BEGIN
	SELECT
		PeriodTypeId,
		[Name]
	FROM
		[ref].[PeriodType]
	WHERE
		PeriodTypeId = @PeriodTypeId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[PeriodType_GetById] TO [fm_user]
	AS [dbo];

