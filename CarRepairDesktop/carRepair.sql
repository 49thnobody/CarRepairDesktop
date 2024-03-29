USE [master]
GO
/****** Object:  Database [CarRepair]    Script Date: 08.03.2022 22:21:07 ******/
CREATE DATABASE [CarRepair]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRepair', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRepair.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRepair_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRepair_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRepair] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRepair].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRepair] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRepair] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRepair] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRepair] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRepair] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRepair] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRepair] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRepair] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRepair] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRepair] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRepair] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRepair] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRepair] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRepair] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRepair] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRepair] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRepair] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRepair] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRepair] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRepair] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRepair] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRepair] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRepair] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRepair] SET  MULTI_USER 
GO
ALTER DATABASE [CarRepair] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRepair] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRepair] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRepair] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRepair] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRepair] SET QUERY_STORE = OFF
GO
USE [CarRepair]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarNumber] [nvarchar](12) NOT NULL,
	[CarModelID] [nvarchar](20) NOT NULL,
	[OwnerID] [nchar](10) NOT NULL,
	[Power] [int] NULL,
	[ManufactureYear] [int] NULL,
	[Color] [nvarchar](50) NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarModel]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModel](
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_CarModel] PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[DriversLicense] [nchar](10) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nchar](11) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[DriversLicense] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone] [nchar](11) NOT NULL,
	[Rank] [int] NOT NULL,
	[WorkshopID] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CarID] [nvarchar](12) NOT NULL,
	[StartDate] [date] NOT NULL,
	[PlannedEndDate] [date] NOT NULL,
	[RealEndDate] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Title] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesInOrder]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesInOrder](
	[OrderID] [int] NOT NULL,
	[ServiceID] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_ServicesInOrder_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshop]    Script Date: 08.03.2022 22:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone] [nchar](6) NOT NULL,
 CONSTRAINT [PK_Workshop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'А022УВ', N'Volkswagen', N'4363499148', 240, 1940, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'А125ЕЕ', N'Москвич', N'4338569345', 76, 1934, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'В750УО', N'Ssangyong', N'4954966091', 153, 2018, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'Е780ВН', N'Jeep', N'4270522981', 309, 2014, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'М193NK', N'Rover', N'4940206357', 228, 2014, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'М961СО', N'ГАЗ', N'4782849599', 85, 1920, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'О496ТМ', N'Opel', N'4954966091', 140, 2010, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'О536ХА', N'Subaru', N'4442753145', 198, 2018, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'Т205СО', N'Porshe', N'4342166887', 650, 2017, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'Т780УС', N'Tesla', N'4226195679', 518, 2021, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'У728МА', N'Mercedes', N'4342166887', 224, 2018, NULL)
INSERT [dbo].[Car] ([CarNumber], [CarModelID], [OwnerID], [Power], [ManufactureYear], [Color]) VALUES (N'Х973НЕ', N'Nissan', N'4731723161', 420, 2000, NULL)
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Acura')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Alfa Romeo')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Aston Martin')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Audi')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Bentley')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'BMV')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Brilliance')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Bugatti')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Buick')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'BYD')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Cadillac')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Changan')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Chery')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Chevrolet')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Chrysler')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Citroen')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Dacia')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Daewoo')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Daihatsu')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Datsun')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Dodge')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Exceed')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'FAW')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Ferrari')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Fiat')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Ford')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'GAC')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Geely')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Genesis')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'GMC')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Great Wall')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Haval')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Honda')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Hyundai')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Infiniti')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Jaguar')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Jeep')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Kia')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lamborgini')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lancia')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Land Rower')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lexus')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lifan')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lincoln')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Lotus')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'MacClaren')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Marussia')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Maserati')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Maybach')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Mazda')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Mercedes')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Mini')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Mitsubishi')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Nissan')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Opel')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Peugeot')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Pontiav')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Porshe')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Renault')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Rolls-Royce')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Rover')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Saab')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Seat')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Skoda')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Smart')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Ssangyong')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Subaru')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Suzuki')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Tagal')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Tesla')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Toyota')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Volkswagen')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Volvo')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'ВАЗ')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'ГАЗ')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'ЗАЗ')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Москвич')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'Мотоцикл')
INSERT [dbo].[CarModel] ([Title]) VALUES (N'УАЗ')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4226195679', N'Соловьев Олег Иванович', N'Россия, г. Череповец, Партизанская ул., д. 13 кв.87', N'89769851438')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4270522981', N'Шестаков Герман Даниилович', N'Россия, г. Сергиев Посад, Гагарина ул., д. 19 кв.167', N'89005004545')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4338569345', N'Макеев Александр Викторович', N'Россия, г. Сергиев Посад, Якуба Коласа ул., д. 1 кв.28', N'89734567812')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4342166887', N'Суворов Александр Тигранович', N'Россия, г. Великий Новгород, Якуба Коласа ул., д. 24 кв.158', N'89514932435')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4363499148', N'Иванов Артём Павлович', N'Россия, г. Калининград, Садовый пер., д. 14 кв.15', N'89654732211')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4442753145', N'Волков Михаил Игоревич', NULL, N'89045678323')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4731723161', N'Андреев Ярослав Кириллович', N'Россия, г. Хасавюрт, Весенняя ул., д. 5 кв.114', N'89641123456')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4782849599', N'Никитин Мирослав Кириллович', N'Россия, г. Тула, Заслонова ул., д. 14 кв.184', N'89743678911')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4940206357', N'Мещеряков Марк Даниилович', NULL, N'89144567123')
INSERT [dbo].[Client] ([DriversLicense], [FullName], [Address], [Phone]) VALUES (N'4954966091', N'Кудрявцев Иван Ярославович', N'Россия, г. Краснодар, Дорожная ул., д. 8 кв.145', N'89543902415')
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (1, N'Макаров Максим Константинович', N'г. Рязань, Полесская ул., д. 1 кв.3', N'89067893456', 3, 1)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (2, N'Орлов Георгий Алиевич', N'г. Рязань, Октябрьский пер., д. 14 кв.89', N'89064562083', 4, 1)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (4, N'Плотников Вячеслав Тимофеевич', N'г. Рязань, Заречный пер., д. 24 кв.206', N'89345672775', 5, 1)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (5, N'Лукьянов Егор Максимович', N'г. Рязань, Центральная ул., д. 7 кв.137', N'89365322834', 6, 1)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (6, N'Шмелев Владимир Максимович', N'г. Рязань, Цветочная ул., д. 20 кв.62', N'89714513765', 2, 2)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (7, N'Громов Стефан Платонович', N'г. Рязань, Центральный пер., д. 1 кв.211', N'89385147640', 3, 2)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (9, N'Бирюков Роман Артёмович', N'г. Рязань, Хуторская ул., д. 7 кв.211', N'89483141804', 6, 2)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (11, N'Журавлев Тимофей Платонович', N'г. Рязань, Максима Горького ул., д. 25 кв.100', N'89931652956', 1, 5)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (13, N'Агапов Глеб Гордеевич', N'г. Рязань, Мичурина ул., д. 13 кв.180', N'89354136729', 4, 5)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (14, N'Мартынов Лев Владимирович', N'г. Рязань, Калинина ул., д. 2 кв.10', N'89153459873', 7, 5)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (15, N'Тарасов Артём Леонович', N'г. Рязань, ЯнкиКупалы ул., д. 14 кв.47', N'89164086327', 3, 7)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (16, N'Коновалов Владислав Артёмович', N'г. Рязань, Чкалова ул., д. 17 кв.114', N'89012636723', 4, 7)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (17, N'Демьянов Захар Александрович', N'г. Рязань, 3 Марта ул., д. 3 кв.48', N'89213746378', 4, 7)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (19, N'Горбунов Никита Денисович', N'г. Рязань, Полевая ул., д. 7 кв.43', N'89415823981', 6, 8)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (21, N'Фетисов Назар Степанович', N'г. Рязань, Южная ул., д. 25 кв.204', N'89574321015', 5, 8)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (22, N'Федоров Андрей Игоревич', N'г. Рязань, Лесной пер., д. 22 кв.81', N'89703621681', 3, 8)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (24, N'Марков Серафим Павлович', N'г. Казань, Дружбы ул., д. 6 кв.28', N'89725462341', 2, 9)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (25, N'Исаев Руслан Александрович', N'г. Казань, Дружбы ул., д. 23 кв.142', N'89345568790', 5, 9)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (26, N'Жуков Алексей Степанович', N'г. Набережные Челны, Песчаная ул., д. 11 кв.48', N'89356708730', 2, 10)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (27, N'Кузнецов Тимофей Дмитриевич', N'г. Набережные Челны, Луговой пер., д. 8 кв.91', N'89068460808', 5, 10)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (28, N'Беспалов Леон Иванович', N'г. Набережные Челны, Садовый пер., д. 22 кв.29', N'89045611453', 3, 10)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (29, N'Белоусов Андрей Михайлович', N'г. Казань, Новоселов ул., д. 22 кв.147', N'89396743561', 4, 12)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (30, N'Колпаков Иван Максимович', N'г. Казань, Советская ул., д. 9 кв.99', N'89462971234', 5, 12)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (31, N'Орлов Максим Ярославович', N'г. Казань, Цветочная ул., д. 2 кв.13', N'89145132727', 2, 13)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (32, N'Филиппов Иван Данилович', N'г. Казань, Дружная ул., д. 2 кв.134', N'89012752465', 3, 13)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (33, N'Одинцов Максим Арсентьевич', N'г. Казань, Интернациональная ул., д. 7 кв.76', N'89058143563', 4, 13)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (35, N'Столяров Артемий Александрович', N'г. Санкт-Петербург, Солнечная ул., д. 24 кв.160', N'89065812928', 5, 14)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (36, N'Кузьмин Александр Миронович', N'г. Санкт-Петербург, Заречная ул., д. 6 кв.147', N'89632513902', 4, 14)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (37, N'Козловский Антон Константинович', N'г. Санкт-Петербург, Луговая ул., д. 8 кв.31', N'89042346597', 6, 15)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (39, N'Жуков Тимофей Михайлович', N'г. Санкт-Петербург, Садовый пер., д. 24 кв.106', N'89622953780', 5, 15)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (40, N'Павлов Дмитрий Ильич', N'г. Санкт-Петербург, Партизанская ул., д. 9 кв.65', N'89638935454', 5, 16)
INSERT [dbo].[Employee] ([ID], [FullName], [Address], [Phone], [Rank], [WorkshopID]) VALUES (41, N'Суханов Михаил Константинович', N'г. Санкт-Петербург, Первомайская ул., д. 10 кв.136', N'89725830909', 5, 16)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (1, 2, N'А022УВ', CAST(N'2022-03-02' AS Date), CAST(N'2022-03-05' AS Date), CAST(N'2022-03-06' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (2, 2, N'А125ЕЕ', CAST(N'2022-02-17' AS Date), CAST(N'2022-02-24' AS Date), CAST(N'2022-02-21' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (3, 1, N'М961СО', CAST(N'2022-01-23' AS Date), CAST(N'2022-02-01' AS Date), CAST(N'2022-01-30' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (4, 25, N'Т780УС', CAST(N'2022-02-15' AS Date), CAST(N'2022-02-16' AS Date), CAST(N'2022-02-16' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (5, 40, N'О536ХА', CAST(N'2022-02-07' AS Date), CAST(N'2022-02-09' AS Date), CAST(N'2022-02-08' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (6, 14, N'М193NK', CAST(N'2022-03-02' AS Date), CAST(N'2022-03-03' AS Date), CAST(N'2022-03-03' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (7, 14, N'М193NK', CAST(N'2021-12-15' AS Date), CAST(N'2022-12-17' AS Date), CAST(N'2022-12-17' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (8, 13, N'О496ТМ', CAST(N'2021-06-09' AS Date), CAST(N'2021-06-14' AS Date), CAST(N'2021-06-16' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (9, 13, N'О496ТМ', CAST(N'2021-11-02' AS Date), CAST(N'2021-11-09' AS Date), CAST(N'2021-11-10' AS Date))
INSERT [dbo].[Order] ([ID], [EmployeeID], [CarID], [StartDate], [PlannedEndDate], [RealEndDate]) VALUES (10, 11, N'О496ТМ', CAST(N'2022-01-03' AS Date), CAST(N'2022-01-04' AS Date), CAST(N'2022-01-04' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[Service] ([Title]) VALUES (N'Внешний тюнинг')
INSERT [dbo].[Service] ([Title]) VALUES (N'Внутренний тюнинг')
INSERT [dbo].[Service] ([Title]) VALUES (N'Кузовной ремонт')
INSERT [dbo].[Service] ([Title]) VALUES (N'Обслуживание и ремонт двигателей')
INSERT [dbo].[Service] ([Title]) VALUES (N'Обслуживание и ремонт кондиционеров в авто')
INSERT [dbo].[Service] ([Title]) VALUES (N'Подготовка и продажа новых и б/у автомобилей')
INSERT [dbo].[Service] ([Title]) VALUES (N'Регламентное ПО')
INSERT [dbo].[Service] ([Title]) VALUES (N'Ремонт автоматических и механических коробок передач')
INSERT [dbo].[Service] ([Title]) VALUES (N'Ремонт ходовой части, балансировка, развал-схождения')
INSERT [dbo].[Service] ([Title]) VALUES (N'Ремонт электрики в машинах')
INSERT [dbo].[Service] ([Title]) VALUES (N'Реставрация авто и запчастей')
INSERT [dbo].[Service] ([Title]) VALUES (N'Установка акустических систем/мультимедийных устройств')
INSERT [dbo].[Service] ([Title]) VALUES (N'Установка и обслуживание газового оборудования в автомобилях')
INSERT [dbo].[Service] ([Title]) VALUES (N'Установка сигнализации/навигации')
INSERT [dbo].[Service] ([Title]) VALUES (N'Шиномантажные работы')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (1, N'Внешний тюнинг')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (1, N'Кузовной ремонт')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (2, N'Обслуживание и ремонт двигателей')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (2, N'Обслуживание и ремонт кондиционеров в авто')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (2, N'Ремонт автоматических и механических коробок передач')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (3, N'Подготовка и продажа новых и б/у автомобилей')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (3, N'Регламентное ПО')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (4, N'Установка сигнализации/навигации')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (4, N'Шиномантажные работы')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (5, N'Ремонт ходовой части, балансировка, развал-схождения')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (6, N'Ремонт электрики в машинах')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (7, N'Внешний тюнинг')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (7, N'Внутренний тюнинг')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (8, N'Кузовной ремонт')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (8, N'Ремонт ходовой части, балансировка, развал-схождения')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (8, N'Ремонт электрики в машинах')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (9, N'Обслуживание и ремонт двигателей')
INSERT [dbo].[ServicesInOrder] ([OrderID], [ServiceID]) VALUES (10, N'Реставрация авто и запчастей')
SET IDENTITY_INSERT [dbo].[Workshop] ON 

INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (1, N'Кузовное Ателье', N'г Рязань, ш Куйбышевское, д 41А', N'234562')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (2, N'Автотехцентр AvtoGrad', N'г Рязань, проезд Яблочкова, д 8В', N'345216')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (5, N'Автосервис Макс-Авто', N'г Рязань, п Шпалозавода, д 14', N'897345')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (7, N'Автокомфорт', N'г Рязань, ул Дзержинского, д 18А', N'786903')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (8, N'Green Service', N'г Рязань, ул Горького, д 1Б стр 1', N'768904')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (9, N'БОШ Сервис Блюзмобиль', N'г Казань, ул Космонавтов, д 67А', N'456789')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (10, N'Компания Сервис Common Rail', N'г Набережные Челны, ул Металлургическая, д 27/4', N'452367')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (12, N'Автосервис Кат Сервис', N'г Казань, ул Патриса Лумумбы, д 61', N'890453')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (13, N'Автосервис ХанСервис', N'г Казань, ул Клубная (Малые Клыки), д 21', N'230987')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (14, N'Автотехцентр ААА', N'г Санкт-Петербург, пр-кт Московский, д 191А', N'400875')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (15, N'Автосервис MotorHome', N'г Санкт-Петербург, ул Ворошилова, д 6И', N'454545')
INSERT [dbo].[Workshop] ([ID], [Title], [Address], [Phone]) VALUES (16, N'Автотехцентр DSG-Rem', N'г Санкт-Петербург, пер 1-й Верхний, д 10', N'237609')
SET IDENTITY_INSERT [dbo].[Workshop] OFF
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_CarModel] FOREIGN KEY([CarModelID])
REFERENCES [dbo].[CarModel] ([Title])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_CarModel]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Client] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Client] ([DriversLicense])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Client]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Workshop] FOREIGN KEY([WorkshopID])
REFERENCES [dbo].[Workshop] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Workshop]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Car] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([CarNumber])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Car]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[ServicesInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServicesInOrder_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[ServicesInOrder] CHECK CONSTRAINT [FK_ServicesInOrder_Order]
GO
ALTER TABLE [dbo].[ServicesInOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServicesInOrder_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([Title])
GO
ALTER TABLE [dbo].[ServicesInOrder] CHECK CONSTRAINT [FK_ServicesInOrder_Service]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [CK_Car] CHECK  (([ManufactureYear]>(1886) AND [ManufactureYear]<(2100)))
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [CK_Car]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK_Employee] CHECK  (([Rank]>(0) AND [Rank]<(8)))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_Employee]
GO
USE [master]
GO
ALTER DATABASE [CarRepair] SET  READ_WRITE 
GO
