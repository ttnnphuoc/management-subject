SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Add new user>
-- =============================================
Alter PROCEDURE sp_addUsers
	@name nvarchar(200),
	@email varchar(100),
	@password varchar(100),
	@date datetime,
	@department nchar(5)
AS
BEGIN
	
    INSERT INTO Users(FULLNAME,EMAIL,[PASSWORD],DATECREATED,[ROLES],IDDEPARTMENT, [STATUS]) 
	VALUES(@name,@email,@password,@date,1,@department,1)
END
GO
