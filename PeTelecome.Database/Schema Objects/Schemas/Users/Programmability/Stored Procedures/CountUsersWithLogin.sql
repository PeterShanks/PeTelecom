CREATE PROCEDURE [User].[CountUsersWithLogin]
	@Login NVARCHAR(100)
AS
	SELECT COUNT(*)
	FROM [User].[User]
	WHERE [Login] = @Login
RETURN 0
