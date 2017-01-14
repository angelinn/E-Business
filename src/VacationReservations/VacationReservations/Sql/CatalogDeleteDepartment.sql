CREATE PROCEDURE CatalogDeleteDepartment
(@DepartmentID int)
AS
DELETE FROM Department
WHERE DepartmentID = @DepartmentID