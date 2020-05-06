CREATE PROCEDURE [User].[UpdateInboxMessageProcessDate]
	@Id UNIQUEIDENTIFIER,
	@Date DATETIME2(7)
AS
BEGIN
	UPDATE [User].InboxMessage
		SET ProcessedDate = @Date
	WHERE Id = @Id
END
