CREATE PROCEDURE [dbo].[Task_Insert]
	@Name nvarchar(100),
	@DateStart date,
	@Description nvarchar(1000),
	@PeriodTypeId int,
	@TaskId int output
AS
BEGIN
	INSERT INTO dbo.Task ([Name], [DateStart], [Description], PeriodTypeId) VALUES (@Name, @DateStart, @Description, @PeriodTypeId);
	SET @TaskId = SCOPE_IDENTITY();
END

GO
GRANT EXECUTE
	ON OBJECT::[dbo].[Task_Insert] TO [fm_user]
	AS [dbo];

