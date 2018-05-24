CREATE PROCEDURE [dbo].[Task_GetAll]
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
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_GetAll] TO [fm_user]
	AS [dbo];

