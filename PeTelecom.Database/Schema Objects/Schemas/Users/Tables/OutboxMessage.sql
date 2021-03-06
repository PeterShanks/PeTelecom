﻿CREATE TABLE [User].[OutboxMessage]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OccurredOn] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_users_OutboxMessages_Id] PRIMARY KEY ([Id] ASC),
	[ValidFrom] DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH(SYSTEM_VERSIONING = ON (HISTORY_TABLE = [User].[OutboxMessageHistory]));

GO;

CREATE NONCLUSTERED INDEX [IX_User.OutboxMessage_ProcessedDate]
ON [User].[OutboxMessage] (Id)
WHERE ProcessedDate IS NULL;
