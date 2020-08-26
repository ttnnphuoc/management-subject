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
-- Create date: <26/08/2020>
-- Description:	<Add subject lesson>
-- =============================================
CREATE PROCEDURE sp_addUserSubject
	-- Add the parameters for the stored procedure here
	@subject varchar(40),
	@user varchar(40),
	@status nchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	INSERT INTO UserSubject VALUES(@subject,@user,@status)
END
GO
