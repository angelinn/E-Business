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


ALTER PROCEDURE CommerceLibOrderGetInfo
(@OrderID int)
AS
SELECT OrderID,
 DateCreated,
 DateShipped,
 Comments,
 Status,
 CustomerID,
 AuthCode,
 Reference,
 Orders.ShippingID,
 ShippingType,
 ShippingCost,
 Orders.TaxID,
 TaxType,
 TaxPercentage
FROM Orders
LEFT OUTER JOIN Tax ON Tax.TaxID = Orders.TaxID
LEFT OUTER JOIN Shipping ON Shipping.ShippingID = Orders.ShippingID
WHERE OrderID = @OrderID