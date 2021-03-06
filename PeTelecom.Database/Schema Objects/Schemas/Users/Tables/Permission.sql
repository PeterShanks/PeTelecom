﻿CREATE TABLE [User].[Permission]
(
	[Code] NVARCHAR(50) NOT NULL CONSTRAINT [PK_User.Permission_Code] PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[ValidFrom] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH(SYSTEM_VERSIONING = ON (HISTORY_TABLE = [User].[PermissionHistory]))
