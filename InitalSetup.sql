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
CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [UserProfiles] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserProfiles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE UNIQUE INDEX [IX_UserProfiles_UserId] ON [UserProfiles] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251115000412_InitDatabase', N'10.0.0');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [Users] ADD [DepartmentId] int NOT NULL DEFAULT 0;

CREATE TABLE [Departments] (
    [Id] int NOT NULL IDENTITY,
    [DepartmentName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
);

CREATE INDEX [IX_Users_DepartmentId] ON [Users] ([DepartmentId]);

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251115001300_AddedDepartmentTable', N'10.0.0');

COMMIT;
GO

BEGIN TRANSACTION;
CREATE TABLE [Courses] (
    [Id] int NOT NULL IDENTITY,
    [CourseName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id])
);

CREATE TABLE [Student] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);

CREATE TABLE [StudentCourse] (
    [CourseId] int NOT NULL,
    [StudentId] int NOT NULL,
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([CourseId], [StudentId]),
    CONSTRAINT [FK_StudentCourse_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentCourse_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id])
);

CREATE INDEX [IX_StudentCourse_StudentId] ON [StudentCourse] ([StudentId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251115002239_AddedStudentCourseTable', N'10.0.0');

COMMIT;
GO

