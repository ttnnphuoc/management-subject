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
-- Create date: <08/26/2020>
-- Description:	<Get subject by user>
-- =============================================
ALTER PROCEDURE sp_getSubjectByUser 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	select sub.ID, sub.Name,stt.Name as NameStatus, sub.Description from Users u
	inner join UserSubject us on us.IDUsers = u.ID
	inner join Subjects sub on us.IDSubject = sub.ID
	inner join StatusCommon stt on stt.ID = sub.Status
	where u.ID = @id
END
GO
