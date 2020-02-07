


/****** Object:  Database [EBookStoreDB]    Script Date: 2/7/2020 6:53:44 PM ******/
CREATE DATABASE [EBookStoreDB]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EBookStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EBookStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EBookStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EBookStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EBookStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EBookStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EBookStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EBookStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EBookStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EBookStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EBookStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EBookStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EBookStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EBookStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EBookStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EBookStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EBookStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EBookStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EBookStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EBookStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EBookStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EBookStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EBookStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EBookStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EBookStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [EBookStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EBookStoreDB] SET DB_CHAINING OFF 
GO

USE [EBookStoreDB]
GO
/****** Object:  UserDefinedTableType [dbo].[UT_EBook_BookPurchase]    Script Date: 2/7/2020 6:53:44 PM ******/
CREATE TYPE [dbo].[UT_EBook_BookPurchase] AS TABLE(
	[BookID] [int] NULL,
	[UserID] [int] NULL,
	[StatusID] [int] NULL,
	[Rating] [int] NULL,
	[Review] [nvarchar](max) NULL
)
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](250) NULL,
	[BookDescription] [nvarchar](max) NULL,
	[Price] [smallmoney] NULL,
	[Author] [nvarchar](250) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookPurchase]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookPurchase](
	[BookPurchaseID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [bigint] NULL,
	[UserID] [bigint] NULL,
	[StatusID] [bigint] NULL,
	[Rating] [smallint] NULL,
	[Review] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_BookPurchase] PRIMARY KEY CLUSTERED 
(
	[BookPurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (1, N'The Alchemist', N'The Alchemist follows the journey of an Andalusian shepherd boy named Santiago.', 249.0000, N' Paulo Coelho')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (2, N'Adventures of Sherlock Holmes', N'The Adventures of Sherlock Holmes is a collection of twelve short stories by Arthur Conan Doyle, first published on 14 October 1892.', 200.0000, N'Sir Arthur Conan Doyle')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (3, N'Alice in the Wonderland', N'Alice''s Adventures in Wonderland is an 1865 novel written by English author Charles Lutwidge Dodgson under the pseudonym Lewis Carroll', 400.0000, N'Lewis Carroll')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (4, N'All’s Well that Ends well', N'All''s Well That Ends Well is a play by William Shakespeare, published in the First Folio in 1623, where it is listed among the comedies', 400.0000, N'William Shakespeare')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (5, N'Androcles and the Lion', N'The play is Shaw''s retelling of the tale of Androcles, a slave who is saved by the requiting mercy of a lion. ', 456.0000, N'George Bernard Shaw')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (6, N'An American Tragedy', N'An American Tragedy is a novel by American writer Theodore Dreiser, published at the end of 1925.', 888.0000, N'Theodore Dreiser')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (7, N'Arthashastra', N'Arthashastra', 755.0000, N'Kautilya')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (8, N'Adventures of Tom Sawyer', N'Adventures of Tom Sawyer', 756.0000, N'Mark Twain')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [Price], [Author]) VALUES (9, N'A Bunch of Old Letters,', N'A Bunch of Old Letters,', 654.0000, N'Jawaharlal Nehru')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookPurchase] ON 

INSERT [dbo].[BookPurchase] ([BookPurchaseID], [BookID], [UserID], [StatusID], [Rating], [Review], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 1, 2, NULL, NULL, 1, CAST(N'2020-02-05T12:11:44.500' AS DateTime), 1, CAST(N'2020-02-07T18:32:45.110' AS DateTime))
INSERT [dbo].[BookPurchase] ([BookPurchaseID], [BookID], [UserID], [StatusID], [Rating], [Review], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 2, 1, 2, NULL, NULL, 1, CAST(N'2020-02-05T16:32:09.393' AS DateTime), 1, CAST(N'2020-02-07T18:32:45.110' AS DateTime))
INSERT [dbo].[BookPurchase] ([BookPurchaseID], [BookID], [UserID], [StatusID], [Rating], [Review], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 9, 1, 2, NULL, NULL, 1, CAST(N'2020-02-05T16:33:10.697' AS DateTime), 1, CAST(N'2020-02-05T16:48:14.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[BookPurchase] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusID], [Description], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Add To Cart', 1, 0, NULL, NULL, NULL)
INSERT [dbo].[Status] ([StatusID], [Description], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'My Order', 1, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [IsActive]) VALUES (1, N'Vijith', N'Vijith20', 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [IsActive]) VALUES (2, N'user1', N'user20', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  StoredProcedure [dbo].[Usp_EBook_GetBookDetails]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		VIJITH
-- Create date: 2/3/2020
-- Description:List of all book details
-- =============================================
CREATE PROCEDURE [dbo].[Usp_EBook_GetBookDetails]

AS
BEGIN
	
   SET NOCOUNT ON;

   SELECT [BookID]
      ,[BookName]
      ,[BookDescription]
      ,[Price]
      ,[Author]
  FROM [dbo].[Book]
  

END

GO
/****** Object:  StoredProcedure [dbo].[Usp_EBook_GetMyOrders]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		VIJITH
-- Create date: 02/03/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Usp_EBook_GetMyOrders] 
	@UserID bigint
	,@StatusID bigint
	
AS
BEGIN
	
	SET NOCOUNT ON;
	
   SELECT 
       BK.[BookID]
      ,BK.[BookName]
      ,BK.[BookDescription]
      ,BK.[Price]
      ,BK.[Author]
	  ,BKP.[Rating]
	  ,BKP.[Review]	  
  FROM [dbo].[BookPurchase] BKP
  INNER JOIN [dbo].[Book] BK
  ON BKP.BookID=BK.BookID
  WHERE BKP.UserID=@UserID
  AND BKP.StatusID=@StatusID




   
END

GO
/****** Object:  StoredProcedure [dbo].[Usp_EBook_InsertBookPurchase]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		VIJITH
-- Create date: 3/2/2020
-- Description:	Save Book Purchase details
-- =============================================
CREATE PROCEDURE [dbo].[Usp_EBook_InsertBookPurchase]
  @BookPurchase_Dt [dbo].[UT_EBook_BookPurchase] readonly
AS
BEGIN

	SET NOCOUNT ON;


MERGE [dbo].[BookPurchase] T
USING @BookPurchase_Dt S
ON (S.[BookID] = T.[BookID] AND S.[UserID] = T.[UserID] )
WHEN MATCHED 
     THEN UPDATE
     SET    T.[StatusID] = S.[StatusID],
            T.[Rating] = S.[Rating],
            T.[Review] = S.[Review],
			T.[ModifiedBy]=S.[UserID],
			T.[ModifiedDate]=GETDATE()
WHEN NOT MATCHED BY TARGET
THEN INSERT ([BookID], [UserID], [StatusID], [Rating],[Review],[CreatedBy],[CreatedDate])
     VALUES (S.[BookID], S.[UserID], S.[StatusID], S.[Rating],S.[Review],S.[UserID],GETDATE());


END

GO
/****** Object:  StoredProcedure [dbo].[Usp_EBook_ValidateLogin]    Script Date: 2/7/2020 6:53:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vijith
-- Create date: 2.6.2020
-- Description:	validate login
-- =============================================
CREATE PROCEDURE  [dbo].[Usp_EBook_ValidateLogin] 


AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [UserID]
      ,[UserName]
      ,[Password]
      ,[IsActive]
    FROM [dbo].[User]
	

   
END

GO
USE [master]
GO
ALTER DATABASE [EBookStoreDB] SET  READ_WRITE 
GO
