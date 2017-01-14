CREATE PROCEDURE CatalogGetProductRecommendations
(@ProductID INT,
@DescriptionLength INT)
AS
SELECT ProductID,
 Name,
 CASE WHEN LEN(Description) <= @DescriptionLength THEN Description
 ELSE SUBSTRING(Description, 1, @DescriptionLength) + '...' END
 AS Description
FROM Product
WHERE ProductID IN
 (
 SELECT TOP 5 od2.ProductID
 FROM OrderDetail od1
 JOIN OrderDetail od2 ON od1.OrderID = od2.OrderID
 WHERE od1.ProductID = @ProductID AND od2.ProductID != @ProductID
 GROUP BY od2.ProductID
 ORDER BY COUNT(od2.ProductID) DESC
 )