SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/04/2020>
-- Description:	<Update Department>
-- =============================================
CREATE PROCEDURE sp_updateDepartment 
	@id int,
	@name nvarchar(200),
	@description ntext,
	@status bit
AS
BEGIN
	UPDATE DEPARTMENT SET Name = @name, [Description] = @description, [Status] = @status where ID=@id
END
GO
