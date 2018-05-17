CREATE PROCEDURE [dbo].[Task_Delete]
	@TaskId int
AS
BEGIN
	DELETE FROM
		dbo.Task
	WHERE
		TaskId = @TaskId
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_Delete] TO [fm_user]
	AS [dbo];

