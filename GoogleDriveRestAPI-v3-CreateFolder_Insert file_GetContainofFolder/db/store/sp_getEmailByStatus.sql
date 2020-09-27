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
-- Create date: <09/27/2020>
-- Description:	<Get email by status>
-- =============================================
CREATE PROCEDURE sp_getEmailByStatus
	@stt nchar(3)
AS
BEGIN
	SELECT * FROM EmailAdmin WHERE [Status] = @stt
END
GO
