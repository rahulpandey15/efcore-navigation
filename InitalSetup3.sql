BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251115002239_AddedStudentCourseTable'
)
BEGIN
    CREATE TABLE [Courses] (
        [Id] int NOT NULL IDENTITY,
        [CourseName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251115002239_AddedStudentCourseTable'
)
BEGIN
    CREATE TABLE [Student] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251115002239_AddedStudentCourseTable'
)
BEGIN
    CREATE TABLE [StudentCourse] (
        [CourseId] int NOT NULL,
        [StudentId] int NOT NULL,
        CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([CourseId], [StudentId]),
        CONSTRAINT [FK_StudentCourse_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_StudentCourse_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251115002239_AddedStudentCourseTable'
)
BEGIN
    CREATE INDEX [IX_StudentCourse_StudentId] ON [StudentCourse] ([StudentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251115002239_AddedStudentCourseTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251115002239_AddedStudentCourseTable', N'10.0.0');
END;

COMMIT;
GO

