CREATE TABLE [dbo].[TaskOwner] (
    [TaskId]     INT NOT NULL,
    [FlatmateId] INT NOT NULL,
    CONSTRAINT [PK_TaskOwner] PRIMARY KEY CLUSTERED ([TaskId] ASC, [FlatmateId] ASC),
    CONSTRAINT [FK_TaskOwner_Flatmate] FOREIGN KEY ([FlatmateId]) REFERENCES [dbo].[Flatmate] ([FlatmateId]),
    CONSTRAINT [FK_TaskOwner_Task] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([TaskId])
);

