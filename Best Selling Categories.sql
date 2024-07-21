SELECT Categories.Name, SUM(Cart.Quantity) AS TotalSold
FROM Categories
JOIN Products ON Categories.CategoryID = Products.CategoryID
JOIN Cart ON Products.ProductID = Cart.ProductID
GROUP BY Categories.Name
ORDER BY TotalSold DESC;
