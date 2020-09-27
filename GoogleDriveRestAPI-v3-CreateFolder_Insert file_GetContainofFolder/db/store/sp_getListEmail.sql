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
-- Description:	<Get email to send to User>
-- =============================================
CREATE PROCEDURE sp_getListEmail
AS
BEGIN
	SELECT * FROM EMAILADMIN EM INNER JOIN StatusCommon STT ON EM.STATUS = STT.ID
END
GO
