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
-- Create date: <09/30/2020>
-- Description:	<Update File ID>
-- =============================================
alter PROCEDURE sp_updateFileIDLesson
	@fieldName varchar(40),
	@value varchar(40),
	@id varchar(40)
AS
BEGIN
	Declare @sql varchar(MAX) = ''
	SET @sql = 'UPDATE Lessons SET ' + @fieldName + '=''' + @value + ''' WHERE ID = ''' + @id+ ''''
	print @sql
	EXEC(@sql)
END
GO
