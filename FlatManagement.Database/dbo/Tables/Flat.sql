CREATE TABLE [dbo].[Flat] (
    [FlatID]   INT            IDENTITY (1, 1) NOT NULL,
    [Address1] NVARCHAR (100) NULL,
    [Address2] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Flat] PRIMARY KEY CLUSTERED ([FlatID] ASC)
);

