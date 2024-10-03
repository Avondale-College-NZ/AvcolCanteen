-- This SQL query retrieves the total quantity of products sold for each category. 
-- It joins the Categories, Products, and Cart tables to calculate the sum of quantities sold 
-- for each category and groups the results by category name. 
-- The results are ordered by the total quantity sold in descending order, showing the most popular categories first.

SELECT Categories.Name, SUM(Cart.Quantity) AS TotalSold
FROM Categories
JOIN Products ON Categories.CategoryID = Products.CategoryID
JOIN Cart ON Products.ProductID = Cart.ProductID
GROUP BY Categories.Name
ORDER BY TotalSold DESC;
