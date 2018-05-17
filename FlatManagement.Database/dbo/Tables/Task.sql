CREATE TABLE [dbo].[Task] (
	[TaskId] INT IDENTITY (1, 1) NOT NULL,
	[FlatId] INT NOT NULL,
	[Name] NVARCHAR (100) NOT NULL,
	[Description] NVARCHAR (1000) NOT NULL,
	[DateStart] DATE NULL,
	[PeriodTypeId] INT NULL, 
	CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskId] ASC),
	CONSTRAINT [FK_Task_PeriodType] FOREIGN KEY ([PeriodTypeId]) REFERENCES ref.PeriodType ([PeriodTypeId]),
	CONSTRAINT [FK_Task_Flat] FOREIGN KEY ([FlatId]) REFERENCES dbo.Flat ([FlatId])
);

