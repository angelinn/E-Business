CREATE PROCEDURE CommerceLibOrderGetInfo
(@OrderID int)
AS
SELECT OrderID,
 DateCreated,
 DateShipped,
 Comments,
 Status,
 CustomerID,
 AuthCode,
 Reference
FROM Orders
WHERE OrderID = @OrderID