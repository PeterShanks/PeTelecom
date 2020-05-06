CREATE PROCEDURE [User].[GetUnprocessedInboxMessages]
AS
BEGIN
	SELECT 
		IM.Id,
		IM.Data,
		IM.Type
	FROM [User].InboxMessage AS IM
	WHERE IM.ProcessedDate IS NULL
END