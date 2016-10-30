CREATE PROCEDURE CatalogGetCategoriesInDepartment
(@DepartmentID INT)
AS
SELECT CategoryID, Name, Description
FROM Category
WHERE DepartmentID = @DepartmentID