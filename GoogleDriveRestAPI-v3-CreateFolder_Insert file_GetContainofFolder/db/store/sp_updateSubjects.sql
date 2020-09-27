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
-- Create date: <27/09/2020>
-- Description:	<Update info subject>
-- =============================================
CREATE PROCEDURE sp_updateSubjects 
	@id varchar(40),
	@name nvarchar(255),
	@description ntext,
	@stt nchar(3)
AS
BEGIN
	UPDATE Subjects SET Name = @name, Description = @description, Status = @stt WHERE @id= ID
END
GO
