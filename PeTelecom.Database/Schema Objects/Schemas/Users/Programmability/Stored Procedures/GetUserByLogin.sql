﻿CREATE PROCEDURE [User].[GetUserByLogin]
	@Login NVARCHAR(100) 
AS
BEGIN
	SELECT 
		U.Id,
		U.Email,
		U.[Login],
		U.FirstName,
		U.LastName,
		U.IsActive,
		U.[Name],
		U.[Password]
	FROM [User].[User] AS U
	WHERE U.[Login] = @Login
END