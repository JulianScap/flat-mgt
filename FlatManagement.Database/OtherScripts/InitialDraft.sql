IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.TaskInstance') AND [type] = 'U')
	DROP TABLE dbo.TaskInstance
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.TaskOwner') AND [type] = 'U')
	DROP TABLE dbo.TaskOwner
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Task') AND [type] = 'U')
	DROP TABLE dbo.Task
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Flatmate') AND [type] = 'U')
	DROP TABLE dbo.Flatmate
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Flat') AND [type] = 'U')
	DROP TABLE dbo.Flat
GO


CREATE TABLE dbo.Flat (
	FlatID INT NOT NULL IDENTITY(1, 1),
	Address1 NVARCHAR(100),
	Address2 NVARCHAR(100),
	CONSTRAINT PK_Flat PRIMARY KEY (FlatID)
)
GO


CREATE TABLE dbo.Flatmate (
	FlatmateID INT NOT NULL IDENTITY(1, 1),
	FlatID INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	NickName NVARCHAR(100),
	BirthDate DATE,
	CONSTRAINT PK_Flatmate PRIMARY KEY (FlatmateID),
	CONSTRAINT FK_Flatmate_Flat FOREIGN KEY (FlatID) REFERENCES dbo.Flat (FlatID)
)
GO


CREATE TABLE dbo.Task (
	TaskID INT NOT NULL IDENTITY(1, 1),
	CONSTRAINT PK_Task PRIMARY KEY (TaskID),
)
GO


CREATE TABLE dbo.TaskInstance (
	TaskInstanceID INT NOT NULL IDENTITY(1, 1),
	TaskID INT NOT NULL,
	FlatmateID INT NOT NULL,
	CompletedOn DATE NOT NULL
	CONSTRAINT PK_TaskInstance PRIMARY KEY (TaskInstanceID),
	CONSTRAINT FK_TaskInstance_Task FOREIGN KEY (TaskID) REFERENCES dbo.Task (TaskID),
	CONSTRAINT FK_TaskInstance_Flatmate FOREIGN KEY (FlatmateID) REFERENCES dbo.Flatmate (FlatmateID),
)
GO


CREATE TABLE dbo.TaskOwner (
	TaskID INT NOT NULL,
	FlatmateID INT NOT NULL,
	CONSTRAINT PK_TaskOwner PRIMARY KEY (TaskID, FlatmateID),
	CONSTRAINT FK_TaskOwner_Task FOREIGN KEY (TaskID) REFERENCES dbo.Task (TaskID),
	CONSTRAINT FK_TaskOwner_Flatmate FOREIGN KEY (FlatmateID) REFERENCES dbo.Flatmate (FlatmateID),
)
