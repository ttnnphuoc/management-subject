SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/03/2020>
-- Description:	<Add new Roles>
-- =============================================
alter PROCEDURE sp_addRoles 
	@name nvarchar(200),
	@description ntext
AS
BEGIN
	INSERT INTO ROLES VALUES(N'' + @name, @description,1)
END
GO
