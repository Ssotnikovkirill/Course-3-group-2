-- Создание таблицы категорий
CREATE TABLE categories (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    category_name TEXT NOT NULL
);

-- Создание таблицы продуктов
CREATE TABLE products (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_name TEXT NOT NULL,
    price REAL NOT NULL,
    category_id INTEGER,
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

-- Создание таблицы клиентов
CREATE TABLE customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    customer_name TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE
);

-- Создание таблицы заказов
CREATE TABLE orders (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    order_date TEXT NOT NULL,
    customer_id INTEGER,
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

-- Создание таблицы деталей заказов
CREATE TABLE order_details (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    order_id INTEGER,
    product_id INTEGER,
    quantity INTEGER NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);

-- Вставка данных в таблицу категорий
INSERT INTO categories (category_name) VALUES 
('Электроника'),
('Одежда'),
('Книги');

-- Вставка данных в таблицу продуктов
INSERT INTO products (product_name, price, category_id) VALUES 
('Смартфон', 700.00, 1),
('Наушники', 50.00, 1),
('Футболка', 20.00, 2),
('Джинсы', 40.00, 2),
('Роман', 15.00, 3),
('Учебник', 30.00, 3);

-- Вставка данных в таблицу клиентов
INSERT INTO customers (customer_name, email) VALUES 
('Иван Иванов', 'ivanov@example.com'),
('Мария Смирнова', 'smirnova@example.com'),
('Петр Петров', 'petrov@example.com');

-- Вставка данных в таблицу заказов
INSERT INTO orders (order_date, customer_id) VALUES 
('2024-08-01', 1),
('2024-08-02', 2),
('2024-08-03', 3);

-- Вставка данных в таблицу деталей заказов
INSERT INTO order_details (order_id, product_id, quantity) VALUES 
(1, 1, 2),  -- Иван Иванов купил 2 смартфона
(1, 3, 1),  -- Иван Иванов купил 1 футболку
(2, 2, 3),  -- Мария Смирнова купила 3 пары наушников
(3, 4, 1),  -- Петр Петров купил 1 пару джинсов
(3, 5, 2);  -- Петр Петров купил 2 романа
