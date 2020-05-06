CREATE PROCEDURE [User].[GetUnprocessedOutboxMessages]
AS
BEGIN
	SELECT Id, Type, Data
	FROM [User].[OutboxMessage] AS OM
	WHERE ProcessedDate IS NULL
END
