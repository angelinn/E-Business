-- Create CatalogAddProductReview stored procedure
CREATE PROCEDURE CatalogAddProductReview
(@CustomerId UNIQUEIDENTIFIER, @ProductId INT, @Review NVARCHAR(MAX))
AS
INSERT INTO Review (CustomerID, ProductID, Review, DateCreated)
 VALUES (@CustomerId, @ProductId, @Review, GETDATE())