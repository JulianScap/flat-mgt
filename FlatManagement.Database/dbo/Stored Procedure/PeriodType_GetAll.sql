CREATE PROCEDURE [dbo].[PeriodType_GetAll]
AS
BEGIN
	SELECT
		PeriodTypeId,
		[Name]
	FROM
		[ref].[PeriodType]
END
