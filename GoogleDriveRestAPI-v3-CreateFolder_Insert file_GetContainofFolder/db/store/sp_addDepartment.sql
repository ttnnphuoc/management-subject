SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Add new department>
-- =============================================
CREATE PROCEDURE sp_addDepartment
	@name nvarchar(200),
	@description ntext
AS
BEGIN
	INSERT INTO DEPARTMENT VALUES(@name,1,@description)
END
GO
