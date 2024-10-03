-- This SQL query retrieves a list of orders with details about the user who placed the order, 
-- the product(s) ordered, the quantity, and the order date. 
-- It joins the Orders, AspNetUsers, Cart, and Products tables based on their related IDs. 
-- The results are ordered by the order date in descending order, showing the most recent orders first.

SELECT 
    Orders.OrderID, 
    AspNetUsers.UserName AS UserName, 
    Products.Name AS ProductName, 
    Cart.Quantity, 
    Orders.Date
FROM 
    Orders
INNER JOIN 
    AspNetUsers ON Orders.AvcolCanteenUserID = AspNetUsers.Id
INNER JOIN 
    Cart ON Orders.OrderID = Cart.OrderID
INNER JOIN 
    Products ON Cart.ProductID = Products.ProductID
ORDER BY 
    Orders.Date DESC;
