﻿CREATE TABLE [User].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [PK_User.User_Id] PRIMARY KEY,
	[Login] NVARCHAR(100) NOT NULL CONSTRAINT [U_User.User_Login] UNIQUE,
	[Email] NVARCHAR (255) NOT NULL,
	[Password] NVARCHAR(255) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR (255) NOT NULL,
	[IsActive] BIT NOT NULL,
	[StatusCode] VARCHAR(50) NOT NULL,
	[RegisterDate] DATETIME NOT NULL,
	[ConfirmedDate] DATETIME NULL
)
GO

CREATE NONCLUSTERED INDEX [IX_User.User_Login_ConfirmedDate_Not_NULL] 
ON [User].[User] ([Login]) WHERE ConfirmedDate IS NOT NULL