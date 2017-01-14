CREATE PROCEDURE OrderGetDetails
(@OrderID int)
AS
SELECT Orders.OrderID,
 ProductID,
 ProductName,
 Quantity,
 UnitCost,
 Subtotal
FROM OrderDetail JOIN Orders
ON Orders.OrderID = OrderDetail.OrderID
WHERE Orders.OrderID = @OrderID