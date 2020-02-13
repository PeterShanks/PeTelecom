CREATE TABLE [User].[RolePermission]
(
	[RoleCode] SMALLINT NOT NULL,
	[PermissionCode] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_RolePermission_RoleCode_PermissionCode] PRIMARY KEY (RoleCode, PermissionCode)
)
