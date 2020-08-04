SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020	>
-- Description:	<User Login>
-- =============================================
CREATE PROCEDURE sp_login
	@email varchar(100),
	@password varchar(150)
AS
BEGIN
	SELECT * FROM USERS WHERE EMAIL = @email AND [PASSWORD] = @password AND [Status] = 1
END
GO
