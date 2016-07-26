
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2016 20:27:40
-- Generated from EDMX file: C:\Users\Aashiq\Documents\Pipe\GitProjects\Bitcoin\FastCoin\FastCoin\EntityModels\FastCoinTrader.EnitityModels\FastCoinTraderContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FastCoinTraderDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tbl_Buys_tbl_Wallet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Buys] DROP CONSTRAINT [FK_tbl_Buys_tbl_Wallet];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Sales_tbl_Wallet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Sales] DROP CONSTRAINT [FK_tbl_Sales_tbl_Wallet];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Wallet_tbl_UserAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Wallet] DROP CONSTRAINT [FK_tbl_Wallet_tbl_UserAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tbl_Buys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Buys];
GO
IF OBJECT_ID(N'[dbo].[tbl_Email]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Email];
GO
IF OBJECT_ID(N'[dbo].[tbl_Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Sales];
GO
IF OBJECT_ID(N'[dbo].[tbl_UserAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_UserAccount];
GO
IF OBJECT_ID(N'[dbo].[tbl_Wallet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Wallet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbl_Email'
CREATE TABLE [dbo].[tbl_Email] (
    [pk_tbl_Email] uniqueidentifier  NOT NULL,
    [tbl_Email_Subject] nvarchar(250)  NOT NULL,
    [tbl_Email_Type] nvarchar(50)  NOT NULL,
    [tbl_Email_Body] nvarchar(max)  NOT NULL,
    [tbl_Email_From] nvarchar(200)  NOT NULL,
    [tbl_Email_To] nvarchar(200)  NOT NULL,
    [tbl_Email_DateCreated] datetime  NOT NULL,
    [tbl_Email_DateLastModified] datetime  NOT NULL
);
GO

-- Creating table 'tbl_Sales'
CREATE TABLE [dbo].[tbl_Sales] (
    [pk_tbl_Sales] uniqueidentifier  NOT NULL,
    [fk_tbl_Wallet] uniqueidentifier  NOT NULL,
    [tbl_Sales_ZARPrice] decimal(18,2)  NOT NULL,
    [tbl_Sales_BTCSold] decimal(14,8)  NOT NULL,
    [tbl_Sales_Status] nvarchar(20)  NOT NULL,
    [tbl_Sales_DateCreated] datetime  NOT NULL,
    [tbl_Sales_DateLastModified] datetime  NOT NULL,
    [tbl_Sales_ZARTotal] decimal(18,2)  NOT NULL,
    [tbl_Sales_BTCTargetAmount] decimal(14,8)  NOT NULL
);
GO

-- Creating table 'tbl_UserAccount'
CREATE TABLE [dbo].[tbl_UserAccount] (
    [pk_tbl_UserAccount] uniqueidentifier  NOT NULL,
    [tbl_UserAccount_EmailAddress] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_Firstname] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_Surname] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_PhysicalAddressLine1] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_PhysicalAddressLine2] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_PhysicalAddressLine3] nvarchar(200)  NOT NULL,
    [tbl_UserAccount_PostalCode] nvarchar(10)  NOT NULL,
    [tbl_UserAccount_CellphoneNumber] nvarchar(13)  NULL,
    [tbl_UserAccount_UserRole] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'tbl_Wallet'
CREATE TABLE [dbo].[tbl_Wallet] (
    [pk_tbl_Wallet] uniqueidentifier  NOT NULL,
    [fk_tbl_UserAccount] uniqueidentifier  NOT NULL,
    [tbl_Wallet_ZARBalance] decimal(18,2)  NOT NULL,
    [tbl_Wallet_BTCBalance] decimal(14,8)  NOT NULL,
    [tbl_Wallet_BTCAddress] nchar(64)  NOT NULL,
    [tbl_Wallet_BankAccNumber] nvarchar(20)  NOT NULL,
    [tbl_Wallet_BankName] nvarchar(100)  NOT NULL,
    [tbl_Wallet_BankBranchName] nvarchar(100)  NOT NULL,
    [tbl_Wallet_BankBranchNumber] nvarchar(26)  NOT NULL,
    [tbl_Wallet_DateCreated] datetime  NOT NULL,
    [tbl_Wallet_DateLastModified] datetime  NOT NULL,
    [tbl_Wallet_ZARPending] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'tbl_Buys'
CREATE TABLE [dbo].[tbl_Buys] (
    [pk_tbl_Buys] uniqueidentifier  NOT NULL,
    [fk_tbl_Wallet] uniqueidentifier  NOT NULL,
    [tbl_Buys_BTCTargetAmount] decimal(14,8)  NOT NULL,
    [tbl_Buys_ZARPrice] decimal(18,2)  NOT NULL,
    [tbl_Buys_BTCBought] decimal(14,2)  NOT NULL,
    [tbl_Buys_Status] nvarchar(20)  NOT NULL,
    [tbl_Buys_DateCreated] datetime  NOT NULL,
    [tbl_Buys_DateLastModified] datetime  NOT NULL,
    [tbl_Buys_ZARTotal] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [pk_tbl_Email] in table 'tbl_Email'
ALTER TABLE [dbo].[tbl_Email]
ADD CONSTRAINT [PK_tbl_Email]
    PRIMARY KEY CLUSTERED ([pk_tbl_Email] ASC);
GO

-- Creating primary key on [pk_tbl_Sales] in table 'tbl_Sales'
ALTER TABLE [dbo].[tbl_Sales]
ADD CONSTRAINT [PK_tbl_Sales]
    PRIMARY KEY CLUSTERED ([pk_tbl_Sales] ASC);
GO

-- Creating primary key on [pk_tbl_UserAccount] in table 'tbl_UserAccount'
ALTER TABLE [dbo].[tbl_UserAccount]
ADD CONSTRAINT [PK_tbl_UserAccount]
    PRIMARY KEY CLUSTERED ([pk_tbl_UserAccount] ASC);
GO

-- Creating primary key on [pk_tbl_Wallet] in table 'tbl_Wallet'
ALTER TABLE [dbo].[tbl_Wallet]
ADD CONSTRAINT [PK_tbl_Wallet]
    PRIMARY KEY CLUSTERED ([pk_tbl_Wallet] ASC);
GO

-- Creating primary key on [pk_tbl_Buys] in table 'tbl_Buys'
ALTER TABLE [dbo].[tbl_Buys]
ADD CONSTRAINT [PK_tbl_Buys]
    PRIMARY KEY CLUSTERED ([pk_tbl_Buys] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fk_tbl_Wallet] in table 'tbl_Sales'
ALTER TABLE [dbo].[tbl_Sales]
ADD CONSTRAINT [FK_tbl_Sales_tbl_Wallet]
    FOREIGN KEY ([fk_tbl_Wallet])
    REFERENCES [dbo].[tbl_Wallet]
        ([pk_tbl_Wallet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Sales_tbl_Wallet'
CREATE INDEX [IX_FK_tbl_Sales_tbl_Wallet]
ON [dbo].[tbl_Sales]
    ([fk_tbl_Wallet]);
GO

-- Creating foreign key on [fk_tbl_UserAccount] in table 'tbl_Wallet'
ALTER TABLE [dbo].[tbl_Wallet]
ADD CONSTRAINT [FK_tbl_Wallet_tbl_UserAccount]
    FOREIGN KEY ([fk_tbl_UserAccount])
    REFERENCES [dbo].[tbl_UserAccount]
        ([pk_tbl_UserAccount])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Wallet_tbl_UserAccount'
CREATE INDEX [IX_FK_tbl_Wallet_tbl_UserAccount]
ON [dbo].[tbl_Wallet]
    ([fk_tbl_UserAccount]);
GO

-- Creating foreign key on [fk_tbl_Wallet] in table 'tbl_Buys'
ALTER TABLE [dbo].[tbl_Buys]
ADD CONSTRAINT [FK_tbl_Buys_tbl_Wallet]
    FOREIGN KEY ([fk_tbl_Wallet])
    REFERENCES [dbo].[tbl_Wallet]
        ([pk_tbl_Wallet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Buys_tbl_Wallet'
CREATE INDEX [IX_FK_tbl_Buys_tbl_Wallet]
ON [dbo].[tbl_Buys]
    ([fk_tbl_Wallet]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------