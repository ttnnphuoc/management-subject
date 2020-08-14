GO
/****** Object:  StoredProcedure [dbo].[sp_addDepartment]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Add new department>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addDepartment]
	@name nvarchar(200),
	@description ntext
AS
BEGIN
	INSERT INTO DEPARTMENT VALUES(@name,1,@description)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addRoles]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/03/2020>
-- Description:	<Add new Roles>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addRoles] 
	@name nvarchar(200),
	@description ntext
AS
BEGIN
	INSERT INTO ROLES VALUES(N'' + @name, @description,1)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addUsers]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Add new user>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addUsers]
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
/****** Object:  StoredProcedure [dbo].[sp_changePassword]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_changePassword]
	@email varchar(100),
	@password varchar(150)
AS
BEGIN
	UPDATE [USERS] set [PASSWORD] = @password WHERE EMAIL = @email
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteDepartment]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/04/2020>
-- Description:	<Delete Department>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteDepartment] 
	@id int
AS
BEGIN
	UPDATE DEPARTMENT SET [Status] = 0 where ID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteRoles]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Delete Role>
-- =============================================
Create PROCEDURE [dbo].[sp_deleteRoles]
	@Id int
AS
BEGIN
	UPDATE Roles SET [Status] = 0 WHERE ID = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteUsers]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/06/2020>
-- Description:	<Delete User>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteUsers]
	@id int
AS
BEGIN
	UPDATE USERs SET [STATUS] = 0 WHERE [ID] = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllDeparment]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllDeparment]
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Department.*,StatusCommon.Name as NameStatus FROM Department inner join StatusCommon on Department.Status = StatusCommon.ID where (@id = 0 OR @id = Department.ID) and (@status = '' or @status = Department.Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllRoles]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/03/2020>
-- Description:	<Get all roles when id is 0>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllRoles]
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Roles.*,StatusCommon.Name as NameStatus FROM Roles inner join StatusCommon on Roles.Status = StatusCommon.ID where (@id = 0 OR @id = Roles.ID) and (@status = '' or @status = Roles.Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllUsers]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Get all user>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllUsers]
	@id int,
	@status nchar(5)
AS
BEGIN
	SELECT Users.*,StatusCommon.Name as NameStatus,dp.Name as Department, r.Name as RolesName FROM Users 
	inner join StatusCommon on Users.Status = StatusCommon.ID 
	inner join Department dp on dp.ID = Users.IDDepartment
	inner join Roles r on r.ID = Users.Roles
	where (@id = 0 OR @id = Users.ID) and (@status = '' or @status = Users.Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020	>
-- Description:	<User Login>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Login]
	@email varchar(100),
	@password varchar(150)
AS
BEGIN
	SELECT * FROM USERS WHERE EMAIL = @email AND [PASSWORD] = @password AND Status = 1
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updateDepartment]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/04/2020>
-- Description:	<Update Department>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateDepartment] 
	@id int,
	@name nvarchar(200),
	@description ntext,
	@status bit
AS
BEGIN
	UPDATE DEPARTMENT SET Name = @name, [Description] = @description, [Status] = @status where ID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updatePermission]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/06/2020>
-- Description:	<Update permission>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updatePermission]
	@id int,
	@department int,
	@roles int,
	@status int
AS
BEGIN
	UPDATE  USERS set IDDepartment = @department,Roles = @roles, Status = @status
	WHERE ID = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updateRoles]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/04/2020>
-- Description:	<Edit Role>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateRoles]
	@Id int,
	@name nvarchar(200),
	@description ntext,
	@status bit
AS
BEGIN
	UPDATE Roles SET Name = @name,[Description] = @description,[Status] = @status WHERE ID = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updateUsers]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <08/06/2020>
-- Description:	<Update Information User>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateUsers] 
	@id int,
	@fullname nvarchar(200),
	@department int,
	@status int
AS
BEGIN
	UPDATE USERS SET Fullname = @fullname, IDDepartment = @department WHERE [id] = @id
	Update Users SET [Status] = @status WHERE [id] = @id AND @status != '-1'
END

GO
/****** Object:  Table [dbo].[Department]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[Description] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [ntext] NULL,
	[Status] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusCommon]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCommon](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/08/2020 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](200) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](150) NULL,
	[Roles] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[IDDepartment] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
