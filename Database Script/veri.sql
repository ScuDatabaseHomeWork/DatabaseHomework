USE [master]
GO
/****** Object:  Database [HospitalAppDB]    Script Date: 13.06.2021 21:44:43 ******/
CREATE DATABASE [HospitalAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VeritabaniDeneme', FILENAME = N'C:\Users\ramazan\VeritabaniDeneme.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VeritabaniDeneme_log', FILENAME = N'C:\Users\ramazan\VeritabaniDeneme_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HospitalAppDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalAppDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalAppDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalAppDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalAppDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalAppDB] SET QUERY_STORE = OFF
GO
USE [HospitalAppDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HospitalAppDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmanName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policlinic]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policlinic](
	[Id] [int] NOT NULL,
	[PoliclinicName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Policlinic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_GetWithPol]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetWithPol]
AS
SELECT        dbo.Department.Id AS DepId, dbo.Department.DepartmanName, dbo.Policlinic.Id AS PolId, dbo.Policlinic.PoliclinicName
FROM            dbo.Department INNER JOIN
                         dbo.Policlinic ON dbo.Department.Id = dbo.Policlinic.DepartmentId
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Date] [smalldatetime] NOT NULL,
	[RegistrarId] [int] NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Confirmed] [bit] NOT NULL,
	[CreatingDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeceptionCount] [smalldatetime] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 13.06.2021 21:44:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Apellation] [nvarchar](50) NOT NULL,
	[SuperAdminId] [int] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] NOT NULL,
	[MotherName] [nvarchar](50) NOT NULL,
	[FatherName] [nvarchar](50) NOT NULL,
	[SuperAdminId] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientRegistrar]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientRegistrar](
	[Id] [int] NOT NULL,
	[TellerNumber] [int] NOT NULL,
	[SuperAdminId] [int] NOT NULL,
 CONSTRAINT [PK_PatientRegistrar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescribe]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescribe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](50) NOT NULL,
	[Medicine] [nvarchar](50) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Prescribe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuperAdmin]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperAdmin](
	[Id] [int] NOT NULL,
	[Apellation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SuperAdmin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TCNo] [bigint] NOT NULL,
	[RolId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SurName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BirthDate] [smalldatetime] NOT NULL,
	[Telephone] [bigint] NOT NULL,
	[Gender] [bit] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Appointment] ([Date], [RegistrarId], [DoctorId], [PatientId], [Confirmed], [CreatingDate]) VALUES (CAST(N'2021-06-04T11:00:00' AS SmallDateTime), NULL, 13020, 13025, 0, CAST(N'2021-06-09T05:21:00' AS SmallDateTime))
INSERT [dbo].[Appointment] ([Date], [RegistrarId], [DoctorId], [PatientId], [Confirmed], [CreatingDate]) VALUES (CAST(N'2021-06-09T11:00:00' AS SmallDateTime), NULL, 13020, 13023, 1, CAST(N'2021-06-09T17:16:00' AS SmallDateTime))
INSERT [dbo].[Appointment] ([Date], [RegistrarId], [DoctorId], [PatientId], [Confirmed], [CreatingDate]) VALUES (CAST(N'2021-06-09T13:15:00' AS SmallDateTime), NULL, 13022, 13025, 1, CAST(N'2021-06-09T17:07:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[BlackList] ON 

INSERT [dbo].[BlackList] ([Id], [DeceptionCount], [DoctorId], [PatientId], [Description]) VALUES (6005, CAST(N'2021-06-15T17:17:00' AS SmallDateTime), 13020, 13023, N'kmyj')
SET IDENTITY_INSERT [dbo].[BlackList] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [DepartmanName]) VALUES (3011, N'Dahiliye')
INSERT [dbo].[Department] ([Id], [DepartmanName]) VALUES (3012, N'Kardiyoloji')
INSERT [dbo].[Department] ([Id], [DepartmanName]) VALUES (3013, N'Üroloji')
INSERT [dbo].[Department] ([Id], [DepartmanName]) VALUES (3014, N'Cildiye')
SET IDENTITY_INSERT [dbo].[Department] OFF
INSERT [dbo].[Doctor] ([Id], [DepartmentId], [Apellation], [SuperAdminId]) VALUES (13020, 3011, N'Doktor', 3008)
INSERT [dbo].[Doctor] ([Id], [DepartmentId], [Apellation], [SuperAdminId]) VALUES (13021, 3012, N'Doçent', 3008)
INSERT [dbo].[Doctor] ([Id], [DepartmentId], [Apellation], [SuperAdminId]) VALUES (13022, 3013, N'Doktor', 3008)
INSERT [dbo].[Patient] ([Id], [MotherName], [FatherName], [SuperAdminId]) VALUES (13023, N'Ayşe', N'Hasan', 3008)
INSERT [dbo].[Patient] ([Id], [MotherName], [FatherName], [SuperAdminId]) VALUES (13024, N'Hatice', N'Birol', 3008)
INSERT [dbo].[Patient] ([Id], [MotherName], [FatherName], [SuperAdminId]) VALUES (13025, N'Ayşe', N'İbrahim', 3008)
INSERT [dbo].[PatientRegistrar] ([Id], [TellerNumber], [SuperAdminId]) VALUES (13026, 1, 3008)
INSERT [dbo].[PatientRegistrar] ([Id], [TellerNumber], [SuperAdminId]) VALUES (13029, 2, 3008)
INSERT [dbo].[Policlinic] ([Id], [PoliclinicName], [DepartmentId]) VALUES (13020, N'Dahiliye 1', 3011)
INSERT [dbo].[Policlinic] ([Id], [PoliclinicName], [DepartmentId]) VALUES (13021, N'Kardiyoloji 1', 3012)
INSERT [dbo].[Policlinic] ([Id], [PoliclinicName], [DepartmentId]) VALUES (13022, N'Üro 1', 3013)
SET IDENTITY_INSERT [dbo].[Prescribe] ON 

INSERT [dbo].[Prescribe] ([Id], [DiseaseName], [Medicine], [DoctorId], [PatientId], [Description]) VALUES (4002, N'Ağrı', N'Parol', 13020, 13025, N'Doktor Karani  Karaman tarafından oluşturuldu')
INSERT [dbo].[Prescribe] ([Id], [DiseaseName], [Medicine], [DoctorId], [PatientId], [Description]) VALUES (5002, N'Ağrı', N'Parol', 13022, 13025, N'Doktor Memati Baş tarafından oluşturuldu')
SET IDENTITY_INSERT [dbo].[Prescribe] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [RolName]) VALUES (1, N'SuperAdmin')
INSERT [dbo].[Rol] ([Id], [RolName]) VALUES (2, N'Patient')
INSERT [dbo].[Rol] ([Id], [RolName]) VALUES (3, N'Doctor')
INSERT [dbo].[Rol] ([Id], [RolName]) VALUES (4, N'PatientRegistrar')
SET IDENTITY_INSERT [dbo].[Rol] OFF
INSERT [dbo].[SuperAdmin] ([Id], [Apellation]) VALUES (3008, N'Professor')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (3008, 38023538002, 1, N'Ramazan', N'İşçanan', N'iscanan@gmail.com', CAST(N'2002-01-02T00:00:00' AS SmallDateTime), 484841561, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13020, 45678912385, 3, N'Karani ', N'Karaman', N'karani89@gmail.com', CAST(N'2021-06-11T00:00:00' AS SmallDateTime), 56456456456, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13021, 45678912396, 3, N'Polat', N'Alemdar', N'polat89@gmail.com', CAST(N'2021-06-03T00:00:00' AS SmallDateTime), 78945612374, 0, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13022, 456789123457, 3, N'Memati', N'Baş', N'dennemme89@gmail.com', CAST(N'2021-06-09T00:00:00' AS SmallDateTime), 56456456456, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13023, 74185296333, 2, N'Yılmaz', N'Kaya', N'dennemme89@gmail.com', CAST(N'2021-06-10T00:00:00' AS SmallDateTime), 45678912396, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13024, 78945612385, 2, N'Oktay', N'Pür', N'yavuz@gmail.com', CAST(N'2021-06-04T00:00:00' AS SmallDateTime), 56456456456, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13025, 45674185296, 2, N'Samet', N'Kara', N'emir@gmail.com', CAST(N'2021-06-03T00:00:00' AS SmallDateTime), 56456456456, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13026, 58963214755, 4, N'Yavuz', N'Öz', N'yavuz@gmail.com', CAST(N'2021-06-10T00:00:00' AS SmallDateTime), 4545678456, 1, N'123')
INSERT [dbo].[User] ([Id], [TCNo], [RolId], [Name], [SurName], [Email], [BirthDate], [Telephone], [Gender], [Password]) VALUES (13029, 7894561238, 4, N'Fatih', N'Kaya', N'fatih@gmail.com', CAST(N'2021-06-11T00:00:00' AS SmallDateTime), 5645645645, 1, N'123')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Index [Tc_User]    Script Date: 13.06.2021 21:44:44 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [Tc_User] UNIQUE NONCLUSTERED 
(
	[TCNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BlackList] ADD  CONSTRAINT [DF_BlackList_DoctorId]  DEFAULT ((-1)) FOR [DoctorId]
GO
ALTER TABLE [dbo].[Appointment]  WITH NOCHECK ADD  CONSTRAINT [FK_Appointment_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Appointment] NOCHECK CONSTRAINT [FK_Appointment_Doctor]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Patient]
GO
ALTER TABLE [dbo].[Appointment]  WITH NOCHECK ADD  CONSTRAINT [FK_Appointment_PatientRegistrar] FOREIGN KEY([RegistrarId])
REFERENCES [dbo].[PatientRegistrar] ([Id])
GO
ALTER TABLE [dbo].[Appointment] NOCHECK CONSTRAINT [FK_Appointment_PatientRegistrar]
GO
ALTER TABLE [dbo].[BlackList]  WITH NOCHECK ADD  CONSTRAINT [FK_BlackList_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[BlackList] NOCHECK CONSTRAINT [FK_BlackList_Doctor]
GO
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD  CONSTRAINT [FK_BlackList_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlackList] CHECK CONSTRAINT [FK_BlackList_Patient]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Department]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_SuperAdmin] FOREIGN KEY([SuperAdminId])
REFERENCES [dbo].[SuperAdmin] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_SuperAdmin]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_User1] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_User1]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_SuperAdmin] FOREIGN KEY([SuperAdminId])
REFERENCES [dbo].[SuperAdmin] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_SuperAdmin]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_User1] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_User1]
GO
ALTER TABLE [dbo].[PatientRegistrar]  WITH CHECK ADD  CONSTRAINT [FK_PatientRegistrar_SuperAdmin] FOREIGN KEY([SuperAdminId])
REFERENCES [dbo].[SuperAdmin] ([Id])
GO
ALTER TABLE [dbo].[PatientRegistrar] CHECK CONSTRAINT [FK_PatientRegistrar_SuperAdmin]
GO
ALTER TABLE [dbo].[PatientRegistrar]  WITH CHECK ADD  CONSTRAINT [FK_PatientRegistrar_User1] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientRegistrar] CHECK CONSTRAINT [FK_PatientRegistrar_User1]
GO
ALTER TABLE [dbo].[Policlinic]  WITH CHECK ADD  CONSTRAINT [FK_Policlinic_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Policlinic] CHECK CONSTRAINT [FK_Policlinic_Department]
GO
ALTER TABLE [dbo].[Policlinic]  WITH CHECK ADD  CONSTRAINT [FK_Policlinic_Doctor] FOREIGN KEY([Id])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Policlinic] CHECK CONSTRAINT [FK_Policlinic_Doctor]
GO
ALTER TABLE [dbo].[Prescribe]  WITH NOCHECK ADD  CONSTRAINT [FK_Prescribe_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Prescribe] NOCHECK CONSTRAINT [FK_Prescribe_Doctor]
GO
ALTER TABLE [dbo].[Prescribe]  WITH CHECK ADD  CONSTRAINT [FK_Prescribe_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prescribe] CHECK CONSTRAINT [FK_Prescribe_Patient]
GO
ALTER TABLE [dbo].[SuperAdmin]  WITH CHECK ADD  CONSTRAINT [FK_SuperAdmin_User1] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuperAdmin] CHECK CONSTRAINT [FK_SuperAdmin_User1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Rol]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckInBlackListByPatientId]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
-- 
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
CREATE PROCEDURE [dbo].[sp_CheckInBlackListByPatientId]
@patientId int
AS
BEGIN
select top 1 * from BlackList where PatientId = @patientId and DeceptionCount>GETDATE()
END
GO
/****** Object:  Trigger [dbo].[previousBlacklistDelete]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[previousBlacklistDelete]
   ON [dbo].[BlackList]
   AFTER INSERT
AS 
BEGIN
declare @patientId int
select @patientId = PatientId from inserted
 delete from BlackList where DeceptionCount<GETDATE() and PatientId=@patientId 
END
GO
ALTER TABLE [dbo].[BlackList] ENABLE TRIGGER [previousBlacklistDelete]
GO
/****** Object:  Trigger [dbo].[doctor_Delete]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[doctor_Delete]
on [dbo].[Doctor]
after delete as
begin 
declare @Id int
select 
@Id = Id from deleted
update BlackList set DoctorId = 0 where DoctorId=@Id
update Prescribe set DoctorId = 0 where DoctorId=@Id
update Appointment set DoctorId = 0 where DoctorId=@Id
End
GO
ALTER TABLE [dbo].[Doctor] ENABLE TRIGGER [doctor_Delete]
GO
/****** Object:  Trigger [dbo].[patientRegistrar_Delete]    Script Date: 13.06.2021 21:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[patientRegistrar_Delete]
on [dbo].[PatientRegistrar]
after delete as
begin 
declare @Id int
select 
@Id = Id from deleted
update Appointment set RegistrarId = null where RegistrarId=@Id
End
GO
ALTER TABLE [dbo].[PatientRegistrar] ENABLE TRIGGER [patientRegistrar_Delete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[36] 2[15] 3) )"
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
         Begin Table = "Department"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 157
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Policlinic"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 146
               Right = 426
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
         Alias = 1425
         Table = 1170
         Output = 870
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetWithPol'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetWithPol'
GO
USE [master]
GO
ALTER DATABASE [HospitalAppDB] SET  READ_WRITE 
GO
