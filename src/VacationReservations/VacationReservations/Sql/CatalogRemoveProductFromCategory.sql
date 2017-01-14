CREATE PROCEDURE CatalogRemoveProductFromCategory
(@ProductID int, @CategoryID int)
AS
DELETE FROM ProductCategory
WHERE CategoryID = @CategoryID AND ProductID = @ProductID