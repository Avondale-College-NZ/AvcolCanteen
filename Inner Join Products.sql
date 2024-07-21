SELECT Products.ProductID, Products.Name, Products.Price, Products.SpecialPrice, Products.Special, Products.Stock, Categories.Name
FROM Products
INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID