CREATE PROCEDURE CatalogUpdateProduct
(@ProductID INT,
 @ProductName VARCHAR(50),
 @ProductDescription VARCHAR(MAX),
 @Price MONEY,
 @Thumbnail VARCHAR(50),
 @Image VARCHAR(50),
 @PromoFront BIT,
 @PromoDept BIT)
AS
UPDATE Product
SET Name = @ProductName,
 Description = @ProductDescription,
 Price = @Price,
 Thumbnail = @Thumbnail,
 Image = @Image,
 PromoFront = @PromoFront,
 PromoDept = @PromoDept
WHERE ProductID = @ProductID