IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [DeptMaster] (
    [DeptCode] int NOT NULL IDENTITY,
    [DeptName] nvarchar(max) NULL,
    CONSTRAINT [PK_DeptMaster] PRIMARY KEY ([DeptCode])
);
GO

CREATE TABLE [EmpProfile] (
    [EmpCode] int NOT NULL IDENTITY,
    [DateOfBirth] datetime2 NOT NULL,
    [EmpName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [DeptCode] int NOT NULL,
    [DeptMasterDeptCode] int NULL,
    CONSTRAINT [PK_EmpProfile] PRIMARY KEY ([EmpCode]),
    CONSTRAINT [FK_EmpProfile_DeptMaster_DeptMasterDeptCode] FOREIGN KEY ([DeptMasterDeptCode]) REFERENCES [DeptMaster] ([DeptCode])
);
GO

CREATE INDEX [IX_EmpProfile_DeptMasterDeptCode] ON [EmpProfile] ([DeptMasterDeptCode]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240104135253_FirstDb', N'6.0.25');
GO

COMMIT;
GO

