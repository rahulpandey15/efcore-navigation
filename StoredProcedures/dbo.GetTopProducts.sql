use SampleDb
go


CREATE PROCEDURE dbo.GetTopProducts
    @TopCount INT,
    @TotalCount INT OUTPUT
AS
BEGIN
    SET @TotalCount = (SELECT COUNT(*) FROM dbo.Products)
    SELECT TOP(@TopCount) id, ProductName FROM dbo.Products
END
