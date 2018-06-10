CREATE PROCEDURE [dbo].[Task_Update]
	@TaskId int,
	@FlatId int,
	@Name nvarchar(100),
	@DateStart date,
	@Description nvarchar(1000),
	@PeriodTypeId int,
	@UserLogin nvarchar(100)
AS
BEGIN
	UPDATE dbo.Task
	SET
		[FlatId] = @FlatId,
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

