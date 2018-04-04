CREATE TABLE [dbo].[Flatmate] (
    [FlatmateId] INT            IDENTITY (1, 1) NOT NULL,
    [FlatId]     INT            NOT NULL,
    [FullName]   NVARCHAR (500) NOT NULL,
    [Nickname]   NVARCHAR (100) NULL,
    [BirthDate]  DATE           NULL,
    [FlatTenant] BIT            NOT NULL,
    CONSTRAINT [PK_Flatmate] PRIMARY KEY CLUSTERED ([FlatmateId] ASC),
    CONSTRAINT [FK_Flatmate_Flat] FOREIGN KEY ([FlatId]) REFERENCES [dbo].[Flat] ([FlatId])
);

