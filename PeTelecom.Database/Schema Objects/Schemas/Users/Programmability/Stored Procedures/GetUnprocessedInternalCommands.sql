CREATE PROCEDURE [User].[GetUnprocessedInternalCommands]
AS
BEGIN
	SELECT IC.Type, IC.Data
	FROM [User].[InternalCommand] AS IC
	WHERE IC.ProcessedDate IS NULL
END
