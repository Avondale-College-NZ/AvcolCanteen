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
