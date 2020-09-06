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
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/06/2020>
-- Description:	<Delete lesson>
-- =============================================
CREATE PROCEDURE sp_deleteLessons 
	@lesson varchar(40)
AS
BEGIN
	UPDATE Lessons SET Status = 0 WHERE ID = @lesson
END
GO
