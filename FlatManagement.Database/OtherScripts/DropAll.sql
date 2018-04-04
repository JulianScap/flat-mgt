IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.TaskInstance') AND [type] = 'U')
	DROP TABLE dbo.TaskInstance;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.TaskOwner') AND [type] = 'U')
	DROP TABLE dbo.TaskOwner;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Task') AND [type] = 'U')
	DROP TABLE dbo.Task;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Flatmate') AND [type] = 'U')
	DROP TABLE dbo.Flatmate;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('dbo.Flat') AND [type] = 'U')
	DROP TABLE dbo.Flat;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.objects WHERE [object_id] = OBJECT_ID('ref.PeriodType') AND [type] = 'U')
	DROP TABLE ref.PeriodType;
GO

IF EXISTS(SELECT TOP 1 1 FROM sys.schemas WHERE name = 'ref')
	DROP SCHEMA ref;
GO
