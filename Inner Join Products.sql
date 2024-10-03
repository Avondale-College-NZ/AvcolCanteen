-- This SQL query retrieves information about products, including their ID, name, price, special price, 
-- whether they are marked as special, stock quantity, and the category name they belong to. 
-- It joins the Products table with the Categories table based on the CategoryID to display the corresponding category for each product.

SELECT Products.ProductID, Products.Name, Products.Price, Products.SpecialPrice, Products.Special, Products.Stock, Categories.Name
FROM Products
INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID