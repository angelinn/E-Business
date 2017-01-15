CREATE PROCEDURE CommerceLibShippingGetInfo
(@ShippingRegionID int)
AS
SELECT ShippingID,
 ShippingType,
 ShippingCost
FROM Shipping
WHERE ShippingRegionID = @ShippingRegionID