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
-- Description:	<Add Lesson>
-- =============================================
CREATE PROCEDURE sp_addLessons 
	-- Add the parameters for the stored procedure here
	@id varchar(40),
	@name nvarchar(500),
	@video varchar(40),
	@pdf varchar(40),
	@ppt varchar(40),
	@word varchar(40),
	@subject varchar(40)
AS
BEGIN
	INSERT INTO Lessons VALUES(@id,@name,@video,@pdf,@ppt,@word,@subject,1,GETDATE())
END
GO
