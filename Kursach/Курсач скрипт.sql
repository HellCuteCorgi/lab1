USE [master]
GO
/****** Object:  Database [Курсач]    Script Date: 16.12.2021 15:57:01 ******/
CREATE DATABASE [Курсач]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Курсач', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Курсач.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Курсач_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Курсач_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Курсач] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Курсач].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Курсач] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Курсач] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Курсач] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Курсач] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Курсач] SET ARITHABORT OFF 
GO
ALTER DATABASE [Курсач] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Курсач] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Курсач] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Курсач] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Курсач] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Курсач] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Курсач] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Курсач] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Курсач] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Курсач] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Курсач] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Курсач] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Курсач] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Курсач] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Курсач] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Курсач] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Курсач] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Курсач] SET RECOVERY FULL 
GO
ALTER DATABASE [Курсач] SET  MULTI_USER 
GO
ALTER DATABASE [Курсач] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Курсач] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Курсач] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Курсач] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Курсач] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Курсач] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Курсач', N'ON'
GO
ALTER DATABASE [Курсач] SET QUERY_STORE = OFF
GO
USE [Курсач]
GO
/****** Object:  Table [dbo].[Зарплаты]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Зарплаты](
	[Работник] [nvarchar](50) NOT NULL,
	[Оклад] [money] NOT NULL,
	[Дата] [date] NOT NULL,
	[Премия] [money] NULL,
	[Итог]  AS ([Оклад]+[Премия])
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Никнейм] [nvarchar](50) NOT NULL,
	[ФИО] [nvarchar](50) NOT NULL,
	[Роль] [nvarchar](50) NOT NULL,
	[Пароль] [nvarchar](max) NOT NULL,
	[Статус] [nvarchar](50) NULL,
	[Дата регистрации] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Никнейм] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Зарплаты1]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Зарплаты1]
AS
SELECT        dbo.Users.ФИО, dbo.Зарплаты.Оклад, dbo.Зарплаты.Дата, dbo.Зарплаты.Премия, dbo.Зарплаты.Итог
FROM            dbo.Зарплаты INNER JOIN
                         dbo.Users ON dbo.Зарплаты.Работник = dbo.Users.Никнейм
GO
/****** Object:  Table [dbo].[Услуги]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Услуги](
	[ID_услуги] [int] NOT NULL,
	[Название] [nvarchar](50) NOT NULL,
	[Цена] [money] NOT NULL,
 CONSTRAINT [PK_Услуги] PRIMARY KEY CLUSTERED 
(
	[ID_услуги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Оборудование]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Оборудование](
	[ID_оборудования] [int] NOT NULL,
	[Вид_оборудования] [nvarchar](50) NOT NULL,
	[Фирма] [nvarchar](50) NOT NULL,
	[Цена_оборудования] [money] NOT NULL,
	[Платформа] [nvarchar](50) NULL,
	[Монитор/Телевизор] [nvarchar](50) NOT NULL,
	[Мышь] [nvarchar](50) NULL,
	[Клавиатура] [nvarchar](50) NULL,
	[Наушники] [nvarchar](50) NULL,
 CONSTRAINT [PK_Оборудование] PRIMARY KEY CLUSTERED 
(
	[ID_оборудования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Основная информация]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Основная информация](
	[ID_оборудования] [int] NOT NULL,
	[Сотрудник] [nvarchar](50) NOT NULL,
	[ID_услуги] [int] NOT NULL,
	[Дата_аренды] [date] NOT NULL,
	[Время_аренды] [time](7) NOT NULL,
	[Клиент] [nvarchar](50) NOT NULL,
	[Цена] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Основная информация1]    Script Date: 16.12.2021 15:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE VIEW [dbo].[Основная информация1]
  AS
  SELECT оборуд.Вид_оборудования as оборудование, [Сотрудник], усл.Название as услуги, [Дата_аренды], [Время_аренды], [Клиент], [Основная информация].Цена
  FROM [Основная информация]
  INNER JOIN [Оборудование] as оборуд 
  on [Основная информация].ID_оборудования = оборуд.ID_оборудования
  INNER JOIN [Услуги] as усл 
  on [Основная информация].ID_услуги = усл.ID_услуги
GO
ALTER TABLE [dbo].[Зарплаты]  WITH CHECK ADD  CONSTRAINT [FK_Зарплаты_Users] FOREIGN KEY([Работник])
REFERENCES [dbo].[Users] ([Никнейм])
GO
ALTER TABLE [dbo].[Зарплаты] CHECK CONSTRAINT [FK_Зарплаты_Users]
GO
ALTER TABLE [dbo].[Основная информация]  WITH CHECK ADD  CONSTRAINT [FK_Основная информация_Users] FOREIGN KEY([Сотрудник])
REFERENCES [dbo].[Users] ([Никнейм])
GO
ALTER TABLE [dbo].[Основная информация] CHECK CONSTRAINT [FK_Основная информация_Users]
GO
ALTER TABLE [dbo].[Основная информация]  WITH CHECK ADD  CONSTRAINT [FK_Основная информация_Users1] FOREIGN KEY([Клиент])
REFERENCES [dbo].[Users] ([Никнейм])
GO
ALTER TABLE [dbo].[Основная информация] CHECK CONSTRAINT [FK_Основная информация_Users1]
GO
ALTER TABLE [dbo].[Основная информация]  WITH CHECK ADD  CONSTRAINT [FK_Основная информация_Оборудование] FOREIGN KEY([ID_оборудования])
REFERENCES [dbo].[Оборудование] ([ID_оборудования])
GO
ALTER TABLE [dbo].[Основная информация] CHECK CONSTRAINT [FK_Основная информация_Оборудование]
GO
ALTER TABLE [dbo].[Основная информация]  WITH CHECK ADD  CONSTRAINT [FK_Основная информация_Услуги] FOREIGN KEY([ID_услуги])
REFERENCES [dbo].[Услуги] ([ID_услуги])
GO
ALTER TABLE [dbo].[Основная информация] CHECK CONSTRAINT [FK_Основная информация_Услуги]
GO
ALTER TABLE [dbo].[Оборудование]  WITH CHECK ADD  CONSTRAINT [CK_Оборудование] CHECK  (([Вид_оборудования]=N'Персональный компьютер' OR [Вид_оборудования]=N'PlayStation 5' OR [Вид_оборудования]=N'XBOX'))
GO
ALTER TABLE [dbo].[Оборудование] CHECK CONSTRAINT [CK_Оборудование]
GO
ALTER TABLE [dbo].[Оборудование]  WITH CHECK ADD  CONSTRAINT [CK_Оборудование_1] CHECK  (([Платформа]=N'Windows' OR [Платформа]=N'PS' OR [Платформа]=N'XBox'))
GO
ALTER TABLE [dbo].[Оборудование] CHECK CONSTRAINT [CK_Оборудование_1]
GO
ALTER TABLE [dbo].[Оборудование]  WITH CHECK ADD  CONSTRAINT [CK_Оборудование_3] CHECK  (([Мышь]=N'Беспроводная' OR [Мышь]=N'Проводная'))
GO
ALTER TABLE [dbo].[Оборудование] CHECK CONSTRAINT [CK_Оборудование_3]
GO
ALTER TABLE [dbo].[Оборудование]  WITH CHECK ADD  CONSTRAINT [CK_Оборудование_4] CHECK  (([Клавиатура]=N'Механическая' OR [Клавиатура]=N'Мембранная'))
GO
ALTER TABLE [dbo].[Оборудование] CHECK CONSTRAINT [CK_Оборудование_4]
GO
ALTER TABLE [dbo].[Оборудование]  WITH CHECK ADD  CONSTRAINT [CK_Оборудование_5] CHECK  (([Наушники]=N'Проводные' OR [Наушники]=N'Беспроводные'))
GO
ALTER TABLE [dbo].[Оборудование] CHECK CONSTRAINT [CK_Оборудование_5]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Зарплаты"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 462
               Bottom = 136
               Right = 649
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Зарплаты1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Зарплаты1'
GO
USE [master]
GO
ALTER DATABASE [Курсач] SET  READ_WRITE 
GO
