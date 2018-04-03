CREATE TABLE [dbo].[TaskOwner] (
    [TaskID]     INT NOT NULL,
    [FlatmateID] INT NOT NULL,
    CONSTRAINT [PK_TaskOwner] PRIMARY KEY CLUSTERED ([TaskID] ASC, [FlatmateID] ASC),
    CONSTRAINT [FK_TaskOwner_Flatmate] FOREIGN KEY ([FlatmateID]) REFERENCES [dbo].[Flatmate] ([FlatmateID]),
    CONSTRAINT [FK_TaskOwner_Task] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[Task] ([TaskID])
);

