CREATE TABLE [dbo].[Flat] (
    [FlatId]   INT            IDENTITY (1, 1) NOT NULL,
    [Address1] NVARCHAR (100) NULL,
    [Address2] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Flat] PRIMARY KEY CLUSTERED ([FlatId] ASC)
);

