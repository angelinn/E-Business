CREATE PROCEDURE CatalogGetAllProductsInCategory
(@CategoryID INT)
AS
SELECT Product.ProductID, Name, Description, Price, Thumbnail,
 Image, PromoDept, PromoFront
FROM Product INNER JOIN ProductCategory
 ON Product.ProductID = ProductCategory.ProductID
WHERE ProductCategory.CategoryID = @CategoryID