CREATE TABLE [dbo].[Flat] (
    [FlatId]   INT            IDENTITY (1, 1) NOT NULL,
    [Address] NVARCHAR (1000) NULL
    CONSTRAINT [PK_Flat] PRIMARY KEY CLUSTERED ([FlatId] ASC)
);

