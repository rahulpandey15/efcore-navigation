use SampleDb
go


CREATE PROCEDURE dbo.usp_FetchEmployeesByDepartmentId
@Id            INT
AS
BEGIN
     SET NOCOUNT ON;

     SELECT 
       usr.Id,
       usr.Name,
       usr.Email,
       usr.Gender,
       usrProfile.Address,
       usrProfile.City,
       usrProfile.Country,
       dept.DepartmentName
     FROM dbo.Users usr INNER JOIN 
     dbo.UserProfiles usrProfile on usr.Id = usrProfile.UserId INNER JOIN
     dbo.Departments dept 
     ON usr.DepartmentId = dept.Id
     WHERE dept.Id = @Id
END
