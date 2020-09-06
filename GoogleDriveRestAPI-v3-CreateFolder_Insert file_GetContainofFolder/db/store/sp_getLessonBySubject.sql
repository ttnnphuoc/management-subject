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
-- Description:	<Get lesson by subject>
-- =============================================
ALTER PROCEDURE sp_getLessonBySubject 
	@subject varchar(40)
AS
BEGIN
	Select id,IDSubject as parent, Name as text, cast(0 as bit) as children from Lessons where IDSubject = @subject
END
GO
