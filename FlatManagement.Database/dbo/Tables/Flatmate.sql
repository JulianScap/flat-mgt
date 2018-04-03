CREATE TABLE [dbo].[Flatmate] (
    [FlatmateID] INT            IDENTITY (1, 1) NOT NULL,
    [FlatID]     INT            NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [NickName]   NVARCHAR (100) NULL,
    [BirthDate]  DATE           NULL,
    CONSTRAINT [PK_Flatmate] PRIMARY KEY CLUSTERED ([FlatmateID] ASC),
    CONSTRAINT [FK_Flatmate_Flat] FOREIGN KEY ([FlatID]) REFERENCES [dbo].[Flat] ([FlatID])
);

