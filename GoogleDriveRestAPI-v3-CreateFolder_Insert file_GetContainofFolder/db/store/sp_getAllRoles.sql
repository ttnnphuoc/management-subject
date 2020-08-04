SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/03/2020>
-- Description:	<Get all roles when id is 0>
-- =============================================
Create PROCEDURE sp_getAllRoles
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Roles.*,StatusCommon.Name as NameStatus FROM Roles inner join StatusCommon on Roles.Status = StatusCommon.ID where (@id = 0 OR @id = Roles.ID) and (@status = '' or @status = Roles.Status)
END
GO
