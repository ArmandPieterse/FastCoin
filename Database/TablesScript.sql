USE [FastTraderDB]
GO
/****** Object:  Table [dbo].[tbl_Buys]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Buys](
	[pk_tbl_Buys] [uniqueidentifier] NOT NULL,
	[fk_tbl_Wallet] [uniqueidentifier] NOT NULL,
	[tbl_Buys_BTCTargetAmount] [decimal](14, 8) NOT NULL,
	[tbl_Buys_ZARPrice] [decimal](18, 2) NOT NULL,
	[tbl_Buys_BTCBought] [decimal](14, 2) NOT NULL,
	[tbl_Buys_Status] [nvarchar](20) NOT NULL,
	[tbl_Buys_DateCreated] [datetime] NOT NULL,
	[tbl_Buys_DateLastModified] [datetime] NOT NULL,
	[tbl_Buys_ZARTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tbl_Buys] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_Buys] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Email]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Email](
	[pk_tbl_Email] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[tbl_Email_Subject] [nvarchar](250) NOT NULL,
	[tbl_Email_Type] [nvarchar](50) NOT NULL,
	[tbl_Email_Body] [nvarchar](max) NOT NULL,
	[tbl_Email_From] [nvarchar](200) NOT NULL,
	[tbl_Email_To] [nvarchar](200) NOT NULL,
	[tbl_Email_DateCreated] [datetime] NOT NULL,
	[tbl_Email_DateLastModified] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Email] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_FAQ]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FAQ](
	[pk_tbl_FAQ] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[tbl_FAQ_Title] [nvarchar](200) NOT NULL,
	[tbl_FAQ_Content] [nvarchar](max) NOT NULL,
	[tbl_FAQ_DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_FAQ] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_FAQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_News]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_News](
	[pk_tbl_News] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[tbl_News_Title] [nvarchar](200) NOT NULL,
	[tbl_News_Paragraph] [nvarchar](max) NULL,
	[tbl_News_VideoLink] [nvarchar](max) NULL,
	[tbl_News_DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_News] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_News] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Sales]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Sales](
	[pk_tbl_Sales] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[fk_tbl_Wallet] [uniqueidentifier] NOT NULL,
	[tbl_Sales_BTCTargetAmount] [decimal](14, 8) NOT NULL,
	[tbl_Sales_ZARPrice] [decimal](18, 2) NOT NULL,
	[tbl_Sales_ZARTotal] [decimal](18, 2) NOT NULL,
	[tbl_Sales_BTCSold] [decimal](14, 8) NOT NULL,
	[tbl_Sales_Status] [nvarchar](20) NOT NULL,
	[tbl_Sales_DateCreated] [datetime] NOT NULL,
	[tbl_Sales_DateLastModified] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Sales] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_Sales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserAccount]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserAccount](
	[pk_tbl_UserAccount] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_tbl_UserAccount_pk_tbl_UserAccount]  DEFAULT (newid()),
	[tbl_UserAccount_EmailAddress] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_Firstname] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_Surname] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_PhysicalAddressLine1] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_PhysicalAddressLine2] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_PhysicalAddressLine3] [nvarchar](200) NOT NULL,
	[tbl_UserAccount_PostalCode] [nvarchar](10) NOT NULL,
	[tbl_UserAccount_CellphoneNumber] [nvarchar](13) NULL,
	[tbl_UserAccount_UserRole] [nvarchar](10) NOT NULL,
	[tbl_UserAccount_Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_UserAccount] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_UserAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Wallet]    Script Date: 8/20/2016 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Wallet](
	[pk_tbl_Wallet] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_tbl_Wallet_pk_tbl_Wallet]  DEFAULT (newid()),
	[fk_tbl_UserAccount] [uniqueidentifier] NOT NULL,
	[tbl_Wallet_ZARBalance] [decimal](18, 2) NOT NULL,
	[tbl_Wallet_BTCBalance] [decimal](14, 8) NOT NULL,
	[tbl_Wallet_BTCAddress] [nchar](64) NOT NULL,
	[tbl_Wallet_BankAccNumber] [nvarchar](20) NOT NULL,
	[tbl_Wallet_BankName] [nvarchar](100) NOT NULL,
	[tbl_Wallet_BankBranchName] [nvarchar](100) NOT NULL,
	[tbl_Wallet_BankBranchNumber] [nvarchar](26) NOT NULL,
	[tbl_Wallet_DateCreated] [datetime] NOT NULL,
	[tbl_Wallet_DateLastModified] [datetime] NOT NULL,
	[tbl_Wallet_ZARPending] [decimal](18, 2) NOT NULL,
	[tbl_Wallet_CodeFactory] [varbinary](32) NOT NULL,
	[tbl_Wallet_BTCPending] [decimal](14, 8) NOT NULL DEFAULT ((0.00000000)),
 CONSTRAINT [PK_tbl_Wallet] PRIMARY KEY CLUSTERED 
(
	[pk_tbl_Wallet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbl_Buys] ADD  CONSTRAINT [DF_tbl_Buys_pk_tbl_Buys]  DEFAULT (newid()) FOR [pk_tbl_Buys]
GO
ALTER TABLE [dbo].[tbl_Email] ADD  CONSTRAINT [DF_tbl_Email_pk_tbl_Email]  DEFAULT (newid()) FOR [pk_tbl_Email]
GO
ALTER TABLE [dbo].[tbl_FAQ] ADD  CONSTRAINT [DF_tbl_FAQ_pk_tbl_FAQ]  DEFAULT (newid()) FOR [pk_tbl_FAQ]
GO
ALTER TABLE [dbo].[tbl_News] ADD  CONSTRAINT [DF_tbl_News_pk_tbl_News]  DEFAULT (newid()) FOR [pk_tbl_News]
GO
ALTER TABLE [dbo].[tbl_Sales] ADD  CONSTRAINT [DF_tbl_Sales_pk_tbl_Sales]  DEFAULT (newid()) FOR [pk_tbl_Sales]
GO
ALTER TABLE [dbo].[tbl_Buys]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Buys_tbl_Wallet] FOREIGN KEY([fk_tbl_Wallet])
REFERENCES [dbo].[tbl_Wallet] ([pk_tbl_Wallet])
GO
ALTER TABLE [dbo].[tbl_Buys] CHECK CONSTRAINT [FK_tbl_Buys_tbl_Wallet]
GO
ALTER TABLE [dbo].[tbl_Sales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Sales_tbl_Wallet] FOREIGN KEY([fk_tbl_Wallet])
REFERENCES [dbo].[tbl_Wallet] ([pk_tbl_Wallet])
GO
ALTER TABLE [dbo].[tbl_Sales] CHECK CONSTRAINT [FK_tbl_Sales_tbl_Wallet]
GO
ALTER TABLE [dbo].[tbl_Wallet]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Wallet_tbl_UserAccount] FOREIGN KEY([fk_tbl_UserAccount])
REFERENCES [dbo].[tbl_UserAccount] ([pk_tbl_UserAccount])
GO
ALTER TABLE [dbo].[tbl_Wallet] CHECK CONSTRAINT [FK_tbl_Wallet_tbl_UserAccount]
GO
