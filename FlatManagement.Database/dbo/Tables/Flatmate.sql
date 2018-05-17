CREATE TABLE [dbo].[Flatmate] (
    [FlatmateId] INT            IDENTITY (1, 1) NOT NULL,
    [FlatId]     INT            NOT NULL,
    [AccountId]  INT            NOT NULL,
    [FullName]   NVARCHAR (500) NOT NULL,
    [Nickname]   NVARCHAR (100) NULL,
    [BirthDate]  DATE           NULL,
    [FlatTenant] BIT            NOT NULL,
    CONSTRAINT [PK_Flatmate] PRIMARY KEY CLUSTERED ([FlatmateId]),
    CONSTRAINT [FK_Flatmate_Flat] FOREIGN KEY ([FlatId]) REFERENCES [dbo].[Flat] ([FlatId]),
    CONSTRAINT [FK_Flatmate_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
);
GO

CREATE UNIQUE INDEX [IX_Flatmate_FlatId_Nickname] ON [dbo].[Flatmate] ([FlatId], [Nickname])
GO
