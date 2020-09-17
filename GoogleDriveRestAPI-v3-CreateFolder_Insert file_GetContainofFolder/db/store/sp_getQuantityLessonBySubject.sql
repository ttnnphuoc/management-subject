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
-- Create date: <09/17/2020>
-- Description:	<Get Quantity lesson by subject>
-- =============================================
CREATE PROCEDURE sp_getQuantityLessonBySubject 
	
AS
BEGIN
	select sb.ID,sb.Name, COUNT(IDSubject) as Soluong from Subjects sb 
		inner join Lessons less 
		on less.IDSubject = sb.ID group by IDSubject,sb.Name,sb.ID order by Soluong
END
GO
