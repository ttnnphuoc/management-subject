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
-- Description:	<Add subject>
-- =============================================
CREATE PROCEDURE sp_addSubjects
	@id varchar(35),
	@name nvarchar(100),
	@description ntext
AS
BEGIN
	INSERT INTO Subjects VALUES(@id,@name,@description)
END
GO
