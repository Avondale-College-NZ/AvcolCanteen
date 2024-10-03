-- Insert statement which inserts all dummy data in the database

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

-- Insert Users
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'52b5d835-2806-41c3-969e-0560c2572960', N'melissa@email.com', N'MELISSA@EMAIL.COM', N'melissa@email.com', N'MELISSA@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEDHgR8is9MOHUW5cED3XuW4Da/QM84GWhSPcMr+vw89GOZEZ9Hp5bEiNi9R94LNrBg==', N'K4SIQSP2YQSJATAHRIGGZNZDTVVYPZEU', N'c4643334-7fb8-49c0-94d7-a8f403a4c6bd', NULL, 0, 0, NULL, 1, 0, N'Melissa', N'Johnson')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'7ff20b03-a784-40c1-8191-fcc4e8055596', N'emily@email.com', N'EMILY@EMAIL.COM', N'emily@email.com', N'EMILY@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEA2lv5onFe7iQzRYF0ut/yZVfaonnE2772IrKEPT1/Z8/eSw/3aoMatwXczKDv/SJw==', N'D62XAKLBIKLP5ENS6F3A3OJN3XD7M5GF', N'dc0308fd-423d-44e1-8f10-eec52eb36d43', NULL, 0, 0, NULL, 1, 0, N'Emily', N'Sean')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'83be9b67-02c2-41d9-835b-0438351341ed', N'Daniel@email.com', N'DANIEL@EMAIL.COM', N'Daniel@email.com', N'DANIEL@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEFz5CItXRmYM2LYx2O7ES1YtA0CNMMVy6g5OJvdCFHp6c5Z+q58+rFN7wD4Df+x9XA==', N'TR5EP3YV3IVMA4DXQIIE54B32HDLETRS', N'a876b58b-cbc4-4f39-aa62-add70729a5b7', NULL, 0, 0, NULL, 1, 0, N'Daniel', N'John')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'ba27c492-cb7f-4c9e-b0c7-8565d41d01a1', N'Ben@email.com', N'BEN@EMAIL.COM', N'Ben@email.com', N'BEN@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAELCzRxQamhpKURtBvWBzOxCBsgO9SncBwmo/+/6QsZh292kHK8YgWFUDQaZPko+ZwA==', N'YDDER4BIC4NSV72WLYF3DLBLAWGZTJZI', N'205e7adc-9285-426d-8fa0-a03097ff893a', NULL, 0, 0, NULL, 1, 0, N'Ben', N'Stokes')

-- Insert Orders
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([OrderID], [AvcolCanteenUserID], [Date], [IsCompleted]) VALUES (1, N'52b5d835-2806-41c3-969e-0560c2572960', N'2024-10-03 00:00:00', 1)
INSERT INTO [dbo].[Orders] ([OrderID], [AvcolCanteenUserID], [Date], [IsCompleted]) VALUES (2, N'7ff20b03-a784-40c1-8191-fcc4e8055596', N'2024-10-04 00:00:00', 1)
INSERT INTO [dbo].[Orders] ([OrderID], [AvcolCanteenUserID], [Date], [IsCompleted]) VALUES (3, N'83be9b67-02c2-41d9-835b-0438351341ed', N'2024-10-05 00:00:00', 1)
INSERT INTO [dbo].[Orders] ([OrderID], [AvcolCanteenUserID], [Date], [IsCompleted]) VALUES (4, N'ba27c492-cb7f-4c9e-b0c7-8565d41d01a1', N'2024-10-06 00:00:00', 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF

-- Insert Cart
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES ( 1, 1, 2);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (1, 2, 1);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (2, 3, 1);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (2, 4, 3);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (3, 5, 4);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (3, 6, 2);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (4, 7, 3);
INSERT INTO Cart (OrderID, ProductID, Quantity) VALUES (4, 8, 1);

-- Insert Payment
INSERT INTO Payment (OrderID, PaymentDate, PaymentType) VALUES (1, '2024-07-15 12:05:00', 0);
INSERT INTO Payment (OrderID, PaymentDate, PaymentType) VALUES (2, '2024-07-15 12:20:00', 1);
INSERT INTO Payment (OrderID, PaymentDate, PaymentType) VALUES (3, '2024-07-15 12:35:00', 2);
INSERT INTO Payment (OrderID, PaymentDate, PaymentType) VALUES (4, '2024-07-15 12:50:00', 3);