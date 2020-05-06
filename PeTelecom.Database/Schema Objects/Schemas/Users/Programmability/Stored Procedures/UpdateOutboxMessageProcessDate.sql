CREATE PROCEDURE [User].[UpdateOutboxMessageProcessDate]
	@Id UNIQUEIDENTIFIER,
	@ProccessDate DATETIME2(7)
AS
BEGIN
	UPDATE [User].[OutboxMessage]
		SET ProcessedDate = @ProccessDate
	WHERE Id = @Id;
END
