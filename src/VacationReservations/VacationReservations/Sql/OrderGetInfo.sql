CREATE PROCEDURE OrderGetInfo
(@OrderID int)
AS
SELECT OrderID,
 (SELECT SUM(Subtotal) FROM OrderDetail WHERE OrderID = @OrderID)
 AS TotalAmount,
 DateCreated,
 DateShipped,
 Verified,
 Completed,
 Canceled,
 Comments,
 CustomerName,
 ShippingAddress,
 CustomerEmail
FROM Orders
WHERE OrderID = @OrderID