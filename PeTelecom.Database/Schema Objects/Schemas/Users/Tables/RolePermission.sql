CREATE TABLE [User].[RolePermission]
(
	[RoleCode] SMALLINT NOT NULL,
	[PermissionCode] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_RolePermission_RoleCode_PermissionCode] PRIMARY KEY (RoleCode, PermissionCode),
	[ValidFrom] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH(SYSTEM_VERSIONING = ON (HISTORY_TABLE = [User].[RolePermissionHistory]))

