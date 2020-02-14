CREATE TABLE [User].[UserRole]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [FK_User.UserRole_UserId] FOREIGN KEY REFERENCES [User].[User](Id),
	[RoleCode] SMALLINT
	CONSTRAINT [PK_User.UserRole_UserId_RoleCode] PRIMARY KEY (UserId, RoleCode)
)
