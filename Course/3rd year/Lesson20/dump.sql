PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE teachers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);
INSERT INTO teachers VALUES(1,'Иванов Иван');
INSERT INTO teachers VALUES(2,'Петрова Петрия');
INSERT INTO teachers VALUES(3,'Сидорова Светлана');
INSERT INTO teachers VALUES(4,'Кузнецов Николай');
INSERT INTO teachers VALUES(5,'Федорова Анна');
CREATE TABLE students (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    class_id INTEGER,
    FOREIGN KEY (class_id) REFERENCES classes(id)
);
INSERT INTO students VALUES(1,'Александр',1);
INSERT INTO students VALUES(2,'Мария',2);
INSERT INTO students VALUES(4,'Елена',3);
INSERT INTO students VALUES(5,'Игорь',2);
CREATE TABLE classes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);
INSERT INTO classes VALUES(1,'10А');
INSERT INTO classes VALUES(2,'10Б');
INSERT INTO classes VALUES(3,'11А');
INSERT INTO classes VALUES(4,'11Б');
INSERT INTO classes VALUES(5,'9А');
CREATE TABLE subjects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);
INSERT INTO subjects VALUES(1,'Математика');
INSERT INTO subjects VALUES(2,'Физика');
INSERT INTO subjects VALUES(3,'Химия');
INSERT INTO subjects VALUES(4,'История');
INSERT INTO subjects VALUES(5,'Литература');
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
INSERT INTO schedule VALUES(1,1,1,1,'08:00');
INSERT INTO schedule VALUES(2,1,2,2,'09:00');
INSERT INTO schedule VALUES(3,2,1,3,'08:00');
INSERT INTO schedule VALUES(4,3,3,4,'10:00');
INSERT INTO schedule VALUES(5,2,4,5,'09:00');
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('teachers',5);
INSERT INTO sqlite_sequence VALUES('classes',5);
INSERT INTO sqlite_sequence VALUES('subjects',5);
INSERT INTO sqlite_sequence VALUES('students',5);
INSERT INTO sqlite_sequence VALUES('schedule',5);
COMMIT;
