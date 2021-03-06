USE [ManageSubject]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/01/2020 12:43:03 AM ******/
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
/****** Object:  Table [dbo].[EmailAdmin]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailAdmin](
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_EmailAdmin] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lessons](
	[ID] [varchar](40) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Video] [varchar](40) NULL,
	[PdfFile] [varchar](40) NULL,
	[PPTFile] [varchar](40) NULL,
	[WordFile] [varchar](40) NULL,
	[IDSubject] [varchar](40) NULL,
	[Status] [int] NULL,
	[DateCreated] [date] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  Table [dbo].[StatusCommon]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCommon](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subjects](
	[ID] [varchar](40) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [ntext] NULL,
	[Status] [int] NULL,
	[children] [bit] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  Table [dbo].[UserSubject]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSubject](
	[IDSubject] [varchar](40) NULL,
	[IDUsers] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [Name], [Status], [Description]) VALUES (1, N'Công Nghệ Thông Tin', 1, N'Công Nghệ Thông Tin')
INSERT [dbo].[Department] ([ID], [Name], [Status], [Description]) VALUES (2, N'Sinh Học', 1, N'Sinh Học')
SET IDENTITY_INSERT [dbo].[Department] OFF
INSERT [dbo].[EmailAdmin] ([Email], [Password], [Status]) VALUES (N'test@gmail.com', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status]) VALUES (1, N'Giáo Viên', N'Giáo Viên', 1)
INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status]) VALUES (2, N'Trưởng Khoa', N'Trưởng Khoa', 1)
INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status]) VALUES (3, N'Quản Trị Viên', N'Quản Trị Viên', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[StatusCommon] ([ID], [Name]) VALUES (1, N'Đang sử dụng')
INSERT [dbo].[StatusCommon] ([ID], [Name]) VALUES (0, N'Đã xóa')
/****** Object:  StoredProcedure [dbo].[sp_addDepartment]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_addLessons]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/05/2020>
-- Description:	<Add Lesson>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addLessons] 
	-- Add the parameters for the stored procedure here
	@id varchar(40),
	@name nvarchar(500),
	@video varchar(40),
	@pdf varchar(40),
	@ppt varchar(40),
	@word varchar(40),
	@subject varchar(40),
	@description ntext
AS
BEGIN
	INSERT INTO Lessons VALUES(@id,@name,@video,@pdf,@ppt,@word,@subject,1,GETDATE(),@description)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addRoles]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_addSubjects]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/21/2020>
-- Description:	<Add subject>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addSubjects]
	@id varchar(40),
	@name nvarchar(100),
	@description ntext
AS
BEGIN
	INSERT INTO Subjects VALUES(@id,@name,@description,1,0)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_addUsers]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_addUserSubject]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <26/08/2020>
-- Description:	<Add subject lesson>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addUserSubject]
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
/****** Object:  StoredProcedure [dbo].[sp_changePassword]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_deleteDepartment]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_deleteLessons]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/06/2020>
-- Description:	<Delete lesson>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteLessons] 
	@lesson varchar(40)
AS
BEGIN
	UPDATE Lessons SET Status = 0 WHERE ID = @lesson
END

GO
/****** Object:  StoredProcedure [dbo].[sp_deleteRoles]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_deleteUsers]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_getAllDeparment]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_getAllLessons]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<TRAN NGOC PHUOC>
-- Create date: <09/03/2020>
-- Description:	<Get All Lesson>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllLessons] 
	-- Add the parameters for the stored procedure here
	@id varchar(40),
	@status nchar(5),
	@subject varchar(40)
AS
BEGIN
	SELECT *,stt.Name as StatusName FROM Lessons Less 
	inner join StatusCommon stt on stt.ID = Less.Status
	WHERE (@id = '' or @id = Less.ID) AND (@subject = '' or @subject = Less.IDSubject)
	AND	(@status = '' or @status = Less.Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllRoles]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_getAllSubjects]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/21/2020>
-- Description:	<Get all subject>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAllSubjects]
	@id varchar(35),
	@status nchar(3)
AS
BEGIN
	SELECT id,'#' as parent, Name as text, cast(children as bit) as children FROM Subjects WHERE (@id = '' or @id = id) AND (@status = '' or @status = [status])
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getAllUsers]    Script Date: 10/01/2020 12:43:04 AM ******/
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
	@status nchar(5),
	@department nchar(3)
AS
BEGIN
	SELECT Users.*,StatusCommon.Name as NameStatus,dp.Name as Department, r.Name as RolesName FROM Users 
	inner join StatusCommon on Users.Status = StatusCommon.ID 
	inner join Department dp on dp.ID = Users.IDDepartment
	inner join Roles r on r.ID = Users.Roles
	where (@id = 0 OR @id = Users.ID) and (@status = '' or @status = Users.Status) 
	and (@department = '' or @department = Users.IDDepartment)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getEmailByStatus]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/27/2020>
-- Description:	<Get email by status>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getEmailByStatus]
	@stt nchar(3)
AS
BEGIN
	SELECT * FROM EmailAdmin WHERE [Status] = @stt
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getLessonBySubject]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/06/2020>
-- Description:	<Get lesson by subject>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getLessonBySubject] 
	@subject varchar(40)
AS
BEGIN
	Select id,IDSubject as parent, Name as text, cast(0 as bit) as children from Lessons where IDSubject = @subject
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getListEmail]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/27/2020>
-- Description:	<Get email to send to User>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getListEmail]
AS
BEGIN
	SELECT * FROM EMAILADMIN EM INNER JOIN StatusCommon STT ON EM.STATUS = STT.ID
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getQuantityLessonBySubject]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/17/2020>
-- Description:	<Get Quantity lesson by subject>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getQuantityLessonBySubject] 
	
AS
BEGIN
	select sb.ID,sb.Name, COUNT(IDSubject) as Soluong from Subjects sb 
		inner join Lessons less 
		on less.IDSubject = sb.ID group by IDSubject,sb.Name,sb.ID order by Soluong
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getSubjectById]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/03/2020>
-- Description:	<Get subject by id>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getSubjectById] 
	-- Add the parameters for the stored procedure here
	@id varchar(40),
	@status nchar(5)
AS
BEGIN
	select sub.ID, sub.Name,stt.Name as NameStatus, sub.Description, sub.status from Users u
	inner join UserSubject us on us.IDUsers = u.ID
	inner join Subjects sub on us.IDSubject = sub.ID
	inner join StatusCommon stt on stt.ID = sub.Status
	where sub.ID = @id and (@status = '' or @status = sub.Status)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_getSubjectByUser]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <08/26/2020>
-- Description:	<Get subject by user>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getSubjectByUser] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	select sub.ID, sub.Name,stt.Name as NameStatus, sub.Description from Users u
	inner join UserSubject us on us.IDUsers = u.ID
	inner join Subjects sub on us.IDSubject = sub.ID
	inner join StatusCommon stt on stt.ID = sub.Status
	where u.ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_updateDepartment]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_updateFileIDLesson]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/30/2020>
-- Description:	<Update File ID>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateFileIDLesson]
	@fieldName varchar(40),
	@value varchar(40),
	@id varchar(40)
AS
BEGIN
	Declare @sql varchar(MAX) = ''
	SET @sql = 'UPDATE Lessons SET ' + @fieldName + '=''' + @value + ''' WHERE ID = ''' + @id+ ''''
	print @sql
	EXEC(@sql)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updatePermission]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_updateRoles]    Script Date: 10/01/2020 12:43:04 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_updateSubjects]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <27/09/2020>
-- Description:	<Update info subject>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateSubjects] 
	@id varchar(40),
	@name nvarchar(255),
	@description ntext,
	@stt nchar(3)
AS
BEGIN
	UPDATE Subjects SET Name = @name, Description = @description, Status = @stt WHERE @id= ID
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updateSubjectsParent]    Script Date: 10/01/2020 12:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tran Ngoc Phuoc>
-- Create date: <09/05/2020>
-- Description:	<Update Children>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateSubjectsParent] 
	@id varchar(40)
AS
BEGIN
	UPDATE Subjects set Children = 1 where ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_updateUsers]    Script Date: 10/01/2020 12:43:04 AM ******/
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
