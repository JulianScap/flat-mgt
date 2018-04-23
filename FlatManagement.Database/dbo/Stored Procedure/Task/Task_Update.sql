CREATE PROCEDURE [dbo].[Task_Update]
	@TaskId int,
	@Name nvarchar(100),
	@DateStart date,
	@Description nvarchar(1000),
	@PeriodTypeId int
AS
BEGIN
	UPDATE dbo.Task
	SET
		[Name] = @Name,
		[DateStart] = @DateStart,
		[Description] = @Description,
		[PeriodTypeId] = @PeriodTypeId
	WHERE TaskId = @TaskId;
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_Update] TO [fm_user]
	AS [dbo];

