USE [grievance_system]
GO
/****** Object:  Table [dbo].[country]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[country](
	[country_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[country_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[country] ([country_name]) VALUES (N'India')
/****** Object:  Table [dbo].[university]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university](
	[university_id] [int] IDENTITY(1,1) NOT NULL,
	[university_name] [varchar](max) NULL,
	[university_state] [varchar](25) NULL,
	[university_city] [varchar](25) NULL,
	[university_address] [varchar](100) NULL,
	[university_contact] [numeric](18, 0) NULL,
 CONSTRAINT [PK__universi__F24BB7200AD2A005] PRIMARY KEY CLUSTERED 
(
	[university_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[university] ON
INSERT [dbo].[university] ([university_id], [university_name], [university_state], [university_city], [university_address], [university_contact]) VALUES (1, N'Mumbai University', N'Maharashtra', N'Mumbai', N'Kalina, Santacruz', CAST(26543300 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[university] OFF
/****** Object:  Table [dbo].[system_admin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[system_admin](
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[system_admin_email] [varchar](max) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[system_admin] ([first_name], [last_name], [system_admin_email], [password]) VALUES (N'System', N'Admin', N'systemadmin@gmail.com', N'Abcd123')
/****** Object:  Table [dbo].[states]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[states](
	[state_name] [varchar](100) NOT NULL,
	[country_name] [varchar](100) NULL,
 CONSTRAINT [PK_state] PRIMARY KEY CLUSTERED 
(
	[state_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Andaman and Nicobar Islands', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Andhra Pradesh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Arunachal Pradesh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Assam', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Bihar', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Chandigarh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Chhattisgarh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Dadra and Nagar Haveli', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Daman and Diu', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Goa', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Gujarat', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Haryana', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Himachal Pradesh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Jammu and Kashmir', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Jharkhand', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Karnataka', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Kerala', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Lakshadweep', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Madhya Pradesh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Maharashtra', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Manipur', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Meghalaya', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Mizoram', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Nagaland', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Odisha', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Puducherry', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Punjab', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Rajasthan', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Sikkim', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Tamil Nadu', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Telangana', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Tripura', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Uttar Pradesh', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'Uttarakhand', N'India')
INSERT [dbo].[states] ([state_name], [country_name]) VALUES (N'West Bengal', N'India')
/****** Object:  Table [dbo].[university_category]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_category](
	[university_category_id] [int] IDENTITY(1,1) NOT NULL,
	[university_category_name] [varchar](50) NULL,
	[university_id] [int] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_university_category] PRIMARY KEY CLUSTERED 
(
	[university_category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university_admin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_admin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[university_admin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[university_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[university_admin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute](
	[institute_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_name] [varchar](max) NULL,
	[institute_state] [varchar](25) NULL,
	[institute_city] [varchar](25) NULL,
	[institute_address] [varchar](100) NULL,
	[institute_contact] [numeric](18, 0) NULL,
	[university_id] [int] NULL,
 CONSTRAINT [PK__institut__2A0A74D50F975522] PRIMARY KEY CLUSTERED 
(
	[institute_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[institute] ON
INSERT [dbo].[institute] ([institute_id], [institute_name], [institute_state], [institute_city], [institute_address], [institute_contact], [university_id]) VALUES (1, N'Vivekanand Education Society', N'Maharashtra', N'Mumbai', N'Chembur', CAST(61532500 AS Numeric(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[institute] OFF
/****** Object:  Table [dbo].[city]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[city](
	[city_name] [varchar](100) NOT NULL,
	[state_name] [varchar](100) NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[city_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[city] ([city_name], [state_name]) VALUES (N'Mumbai', N'Maharashtra')
INSERT [dbo].[city] ([city_name], [state_name]) VALUES (N'Pune', N'Maharashtra')
/****** Object:  Table [dbo].[university_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_subadmin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[university_subadmin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[university_admin_email] [varchar](50) NULL,
	[university_category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[university_subadmin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_category]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_category](
	[institute_category_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_category_name] [varchar](50) NULL,
	[institute_id] [int] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_institute_category] PRIMARY KEY CLUSTERED 
(
	[institute_category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_admin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_admin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[institute_admin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[institute_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[institute_admin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department](
	[department_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_id] [int] NULL,
	[department_name] [varchar](max) NULL,
 CONSTRAINT [PK__departme__C22324221920BF5C] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[department] ON
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (1, 1, N'Master of Computer Application')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (2, 1, N'Information Technology')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (3, 1, N'Computer Engineering')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (4, 1, N'Electronics')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (5, 1, N'Electronics and Telecommunication')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (6, 1, N'Humanities and Science')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (7, 1, N'Master of Engineering')
INSERT [dbo].[department] ([department_id], [institute_id], [department_name]) VALUES (8, 1, N'Instrumentation')
SET IDENTITY_INSERT [dbo].[department] OFF
/****** Object:  Table [dbo].[department_category]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_category](
	[department_category_id] [int] IDENTITY(1,1) NOT NULL,
	[department_category_name] [varchar](50) NULL,
	[department_id] [int] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_department_category] PRIMARY KEY CLUSTERED 
(
	[department_category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_admin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_admin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[department_admin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[department_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[department_admin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[student]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[student](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[student_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[contact] [numeric](18, 0) NULL,
	[institute_id] [int] NULL,
	[department_id] [int] NULL,
	[university_id] [int] NULL,
 CONSTRAINT [PK__student__820A8F3F145C0A3F] PRIMARY KEY CLUSTERED 
(
	[student_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[student] ([first_name], [last_name], [student_email], [password], [contact], [institute_id], [department_id], [university_id]) VALUES (N'Nabil', N'Kazi', N'2018nabil.kazi@ves.ac.in', N'Abcd123', CAST(8169198826 AS Numeric(18, 0)), 1, 1, 1)
/****** Object:  Table [dbo].[university_mode]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_mode](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[university_mode_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[university_subadmin_email] [varchar](50) NULL,
	[no_of_solved_complaint] [int] NULL,
	[total_no_of_complaint] [int] NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[university_mode_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_subadmin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[institute_subadmin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[institute_admin_email] [varchar](50) NULL,
	[institute_category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[institute_subadmin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[student_academic_detail]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[student_academic_detail](
	[student_academic_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[student_email] [varchar](50) NULL,
	[department_id] [int] NULL,
	[admission_year] [int] NULL,
	[current_year] [varchar](50) NULL,
	[roll_no] [int] NULL,
	[prn_no] [numeric](18, 0) NULL,
	[shift] [varchar](50) NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_student_academic_detail] PRIMARY KEY CLUSTERED 
(
	[student_academic_detail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[student_academic_detail] ON
INSERT [dbo].[student_academic_detail] ([student_academic_detail_id], [student_email], [department_id], [admission_year], [current_year], [roll_no], [prn_no], [shift], [status]) VALUES (1, N'2018nabil.kazi@ves.ac.in', 1, 2018, N'Second Year', 30, CAST(2013016401113315 AS Numeric(18, 0)), N'Second Shift', N'Active')
SET IDENTITY_INSERT [dbo].[student_academic_detail] OFF
/****** Object:  Table [dbo].[institute_mode]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_mode](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[institute_mode_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[institute_subadmin_email] [varchar](50) NULL,
	[no_of_solved_complaint] [int] NULL,
	[total_no_of_complaint] [int] NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[institute_mode_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_subadmin](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[department_subadmin_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[department_admin_email] [varchar](50) NULL,
	[department_category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[department_subadmin_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_complaint]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_complaint](
	[department_complaint_id] [int] IDENTITY(1,1) NOT NULL,
	[student_email] [varchar](50) NULL,
	[complaint_level] [varchar](20) NULL,
	[department_category_id] [int] NULL,
	[complaint_date] [date] NULL,
	[complaint_time] [varchar](30) NULL,
	[complaint_title] [varchar](100) NULL,
	[complaint_description] [varchar](max) NULL,
	[complaint_status] [varchar](20) NULL,
	[complaint_progress] [varchar](20) NULL,
	[student_academic_detail_id] [int] NULL,
 CONSTRAINT [PK__departme__79F15D6476969D2E] PRIMARY KEY CLUSTERED 
(
	[department_complaint_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_mode]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_mode](
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[department_mode_email] [varchar](50) NOT NULL,
	[password] [varchar](100) NULL,
	[department_subadmin_email] [varchar](50) NULL,
	[no_of_solved_complaint] [int] NULL,
	[total_no_of_complaint] [int] NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[department_mode_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_complaint]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_complaint](
	[institute_complaint_id] [int] IDENTITY(1,1) NOT NULL,
	[student_email] [varchar](50) NULL,
	[complaint_level] [varchar](20) NULL,
	[institute_category_id] [int] NULL,
	[complaint_date] [date] NULL,
	[complaint_time] [varchar](30) NULL,
	[complaint_title] [varchar](100) NULL,
	[complaint_description] [varchar](max) NULL,
	[complaint_status] [varchar](20) NULL,
	[complaint_progress] [varchar](20) NULL,
	[student_academic_detail_id] [int] NULL,
 CONSTRAINT [PK__institut__3C93ABAB70DDC3D8] PRIMARY KEY CLUSTERED 
(
	[institute_complaint_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university_complaint]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_complaint](
	[university_complaint_id] [int] IDENTITY(1,1) NOT NULL,
	[student_email] [varchar](50) NULL,
	[complaint_level] [varchar](20) NULL,
	[university_category_id] [int] NULL,
	[complaint_date] [date] NULL,
	[complaint_time] [varchar](30) NULL,
	[complaint_title] [varchar](100) NULL,
	[complaint_description] [varchar](max) NULL,
	[complaint_status] [varchar](20) NULL,
	[complaint_progress] [varchar](20) NULL,
	[student_academic_detail_id] [int] NULL,
 CONSTRAINT [PK__universi__DA8A26C600200768] PRIMARY KEY CLUSTERED 
(
	[university_complaint_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_student_comment](
	[university_student_comment_id] [int] IDENTITY(1,1) NOT NULL,
	[university_complaint_id] [int] NULL,
	[sender_email] [varchar](max) NULL,
	[reciever_email] [varchar](max) NULL,
	[comment_date] [date] NULL,
	[comment_time] [varchar](50) NULL,
	[comment_description] [varchar](max) NULL,
	[type_of_user] [varchar](50) NULL,
	[comment_username] [varchar](50) NULL,
 CONSTRAINT [PK__universi__EFA3B61D1332DBDC] PRIMARY KEY CLUSTERED 
(
	[university_student_comment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_mode_assign](
	[university_mode_assign_id] [int] IDENTITY(1,1) NOT NULL,
	[university_complaint_id] [int] NULL,
	[university_mode_email] [varchar](50) NULL,
	[assign_status] [varchar](20) NULL,
	[reassign_status] [varchar](20) NULL,
	[university_category_id] [int] NULL,
	[reassign_description] [varchar](max) NULL,
	[reassign_request_user] [varchar](50) NULL,
 CONSTRAINT [PK__universi__A1882C2140058253] PRIMARY KEY CLUSTERED 
(
	[university_mode_assign_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university_complaint_report](
	[university_complaint_report_id] [int] IDENTITY(1,1) NOT NULL,
	[university_complaint_id] [int] NULL,
	[university_mode_email] [varchar](50) NULL,
	[type_of_report] [varchar](100) NULL,
	[report_description] [varchar](max) NULL,
	[report_approved] [varchar](20) NULL,
 CONSTRAINT [PK__universi__5679A2E35BAD9CC8] PRIMARY KEY CLUSTERED 
(
	[university_complaint_report_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_student_comment](
	[institute_student_comment_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_complaint_id] [int] NULL,
	[sender_email] [varchar](max) NULL,
	[reciever_email] [varchar](max) NULL,
	[comment_date] [date] NULL,
	[comment_time] [varchar](50) NULL,
	[comment_description] [varchar](max) NULL,
	[type_of_user] [varchar](50) NULL,
	[comment_username] [varchar](50) NULL,
 CONSTRAINT [PK__institut__A172359307C12930] PRIMARY KEY CLUSTERED 
(
	[institute_student_comment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_mode_assign](
	[institute_mode_assign_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_complaint_id] [int] NULL,
	[institute_mode_email] [varchar](50) NULL,
	[assign_status] [varchar](20) NULL,
	[reassign_status] [varchar](20) NULL,
	[institute_category_id] [int] NULL,
	[reassign_description] [varchar](max) NULL,
	[reassign_request_user] [varchar](50) NULL,
 CONSTRAINT [PK__institut__BA2BF26D2FCF1A8A] PRIMARY KEY CLUSTERED 
(
	[institute_mode_assign_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[institute_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[institute_complaint_report](
	[institute_complaint_report_id] [int] IDENTITY(1,1) NOT NULL,
	[institute_complaint_id] [int] NULL,
	[institute_mode_email] [varchar](50) NULL,
	[type_of_report] [varchar](100) NULL,
	[report_description] [varchar](max) NULL,
	[report_approved] [varchar](20) NULL,
 CONSTRAINT [PK__institut__FE8FC83D503BEA1C] PRIMARY KEY CLUSTERED 
(
	[institute_complaint_report_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_student_comment](
	[department_student_comment_id] [int] IDENTITY(1,1) NOT NULL,
	[department_complaint_id] [int] NULL,
	[sender_email] [varchar](max) NULL,
	[reciever_email] [varchar](max) NULL,
	[comment_date] [date] NULL,
	[comment_time] [varchar](50) NULL,
	[comment_description] [varchar](max) NULL,
	[type_of_user] [varchar](50) NULL,
	[comment_username] [varchar](50) NULL,
 CONSTRAINT [PK__departme__C14F439B0D7A0286] PRIMARY KEY CLUSTERED 
(
	[department_student_comment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_mode_assign](
	[department_mode_assign_id] [int] IDENTITY(1,1) NOT NULL,
	[department_complaint_id] [int] NULL,
	[department_mode_email] [varchar](50) NULL,
	[assign_status] [varchar](20) NULL,
	[reassign_status] [varchar](20) NULL,
	[department_category_id] [int] NULL,
	[reassign_description] [varchar](max) NULL,
	[reassign_request_user] [varchar](50) NULL,
 CONSTRAINT [PK__departme__6AB84F773587F3E0] PRIMARY KEY CLUSTERED 
(
	[department_mode_assign_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department_complaint_report](
	[department_complaint_report_id] [int] IDENTITY(1,1) NOT NULL,
	[department_complaint_id] [int] NULL,
	[department_mode_email] [varchar](50) NULL,
	[type_of_report] [varchar](100) NULL,
	[report_description] [varchar](max) NULL,
	[report_approved] [varchar](20) NULL,
 CONSTRAINT [PK__departme__898640F755F4C372] PRIMARY KEY CLUSTERED 
(
	[department_complaint_report_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_department_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint] ADD  CONSTRAINT [DF_department_complaint]  DEFAULT ('Department') FOR [complaint_level]
GO
/****** Object:  Default [DF_department_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint_report] ADD  CONSTRAINT [DF_department_complaint_report]  DEFAULT (NULL) FOR [report_approved]
GO
/****** Object:  Default [DF_department_mode]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode] ADD  CONSTRAINT [DF_department_mode]  DEFAULT ('No') FOR [status]
GO
/****** Object:  Default [DF_department_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode_assign] ADD  CONSTRAINT [DF_department_mode_assign]  DEFAULT ('Assign') FOR [assign_status]
GO
/****** Object:  Default [DF_department_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode_assign] ADD  CONSTRAINT [DF_department_mode_assign_email]  DEFAULT (NULL) FOR [reassign_status]
GO
/****** Object:  Default [DF_institute_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint] ADD  CONSTRAINT [DF_institute_complaint]  DEFAULT ('Institute') FOR [complaint_level]
GO
/****** Object:  Default [DF_institute_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint_report] ADD  CONSTRAINT [DF_institute_complaint_report]  DEFAULT (NULL) FOR [report_approved]
GO
/****** Object:  Default [DF_institute_mode_status]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode] ADD  CONSTRAINT [DF_institute_mode_status]  DEFAULT ('No') FOR [status]
GO
/****** Object:  Default [DF_institute_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode_assign] ADD  CONSTRAINT [DF_institute_mode_assign]  DEFAULT ('Assign') FOR [assign_status]
GO
/****** Object:  Default [DF_institute_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode_assign] ADD  CONSTRAINT [DF_institute_mode_assign_email]  DEFAULT (NULL) FOR [reassign_status]
GO
/****** Object:  Default [DF_university_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint] ADD  CONSTRAINT [DF_university_complaint]  DEFAULT ('University') FOR [complaint_level]
GO
/****** Object:  Default [DF_university_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint_report] ADD  CONSTRAINT [DF_university_complaint_report]  DEFAULT (NULL) FOR [report_approved]
GO
/****** Object:  Default [DF_university_mode]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode] ADD  CONSTRAINT [DF_university_mode]  DEFAULT ('No') FOR [status]
GO
/****** Object:  Default [DF_university_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode_assign] ADD  CONSTRAINT [DF_university_mode_assign]  DEFAULT ('Assign') FOR [assign_status]
GO
/****** Object:  Default [DF_university_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode_assign] ADD  CONSTRAINT [DF_university_mode_assign_email]  DEFAULT (NULL) FOR [reassign_status]
GO
/****** Object:  ForeignKey [FK_city_states]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[city]  WITH CHECK ADD  CONSTRAINT [FK_city_states] FOREIGN KEY([state_name])
REFERENCES [dbo].[states] ([state_name])
GO
ALTER TABLE [dbo].[city] CHECK CONSTRAINT [FK_city_states]
GO
/****** Object:  ForeignKey [FK_institute]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department]  WITH CHECK ADD  CONSTRAINT [FK_institute] FOREIGN KEY([institute_id])
REFERENCES [dbo].[institute] ([institute_id])
GO
ALTER TABLE [dbo].[department] CHECK CONSTRAINT [FK_institute]
GO
/****** Object:  ForeignKey [FK_department_admin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_admin]  WITH CHECK ADD  CONSTRAINT [FK_department_admin] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([department_id])
GO
ALTER TABLE [dbo].[department_admin] CHECK CONSTRAINT [FK_department_admin]
GO
/****** Object:  ForeignKey [FK_department_category_department_category]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_category]  WITH CHECK ADD  CONSTRAINT [FK_department_category_department_category] FOREIGN KEY([department_category_id])
REFERENCES [dbo].[department_category] ([department_category_id])
GO
ALTER TABLE [dbo].[department_category] CHECK CONSTRAINT [FK_department_category_department_category]
GO
/****** Object:  ForeignKey [FK_departmentcategory_department]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_category]  WITH CHECK ADD  CONSTRAINT [FK_departmentcategory_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([department_id])
GO
ALTER TABLE [dbo].[department_category] CHECK CONSTRAINT [FK_departmentcategory_department]
GO
/****** Object:  ForeignKey [FK_department_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint]  WITH CHECK ADD  CONSTRAINT [FK_department_complaint] FOREIGN KEY([student_email])
REFERENCES [dbo].[student] ([student_email])
GO
ALTER TABLE [dbo].[department_complaint] CHECK CONSTRAINT [FK_department_complaint]
GO
/****** Object:  ForeignKey [FK_departmentcategory_departmentcomplaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint]  WITH CHECK ADD  CONSTRAINT [FK_departmentcategory_departmentcomplaint] FOREIGN KEY([department_category_id])
REFERENCES [dbo].[department_category] ([department_category_id])
GO
ALTER TABLE [dbo].[department_complaint] CHECK CONSTRAINT [FK_departmentcategory_departmentcomplaint]
GO
/****** Object:  ForeignKey [FK_departmentcomplaint_studentacademicdetail]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint]  WITH CHECK ADD  CONSTRAINT [FK_departmentcomplaint_studentacademicdetail] FOREIGN KEY([student_academic_detail_id])
REFERENCES [dbo].[student_academic_detail] ([student_academic_detail_id])
GO
ALTER TABLE [dbo].[department_complaint] CHECK CONSTRAINT [FK_departmentcomplaint_studentacademicdetail]
GO
/****** Object:  ForeignKey [FK_department_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_department_complaint_report] FOREIGN KEY([department_complaint_id])
REFERENCES [dbo].[department_complaint] ([department_complaint_id])
GO
ALTER TABLE [dbo].[department_complaint_report] CHECK CONSTRAINT [FK_department_complaint_report]
GO
/****** Object:  ForeignKey [FK_department_complaint_report_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_department_complaint_report_email] FOREIGN KEY([department_mode_email])
REFERENCES [dbo].[department_mode] ([department_mode_email])
GO
ALTER TABLE [dbo].[department_complaint_report] CHECK CONSTRAINT [FK_department_complaint_report_email]
GO
/****** Object:  ForeignKey [FK_department_mode]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode]  WITH CHECK ADD  CONSTRAINT [FK_department_mode] FOREIGN KEY([department_subadmin_email])
REFERENCES [dbo].[department_subadmin] ([department_subadmin_email])
GO
ALTER TABLE [dbo].[department_mode] CHECK CONSTRAINT [FK_department_mode]
GO
/****** Object:  ForeignKey [FK_department_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_department_mode_assign] FOREIGN KEY([department_complaint_id])
REFERENCES [dbo].[department_complaint] ([department_complaint_id])
GO
ALTER TABLE [dbo].[department_mode_assign] CHECK CONSTRAINT [FK_department_mode_assign]
GO
/****** Object:  ForeignKey [FK_department_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_department_mode_assign_email] FOREIGN KEY([department_mode_email])
REFERENCES [dbo].[department_mode] ([department_mode_email])
GO
ALTER TABLE [dbo].[department_mode_assign] CHECK CONSTRAINT [FK_department_mode_assign_email]
GO
/****** Object:  ForeignKey [fk_universitymodeassign_departmentcategory]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_mode_assign]  WITH CHECK ADD  CONSTRAINT [fk_universitymodeassign_departmentcategory] FOREIGN KEY([department_category_id])
REFERENCES [dbo].[department_category] ([department_category_id])
GO
ALTER TABLE [dbo].[department_mode_assign] CHECK CONSTRAINT [fk_universitymodeassign_departmentcategory]
GO
/****** Object:  ForeignKey [FK_department_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_student_comment]  WITH CHECK ADD  CONSTRAINT [FK_department_student_comment] FOREIGN KEY([department_complaint_id])
REFERENCES [dbo].[department_complaint] ([department_complaint_id])
GO
ALTER TABLE [dbo].[department_student_comment] CHECK CONSTRAINT [FK_department_student_comment]
GO
/****** Object:  ForeignKey [FK_department_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_department_subadmin] FOREIGN KEY([department_admin_email])
REFERENCES [dbo].[department_admin] ([department_admin_email])
GO
ALTER TABLE [dbo].[department_subadmin] CHECK CONSTRAINT [FK_department_subadmin]
GO
/****** Object:  ForeignKey [FK_departmentcategory_departmentsubadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[department_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_departmentcategory_departmentsubadmin] FOREIGN KEY([department_category_id])
REFERENCES [dbo].[department_category] ([department_category_id])
GO
ALTER TABLE [dbo].[department_subadmin] CHECK CONSTRAINT [FK_departmentcategory_departmentsubadmin]
GO
/****** Object:  ForeignKey [FK_university]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute]  WITH CHECK ADD  CONSTRAINT [FK_university] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([university_id])
GO
ALTER TABLE [dbo].[institute] CHECK CONSTRAINT [FK_university]
GO
/****** Object:  ForeignKey [FK_institute_admin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_admin]  WITH CHECK ADD  CONSTRAINT [FK_institute_admin] FOREIGN KEY([institute_id])
REFERENCES [dbo].[institute] ([institute_id])
GO
ALTER TABLE [dbo].[institute_admin] CHECK CONSTRAINT [FK_institute_admin]
GO
/****** Object:  ForeignKey [FK_institutecategory_institute]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_category]  WITH CHECK ADD  CONSTRAINT [FK_institutecategory_institute] FOREIGN KEY([institute_id])
REFERENCES [dbo].[institute] ([institute_id])
GO
ALTER TABLE [dbo].[institute_category] CHECK CONSTRAINT [FK_institutecategory_institute]
GO
/****** Object:  ForeignKey [FK_institute_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint]  WITH CHECK ADD  CONSTRAINT [FK_institute_complaint] FOREIGN KEY([student_email])
REFERENCES [dbo].[student] ([student_email])
GO
ALTER TABLE [dbo].[institute_complaint] CHECK CONSTRAINT [FK_institute_complaint]
GO
/****** Object:  ForeignKey [FK_institutecategory_institutecomplaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint]  WITH CHECK ADD  CONSTRAINT [FK_institutecategory_institutecomplaint] FOREIGN KEY([institute_category_id])
REFERENCES [dbo].[institute_category] ([institute_category_id])
GO
ALTER TABLE [dbo].[institute_complaint] CHECK CONSTRAINT [FK_institutecategory_institutecomplaint]
GO
/****** Object:  ForeignKey [FK_institutecomplaint_studentacademicdetail]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint]  WITH CHECK ADD  CONSTRAINT [FK_institutecomplaint_studentacademicdetail] FOREIGN KEY([student_academic_detail_id])
REFERENCES [dbo].[student_academic_detail] ([student_academic_detail_id])
GO
ALTER TABLE [dbo].[institute_complaint] CHECK CONSTRAINT [FK_institutecomplaint_studentacademicdetail]
GO
/****** Object:  ForeignKey [FK_institute_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_institute_complaint_report] FOREIGN KEY([institute_complaint_id])
REFERENCES [dbo].[institute_complaint] ([institute_complaint_id])
GO
ALTER TABLE [dbo].[institute_complaint_report] CHECK CONSTRAINT [FK_institute_complaint_report]
GO
/****** Object:  ForeignKey [FK_institute_complaint_report_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_institute_complaint_report_email] FOREIGN KEY([institute_mode_email])
REFERENCES [dbo].[institute_mode] ([institute_mode_email])
GO
ALTER TABLE [dbo].[institute_complaint_report] CHECK CONSTRAINT [FK_institute_complaint_report_email]
GO
/****** Object:  ForeignKey [FK_institute_mode]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode]  WITH CHECK ADD  CONSTRAINT [FK_institute_mode] FOREIGN KEY([institute_subadmin_email])
REFERENCES [dbo].[institute_subadmin] ([institute_subadmin_email])
GO
ALTER TABLE [dbo].[institute_mode] CHECK CONSTRAINT [FK_institute_mode]
GO
/****** Object:  ForeignKey [FK_institute_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_institute_mode_assign] FOREIGN KEY([institute_complaint_id])
REFERENCES [dbo].[institute_complaint] ([institute_complaint_id])
GO
ALTER TABLE [dbo].[institute_mode_assign] CHECK CONSTRAINT [FK_institute_mode_assign]
GO
/****** Object:  ForeignKey [FK_institute_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_institute_mode_assign_email] FOREIGN KEY([institute_mode_email])
REFERENCES [dbo].[institute_mode] ([institute_mode_email])
GO
ALTER TABLE [dbo].[institute_mode_assign] CHECK CONSTRAINT [FK_institute_mode_assign_email]
GO
/****** Object:  ForeignKey [fk_institutemodeassign_institutecategory]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_mode_assign]  WITH CHECK ADD  CONSTRAINT [fk_institutemodeassign_institutecategory] FOREIGN KEY([institute_category_id])
REFERENCES [dbo].[institute_category] ([institute_category_id])
GO
ALTER TABLE [dbo].[institute_mode_assign] CHECK CONSTRAINT [fk_institutemodeassign_institutecategory]
GO
/****** Object:  ForeignKey [FK_institute_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_student_comment]  WITH CHECK ADD  CONSTRAINT [FK_institute_student_comment] FOREIGN KEY([institute_complaint_id])
REFERENCES [dbo].[institute_complaint] ([institute_complaint_id])
GO
ALTER TABLE [dbo].[institute_student_comment] CHECK CONSTRAINT [FK_institute_student_comment]
GO
/****** Object:  ForeignKey [FK_institute_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_institute_subadmin] FOREIGN KEY([institute_admin_email])
REFERENCES [dbo].[institute_admin] ([institute_admin_email])
GO
ALTER TABLE [dbo].[institute_subadmin] CHECK CONSTRAINT [FK_institute_subadmin]
GO
/****** Object:  ForeignKey [FK_institutecategory_institutesubadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[institute_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_institutecategory_institutesubadmin] FOREIGN KEY([institute_category_id])
REFERENCES [dbo].[institute_category] ([institute_category_id])
GO
ALTER TABLE [dbo].[institute_subadmin] CHECK CONSTRAINT [FK_institutecategory_institutesubadmin]
GO
/****** Object:  ForeignKey [FK_states_country]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[states]  WITH CHECK ADD  CONSTRAINT [FK_states_country] FOREIGN KEY([country_name])
REFERENCES [dbo].[country] ([country_name])
GO
ALTER TABLE [dbo].[states] CHECK CONSTRAINT [FK_states_country]
GO
/****** Object:  ForeignKey [FK_student_department]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[student]  WITH CHECK ADD  CONSTRAINT [FK_student_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([department_id])
GO
ALTER TABLE [dbo].[student] CHECK CONSTRAINT [FK_student_department]
GO
/****** Object:  ForeignKey [FK_student_institute]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[student]  WITH CHECK ADD  CONSTRAINT [FK_student_institute] FOREIGN KEY([institute_id])
REFERENCES [dbo].[institute] ([institute_id])
GO
ALTER TABLE [dbo].[student] CHECK CONSTRAINT [FK_student_institute]
GO
/****** Object:  ForeignKey [FK_student_university]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[student]  WITH CHECK ADD  CONSTRAINT [FK_student_university] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([university_id])
GO
ALTER TABLE [dbo].[student] CHECK CONSTRAINT [FK_student_university]
GO
/****** Object:  ForeignKey [FK_studentacademicdetail_department]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[student_academic_detail]  WITH CHECK ADD  CONSTRAINT [FK_studentacademicdetail_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([department_id])
GO
ALTER TABLE [dbo].[student_academic_detail] CHECK CONSTRAINT [FK_studentacademicdetail_department]
GO
/****** Object:  ForeignKey [FK_studentacademicdetail_student]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[student_academic_detail]  WITH CHECK ADD  CONSTRAINT [FK_studentacademicdetail_student] FOREIGN KEY([student_email])
REFERENCES [dbo].[student] ([student_email])
GO
ALTER TABLE [dbo].[student_academic_detail] CHECK CONSTRAINT [FK_studentacademicdetail_student]
GO
/****** Object:  ForeignKey [FK_university_admin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_admin]  WITH CHECK ADD  CONSTRAINT [FK_university_admin] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([university_id])
GO
ALTER TABLE [dbo].[university_admin] CHECK CONSTRAINT [FK_university_admin]
GO
/****** Object:  ForeignKey [FK_universitycategory_university]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_category]  WITH CHECK ADD  CONSTRAINT [FK_universitycategory_university] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([university_id])
GO
ALTER TABLE [dbo].[university_category] CHECK CONSTRAINT [FK_universitycategory_university]
GO
/****** Object:  ForeignKey [FK_university_complaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint]  WITH CHECK ADD  CONSTRAINT [FK_university_complaint] FOREIGN KEY([student_email])
REFERENCES [dbo].[student] ([student_email])
GO
ALTER TABLE [dbo].[university_complaint] CHECK CONSTRAINT [FK_university_complaint]
GO
/****** Object:  ForeignKey [FK_universitycategory_universitycomplaint]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint]  WITH CHECK ADD  CONSTRAINT [FK_universitycategory_universitycomplaint] FOREIGN KEY([university_category_id])
REFERENCES [dbo].[university_category] ([university_category_id])
GO
ALTER TABLE [dbo].[university_complaint] CHECK CONSTRAINT [FK_universitycategory_universitycomplaint]
GO
/****** Object:  ForeignKey [FK_universitycomplaint_studentacademicdetail]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint]  WITH CHECK ADD  CONSTRAINT [FK_universitycomplaint_studentacademicdetail] FOREIGN KEY([student_academic_detail_id])
REFERENCES [dbo].[student_academic_detail] ([student_academic_detail_id])
GO
ALTER TABLE [dbo].[university_complaint] CHECK CONSTRAINT [FK_universitycomplaint_studentacademicdetail]
GO
/****** Object:  ForeignKey [FK_university_complaint_report]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_university_complaint_report] FOREIGN KEY([university_complaint_id])
REFERENCES [dbo].[university_complaint] ([university_complaint_id])
GO
ALTER TABLE [dbo].[university_complaint_report] CHECK CONSTRAINT [FK_university_complaint_report]
GO
/****** Object:  ForeignKey [FK_university_complaint_report_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_complaint_report]  WITH CHECK ADD  CONSTRAINT [FK_university_complaint_report_email] FOREIGN KEY([university_mode_email])
REFERENCES [dbo].[university_mode] ([university_mode_email])
GO
ALTER TABLE [dbo].[university_complaint_report] CHECK CONSTRAINT [FK_university_complaint_report_email]
GO
/****** Object:  ForeignKey [FK_university_mode]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode]  WITH CHECK ADD  CONSTRAINT [FK_university_mode] FOREIGN KEY([university_subadmin_email])
REFERENCES [dbo].[university_subadmin] ([university_subadmin_email])
GO
ALTER TABLE [dbo].[university_mode] CHECK CONSTRAINT [FK_university_mode]
GO
/****** Object:  ForeignKey [FK_university_mode_assign]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_university_mode_assign] FOREIGN KEY([university_complaint_id])
REFERENCES [dbo].[university_complaint] ([university_complaint_id])
GO
ALTER TABLE [dbo].[university_mode_assign] CHECK CONSTRAINT [FK_university_mode_assign]
GO
/****** Object:  ForeignKey [FK_university_mode_assign_email]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode_assign]  WITH CHECK ADD  CONSTRAINT [FK_university_mode_assign_email] FOREIGN KEY([university_mode_email])
REFERENCES [dbo].[university_mode] ([university_mode_email])
GO
ALTER TABLE [dbo].[university_mode_assign] CHECK CONSTRAINT [FK_university_mode_assign_email]
GO
/****** Object:  ForeignKey [fk_universitymodeassign_universitycategory]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_mode_assign]  WITH CHECK ADD  CONSTRAINT [fk_universitymodeassign_universitycategory] FOREIGN KEY([university_category_id])
REFERENCES [dbo].[university_category] ([university_category_id])
GO
ALTER TABLE [dbo].[university_mode_assign] CHECK CONSTRAINT [fk_universitymodeassign_universitycategory]
GO
/****** Object:  ForeignKey [FK_university_student_comment]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_student_comment]  WITH CHECK ADD  CONSTRAINT [FK_university_student_comment] FOREIGN KEY([university_complaint_id])
REFERENCES [dbo].[university_complaint] ([university_complaint_id])
GO
ALTER TABLE [dbo].[university_student_comment] CHECK CONSTRAINT [FK_university_student_comment]
GO
/****** Object:  ForeignKey [FK_university_subadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_university_subadmin] FOREIGN KEY([university_admin_email])
REFERENCES [dbo].[university_admin] ([university_admin_email])
GO
ALTER TABLE [dbo].[university_subadmin] CHECK CONSTRAINT [FK_university_subadmin]
GO
/****** Object:  ForeignKey [FK_universitycategory_universitysubadmin]    Script Date: 04/01/2020 05:31:16 ******/
ALTER TABLE [dbo].[university_subadmin]  WITH CHECK ADD  CONSTRAINT [FK_universitycategory_universitysubadmin] FOREIGN KEY([university_category_id])
REFERENCES [dbo].[university_category] ([university_category_id])
GO
ALTER TABLE [dbo].[university_subadmin] CHECK CONSTRAINT [FK_universitycategory_universitysubadmin]
GO
