CREATE PROCEDURE CatalogDeleteProduct
(@ProductID INT)
AS
DELETE FROM ProductCategory WHERE ProductID=@ProductID
DELETE FROM Product where ProductID=@ProductID