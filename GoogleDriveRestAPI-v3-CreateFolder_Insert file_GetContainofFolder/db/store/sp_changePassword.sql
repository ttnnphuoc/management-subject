SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_changePassword
	@email varchar(100),
	@password varchar(150)
AS
BEGIN
	UPDATE [USERS] set [PASSWORD] = @password WHERE EMAIL = @email
END
GO
