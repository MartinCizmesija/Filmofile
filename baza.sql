USE [master]
GO
/****** Object:  Database [MovieDB]    Script Date: 6/8/2020 5:55:35 AM ******/
CREATE DATABASE [MovieDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MovieDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieDB] SET  MULTI_USER 
GO
ALTER DATABASE [MovieDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieDB', N'ON'
GO
ALTER DATABASE [MovieDB] SET QUERY_STORE = OFF
GO
USE [MovieDB]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[Text] [text] NOT NULL,
 CONSTRAINT [PK__comment__E7957687C333C39F] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__country__7E8CD0550B808008] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country_movie](
	[CountryId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[favourite]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favourite](
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__genre__18428D42132BE3EC] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre_movie](
	[GenreId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[keyword]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[keyword](
	[KeywordId] [int] IDENTITY(1,1) NOT NULL,
	[KeywordName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__keyword__03E8D7CF1F076047] PRIMARY KEY CLUSTERED 
(
	[KeywordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[keyword_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[keyword_movie](
	[KeywordId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KeywordId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[language]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[languageName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__language__804CF6B3505EAF02] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[language_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[language_movie](
	[LanguageId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [varchar](255) NOT NULL,
	[CriticsRating] [float] NULL,
	[NumberOfCritics] [int] NOT NULL,
	[UserRating] [float] NULL,
	[NumberOfUsers] [int] NOT NULL,
	[ReleaseDate] [date] NULL,
	[Budget] [int] NULL,
	[Revenue] [int] NULL,
 CONSTRAINT [PK__movie__83CDF749CFF48BA9] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[multimedia]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[multimedia](
	[MultimediaId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[MultimediaLink] [text] NOT NULL,
 CONSTRAINT [PK__multimed__C5029F690551F4CC] PRIMARY KEY CLUSTERED 
(
	[MultimediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nomination]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nomination](
	[NominationId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[NominationName] [varchar](255) NOT NULL,
	[NominationCategory] [varchar](255) NULL,
	[NominationYear] [int] NOT NULL,
	[DidItWin] [bit] NULL,
 CONSTRAINT [PK__nominati__83A9379C41855C45] PRIMARY KEY CLUSTERED 
(
	[NominationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[person]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[person](
	[personId] [int] IDENTITY(1,1) NOT NULL,
	[personName] [varchar](255) NOT NULL,
	[personSurname] [varchar](255) NULL,
	[birth] [date] NULL,
	[biography] [text] NULL,
 CONSTRAINT [PK__person__543848DFAD830067] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[characterName] [varchar](255) NOT NULL,
	[characterSurname] [varchar](255) NULL,
	[personId] [int] NULL,
	[roleDescription] [text] NULL,
 CONSTRAINT [PK__role__760965CCF7696AFD] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_movie](
	[RoleId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[similar]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[similar](
	[RootMovie] [int] NOT NULL,
	[RefrencedMovie] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RootMovie] ASC,
	[RefrencedMovie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[technician]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[technician](
	[technicianId] [int] IDENTITY(1,1) NOT NULL,
	[jobBehindSet] [varchar](255) NULL,
	[personId] [int] NOT NULL,
 CONSTRAINT [PK__technici__BA765DE0D24DACAE] PRIMARY KEY CLUSTERED 
(
	[technicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[technician_movie]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[technician_movie](
	[MovieId] [int] NOT NULL,
	[technicianId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[technicianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[mail] [varchar](255) NOT NULL,
	[user_role] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__user__B9BE370FC089C08C] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_rating]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_rating](
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[UserRating] [int] NOT NULL,
 CONSTRAINT [PK__user_rat__3182E87B084B8B45] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[watchlist]    Script Date: 6/8/2020 5:55:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[watchlist](
	[UserId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_user_username]    Script Date: 6/8/2020 5:55:35 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_user_username] ON [dbo].[user]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK__comment__movie_i__70DDC3D8] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK__comment__movie_i__70DDC3D8]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK__comment__user_id__71D1E811] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([userId])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK__comment__user_id__71D1E811]
GO
ALTER TABLE [dbo].[country_movie]  WITH CHECK ADD  CONSTRAINT [FK__county_mo__count__6383C8BA] FOREIGN KEY([CountryId])
REFERENCES [dbo].[country] ([CountryId])
GO
ALTER TABLE [dbo].[country_movie] CHECK CONSTRAINT [FK__county_mo__count__6383C8BA]
GO
ALTER TABLE [dbo].[country_movie]  WITH CHECK ADD  CONSTRAINT [FK__county_mo__movie__6477ECF3] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[country_movie] CHECK CONSTRAINT [FK__county_mo__movie__6477ECF3]
GO
ALTER TABLE [dbo].[favourite]  WITH CHECK ADD  CONSTRAINT [FK__favourite__movie__778AC167] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[favourite] CHECK CONSTRAINT [FK__favourite__movie__778AC167]
GO
ALTER TABLE [dbo].[favourite]  WITH CHECK ADD  CONSTRAINT [FK__favourite__user___72C60C4A] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([userId])
GO
ALTER TABLE [dbo].[favourite] CHECK CONSTRAINT [FK__favourite__user___72C60C4A]
GO
ALTER TABLE [dbo].[genre_movie]  WITH CHECK ADD  CONSTRAINT [FK__genre_mov__genre__6754599E] FOREIGN KEY([GenreId])
REFERENCES [dbo].[genre] ([GenreId])
GO
ALTER TABLE [dbo].[genre_movie] CHECK CONSTRAINT [FK__genre_mov__genre__6754599E]
GO
ALTER TABLE [dbo].[genre_movie]  WITH CHECK ADD  CONSTRAINT [FK__genre_mov__movie__68487DD7] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[genre_movie] CHECK CONSTRAINT [FK__genre_mov__movie__68487DD7]
GO
ALTER TABLE [dbo].[keyword_movie]  WITH CHECK ADD  CONSTRAINT [FK__keyword_m__keywo__619B8048] FOREIGN KEY([KeywordId])
REFERENCES [dbo].[keyword] ([KeywordId])
GO
ALTER TABLE [dbo].[keyword_movie] CHECK CONSTRAINT [FK__keyword_m__keywo__619B8048]
GO
ALTER TABLE [dbo].[keyword_movie]  WITH CHECK ADD  CONSTRAINT [FK__keyword_m__movie__628FA481] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[keyword_movie] CHECK CONSTRAINT [FK__keyword_m__movie__628FA481]
GO
ALTER TABLE [dbo].[language_movie]  WITH CHECK ADD  CONSTRAINT [FK__language___langu__656C112C] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[language] ([LanguageId])
GO
ALTER TABLE [dbo].[language_movie] CHECK CONSTRAINT [FK__language___langu__656C112C]
GO
ALTER TABLE [dbo].[language_movie]  WITH CHECK ADD  CONSTRAINT [FK__language___movie__66603565] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[language_movie] CHECK CONSTRAINT [FK__language___movie__66603565]
GO
ALTER TABLE [dbo].[multimedia]  WITH CHECK ADD  CONSTRAINT [FK__multimedi__movie__6E01572D] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[multimedia] CHECK CONSTRAINT [FK__multimedi__movie__6E01572D]
GO
ALTER TABLE [dbo].[nomination]  WITH CHECK ADD  CONSTRAINT [FK__nominatio__movie__6EF57B66] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[nomination] CHECK CONSTRAINT [FK__nominatio__movie__6EF57B66]
GO
ALTER TABLE [dbo].[role]  WITH CHECK ADD  CONSTRAINT [FK__role__person_id__151B244E] FOREIGN KEY([personId])
REFERENCES [dbo].[person] ([personId])
GO
ALTER TABLE [dbo].[role] CHECK CONSTRAINT [FK__role__person_id__151B244E]
GO
ALTER TABLE [dbo].[role_movie]  WITH CHECK ADD  CONSTRAINT [FK__role_movi__movie__693CA210] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[role_movie] CHECK CONSTRAINT [FK__role_movi__movie__693CA210]
GO
ALTER TABLE [dbo].[role_movie]  WITH CHECK ADD  CONSTRAINT [FK__role_movi__role___6A30C649] FOREIGN KEY([RoleId])
REFERENCES [dbo].[role] ([RoleId])
GO
ALTER TABLE [dbo].[role_movie] CHECK CONSTRAINT [FK__role_movi__role___6A30C649]
GO
ALTER TABLE [dbo].[similar]  WITH CHECK ADD  CONSTRAINT [FK__similar__refrenc__25518C17] FOREIGN KEY([RefrencedMovie])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[similar] CHECK CONSTRAINT [FK__similar__refrenc__25518C17]
GO
ALTER TABLE [dbo].[similar]  WITH CHECK ADD  CONSTRAINT [FK__similar__root_mo__1AD3FDA4] FOREIGN KEY([RootMovie])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[similar] CHECK CONSTRAINT [FK__similar__root_mo__1AD3FDA4]
GO
ALTER TABLE [dbo].[technician]  WITH CHECK ADD  CONSTRAINT [FK__technicia__perso__2645B050] FOREIGN KEY([personId])
REFERENCES [dbo].[person] ([personId])
GO
ALTER TABLE [dbo].[technician] CHECK CONSTRAINT [FK__technicia__perso__2645B050]
GO
ALTER TABLE [dbo].[technician_movie]  WITH CHECK ADD  CONSTRAINT [FK__technicia__movie__6C190EBB] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[technician_movie] CHECK CONSTRAINT [FK__technicia__movie__6C190EBB]
GO
ALTER TABLE [dbo].[technician_movie]  WITH CHECK ADD  CONSTRAINT [FK__technicia__techn__6B24EA82] FOREIGN KEY([technicianId])
REFERENCES [dbo].[technician] ([technicianId])
GO
ALTER TABLE [dbo].[technician_movie] CHECK CONSTRAINT [FK__technicia__techn__6B24EA82]
GO
ALTER TABLE [dbo].[user_rating]  WITH CHECK ADD  CONSTRAINT [FK__user_rati__movie__6FE99F9F] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[user_rating] CHECK CONSTRAINT [FK__user_rati__movie__6FE99F9F]
GO
ALTER TABLE [dbo].[user_rating]  WITH CHECK ADD  CONSTRAINT [FK__user_rati__user___6D0D32F4] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([userId])
GO
ALTER TABLE [dbo].[user_rating] CHECK CONSTRAINT [FK__user_rati__user___6D0D32F4]
GO
ALTER TABLE [dbo].[watchlist]  WITH CHECK ADD  CONSTRAINT [FK__watchlist__movie__03F0984C] FOREIGN KEY([MovieId])
REFERENCES [dbo].[movie] ([MovieId])
GO
ALTER TABLE [dbo].[watchlist] CHECK CONSTRAINT [FK__watchlist__movie__03F0984C]
GO
ALTER TABLE [dbo].[watchlist]  WITH CHECK ADD  CONSTRAINT [FK__watchlist__user___05D8E0BE] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([userId])
GO
ALTER TABLE [dbo].[watchlist] CHECK CONSTRAINT [FK__watchlist__user___05D8E0BE]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [CK__user__user_role__24927208] CHECK  (([user_role]='admin' OR [user_role]='critic' OR [user_role]='user'))
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [CK__user__user_role__24927208]
GO
USE [master]
GO
ALTER DATABASE [MovieDB] SET  READ_WRITE 
GO
