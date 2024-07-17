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