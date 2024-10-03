-- The first statement adds a new column called 'Description' to the 'Products' table, 
-- with the data type NVARCHAR(MAX) to store text of variable length.
-- The second statement removes the 'Description' column from the 'Products' table.

ALTER TABLE Products
ADD Description NVARCHAR(MAX);

ALTER TABLE Products
DROP COLUMN Description
