CREATE Procedure ShoppingCartAddItem
(@CartID char(36),
 @ProductID int,
 @Attributes nvarchar(1000))
AS
IF EXISTS
 (SELECT CartID
 FROM ShoppingCart
 WHERE ProductID = @ProductID AND CartID = @CartID)
 UPDATE ShoppingCart
 SET Quantity = Quantity + 1
 WHERE ProductID = @ProductID AND CartID = @CartID
ELSE
 IF EXISTS (SELECT Name FROM Product WHERE ProductID=@ProductID)
 INSERT INTO ShoppingCart (CartID, ProductID, Attributes, Quantity, DateAdded)
 VALUES (@CartID, @ProductID, @Attributes, 1, GETDATE())