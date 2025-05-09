CREATE DATABASE [CarsDB]
GO
USE [CarsDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCity] [int] NOT NULL,
	[IdStreet] [int] NOT NULL,
	[HouseNum] [nvarchar](30) NOT NULL,
	[FlatNum] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auto]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTypeDriveUnit] [int] NOT NULL,
	[IdModel] [int] NOT NULL,
	[IdBrand] [int] NOT NULL,
	[IdAddress] [int] NULL,
	[YearOfCreate] [int] NOT NULL,
	[Mileage] [decimal](18, 2) NOT NULL,
	[VinNumber] [nvarchar](17) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Image] [image] NULL,
	[Engine] [nvarchar](50) NOT NULL,
	[Owners] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Auto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfBrand] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfCity] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfModel] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdManager] [int] NULL,
	[IdAuto] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[DateOfSale] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdOrder] [int] NOT NULL,
	[IdTypeOfPayment] [int] NOT NULL,
	[DateTimeOfPayment] [datetime] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdAuto] [int] NOT NULL,
	[DescriptionReview] [nvarchar](550) NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Street]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Street](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfStreet] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Street] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeDriveUnit]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeDriveUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameTypeDriveUnit] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeDriveUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfPayment]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOfPayment] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUserRole] [int] NOT NULL,
	[SecondName] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[ThirdName] [nvarchar](150) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warranty]    Script Date: 27.04.2024 9:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warranty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOrder] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](550) NOT NULL,
 CONSTRAINT [PK_Warranty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [IdCity], [IdStreet], [HouseNum], [FlatNum]) VALUES (1, 1, 1, N'54а', N'65')
INSERT [dbo].[Address] ([Id], [IdCity], [IdStreet], [HouseNum], [FlatNum]) VALUES (2, 2, 2, N'65', N'12')
INSERT [dbo].[Address] ([Id], [IdCity], [IdStreet], [HouseNum], [FlatNum]) VALUES (3, 2, 1, N'11', N'65Г')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Auto] ON 

INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (1, 1, 1, 1, NULL, 2011, CAST(109.00 AS Decimal(18, 2)), N'GFD65434321UYTREW', N'Комплектация MAX:

- Выдвижные пороги;
- Круиз-контроль;
- Четырехзонный климат-контроль;
- Камера 360°;
- Панорамная крыша;
- Доводчики дверей;
- Электрорегулировка руля;
- Проекционный дисплей;
- Система выбора режима движения;
- Система доступа без ключа;
- Электропривод крышки багажника;
- Премиальная аудиосистема;
- Мультимедиа система для задних пассажиров;
- Навигационная система;
- Розетка 220V;
', CAST(6250000.00 AS Decimal(18, 2)), NULL, N'1.5 гибрид / 449 л.с.', 1, 1)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (2, 1, 2, 6, NULL, 2020, CAST(2200.20 AS Decimal(18, 2)), N'ASDASD76786SAD876', N'Действующий ЭПТС.

2 ключа.

Комплектация:

- Система «старт-стоп»;
- Камеры 360°;
- Доводчики дверей;
- Парктроники;
- Проекция;
- Бесключевой доступ;
- Адаптивный круиз-контроль;
- Климат-контроль многозонный;
- Дистанционный запуск двигателя;
- Система автоматической парковки;
- Открытие багажника без помощи рук;
- Люк, Панорамная крыша;
- Сиденья с массажем;
- Вентиляция передних и задних сидений;
- Подогрев руля, передних и задних сидений;
- Декоративная подсветка салона;
- Навигация;', CAST(2200000.00 AS Decimal(18, 2)), NULL, N'1.5 гибрид / 449 л.с.', 0, 0)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (3, 1, 7, 4, NULL, 2023, CAST(14.00 AS Decimal(18, 2)), N'HGFG2312HG3F21GH3', N'Автомобиль привезен из Китая в январе 2024 года.

Действующий ЭПТС.

2 ключа.

Комплектация «Flagship»:

- Адаптивный круиз-контроль;
- Климат-контроль многозонный;
- Проекция на лобовое стекло;
- Бесключевой доступ;
- Дистанционный запуск двигателя;
- Камеры 360°;
- Вентиляция и подогрев передних сидений;
- Электрорегулировка передних сидений с памятью положения;
- Панорамная крыша;
- Датчик усталости водителя;
- Система предотвращения столкновения;
- Система контроля за полосой движения;
- Система распознавания дорожных знаков;
- Система автоматической парковки;
- Открытие багажника без помощи рук;', CAST(4050000.00 AS Decimal(18, 2)), NULL, N'2.0 бензин / 238 л.с.', 0, 0)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (4, 1, 11, 1, NULL, 2019, CAST(86.43 AS Decimal(18, 2)), N'FSDFSDF34234234DS', N'Автомобиль куплен у официального дилера в 2019 году.

Автомобиль полностью в родном окрасе и бронепленке.

Полный комплект ключей.

Оригинальный ПТС.

Комплектация:

- Четырёхзонный климат-контроль;
- Панорамная крыша;
- Доводчики дверей;
- Память положения передних сидений;
- Электропривод крышки багажника;
- Камеры 360;
- Электропривод руля;
- Пневмоподвеска;
- Премиальная аудиосистема Bowers & Wilkins;
- Подогрев руля;
- Подогрев и вентиляция сидений;', CAST(9449000.00 AS Decimal(18, 2)), NULL, N'3.0 дизель / 400 л.с.', 3, 0)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (5, 1, 1, 1, NULL, 2021, CAST(58.20 AS Decimal(18, 2)), N'J2HKJ12H32K1J3H21', N'Автомобиль куплен у официального дилера в 2021 году.

2 собственника.

Заводской окрас.

Автомобиль в защитной пленке.

Действующий ЭПТС.

Комплектация:

- Спортивный комбинированный салон;
- Электропривод передних сидений;
- Навигация;
- Подогрев сидений;
- Подогрев руля;
- Расширенная мультимедиа;
- Черный потолок;
- Цифровая приборная панель;
- Электропривод багажника;', CAST(5849000.00 AS Decimal(18, 2)), NULL, N'2.0 дизель / 190 л.с.', 2, 0)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (6, 1, 3, 2, NULL, 2020, CAST(70.94 AS Decimal(18, 2)), N'BJ2H1B3JB12J3HB12', N'Автомобиль куплен у официального дилера в 2020 году.

2 собственника.

Комплектация:

- Система предупреждения о выезде с полосы движения;
- Акустическая система Bose Premium;
- Бесключевой запуск двигателя;
- Боковые подножки;
- Датчики давления в шинах;
- Камера заднего вида с функцией потоковой передачи видео на внутрисалонное зеркало заднего вида;
- Навигация;
- Пакет памяти регулировки передних сидений, боковых зеркал, рулевого колеса, педального узла;
- Подогрев задних сидений и руля;', CAST(7989000.00 AS Decimal(18, 2)), NULL, N'6.2 бензин / 426 л.с.', 2, 0)
INSERT [dbo].[Auto] ([Id], [IdTypeDriveUnit], [IdModel], [IdBrand], [IdAddress], [YearOfCreate], [Mileage], [VinNumber], [Description], [Price], [Image], [Engine], [Owners], [Status]) VALUES (7, 1, 5, 1, NULL, 2023, CAST(4.92 AS Decimal(18, 2)), N'JKJH213H213213JH2', N'Богатая комплектация «M60 Suite Sport»:

- Система предотвращения столкновения;
- Система контроля за полосой движения;
- Система помощи при торможении;
- Ассистент парковки;
- Система контроля слепых зон;
- Климат-контроль многозонный;
- Адаптивный круиз-контроль;
- Парктроники передние и задние;
- Камера 360°;
- Проекция на лобовое стекло;
- Бесключевой доступ;
- Запуск двигателя с кнопки;
- Доводчик дверей;
- Активный усилитель руля;
- Аудиосистема Bowers & Wilkins;
- Мультимедиа с функцией Android Auto и CarPlay;
- Беспроводная зарядка для смартфона c охлаждением;
- Электрорегулировка передних сидений с памятью положения и вентиляцией;
- Подогрев всех сидений;
- Лазерная оптика;
- Панорамная крыша с затемнением;
- Сиденья с массажем;
- Подогрев руля;', CAST(14554000.00 AS Decimal(18, 2)), NULL, N'397 кВт / 540 л.с.', 1, 0)
SET IDENTITY_INSERT [dbo].[Auto] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (1, N'BMW')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (2, N'Cadillac')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (3, N'Mercedes-Benz')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (4, N'Geely')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (5, N'Haval')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (6, N'Nissan')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (7, N'Land Rover')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (8, N'Toyota')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (9, N'Chery')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (10, N'Chevrolet')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (11, N'Honda')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (12, N'Dodge')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (13, N'Hyundai')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (14, N'Porsche')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (15, N'Kia')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (16, N'Audi')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (17, N'Mitsubishi')
INSERT [dbo].[Brand] ([Id], [NameOfBrand]) VALUES (18, N'Infiniti')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [NameOfCity]) VALUES (1, N'Москва')
INSERT [dbo].[City] ([Id], [NameOfCity]) VALUES (2, N'Дмитров')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (1, N'520d')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (2, N'M850i')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (3, N'Escalade')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (4, N'320d')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (5, N'iX')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (6, N'GLC')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (7, N'Monjaro')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (8, N'E220')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (9, N'Dargo')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (10, N'Discovery')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (11, N'X7')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (12, N'Rogue')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (13, N'Land Cruiser')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (14, N'Explore 06')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (15, N'Tahoe')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (16, N'Charger')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (17, N'911')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (18, N'E200')
INSERT [dbo].[Model] ([Id], [NameOfModel]) VALUES (19, N'Sorento')
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [IdClient], [IdManager], [IdAuto], [Status], [DateOfSale]) VALUES (1, 3, NULL, 1, 1, CAST(N'2024-04-18' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([Id], [IdUser], [IdOrder], [IdTypeOfPayment], [DateTimeOfPayment]) VALUES (1, 1, 1, 1, CAST(N'2024-04-27T09:30:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([Id], [IdUser], [IdAuto], [DescriptionReview]) VALUES (1, 1, 1, N'Хороший автомобиль, минимальный пробег, не битый')
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
SET IDENTITY_INSERT [dbo].[Street] ON 

INSERT [dbo].[Street] ([Id], [NameOfStreet]) VALUES (1, N'1-я Парковая')
INSERT [dbo].[Street] ([Id], [NameOfStreet]) VALUES (2, N'Калужское шоссе')
SET IDENTITY_INSERT [dbo].[Street] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeDriveUnit] ON 

INSERT [dbo].[TypeDriveUnit] ([Id], [NameTypeDriveUnit]) VALUES (1, N'Полный')
INSERT [dbo].[TypeDriveUnit] ([Id], [NameTypeDriveUnit]) VALUES (2, N'Передний')
INSERT [dbo].[TypeDriveUnit] ([Id], [NameTypeDriveUnit]) VALUES (3, N'Задний')
SET IDENTITY_INSERT [dbo].[TypeDriveUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfPayment] ON 

INSERT [dbo].[TypeOfPayment] ([Id], [NameOfPayment]) VALUES (1, N'Б/н')
INSERT [dbo].[TypeOfPayment] ([Id], [NameOfPayment]) VALUES (2, N'Н')
SET IDENTITY_INSERT [dbo].[TypeOfPayment] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (1, 1, N'Иванов', N'Иван', N'Иванович', N'89654455678', N'ivanovi87@mail.ru', N'ivanovi', N'12345')
INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (2, 2, N'manager', N'manager', N'manager', N'89768877765', N'manager0@test.ru', N'manager1', N'manager1')
INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (3, 1, N'client1', N'client1', N'client1', N'89765443332', N'client54@mail.ru', N'client1', N'client1')
INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (4, 1, N'Петров', N'Петр', N'Петрович', N'89765544432', N'ppetrov76@mail.ru', N'ppetrov76', N'7654')
INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (5, 2, N'Робинов', N'Робин', N'Робинович', N'89765432109', N'rrobinn@rambler.ru', N'robbin77', N'7765r')
INSERT [dbo].[User] ([Id], [IdUserRole], [SecondName], [FirstName], [ThirdName], [PhoneNumber], [Email], [Login], [Password]) VALUES (6, 1, N'Иванов', N'Петр', N'Игнатьевич', N'+798766633354', N'asda@mail.ru', N'asda', N'111')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleName]) VALUES (1, N'Клиент')
INSERT [dbo].[UserRole] ([Id], [RoleName]) VALUES (2, N'Менеджер')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Warranty] ON 

INSERT [dbo].[Warranty] ([Id], [IdOrder], [StartDate], [EndDate], [Cost], [Description]) VALUES (1, 1, CAST(N'2024-04-27' AS Date), CAST(N'2025-04-27' AS Date), CAST(30000.00 AS Decimal(18, 2)), N'На кузов')
SET IDENTITY_INSERT [dbo].[Warranty] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Street] FOREIGN KEY([IdStreet])
REFERENCES [dbo].[Street] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Street]
GO
ALTER TABLE [dbo].[Auto]  WITH CHECK ADD  CONSTRAINT [FK_Auto_Address] FOREIGN KEY([IdAddress])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Auto] CHECK CONSTRAINT [FK_Auto_Address]
GO
ALTER TABLE [dbo].[Auto]  WITH CHECK ADD  CONSTRAINT [FK_Auto_Brand] FOREIGN KEY([IdBrand])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Auto] CHECK CONSTRAINT [FK_Auto_Brand]
GO
ALTER TABLE [dbo].[Auto]  WITH CHECK ADD  CONSTRAINT [FK_Auto_Model] FOREIGN KEY([IdModel])
REFERENCES [dbo].[Model] ([Id])
GO
ALTER TABLE [dbo].[Auto] CHECK CONSTRAINT [FK_Auto_Model]
GO
ALTER TABLE [dbo].[Auto]  WITH CHECK ADD  CONSTRAINT [FK_Auto_TypeDriveUnit] FOREIGN KEY([IdTypeDriveUnit])
REFERENCES [dbo].[TypeDriveUnit] ([Id])
GO
ALTER TABLE [dbo].[Auto] CHECK CONSTRAINT [FK_Auto_TypeDriveUnit]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Auto] FOREIGN KEY([IdAuto])
REFERENCES [dbo].[Auto] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Auto]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([IdClient])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User1] FOREIGN KEY([IdManager])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User1]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_TypeOfPayment] FOREIGN KEY([IdTypeOfPayment])
REFERENCES [dbo].[TypeOfPayment] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_TypeOfPayment]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_User]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Auto] FOREIGN KEY([IdAuto])
REFERENCES [dbo].[Auto] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Auto]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([IdUserRole])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
ALTER TABLE [dbo].[Warranty]  WITH CHECK ADD  CONSTRAINT [FK_Warranty_Order] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Warranty] CHECK CONSTRAINT [FK_Warranty_Order]
GO
USE [master]
GO
ALTER DATABASE [CarsDB] SET  READ_WRITE 
GO
