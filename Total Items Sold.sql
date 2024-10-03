-- This SQL query retrieves the total quantity sold for each product. 
-- It joins the Cart and Products tables based on the ProductID to calculate the sum of quantities 
-- sold for each product and groups the results by product name.

	SELECT Products.Name, SUM(Cart.Quantity) AS TotalSold
	FROM Cart
	JOIN Products ON Cart.ProductID = Products.ProductID
	GROUP BY Products.Name;
