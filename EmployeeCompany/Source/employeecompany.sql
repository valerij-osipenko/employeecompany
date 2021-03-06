USE [EmployeeCompanyDb]
GO
SET IDENTITY_INSERT [dbo].[StatusTypes] ON 

INSERT [dbo].[StatusTypes] ([Id], [StatusName]) VALUES (1, N'Активен')
INSERT [dbo].[StatusTypes] ([Id], [StatusName]) VALUES (2, N'Неактивен')
SET IDENTITY_INSERT [dbo].[StatusTypes] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (1, N'Иванов И.И.', N'Директор', 1, 500000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (2, N'Петров А.А.', N'Зам директора', 1, 30000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (3, N'Орхипова С.М.', N'Бухгалтер', 1, 25000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (4, N'Бондаренко С.М.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (5, N'Бусиллов М.Е.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (6, N'Бусилл М.Е.', N'Менеджер', 1, 15000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (7, N'Иващенко И.И.', N'Менеджер', 2, 50000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (8, N'Петрский А.А.', N'Администратор', 1, 30000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (9, N'Орхипова С.М.', N'Бухгалтер', 1, 25000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (10, N'Бондаренко С.М.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (11, N'Бусиллов М.Е.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (12, N'Бусилл М.Е.', N'Менеджер', 1, 15000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (13, N'Иванов И.И.', N'Директор', 1, 500000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (14, N'Сандерсон А.А.', N'Зам директора', 1, 300000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (15, N'Орхипова С.М.', N'Бухгалтер', 1, 25000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (16, N'Бондаренко С.М.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (17, N'Бусиллов М.Е.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (18, N'Бусилл М.Е.', N'Менеджер', 1, 15000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (19, N'Иванов И.М.', N'Куръер', 1, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (20, N'Архипов  А.А.', N'Администратор', 1, 3000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (21, N'Орхипова С.М.', N'Бухгалтер', 1, 25000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (22, N'Бондаренко С.М.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (23, N'Бусиллов М.Е.', N'Менеджер', 2, 10000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (24, N'Бусилл М.Е.', N'Менеджер', 1, 15000)
INSERT [dbo].[Employees] ([Id], [Name], [Post], [StatusTypeId], [Salary]) VALUES (25, N'Брусилов А.Л.', N'Бухгалтер', 1, 10000.45)
SET IDENTITY_INSERT [dbo].[Employees] OFF
