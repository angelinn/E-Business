CREATE PROCEDURE CreateCustomerOrder
(@CartID char(36),
 @CustomerID uniqueidentifier)
AS
/* Insert a new record into Orders */
DECLARE @OrderID int
INSERT INTO Orders (CustomerID) VALUES (@CustomerID)
/* Save the new Order ID */
SET @OrderID = @@IDENTITY
/* Add the order details to OrderDetail */
INSERT INTO OrderDetail
 (OrderID, ProductID, ProductName, Quantity, UnitCost)
SELECT
 @OrderID, Product.ProductID, Product.Name,
 ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID
/* Clear the shopping cart */
DELETE FROM ShoppingCart
WHERE CartID = @CartID
/* Return the Order ID */
SELECT @OrderID


ALTER PROCEDURE CreateCustomerOrder
(@CartID char(36),
 @CustomerID uniqueidentifier,
 @ShippingID int,
 @TaxID int)
AS
/* Insert a new record into Orders */
DECLARE @OrderID int
INSERT INTO Orders (CustomerID, ShippingID, TaxID)
VALUES (@CustomerID, @ShippingID, @TaxID)
/* Save the new Order ID */
SET @OrderID = @@IDENTITY
/* Add the order details to OrderDetail */
INSERT INTO OrderDetail
 (OrderID, ProductID, ProductName, Quantity, UnitCost)
SELECT
 @OrderID, Product.ProductID, Product.Name,
 ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID
/* Clear the shopping cart */
DELETE FROM ShoppingCart
WHERE CartID = @CartID
/* Return the Order ID */
SELECT @OrderID