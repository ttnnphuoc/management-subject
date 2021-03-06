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
alter PROCEDURE sp_GetSubjectTree
@userID nchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--select Us.ID, us.IDDepartment as parent, us.Fullname as text, 
	--CAST((CASE WHEN COUNT(sub.IDUsers) > 0 THEN 1 ELSE 0 END) AS bit) AS children 
	--from Users Us 
	--LEFT JOIN UserSubject sub ON Us.ID = sub.IDUsers
	--group by Us.ID, sub.IDSubject,Us.IDDepartment,us.Fullname
	select
		Usub.IDSubject as id, Usub.IDUsers as parent, sub.Name as text, 
		CAST((CASE WHEN COUNT(less.ID) > 0 THEN 1 ELSE 0 END) AS bit) AS children 
	from 
		UserSubject Usub
	left join
		Subjects sub on Usub.IDSubject = sub.ID
	left join
		Lessons less on less.IDSubject = sub.ID
	where 
		Usub.IDUsers = @userID
	group by 
		Usub.IDSubject, Usub.IDUsers,sub.Name,less.ID
	
END
GO