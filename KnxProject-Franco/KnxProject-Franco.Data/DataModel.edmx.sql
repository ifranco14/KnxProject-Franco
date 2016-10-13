
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2016 00:22:29
-- Generated from EDMX file: C:\Users\Ignacio\Source\Repos\KnxProject-Franco\KnxProject-Franco\KnxProject-Franco.Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KnxProject_FrancoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourtCaseDetails_CourtCases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCaseDetails] DROP CONSTRAINT [FK_CourtCaseDetails_CourtCases];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseDetails_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCaseDetails] DROP CONSTRAINT [FK_CourtCaseDetails_States];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCases_CourtBranches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCases] DROP CONSTRAINT [FK_CourtCases_CourtBranches];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCases_States]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCases] DROP CONSTRAINT [FK_CourtCases_States];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_CurrentCases_Clients]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[CurrentCases] DROP CONSTRAINT [FK_CurrentCases_Clients];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_CurrentCases_CourtCases]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[CurrentCases] DROP CONSTRAINT [FK_CurrentCases_CourtCases];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyerCourtBranches_CourtBranches]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtBranches] DROP CONSTRAINT [FK_LawyerCourtBranches_CourtBranches];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyerCourtBranches_Lawyers]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtBranches] DROP CONSTRAINT [FK_LawyerCourtBranches_Lawyers];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyerCourtCases_CourtCases]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtCases] DROP CONSTRAINT [FK_LawyerCourtCases_CourtCases];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyerCourtCases_Lawyers]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtCases] DROP CONSTRAINT [FK_LawyerCourtCases_Lawyers];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyersQuerys_Lawyers]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyersQuerys] DROP CONSTRAINT [FK_LawyersQuerys_Lawyers];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[FK_LawyersQuerys_QAs]', 'F') IS NOT NULL
    ALTER TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyersQuerys] DROP CONSTRAINT [FK_LawyersQuerys_QAs];
GO
IF OBJECT_ID(N'[dbo].[FK_News_CourtBranches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[News] DROP CONSTRAINT [FK_News_CourtBranches];
GO
IF OBJECT_ID(N'[dbo].[FK_News_Scopes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[News] DROP CONSTRAINT [FK_News_Scopes];
GO
IF OBJECT_ID(N'[dbo].[FK_Persons_DocumentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_DocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_QAs_CourtCaseDetails1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QAs] DROP CONSTRAINT [FK_QAs_CourtCaseDetails1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[CourtBranches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtBranches];
GO
IF OBJECT_ID(N'[dbo].[CourtCaseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCaseDetails];
GO
IF OBJECT_ID(N'[dbo].[CourtCases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCases];
GO
IF OBJECT_ID(N'[dbo].[DocumentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Lawyers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lawyers];
GO
IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[QAs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QAs];
GO
IF OBJECT_ID(N'[dbo].[Scopes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Scopes];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[CurrentCases]', 'U') IS NOT NULL
    DROP TABLE [KnxProject_FrancoDBModelStoreContainer].[CurrentCases];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[LawyerCourtBranches]', 'U') IS NOT NULL
    DROP TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtBranches];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[LawyerCourtCases]', 'U') IS NOT NULL
    DROP TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyerCourtCases];
GO
IF OBJECT_ID(N'[KnxProject_FrancoDBModelStoreContainer].[LawyersQuerys]', 'U') IS NOT NULL
    DROP TABLE [KnxProject_FrancoDBModelStoreContainer].[LawyersQuerys];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'DocumentTypes'
CREATE TABLE [dbo].[DocumentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Scopes'
CREATE TABLE [dbo].[Scopes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CourtBranches'
CREATE TABLE [dbo].[CourtBranches] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'CourtCaseDetails'
CREATE TABLE [dbo].[CourtCaseDetails] (
    [CaseId] int  NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    [Comment] nvarchar(250)  NOT NULL,
    [Date] datetime  NOT NULL,
    [StatusId] int  NOT NULL
);
GO

-- Creating table 'CourtCases'
CREATE TABLE [dbo].[CourtCases] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CurrentStatusId] int  NOT NULL,
    [CourtBranchId] int  NOT NULL,
    [LawyerId] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [CourtBranchId] int  NOT NULL,
    [Body] nvarchar(2000)  NOT NULL,
    [Place] nvarchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [LetterHead] nvarchar(100)  NOT NULL,
    [ScopeID] int  NOT NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [CellPhoneNumber] nvarchar(30)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [DocumentTypeId] int  NOT NULL,
    [DocumentNumber] nvarchar(12)  NOT NULL
);
GO

-- Creating table 'QAs'
CREATE TABLE [dbo].[QAs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CourtCaseDetailID] int  NOT NULL,
    [Query] nvarchar(250)  NOT NULL,
    [SendDate] datetime  NOT NULL,
    [Answer] nvarchar(250)  NULL,
    [AnswerDate] datetime  NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Persons_Clients'
CREATE TABLE [dbo].[Persons_Clients] (
    [IDClient] int IDENTITY(1,1) NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Persons_Lawyers'
CREATE TABLE [dbo].[Persons_Lawyers] (
    [IDLawyer] int IDENTITY(1,1) NOT NULL,
    [ProfessionalLicense] int  NOT NULL,
    [ContractDate] datetime  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'Persons_Employees'
CREATE TABLE [dbo].[Persons_Employees] (
    [IDEmployee] int IDENTITY(1,1) NOT NULL,
    [Employment] nvarchar(50)  NOT NULL,
    [ContractDate] datetime  NOT NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'CurrentCases'
CREATE TABLE [dbo].[CurrentCases] (
    [Clients_ID] int  NOT NULL,
    [CourtCases_ID] int  NOT NULL
);
GO

-- Creating table 'LawyerCourtBranches'
CREATE TABLE [dbo].[LawyerCourtBranches] (
    [CourtBranches_ID] int  NOT NULL,
    [Lawyers_ID] int  NOT NULL
);
GO

-- Creating table 'LawyerCourtCases'
CREATE TABLE [dbo].[LawyerCourtCases] (
    [CourtCases_ID] int  NOT NULL,
    [Lawyers_ID] int  NOT NULL
);
GO

-- Creating table 'LawyersQuerys'
CREATE TABLE [dbo].[LawyersQuerys] (
    [Lawyers_ID] int  NOT NULL,
    [QAs_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentTypes'
ALTER TABLE [dbo].[DocumentTypes]
ADD CONSTRAINT [PK_DocumentTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Scopes'
ALTER TABLE [dbo].[Scopes]
ADD CONSTRAINT [PK_Scopes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CourtBranches'
ALTER TABLE [dbo].[CourtBranches]
ADD CONSTRAINT [PK_CourtBranches]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CourtCaseDetails'
ALTER TABLE [dbo].[CourtCaseDetails]
ADD CONSTRAINT [PK_CourtCaseDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CourtCases'
ALTER TABLE [dbo].[CourtCases]
ADD CONSTRAINT [PK_CourtCases]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QAs'
ALTER TABLE [dbo].[QAs]
ADD CONSTRAINT [PK_QAs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Persons_Clients'
ALTER TABLE [dbo].[Persons_Clients]
ADD CONSTRAINT [PK_Persons_Clients]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Persons_Lawyers'
ALTER TABLE [dbo].[Persons_Lawyers]
ADD CONSTRAINT [PK_Persons_Lawyers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Persons_Employees'
ALTER TABLE [dbo].[Persons_Employees]
ADD CONSTRAINT [PK_Persons_Employees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Clients_ID], [CourtCases_ID] in table 'CurrentCases'
ALTER TABLE [dbo].[CurrentCases]
ADD CONSTRAINT [PK_CurrentCases]
    PRIMARY KEY CLUSTERED ([Clients_ID], [CourtCases_ID] ASC);
GO

-- Creating primary key on [CourtBranches_ID], [Lawyers_ID] in table 'LawyerCourtBranches'
ALTER TABLE [dbo].[LawyerCourtBranches]
ADD CONSTRAINT [PK_LawyerCourtBranches]
    PRIMARY KEY CLUSTERED ([CourtBranches_ID], [Lawyers_ID] ASC);
GO

-- Creating primary key on [CourtCases_ID], [Lawyers_ID] in table 'LawyerCourtCases'
ALTER TABLE [dbo].[LawyerCourtCases]
ADD CONSTRAINT [PK_LawyerCourtCases]
    PRIMARY KEY CLUSTERED ([CourtCases_ID], [Lawyers_ID] ASC);
GO

-- Creating primary key on [Lawyers_ID], [QAs_ID] in table 'LawyersQuerys'
ALTER TABLE [dbo].[LawyersQuerys]
ADD CONSTRAINT [PK_LawyersQuerys]
    PRIMARY KEY CLUSTERED ([Lawyers_ID], [QAs_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourtBranchId] in table 'CourtCases'
ALTER TABLE [dbo].[CourtCases]
ADD CONSTRAINT [FK_CourtCases_CourtBranches]
    FOREIGN KEY ([CourtBranchId])
    REFERENCES [dbo].[CourtBranches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCases_CourtBranches'
CREATE INDEX [IX_FK_CourtCases_CourtBranches]
ON [dbo].[CourtCases]
    ([CourtBranchId]);
GO

-- Creating foreign key on [CourtBranchId] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [FK_News_CourtBranches]
    FOREIGN KEY ([CourtBranchId])
    REFERENCES [dbo].[CourtBranches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_News_CourtBranches'
CREATE INDEX [IX_FK_News_CourtBranches]
ON [dbo].[News]
    ([CourtBranchId]);
GO

-- Creating foreign key on [CaseId] in table 'CourtCaseDetails'
ALTER TABLE [dbo].[CourtCaseDetails]
ADD CONSTRAINT [FK_CourtCaseDetails_CourtCases]
    FOREIGN KEY ([CaseId])
    REFERENCES [dbo].[CourtCases]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseDetails_CourtCases'
CREATE INDEX [IX_FK_CourtCaseDetails_CourtCases]
ON [dbo].[CourtCaseDetails]
    ([CaseId]);
GO

-- Creating foreign key on [StatusId] in table 'CourtCaseDetails'
ALTER TABLE [dbo].[CourtCaseDetails]
ADD CONSTRAINT [FK_CourtCaseDetails_States]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[States]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseDetails_States'
CREATE INDEX [IX_FK_CourtCaseDetails_States]
ON [dbo].[CourtCaseDetails]
    ([StatusId]);
GO

-- Creating foreign key on [CourtCaseDetailID] in table 'QAs'
ALTER TABLE [dbo].[QAs]
ADD CONSTRAINT [FK_QAs_CourtCaseDetails1]
    FOREIGN KEY ([CourtCaseDetailID])
    REFERENCES [dbo].[CourtCaseDetails]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QAs_CourtCaseDetails1'
CREATE INDEX [IX_FK_QAs_CourtCaseDetails1]
ON [dbo].[QAs]
    ([CourtCaseDetailID]);
GO

-- Creating foreign key on [CurrentStatusId] in table 'CourtCases'
ALTER TABLE [dbo].[CourtCases]
ADD CONSTRAINT [FK_CourtCases_States]
    FOREIGN KEY ([CurrentStatusId])
    REFERENCES [dbo].[States]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCases_States'
CREATE INDEX [IX_FK_CourtCases_States]
ON [dbo].[CourtCases]
    ([CurrentStatusId]);
GO

-- Creating foreign key on [DocumentTypeId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_Persons_DocumentTypes]
    FOREIGN KEY ([DocumentTypeId])
    REFERENCES [dbo].[DocumentTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Persons_DocumentTypes'
CREATE INDEX [IX_FK_Persons_DocumentTypes]
ON [dbo].[Persons]
    ([DocumentTypeId]);
GO

-- Creating foreign key on [ScopeID] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [FK_News_Scopes]
    FOREIGN KEY ([ScopeID])
    REFERENCES [dbo].[Scopes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_News_Scopes'
CREATE INDEX [IX_FK_News_Scopes]
ON [dbo].[News]
    ([ScopeID]);
GO

-- Creating foreign key on [Clients_ID] in table 'CurrentCases'
ALTER TABLE [dbo].[CurrentCases]
ADD CONSTRAINT [FK_CurrentCases_Clients]
    FOREIGN KEY ([Clients_ID])
    REFERENCES [dbo].[Persons_Clients]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CourtCases_ID] in table 'CurrentCases'
ALTER TABLE [dbo].[CurrentCases]
ADD CONSTRAINT [FK_CurrentCases_CourtCases]
    FOREIGN KEY ([CourtCases_ID])
    REFERENCES [dbo].[CourtCases]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CurrentCases_CourtCases'
CREATE INDEX [IX_FK_CurrentCases_CourtCases]
ON [dbo].[CurrentCases]
    ([CourtCases_ID]);
GO

-- Creating foreign key on [CourtBranches_ID] in table 'LawyerCourtBranches'
ALTER TABLE [dbo].[LawyerCourtBranches]
ADD CONSTRAINT [FK_LawyerCourtBranches_CourtBranches]
    FOREIGN KEY ([CourtBranches_ID])
    REFERENCES [dbo].[CourtBranches]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lawyers_ID] in table 'LawyerCourtBranches'
ALTER TABLE [dbo].[LawyerCourtBranches]
ADD CONSTRAINT [FK_LawyerCourtBranches_Lawyers]
    FOREIGN KEY ([Lawyers_ID])
    REFERENCES [dbo].[Persons_Lawyers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LawyerCourtBranches_Lawyers'
CREATE INDEX [IX_FK_LawyerCourtBranches_Lawyers]
ON [dbo].[LawyerCourtBranches]
    ([Lawyers_ID]);
GO

-- Creating foreign key on [CourtCases_ID] in table 'LawyerCourtCases'
ALTER TABLE [dbo].[LawyerCourtCases]
ADD CONSTRAINT [FK_LawyerCourtCases_CourtCases]
    FOREIGN KEY ([CourtCases_ID])
    REFERENCES [dbo].[CourtCases]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lawyers_ID] in table 'LawyerCourtCases'
ALTER TABLE [dbo].[LawyerCourtCases]
ADD CONSTRAINT [FK_LawyerCourtCases_Lawyers]
    FOREIGN KEY ([Lawyers_ID])
    REFERENCES [dbo].[Persons_Lawyers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LawyerCourtCases_Lawyers'
CREATE INDEX [IX_FK_LawyerCourtCases_Lawyers]
ON [dbo].[LawyerCourtCases]
    ([Lawyers_ID]);
GO

-- Creating foreign key on [Lawyers_ID] in table 'LawyersQuerys'
ALTER TABLE [dbo].[LawyersQuerys]
ADD CONSTRAINT [FK_LawyersQuerys_Lawyers]
    FOREIGN KEY ([Lawyers_ID])
    REFERENCES [dbo].[Persons_Lawyers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [QAs_ID] in table 'LawyersQuerys'
ALTER TABLE [dbo].[LawyersQuerys]
ADD CONSTRAINT [FK_LawyersQuerys_QAs]
    FOREIGN KEY ([QAs_ID])
    REFERENCES [dbo].[QAs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LawyersQuerys_QAs'
CREATE INDEX [IX_FK_LawyersQuerys_QAs]
ON [dbo].[LawyersQuerys]
    ([QAs_ID]);
GO

-- Creating foreign key on [ID] in table 'Persons_Clients'
ALTER TABLE [dbo].[Persons_Clients]
ADD CONSTRAINT [FK_Clients_inherits_Persons]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Persons]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Persons_Lawyers'
ALTER TABLE [dbo].[Persons_Lawyers]
ADD CONSTRAINT [FK_Lawyers_inherits_Persons]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Persons]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'Persons_Employees'
ALTER TABLE [dbo].[Persons_Employees]
ADD CONSTRAINT [FK_Employees_inherits_Persons]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[Persons]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------