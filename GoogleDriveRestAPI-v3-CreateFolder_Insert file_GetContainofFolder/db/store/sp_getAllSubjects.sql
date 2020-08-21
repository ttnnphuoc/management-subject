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
-- Create date: <08/21/2020>
-- Description:	<Get all subject>
-- =============================================
Alter PROCEDURE sp_getAllSubjects
	@id varchar(35),
	@status nchar(3)
AS
BEGIN
	SELECT id,'#' as parent, Name as text, cast(0 as bit) as children FROM Subjects WHERE (@id = '' or @id = id) AND (@status = '' or @status = [status])
END
GO
