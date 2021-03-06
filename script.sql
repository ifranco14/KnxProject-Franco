USE [master]
GO
/****** Object:  Database [KnxProject_FrancoDB]    Script Date: 12/11/2016 19:25:10 ******/
CREATE DATABASE [KnxProject_FrancoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KnxProject_FrancoDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KnxProject_FrancoDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KnxProject_FrancoDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KnxProject_FrancoDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KnxProject_FrancoDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KnxProject_FrancoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET  MULTI_USER 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KnxProject_FrancoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KnxProject_FrancoDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [KnxProject_FrancoDB]
GO
/****** Object:  Table [dbo].[About]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[Mission] [nvarchar](max) NULL,
	[Vision] [nvarchar](max) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Functions] [nvarchar](max) NULL,
	[History] [nvarchar](max) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clients]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[IDClient] [int] IDENTITY(1,1) NOT NULL,
	[IDPerson] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK__Clients__78E1C5248E9BD722] PRIMARY KEY CLUSTERED 
(
	[IDClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourtBranches]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtBranches](
	[IDCourtBranch] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CourtBranches] PRIMARY KEY CLUSTERED 
(
	[IDCourtBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourtCaseDetails]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtCaseDetails](
	[IDCourtCaseDetail] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](250) NOT NULL,
	[Date] [date] NOT NULL,
	[IDState] [int] NOT NULL,
	[IDCourtCase] [int] NOT NULL,
 CONSTRAINT [PK_CourtCaseDetails] PRIMARY KEY CLUSTERED 
(
	[IDCourtCaseDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourtCases]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourtCases](
	[IDCourtCase] [int] IDENTITY(1,1) NOT NULL,
	[IDCurrentState] [int] NULL,
	[IDCourtBranch] [int] NOT NULL,
	[IDLawyer] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[IDClient] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CourtCases] PRIMARY KEY CLUSTERED 
(
	[IDCourtCase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentTypes]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTypes](
	[IDDocumentType] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED 
(
	[IDDocumentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[IDEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Employment] [varchar](50) NOT NULL,
	[ContractDate] [date] NOT NULL,
	[IDPerson] [int] NOT NULL,
 CONSTRAINT [PK__Employee__78E1C5245ED2F324] PRIMARY KEY CLUSTERED 
(
	[IDEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lawyers]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lawyers](
	[IDLawyer] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionalLicense] [int] NOT NULL,
	[ContractDate] [date] NOT NULL,
	[IDCourtBranch] [int] NOT NULL,
	[IDPerson] [int] NOT NULL,
 CONSTRAINT [PK__Lawyers__78E1C5242B51B630] PRIMARY KEY CLUSTERED 
(
	[IDLawyer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[IDNew] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[IDCourtBranch] [int] NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Place] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[LetterHead] [nvarchar](max) NOT NULL,
	[IDScope] [int] NOT NULL,
	[ImageURL] [nvarchar](70) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[IDNew] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[IDPerson] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CellPhoneNumber] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[IDDocumentType] [int] NOT NULL,
	[DocumentNumber] [varchar](12) NOT NULL,
	[ImageName] [varchar](150) NULL,
	[PersonType] [nvarchar](50) NULL,
 CONSTRAINT [PK__People__78E1C5244DC5C979] PRIMARY KEY CLUSTERED 
(
	[IDPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QAs]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QAs](
	[IDQA] [int] IDENTITY(1,1) NOT NULL,
	[IDCourtCaseDetail] [int] NULL,
	[Query] [nvarchar](max) NOT NULL,
	[SendDate] [date] NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[AnswerDate] [date] NULL,
	[IDLawyer] [int] NOT NULL,
	[IDCourtCase] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[IDClient] [int] NULL,
	[Topic] [nvarchar](100) NULL,
 CONSTRAINT [PK_QAs] PRIMARY KEY CLUSTERED 
(
	[IDQA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scopes]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scopes](
	[IDScope] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Scopes] PRIMARY KEY CLUSTERED 
(
	[IDScope] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[IDState] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[IDState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](56) NOT NULL,
	[IDPerson] [int] NULL,
 CONSTRAINT [PK__Users__1788CCACE0D4AC89] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Users__536C85E4858F126C] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 12/11/2016 19:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
USE [master]
GO
ALTER DATABASE [KnxProject_FrancoDB] SET  READ_WRITE 
GO
