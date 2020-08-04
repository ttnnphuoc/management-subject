SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Get all department>
-- =============================================
CREATE PROCEDURE sp_getAllDeparment
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Department.*,StatusCommon.Name as NameStatus FROM Department inner join StatusCommon on Department.Status = StatusCommon.ID where (@id = 0 OR @id = Department.ID) and (@status = '' or @status = Department.Status)
END
GO
