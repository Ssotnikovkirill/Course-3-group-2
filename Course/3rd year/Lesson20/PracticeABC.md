# PracticeABC (порядок моих действий)

Вообще, я создал дамп базы данных (dump.sql), который можно открыть и посмотреть. Но для более детального контроля выполнения заданий вы можете ознакомиться со всеми моими дейсвтиями (см. ниже).

## Требования
- SQLite = 3.43.2
(это моя версия SQLite - возможно, подойдет и другая)



## Practice A

1. Создание базы данных:
```bash
    sqlite3 school_schedule.db
```
2. Создание таблиц:
```sql
CREATE TABLE teachers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE students (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    class_id INTEGER,
    FOREIGN KEY (class_id) REFERENCES classes(id)
);

CREATE TABLE classes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE subjects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE schedule (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    class_id INTEGER,
    subject_id INTEGER,
    teacher_id INTEGER,
    time TEXT,
    FOREIGN KEY (class_id) REFERENCES classes(id),
    FOREIGN KEY (subject_id) REFERENCES subjects(id),
    FOREIGN KEY (teacher_id) REFERENCES teachers(id)
);
```

3. Заполнение таблиц данными:
```sql
-- Добавление данных в таблицу teachers
INSERT INTO teachers (name) VALUES ('Иванов Иван');
INSERT INTO teachers (name) VALUES ('Петров Петр');
INSERT INTO teachers (name) VALUES ('Сидорова Светлана');
INSERT INTO teachers (name) VALUES ('Кузнецов Николай');
INSERT INTO teachers (name) VALUES ('Федорова Анна');

-- Добавление данных в таблицу classes
INSERT INTO classes (name) VALUES ('10А');
INSERT INTO classes (name) VALUES ('10Б');
INSERT INTO classes (name) VALUES ('11А');
INSERT INTO classes (name) VALUES ('11Б');
INSERT INTO classes (name) VALUES ('9А');

-- Добавление данных в таблицу subjects
INSERT INTO subjects (name) VALUES ('Математика');
INSERT INTO subjects (name) VALUES ('Физика');
INSERT INTO subjects (name) VALUES ('Химия');
INSERT INTO subjects (name) VALUES ('История');
INSERT INTO subjects (name) VALUES ('Литература');

-- Добавление данных в таблицу students
INSERT INTO students (name, class_id) VALUES ('Александр', 1);
INSERT INTO students (name, class_id) VALUES ('Мария', 2);
INSERT INTO students (name, class_id) VALUES ('Дмитрий', 1);
INSERT INTO students (name, class_id) VALUES ('Елена', 3);
INSERT INTO students (name, class_id) VALUES ('Игорь', 2);

-- Добавление данных в таблицу schedule
INSERT INTO schedule (class_id, subject_id, teacher_id, time) VALUES (1, 1, 1, '08:00');
INSERT INTO schedule (class_id, subject_id, teacher_id, time) VALUES (1, 2, 2, '09:00');
INSERT INTO schedule (class_id, subject_id, teacher_id, time) VALUES (2, 1, 3, '08:00');
INSERT INTO schedule (class_id, subject_id, teacher_id, time) VALUES (3, 3, 4, '10:00');
INSERT INTO schedule (class_id, subject_id, teacher_id, time) VALUES (2, 4, 5, '09:00');
```


## Practice B
Пишу формулировку задания и мой пример выполнения в SQLite.

1. Обновите информацию об учителе с id = 2:
```sql
UPDATE teachers
SET name = 'Петрова Петрия'
WHERE id = 2;
```

2. Обновите расписание для класса с id = 4, для предмета - математика:
```sql
UPDATE schedule
SET time = '10:30'
WHERE class_id = 4 AND subject_id = (SELECT id FROM subjects WHERE name = 'Математика');
```

3. Удалите ученика с id = 3:
```sql
DELETE FROM students
WHERE id = 3;
```

4. Удалите расписание для класса с id = 2 и для предмета с id = 2:
```sql
DELETE FROM schedule
WHERE class_id = 2 AND subject_id = 2;
```

5. Переместите ученика с id = 5 из одного класса в другой:
```sql
UPDATE students
SET class_id = 3
WHERE id = 5;
```


## Practice С (запросы для получения информации)
Пишу формулировку задания и мой пример выполнения в SQLite.

1. Выведите информацию о студенте (имя) и названии класса, в котором он учится:
```sql
SELECT students.name AS student_name, classes.name AS class_name
FROM students
JOIN classes ON students.class_id = classes.id;
```

2. Выведите расписание для класса с id = 4:
```sql
SELECT schedule.time, subjects.name AS subject_name, teachers.name AS teacher_name
FROM schedule
JOIN subjects ON schedule.subject_id = subjects.id
JOIN teachers ON schedule.teacher_id = teachers.id
WHERE schedule.class_id = 4;
```

3. Выведите информацию о студенте и количестве классов, в которые он записан:
```sql
SELECT students.name AS student_name, COUNT(classes.id) AS class_count
FROM students
JOIN classes ON students.class_id = classes.id
GROUP BY students.id;
```