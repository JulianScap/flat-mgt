CREATE TABLE [dbo].[Account]
(
	[AccountId]    INT IDENTITY(1, 1) NOT NULL,
	[Login]        NVARCHAR(100) NOT NULL,
	[Password]     NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId])
)
GO

CREATE UNIQUE INDEX [IX_Account_Login] ON [dbo].[Account] ([Login])
GO
