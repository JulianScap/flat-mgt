CREATE PROCEDURE [dbo].[Task_GetById]
	@TaskId int
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
	WHERE
		TaskId = @TaskId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_GetById] TO [fm_user]
	AS [dbo];

