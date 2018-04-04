CREATE TABLE [dbo].[TaskInstance] (
    [TaskInstanceId] INT  IDENTITY (1, 1) NOT NULL,
    [TaskId]         INT  NOT NULL,
    [FlatmateId]     INT  NOT NULL,
    [CompletedOn]    DATE NOT NULL,
    CONSTRAINT [PK_TaskInstance] PRIMARY KEY CLUSTERED ([TaskInstanceId] ASC),
    CONSTRAINT [FK_TaskInstance_Flatmate] FOREIGN KEY ([FlatmateId]) REFERENCES [dbo].[Flatmate] ([FlatmateId]),
    CONSTRAINT [FK_TaskInstance_Task] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([TaskId])
);

