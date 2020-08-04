SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Edit Role>
-- =============================================
CREATE PROCEDURE sp_updateRoles
	@Id int,
	@name nvarchar(200),
	@description ntext,
	@status bit
AS
BEGIN
	UPDATE Roles SET Name = @name,[Description] = @description,[Status] = @status WHERE ID = @Id
END
GO
