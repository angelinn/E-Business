CREATE PROCEDURE OrderMarkCompleted
(@OrderID int)
AS
UPDATE Orders
SET Completed = 1,
 DateShipped = GETDATE()
WHERE OrderID = @OrderID