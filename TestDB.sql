USE [TestDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NOT NULL,
	[Address2] [nvarchar](50) NOT NULL,
	[Address3] [nvarchar](50) NOT NULL,
	[Town] [nvarchar](50) NOT NULL,
	[County] [nvarchar](50) NOT NULL,
	[Postcode] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerHistory]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerHistory](
	[CustomerHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[EditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerHistory] PRIMARY KEY CLUSTERED 
(
	[CustomerHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([CustomerID], [Title], [FirstName], [Surname], [Address1], [Address2], [Address3], [Town], [County], [Postcode]) VALUES (11, N'Mr', N'Norville', N'Ramsbottom', N'1 High Street', N'Wombourne', N'', N'Wolverhampton', N'West Midlands', N'WV5 9TD')
GO
INSERT [dbo].[Customer] ([CustomerID], [Title], [FirstName], [Surname], [Address1], [Address2], [Address3], [Town], [County], [Postcode]) VALUES (12, N'Miss', N'Florence', N'Torrance', N'209 Gatcombe Close', N'Moseley', N'', N'Wolverhampton', N'West Midlands', N'WV10 8WT')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerHistory] ON 
GO
INSERT [dbo].[CustomerHistory] ([CustomerHistoryID], [CustomerID], [EditDate]) VALUES (31, 11, CAST(N'2024-09-02T22:01:50.240' AS DateTime))
GO
INSERT [dbo].[CustomerHistory] ([CustomerHistoryID], [CustomerID], [EditDate]) VALUES (32, 12, CAST(N'2024-09-02T22:03:12.183' AS DateTime))
GO
INSERT [dbo].[CustomerHistory] ([CustomerHistoryID], [CustomerID], [EditDate]) VALUES (33, 12, CAST(N'2024-09-02T22:03:17.187' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CustomerHistory] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer]    Script Date: 02/09/2024 22:06:52 ******/
CREATE NONCLUSTERED INDEX [IX_Customer] ON [dbo].[Customer]
(
	[FirstName] ASC,
	[Surname] ASC,
	[Address1] ASC,
	[Address2] ASC,
	[Address3] ASC,
	[Town] ASC,
	[County] ASC,
	[Postcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Customer#Create]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customer#Create]

	@title nvarchar(10),
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@address1 nvarchar(50),
	@address2 nvarchar(50),
	@address3 nvarchar(50),
	@town nvarchar(50),
	@county nvarchar(50),
	@postcode nvarchar(8)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO Customer (Title, FirstName, Surname, Address1, Address2, Address3, Town, County, Postcode)
	OUTPUT inserted.CustomerID
	VALUES
	(
		@title,
		@firstName,
		@surname,
		@address1,
		@address2,
		@address3,
		@town,
		@county,
		@postcode
	)

END
GO
/****** Object:  StoredProcedure [dbo].[Customer#Delete]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customer#Delete]
	
	@customerID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Customer WHERE CustomerID = @customerID
END
GO
/****** Object:  StoredProcedure [dbo].[Customer#Get]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customer#Get]
	@customerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM Customer WHERE CustomerID = @customerID
END
GO
/****** Object:  StoredProcedure [dbo].[Customer#Update]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customer#Update]
	@customerID int,
	@title nvarchar(10),
	@firstName nvarchar(50),
	@surname nvarchar(50),
	@address1 nvarchar(50),
	@address2 nvarchar(50),
	@address3 nvarchar(50),
	@town nvarchar(50),
	@county nvarchar(50),
	@postcode nvarchar(8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Customer SET
		Title = @title,
		FirstName = @firstName,
		Surname = @surname,
		Address1 = @address1,
		Address2 = @address2,
		Address3 = @address3,
		Town = @town,
		County = @county,
		Postcode = @postcode
	WHERE CustomerID = @customerID

END
GO
/****** Object:  StoredProcedure [dbo].[CustomerHistory#Create]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CustomerHistory#Create]
	@customerID int,
	@editDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO CustomerHistory (CustomerID, EditDate)
	OUTPUT inserted.CustomerHistoryID
	VALUES
	(
		@customerID,
		@editDate
	)
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerHistory#DeleteForCustomer]    Script Date: 02/09/2024 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CustomerHistory#DeleteForCustomer]
	@customerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM CustomerHistory WHERE CustomerID = @customerID
END
GO
