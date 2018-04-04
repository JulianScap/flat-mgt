CREATE TABLE [dbo].[Flatmate] (
    [FlatmateId] INT            IDENTITY (1, 1) NOT NULL,
    [FlatId]     INT            NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [NickName]   NVARCHAR (100) NULL,
    [BirthDate]  DATE           NULL,
    CONSTRAINT [PK_Flatmate] PRIMARY KEY CLUSTERED ([FlatmateId] ASC),
    CONSTRAINT [FK_Flatmate_Flat] FOREIGN KEY ([FlatId]) REFERENCES [dbo].[Flat] ([FlatId])
);

