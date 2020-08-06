-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/06/2020>
-- Description:	<Update permission>
-- =============================================
CREATE PROCEDURE sp_updatePermission
	@id int,
	@department int,
	@roles int,
	@status int
AS
BEGIN
	UPDATE  USERS set IDDepartment = @department,Roles = @roles, Status = @status
	WHERE ID = @id;
END
GO
