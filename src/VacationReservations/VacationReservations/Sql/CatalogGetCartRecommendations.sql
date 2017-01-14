CREATE PROCEDURE CatalogGetCartRecommendations
(@CartID CHAR(36),
 @DescriptionLength INT)
AS
--- Returns the product recommendations
SELECT ProductID,
 Name,
 CASE WHEN LEN(Description) <= @DescriptionLength THEN Description
 ELSE SUBSTRING(Description, 1, @DescriptionLength) + '...' END
 AS Description
FROM Product
WHERE ProductID IN
 (
 -- Returns the products that exist in a list of orders
 SELECT TOP 5 od1.ProductID AS Rank
 FROM OrderDetail od1
 JOIN OrderDetail od2
 ON od1.OrderID=od2.OrderID
 JOIN ShoppingCart sp
 ON od2.ProductID = sp.ProductID
 WHERE sp.CartID = @CartID
 -- Must not include products that already exist in the visitor's cart
 AND od1.ProductID NOT IN
 (
 -- Returns the products in the specified shopping cart
 SELECT ProductID
 FROM ShoppingCart
 WHERE CartID = @CartID
 )
 -- Group the ProductID so we can calculate the rank
 GROUP BY od1.ProductID
 -- Order descending by rank
 ORDER BY COUNT(od1.ProductID) DESC
 )