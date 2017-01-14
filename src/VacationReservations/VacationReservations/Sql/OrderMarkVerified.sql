CREATE PROCEDURE OrderMarkVerified
(@OrderID int)
AS
UPDATE Orders
SET Verified = 1
WHERE OrderID = @OrderID