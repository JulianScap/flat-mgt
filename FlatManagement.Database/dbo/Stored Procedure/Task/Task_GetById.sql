CREATE PROCEDURE [dbo].[Task_GetById]
	@TaskId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	SELECT
		TaskId,
		[FlatId],
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

