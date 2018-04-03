CREATE TABLE [dbo].[TaskInstance] (
    [TaskInstanceID] INT  IDENTITY (1, 1) NOT NULL,
    [TaskID]         INT  NOT NULL,
    [FlatmateID]     INT  NOT NULL,
    [CompletedOn]    DATE NOT NULL,
    CONSTRAINT [PK_TaskInstance] PRIMARY KEY CLUSTERED ([TaskInstanceID] ASC),
    CONSTRAINT [FK_TaskInstance_Flatmate] FOREIGN KEY ([FlatmateID]) REFERENCES [dbo].[Flatmate] ([FlatmateID]),
    CONSTRAINT [FK_TaskInstance_Task] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[Task] ([TaskID])
);

