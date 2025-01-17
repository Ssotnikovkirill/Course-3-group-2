## Требования
- SQLite = 3.43.2
(это моя версия SQLite - возможно, подойдет и другая)



## Practice A

```sql
SELECT 
    orders.id AS order_id,
    orders.order_date,
    customers.customer_name,
    customers.email,
    products.product_name,
    products.price,
    order_details.quantity,
    (products.price * order_details.quantity) AS total_price
FROM 
    orders
INNER JOIN customers ON orders.customer_id = customers.id
INNER JOIN order_details ON orders.id = order_details.order_id
INNER JOIN products ON order_details.product_id = products.id;
```

```sql
SELECT 
    customers.customer_name,
    customers.email,
    orders.id AS order_id,
    orders.order_date
FROM 
    customers
LEFT JOIN orders ON customers.id = orders.customer_id;
```

```sql
SELECT 
    products.product_name,
    products.price,
    order_details.order_id
FROM 
    products
LEFT JOIN order_details ON products.id = order_details.product_id;
```

```sql
SELECT 
    customers.customer_name,
    products.product_name
FROM 
    customers
CROSS JOIN products;
```


## Practice B

```sql
SELECT 
    p1.product_name AS product_1,
    p2.product_name AS product_2,
    p1.category_id
FROM 
    products p1
INNER JOIN products p2 ON p1.category_id = p2.category_id AND p1.id < p2.id AND p1.price <> p2.price;
```


```sql
SELECT 
    customers.customer_name,
    SUM(products.price * order_details.quantity) AS total_spent
FROM 
    customers
INNER JOIN orders ON customers.id = orders.customer_id
INNER JOIN order_details ON orders.id = order_details.order_id
INNER JOIN products ON order_details.product_id = products.id
GROUP BY customers.id
HAVING total_spent > 100;
```


```sql
SELECT 
    customer_name,
    email
FROM 
    customers
WHERE id NOT IN (SELECT customer_id FROM orders);
```

## Practice C

```sql
SELECT 
    customer_name,
    email
FROM 
    customers
WHERE id NOT IN (SELECT customer_id FROM orders);
```

```sql
SELECT 
    customers.customer_name,
    products.product_name
FROM 
    customers
LEFT JOIN order_details ON customers.id = order_details.order_id
LEFT JOIN products ON order_details.product_id = products.id
UNION
SELECT 
    customers.customer_name,
    products.product_name
FROM 
    products
LEFT JOIN order_details ON products.id = order_details.product_id
LEFT JOIN customers ON order_details.order_id = customers.id;
```

```sql
SELECT 
    p1.product_name AS product_1,
    p2.product_name AS product_2
FROM 
    products p1
CROSS JOIN products p2
WHERE p1.id <> p2.id AND p1.category_id <> 1 AND p2.category_id <> 1;
```