USE [Gehirnjogging]
GO
/****** Object:  Table [dbo].[Charakters]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charakters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[HP] [nvarchar](max) NOT NULL,
	[Damage] [nvarchar](max) NOT NULL,
	[Luck] [nvarchar](max) NOT NULL,
	[Stage] [nvarchar](max) NOT NULL,
	[SolveTime] [nvarchar](max) NOT NULL,
	[Assets] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Charakters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enemies]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enemies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Damage] [nvarchar](max) NOT NULL,
	[HP] [nvarchar](max) NOT NULL,
	[XP] [nvarchar](max) NOT NULL,
	[Coins] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Enemies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventars]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[CharakterID] [int] NOT NULL,
 CONSTRAINT [PK_Inventars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TypeID] [int] NOT NULL,
	[Price] [nvarchar](max) NOT NULL,
	[SellingPrice] [nvarchar](max) NOT NULL,
	[minStage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Levelinfos]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levelinfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LevelID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[EnemyID] [int] NOT NULL,
 CONSTRAINT [PK_Levelinfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Levels]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ThreeStartime] [nvarchar](max) NOT NULL,
	[TwoStartime] [nvarchar](max) NOT NULL,
	[OneStartime] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Levels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassedLevels]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassedLevels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SavegameID] [int] NOT NULL,
	[Time] [nvarchar](max) NOT NULL,
	[LevelID] [int] NOT NULL,
 CONSTRAINT [PK_PassedLevels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Questions] [nvarchar](max) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Savegames]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Savegames](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CharakterID] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Savegames] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 08.05.2019 08:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventars]  WITH CHECK ADD  CONSTRAINT [FK_InventarCharakter] FOREIGN KEY([CharakterID])
REFERENCES [dbo].[Charakters] ([ID])
GO
ALTER TABLE [dbo].[Inventars] CHECK CONSTRAINT [FK_InventarCharakter]
GO
ALTER TABLE [dbo].[Inventars]  WITH CHECK ADD  CONSTRAINT [FK_InventarItem] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[Inventars] CHECK CONSTRAINT [FK_InventarItem]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_TypeItem] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Types] ([ID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_TypeItem]
GO
ALTER TABLE [dbo].[Levelinfos]  WITH CHECK ADD  CONSTRAINT [FK_EnemyLevelinfos] FOREIGN KEY([EnemyID])
REFERENCES [dbo].[Enemies] ([ID])
GO
ALTER TABLE [dbo].[Levelinfos] CHECK CONSTRAINT [FK_EnemyLevelinfos]
GO
ALTER TABLE [dbo].[Levelinfos]  WITH CHECK ADD  CONSTRAINT [FK_LevelinfosQuestion] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Levelinfos] CHECK CONSTRAINT [FK_LevelinfosQuestion]
GO
ALTER TABLE [dbo].[Levelinfos]  WITH CHECK ADD  CONSTRAINT [FK_LevelLevelinfos] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Levels] ([ID])
GO
ALTER TABLE [dbo].[Levelinfos] CHECK CONSTRAINT [FK_LevelLevelinfos]
GO
ALTER TABLE [dbo].[PassedLevels]  WITH CHECK ADD  CONSTRAINT [FK_FinishedLevelSavegame] FOREIGN KEY([SavegameID])
REFERENCES [dbo].[Savegames] ([ID])
GO
ALTER TABLE [dbo].[PassedLevels] CHECK CONSTRAINT [FK_FinishedLevelSavegame]
GO
ALTER TABLE [dbo].[PassedLevels]  WITH CHECK ADD  CONSTRAINT [FK_PassedLevelLevel] FOREIGN KEY([LevelID])
REFERENCES [dbo].[Levels] ([ID])
GO
ALTER TABLE [dbo].[PassedLevels] CHECK CONSTRAINT [FK_PassedLevelLevel]
GO
ALTER TABLE [dbo].[Savegames]  WITH CHECK ADD  CONSTRAINT [FK_SavegameCharakter] FOREIGN KEY([CharakterID])
REFERENCES [dbo].[Charakters] ([ID])
GO
ALTER TABLE [dbo].[Savegames] CHECK CONSTRAINT [FK_SavegameCharakter]
GO
