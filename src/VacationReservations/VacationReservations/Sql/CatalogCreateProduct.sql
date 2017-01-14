CREATE PROCEDURE CatalogCreateProduct
(@CategoryID INT,
@ProductName NVARCHAR(50),
@ProductDescription NVARCHAR(MAX),
@Price MONEY,
@Thumbnail NVARCHAR(50),
@Image NVARCHAR(50),
@PromoFront BIT,
@PromoDept BIT)
AS
-- Declare a variable to hold the generated product ID
DECLARE @ProductID int
-- Create the new product entry
INSERT INTO Product
 (Name,
 Description,
 Price,
 Thumbnail,
 Image,
 PromoFront,
 PromoDept)
VALUES
 (@ProductName,
 @ProductDescription,
 @Price, 
 @Thumbnail,
 @Image,
 @PromoFront,
 @PromoDept)
-- Save the generated product ID to a variable
SELECT @ProductID = @@Identity
-- Associate the product with a category
INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES (@ProductID, @CategoryID)