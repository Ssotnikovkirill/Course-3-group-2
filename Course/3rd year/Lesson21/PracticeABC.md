## Требования
- SQLite = 3.43.2
(это моя версия SQLite - возможно, подойдет и другая)



## Practice A

```sql
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY, 
    name TEXT, 
    age INTEGER
);

CREATE TABLE IF NOT EXISTS orders (
    id INTEGER PRIMARY KEY, 
    user_id INTEGER, 
    amount INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- Транзакция для добавления пользователя Alice и её заказа
BEGIN TRANSACTION;

-- Добавляем пользователя Alice
INSERT INTO users (name, age) 
VALUES ('Alice', 25);

-- Получаем id только что добавленного пользователя Alice
INSERT INTO orders (user_id, amount) 
VALUES ((SELECT id FROM users WHERE name = 'Alice' LIMIT 1), 150);

-- Фиксируем изменения
COMMIT;
```



## Practice B
```sql
-- Транзакция с проверкой на существование пользователя Alice и сумму заказа
BEGIN TRANSACTION;

-- Проверяем, существует ли пользователь Alice
IF EXISTS (SELECT 1 FROM users WHERE name = 'Alice') THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Добавляем пользователя Alice
INSERT INTO users (name, age) 
VALUES ('Alice', 25);

-- Проверяем сумму заказа
IF 150 > 1000 THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Добавляем заказ для пользователя Alice
INSERT INTO orders (user_id, amount) 
VALUES ((SELECT id FROM users WHERE name = 'Alice' LIMIT 1), 150);

-- Фиксируем изменения
COMMIT;
```



## Practice C
```sql
-- Создаем таблицы users и orders с добавлением колонки order_date
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY, 
    name TEXT, 
    age INTEGER
);

CREATE TABLE IF NOT EXISTS orders (
    id INTEGER PRIMARY KEY, 
    user_id INTEGER, 
    amount INTEGER, 
    order_date DATE,
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- Транзакция для добавления пользователя Alice и её заказа с проверками
BEGIN TRANSACTION;

-- Проверяем, существует ли пользователь Alice
IF EXISTS (SELECT 1 FROM users WHERE name = 'Alice') THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Добавляем пользователя Alice
INSERT INTO users (name, age) 
VALUES ('Alice', 25);

-- Проверяем сумму всех заказов пользователя Alice
IF (SELECT SUM(amount) FROM orders WHERE user_id = (SELECT id FROM users WHERE name = 'Alice')) > 5000 THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Проверяем сумму текущего заказа
IF 150 > 1000 THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Проверяем дату текущего заказа
IF DATE('now', '-1 year') > DATE('now') THEN
    ROLLBACK;
    -- Прерываем выполнение скрипта
    RETURN;
END IF;

-- Добавляем заказ для пользователя Alice с текущей датой
INSERT INTO orders (user_id, amount, order_date) 
VALUES ((SELECT id FROM users WHERE name = 'Alice' LIMIT 1), 150, DATE('now'));

-- Фиксируем изменения
COMMIT;
```