/****** Object:  StoredProcedure [dbo].[sp_updateRoles]    Script Date: 08/04/2020 10:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Delete Role>
-- =============================================
Create PROCEDURE [dbo].[sp_deleteRoles]
	@Id int
AS
BEGIN
	UPDATE Roles SET [Status] = 0 WHERE ID = @Id
END
