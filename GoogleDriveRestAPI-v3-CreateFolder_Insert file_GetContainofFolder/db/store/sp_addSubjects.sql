USE [ManageSubject]
GO
/****** Object:  StoredProcedure [dbo].[sp_addSubjects]    Script Date: 08/26/2020 4:08:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/21/2020>
-- Description:	<Add subject>
-- =============================================
ALTER PROCEDURE [dbo].[sp_addSubjects]
	@id varchar(40),
	@name nvarchar(100),
	@description ntext
AS
BEGIN
	INSERT INTO Subjects VALUES(@id,@name,@description,1,0)
END
