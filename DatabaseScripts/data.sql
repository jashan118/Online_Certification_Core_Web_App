SET IDENTITY_INSERT [dbo].[Certification] ON
INSERT INTO [dbo].[Certification] ([Id], [Name], [Organisation], [Price]) VALUES (1, N'Oracle Certified Java Programmer', N'Oracle', CAST(250.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Certification] ([Id], [Name], [Organisation], [Price]) VALUES (2, N'Microsoft Certified Web Developer', N'Microsoft', CAST(300.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Certification] ([Id], [Name], [Organisation], [Price]) VALUES (3, N'Cisco Certified Network Administrator', N'Cisco', CAST(350.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Certification] OFF
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([Id], [Name], [Contact]) VALUES (1, N'Ken Smith', N'0214567890')
INSERT INTO [dbo].[Student] ([Id], [Name], [Contact]) VALUES (2, N'John Franklin', N'0213888905')
INSERT INTO [dbo].[Student] ([Id], [Name], [Contact]) VALUES (3, N'David Thomson', N'0216667890')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Exam] ON
INSERT INTO [dbo].[Exam] ([Id], [CertificationId], [StudentId], [Marks]) VALUES (1, 1, 1, 90)
INSERT INTO [dbo].[Exam] ([Id], [CertificationId], [StudentId], [Marks]) VALUES (2, 2, 3, 95)
INSERT INTO [dbo].[Exam] ([Id], [CertificationId], [StudentId], [Marks]) VALUES (3, 3, 2, 92)
INSERT INTO [dbo].[Exam] ([Id], [CertificationId], [StudentId], [Marks]) VALUES (4, 1, 3, 98)
SET IDENTITY_INSERT [dbo].[Exam] OFF
