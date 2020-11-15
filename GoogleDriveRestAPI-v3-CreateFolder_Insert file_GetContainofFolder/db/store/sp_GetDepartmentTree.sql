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
-- Create date: <11/08/2020>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_GetDepartmentTree
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select Dept.ID, '#' as parent, Name as text, CAST((CASE WHEN COUNT(Us.ID) > 0 THEN 1 ELSE 0 END) AS bit) AS children from Department Dept
	LEFT JOIN Users Us ON Us.IDDepartment = Dept.ID
	group by Dept.ID, Dept.Name,us.ID
END
GO
