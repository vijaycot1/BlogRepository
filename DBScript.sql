/****** Object:  Database [BlogDB]    Script Date: 19/02/2021 12:07:26 AM ******/
CREATE DATABASE [BlogDB]  (EDITION = 'Standard', SERVICE_OBJECTIVE = 'S1', MAXSIZE = 1 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [BlogDB] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [BlogDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [BlogDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlogDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlogDB] SET ENCRYPTION ON
GO
ALTER DATABASE [BlogDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BlogDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[category]    Script Date: 19/02/2021 12:07:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](100) NULL,
	[metaTitle] [varchar](100) NULL,
	[slug] [varchar](250) NOT NULL,
	[content] [text] NULL,
	[active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 19/02/2021 12:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[authorId] [bigint] NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](75) NOT NULL,
	[metaTitle] [varchar](100) NULL,
	[slug] [varchar](100) NOT NULL,
	[summary] [varchar](250) NULL,
	[published] [bit] NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedDate] [datetime] NULL,
	[publishedDate] [datetime] NULL,
	[content] [text] NULL,
	[active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_category]    Script Date: 19/02/2021 12:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_category](
	[postId] [bigint] NOT NULL,
	[categoryId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[postId] ASC,
	[categoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_comment]    Script Date: 19/02/2021 12:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_comment](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postId] [bigint] NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](100) NOT NULL,
	[published] [bit] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[publishedAt] [datetime] NULL,
	[content] [text] NULL,
	[active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_meta]    Script Date: 19/02/2021 12:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_meta](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postId] [bigint] NOT NULL,
	[key] [varchar](50) NOT NULL,
	[content] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19/02/2021 12:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[firstName] [varchar](50) NULL,
	[middleName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[mobile] [varchar](15) NULL,
	[email] [varchar](50) NULL,
	[passwordHash] [varchar](250) NULL,
	[createdDate] [datetime] NOT NULL,
	[createdBy] [varchar](20) NOT NULL,
	[isActive] [bit] NOT NULL,
	[lastLogin] [datetime] NULL,
	[salt] [varchar](250) NOT NULL,
 CONSTRAINT [PK_TempSales] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[category] ADD  DEFAULT (NULL) FOR [parentId]
GO
ALTER TABLE [dbo].[category] ADD  DEFAULT (NULL) FOR [metaTitle]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (NULL) FOR [parentId]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (NULL) FOR [metaTitle]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT ('0') FOR [published]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (NULL) FOR [modifiedDate]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (NULL) FOR [publishedDate]
GO
ALTER TABLE [dbo].[post_comment] ADD  DEFAULT (NULL) FOR [parentId]
GO
ALTER TABLE [dbo].[post_comment] ADD  DEFAULT ('0') FOR [published]
GO
ALTER TABLE [dbo].[post_comment] ADD  DEFAULT (NULL) FOR [publishedAt]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [firstName]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [middleName]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [lastName]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [mobile]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (NULL) FOR [lastLogin]
GO
ALTER TABLE [dbo].[category]  WITH CHECK ADD  CONSTRAINT [fk_category_parent] FOREIGN KEY([parentId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[category] CHECK CONSTRAINT [fk_category_parent]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [fk_post_parent] FOREIGN KEY([parentId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [fk_post_parent]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [fk_post_user] FOREIGN KEY([authorId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [fk_post_user]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [fk_pc_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [fk_pc_category]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [fk_pc_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [fk_pc_post]
GO
ALTER TABLE [dbo].[post_comment]  WITH CHECK ADD  CONSTRAINT [fk_comment_parent] FOREIGN KEY([parentId])
REFERENCES [dbo].[post_comment] ([id])
GO
ALTER TABLE [dbo].[post_comment] CHECK CONSTRAINT [fk_comment_parent]
GO
ALTER TABLE [dbo].[post_comment]  WITH CHECK ADD  CONSTRAINT [fk_comment_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_comment] CHECK CONSTRAINT [fk_comment_post]
GO
ALTER TABLE [dbo].[post_meta]  WITH CHECK ADD  CONSTRAINT [fk_meta_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_meta] CHECK CONSTRAINT [fk_meta_post]
GO
ALTER DATABASE [BlogDB] SET  READ_WRITE 
GO
