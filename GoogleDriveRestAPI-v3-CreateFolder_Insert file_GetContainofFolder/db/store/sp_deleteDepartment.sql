SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/04/2020>
-- Description:	<Delete Department>
-- =============================================
CREATE PROCEDURE sp_deleteDepartment 
	@id int
AS
BEGIN
	UPDATE DEPARTMENT SET [Status] = 0 where ID=@id
END
GO
