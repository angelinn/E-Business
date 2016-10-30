CREATE PROCEDURE CatalogGetDepartmentDetails
(@DepartmentID INT)
AS
SELECT Name, Description
FROM Department
WHERE DepartmentID = @DepartmentID