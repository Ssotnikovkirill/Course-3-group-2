INSERT INTO Users (UserName, Email) VALUES
('John Doe', 'john@example.com'),
('Jane Smith', 'jane@example.com'),
('Alice Johnson', 'alice@example.com');

INSERT INTO Products (ProductName, Category, Price) VALUES
('Laptop', 'Electronics', 1200.00),
('Smartphone', 'Electronics', 800.00),
('Desk Chair', 'Furniture', 150.00);

INSERT INTO Orders (UserID, ProductID, Quantity, OrderDate) VALUES
(1, 1, 1, '2023-08-01'),
(2, 2, 2, '2023-08-02'),
(3, 3, 1, '2023-08-03');
