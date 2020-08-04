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
-- Create date: <08/04/2020>
-- Description:	<Get all user>
-- =============================================
Alter PROCEDURE [dbo].[sp_getAllUsers]
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Users.*,StatusCommon.Name as NameStatus,dp.Name as Department FROM Users 
	inner join StatusCommon on Users.Status = StatusCommon.ID 
	inner join Department dp on dp.ID = Users.ID
	where (@id = 0 OR @id = Users.ID) and (@status = '' or @status = Users.Status)
END
