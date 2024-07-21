SELECT Products.Name, SUM(Cart.Quantity) AS TotalSold
FROM Cart
JOIN Products ON Cart.ProductID = Products.ProductID
GROUP BY Products.Name;
