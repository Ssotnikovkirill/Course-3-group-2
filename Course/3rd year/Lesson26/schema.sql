-- Таблица мест в театре
CREATE TABLE Seats (
    SeatID INTEGER PRIMARY KEY AUTOINCREMENT,
    SeatNumber TEXT NOT NULL UNIQUE,
    IsReserved BOOLEAN DEFAULT 0
);

-- Таблица резерваций
CREATE TABLE Reservations (
    ReservationID INTEGER PRIMARY KEY AUTOINCREMENT,
    SeatID INTEGER,
    CustomerName TEXT NOT NULL,
    ReservationTime TEXT DEFAULT (DATETIME('now')),
    FOREIGN KEY (SeatID) REFERENCES Seats(SeatID)
);
