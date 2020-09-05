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
-- Create date: <09/05/2020>
-- Description:	<Update Children>
-- =============================================
CREATE PROCEDURE sp_updateSubjectsParent 
	@id varchar(40)
AS
BEGIN
	UPDATE Subjects set Children = 1 where ID = @id
END
GO
