CREATE PROCEDURE CatalogGetProductsInCategory
(@CategoryID INT,
@DescriptionLength INT,
@PageNumber INT,
@ProductsPerPage INT,
@HowManyProducts INT OUTPUT)
AS
-- declare a new TABLE variable
DECLARE @Products TABLE
(RowNumber INT,
 ProductID INT,
 Name NVARCHAR(50),
 Description NVARCHAR(MAX),
 Price MONEY,
 Thumbnail NVARCHAR(50),
 Image NVARCHAR(50),
 PromoFront bit,
 PromoDept bit)
-- populate the table variable with the complete list of products
INSERT INTO @Products
SELECT ROW_NUMBER() OVER (ORDER BY Product.ProductID),
 Product.ProductID, Name,
 CASE WHEN LEN(Description) <= @DescriptionLength THEN Description
 ELSE SUBSTRING(Description, 1, @DescriptionLength) + '...' END
 AS Description, Price, Thumbnail, Image, PromoFront, PromoDept
FROM Product INNER JOIN ProductCategory
 ON Product.ProductID = ProductCategory.ProductID
WHERE ProductCategory.CategoryID = @CategoryID
-- return the total number of products using an OUTPUT variable
SELECT @HowManyProducts = COUNT(ProductID) FROM @Products
-- extract the requested page of products
SELECT ProductID, Name, Description, Price, Thumbnail,
 Image, PromoFront, PromoDept
FROM @Products
WHERE RowNumber > (@PageNumber - 1) * @ProductsPerPage
 AND RowNumber <= @PageNumber * @ProductsPerPage