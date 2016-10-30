CREATE PROCEDURE CatalogGetCategoryDetails
(@CategoryID INT)
AS
SELECT DepartmentID, Name, Description
FROM Category
WHERE CategoryID = @CategoryID