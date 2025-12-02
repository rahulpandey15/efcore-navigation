use SampleDb
go

CREATE PROCEDURE dbo.usp_InsertDepartment	
	@DepartmentName    NVARCHAR(100)
AS
BEGIN
     SET NOCOUNT ON;
	 INSERT INTO dbo.Departments(DepartmentName) VALUES(@DepartmentName)
END
