CREATE PROCEDURE OrderUpdate
(@OrderID int,
 @DateCreated smalldatetime,
 @DateShipped smalldatetime = NULL,
 @Verified bit,
 @Completed bit,
 @Canceled bit,
 @Comments NVARCHAR(200),
 @CustomerName NVARCHAR(50),
 @ShippingAddress NVARCHAR(200),
 @CustomerEmail NVARCHAR(50))
AS
UPDATE Orders
SET DateCreated=@DateCreated,
 DateShipped=@DateShipped,
 Verified=@Verified,
 Completed=@Completed,
 Canceled=@Canceled,
 Comments=@Comments,
 CustomerName=@CustomerName,
 ShippingAddress=@ShippingAddress,
 CustomerEmail=@CustomerEmail
WHERE OrderID = @OrderID