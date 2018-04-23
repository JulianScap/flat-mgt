CREATE PROCEDURE [dbo].[Task_GetAll]
AS
BEGIN
	SELECT
		TaskId,
		[Name],
		[Description],
		[DateStart],
		[PeriodTypeId]
	FROM
		dbo.Task
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_GetAll] TO [fm_user]
	AS [dbo];

