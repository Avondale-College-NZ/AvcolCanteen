SELECT Products.ProductID, Products.Name
FROM Products
LEFT JOIN Cart ON Products.ProductID = Cart.ProductID
WHERE Cart.ProductID IS NULL;