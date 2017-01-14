CREATE PROCEDURE CatalogDeleteCategory
(@CategoryID int)
AS
DELETE FROM Category
WHERE CategoryID = @CategoryID