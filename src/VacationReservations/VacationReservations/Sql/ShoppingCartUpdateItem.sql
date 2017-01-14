CREATE Procedure ShoppingCartUpdateItem
(@CartID char(36),
@ProductID int,
@Quantity int)
AS
IF @Quantity <= 0
 EXEC ShoppingCartRemoveItem @CartID, @ProductID
ELSE
 UPDATE ShoppingCart
 SET Quantity = @Quantity, DateAdded = GETDATE()
 WHERE ProductID = @ProductID AND CartID = @CartID