CREATE PROCEDURE [User].[CountUsersWithLogin]
	@Login NVARCHAR(100)
AS
BEGIN
	SELECT COUNT(*)
	FROM [User].[User]
	WHERE [Login] = @Login
END
