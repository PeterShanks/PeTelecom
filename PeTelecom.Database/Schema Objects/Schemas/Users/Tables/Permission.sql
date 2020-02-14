CREATE TABLE [User].[Permission]
(
	[Code] NVARCHAR(50) NOT NULL CONSTRAINT [PK_User.Permission_Code] PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(255) NULL
)
