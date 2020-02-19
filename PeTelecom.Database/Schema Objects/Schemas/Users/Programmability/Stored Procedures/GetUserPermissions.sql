CREATE PROCEDURE [User].[GetUserPermissions]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT DISTINCT
		1
	FROM [User].[User] AS U
		INNER JOIN [User].[UserRole] AS UR
			ON U.Id = UR.UserId
			AND U.Id = @UserId
		INNER JOIN [User].RolePermission AS RP
			ON UR.RoleCode = RP.RoleCode
END
