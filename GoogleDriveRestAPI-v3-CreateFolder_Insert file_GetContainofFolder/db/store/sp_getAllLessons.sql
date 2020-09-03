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
-- Create date: <09/03/2020>
-- Description:	<Get All Lesson>
-- =============================================
CREATE PROCEDURE sp_getAllLessons 
	-- Add the parameters for the stored procedure here
	@id varchar(40),
	@status nchar(5),
	@subject varchar(40)
AS
BEGIN
	SELECT * FROM Lessons Less 
	inner join StatusCommon stt on stt.ID = Less.Status
	WHERE (@id = '' or @id = Less.ID) AND (@subject = '' or @subject = Less.IDSubject)
	AND	(@status = '' or @status = Less.Status)
END
GO
