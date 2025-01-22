## Требования
- SQLite = 3.43.2
(это моя версия SQLite - возможно, подойдет и другая)



## Practice A

- запрос для выборки всех сотрудников, у которых зарплата выше 70,000
```sql
SELECT * 
FROM employees 
WHERE salary > 70000;
```
- запрос для выборки всех сотрудников, которые занимают должность "Разработчик"
```sql
SELECT * 
FROM employees 
WHERE position is 'Разработчик';
```
- запрос для выборки всех сотрудников из отдела "Разработка", отсортированных по имени
```sql
SELECT e.*
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
ORDER BY e.name ASC;
```


## Practice B

- запрос для выборки всех сотрудников с зарплатой 72,000, отсортированных по имени в обратном алфавитном порядке
```sql
SELECT * 
FROM employees 
WHERE salary is 72000
ORDER BY name DESC;
```

- запрос для выборки всех сотрудников, у которых зарплата находится в диапазоне от 60,000 до 80,000
```sql
 SELECT * 
FROM employees 
WHERE salary BETWEEN 60000 AND 80000;
```

- запрос для выборки всех сотрудников определенного отдела, отсортированных по зарплате
```sql
SELECT e.*
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
ORDER BY e.salary ASC;
```

## Practice C

- запрос для группировки сотрудников по должности в отделе "HR" и подсчет количества сотрудников на каждой должности
```sql
SELECT position, COUNT(*) AS employee_count
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'HR'
GROUP BY position;
```

- запрос для подсчета общей зарплаты по каждой должности в определенном отделе
```sql
SELECT position, SUM(salary) AS total_salary
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position;
```

- запрос для выборки должностей с максимальной и минимальной зарплатой в определенном отделе
```sql
SELECT position, MAX(salary) AS max_salary
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position
ORDER BY max_salary DESC LIMIT 1;

SELECT position, MIN(salary) AS min_salary
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position
ORDER BY min_salary ASC LIMIT 1;
```

- запрос для выборки всех сотрудников из отделов "Разработка" и "Маркетинг", отсортированных сначала по зарплате (по убыванию), затем по должности (по возрастанию)
```sql
SELECT e.*
FROM employees e
JOIN departments d ON e.department_id = d.id
WHERE d.department_name IN ('Разработка', 'Маркетинг')
ORDER BY e.salary DESC, e.position ASC;
```