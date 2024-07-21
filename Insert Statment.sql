-- Insert Categories
INSERT INTO Categories ( Name) VALUES ( 'Beverages');
INSERT INTO Categories ( Name) VALUES ( 'Snacks');
INSERT INTO Categories ( Name) VALUES ( 'Lunch');
INSERT INTO Categories ( Name) VALUES ( 'Desserts');

-- Insert Products
INSERT INTO Products (Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Apple Juice', 1.50, NULL, 'apple_juice.png', 1, 100, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Chips', 1.00, NULL, 'chips.png', 2, 200, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Sandwich', 3.50, NULL, 'sandwich.png', 3, 50, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Soda', 1.25, NULL, 'soda.png', 1, 150, 0);
INSERT INTO Products (Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Cookies', 0.75, NULL, 'cookies.png', 4, 300, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Fruit Salad', 2.50, NULL, 'fruit_salad.png', 4, 80, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Chocolate Bar', 1.20, NULL, 'chocolate_bar.png', 2, 120, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Pasta', 4.00, NULL, 'pasta.png', 3, 60, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Water Bottle', 1.00, NULL, 'water_bottle.png', 1, 200, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Muffin', 1.50, NULL, 'muffin.png', 4, 100, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Cheese Sandwich', 3.00, NULL, 'cheese_sandwich.png', 3, 40, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Ice Cream', 2.00, NULL, 'ice_cream.png', 4, 75, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Granola Bar', 1.50, NULL, 'granola_bar.png', 2, 90, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Yogurt', 1.00, NULL, 'yogurt.png', 4, 150, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Hot Dog', 2.50, NULL, 'hot_dog.png', 3, 100, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Pizza Slice', 2.75, NULL, 'pizza_slice.png', 3, 120, 0);
INSERT INTO Products (Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Tea', 1.00, NULL, 'tea.png', 1, 80, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ('Cupcake', 1.25, NULL, 'cupcake.png', 4, 90, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Salad', 3.50, NULL, 'salad.png', 3, 70, 0);
INSERT INTO Products ( Name, Price, SpecialPrice, ImageName, CategoryID, Stock, Special) VALUES ( 'Brownie', 1.75, NULL, 'brownie.png', 4, 110, 0);

-- Create 4 users and create 4 Orders with those users then run the second insert statement